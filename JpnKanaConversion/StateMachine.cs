using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.International.Converters
{
    internal class StateMachine
    {
        internal ConversionMap conversionMap = new ConversionMap();
        internal SortedList<string, State> stateList = new SortedList<string, State>();
        internal StateMachineBuffer buffer = new StateMachineBuffer();
        internal EventHandler<StateChangedEventArgs> stateChanged;
        internal State entryState;
        internal State currentState;
        internal string charSet;
        internal TextWriter output;

        private static string UnescapeUnicodeChar(string s)
        {
            s = Regex.Replace(s, "\\\\ u (?<num> [0-9a-f]{4} )", (MatchEvaluator)(match => Convert.ToString(Convert.ToChar(Convert.ToUInt32(match.Groups["num"].Value, 16)), (IFormatProvider)null)), RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
            return s;
        }

        internal StateMachine(AutoConverterConfig config, TextWriter opt, EventHandler<StateChangedEventArgs> stateChangedEventHandler)
        {
            output = opt;
            stateChanged = stateChangedEventHandler;
            charSet = config.StateMachineConfig.CharSet;
            for (int index = 0; index < config.StateMachineConfig.States.Count; ++index)
            {
                State state = new State(this, config.StateMachineConfig.States[index]);
                stateList.Add(state.Id, state);
            }
            entryState = stateList[config.StateMachineConfig.EntryState];
            for (int index = 0; index < config.ConversionTableConfig.Items.Length; ++index)
                conversionMap.Add(UnescapeUnicodeChar(config.ConversionTableConfig.Items[index].Input), UnescapeUnicodeChar(config.ConversionTableConfig.Items[index].Output));
            currentState = entryState;
        }

        internal string Transit(char ch)
        {
            Transition transition = null;
            for (int index = 0; index < currentState.Transitions.Count; ++index)
            {
                if (currentState.Transitions[index].IsMatch(ch))
                {
                    transition = currentState.Transitions[index];
                    break;
                }
            }
            if (transition == null)
            {
                Goto(entryState, ch, null);
                if (buffer.IsEmpty)
                {
                    output.Write(ch);
                    return string.Empty;
                }
                string content = buffer.Content;
                if (!Regex.IsMatch(ch.ToString(), charSet))
                {
                    buffer.Clear();
                    Transit(content);
                    End();
                    output.Write(ch);
                    return string.Empty;
                }
                output.Write(conversionMap.Convert(content[0].ToString()) ?? content[0].ToString());
                string s = content.Remove(0, 1) + ch;
                buffer.Clear();
                return Transit(s);
            }
            string allConvertedResult;
            Goto(GoThrough(ch, transition, out allConvertedResult), ch, transition);
            return allConvertedResult;
        }

        private string Transit(string s)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int index = 0; index < s.Length; ++index)
                stringBuilder.Append(Transit(s[index]));
            return stringBuilder.ToString();
        }

        internal void End()
        {
            string content = buffer.Content;
            if (string.IsNullOrEmpty(content))
                return;
            string str = conversionMap.Convert(content);
            output.Write(str ?? content);
            buffer.Clear();
            if (currentState == entryState)
                return;
            Goto(entryState, char.MinValue, null);
        }

        private State GoThrough(char ch, Transition transition, out string allConvertedResult)
        {
            allConvertedResult = string.Empty;
            List<Action> actions = transition.Actions;
            for (int index = 0; index < actions.Count; ++index)
            {
                switch (actions[index].Command)
                {
                    case ActionCommand.AppendInput:
                        buffer.Append(ch);
                        break;
                    case ActionCommand.ConvertToOutput:
                        string str = conversionMap.Convert(buffer.Content);
                        allConvertedResult += str;
                        output.Write(str);
                        break;
                    case ActionCommand.Clear:
                        buffer.Clear();
                        break;
                    case ActionCommand.AppendX:
                        buffer.Append(Convert.ToChar(actions[index].Parameter, (IFormatProvider)null));
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
            return transition.NextState;
        }

        private void Goto(State state, char ch, Transition transition)
        {
            State cState = currentState;
            currentState = state;
            stateChanged(this, new StateChangedEventArgs(ch, cState, currentState, transition));
        }
    }
}
