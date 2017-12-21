using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Microsoft.International.Converters
{
    /// <summary>
    /// Class that represents a transition from one <see cref="T:Microsoft.International.Converters.State" /> to another.
    /// </summary>
    /// <remarks>
    /// See <see cref="T:Microsoft.International.Converters.TransliteralConverter" /> for an example of using TransliteralConverter.
    /// </remarks>
    public class Transition
    {
        private readonly List<FormattableRegex> _formattableRegexList = new List<FormattableRegex>();
        private readonly List<Action> _actionList = new List<Action>();
        private readonly StateMachine _stateMachine;
        private readonly string _nextStateId;

        /// <summary>Gets the identity of next state.</summary>
        /// <value>The identity of next state.</value>
        /// <remarks>
        /// See <see cref="T:Microsoft.International.Converters.TransliteralConverter" /> for an example of using TransliteralConverter.
        /// </remarks>
        public State NextState => _stateMachine.stateList[_nextStateId];

        internal List<Action> Actions => _actionList;

        internal Transition(StateMachine stateMachine, string nextStateId, List<RegexConfig> regexConfig, List<ActionConfig> actions)
        {
            this._stateMachine = stateMachine;
            this._nextStateId = nextStateId;
            for (int index = 0; index < regexConfig.Count; ++index)
                _formattableRegexList.Add(new FormattableRegex(regexConfig[index].Value));
            for (int index = 0; index < actions.Count; ++index)
            {
                string input = actions[index].Value;
                switch (input)
                {
                    case "AppendInput":
                        this._actionList.Add(new Action(ActionCommand.AppendInput));
                        break;
                    case "Clear":
                        this._actionList.Add(new Action(ActionCommand.Clear));
                        break;
                    case "ConvertToOutput":
                        this._actionList.Add(new Action(ActionCommand.ConvertToOutput));
                        break;
                    default:
                        Match match = Regex.Match(input, "Append\\s*\\(\\s*(?<ch>\\w)\\s*\\)", RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
                        if (!match.Success)
                            throw new InvalidOperationException();
                        this._actionList.Add(new Action(ActionCommand.AppendX, (object)match.Groups["ch"].Value));
                        break;
                }
            }
        }

        internal bool IsMatch(char ch)
        {
            for (int index = 0; index < this._formattableRegexList.Count; ++index)
            {
                char? nullable = this._stateMachine.buffer.GetChar(this._formattableRegexList[index].parameter);
                string str = Regex.Escape(Convert.ToString(nullable.HasValue ? nullable.GetValueOrDefault() : char.MaxValue, (IFormatProvider)null));
                string pattern = string.Format(null, _formattableRegexList[index].regex, new object[1]
                {
                    str
                });
                if (!Regex.IsMatch(ch.ToString(), pattern, RegexOptions.IgnoreCase))
                    return false;
            }
            return true;
        }

        private class FormattableRegex
        {
            internal string regex;
            internal int parameter;

            internal FormattableRegex(string regexp)
            {
                this.regex = regexp;
                this.regex = this.regex.Replace("{", "{{");
                this.regex = this.regex.Replace("}", "}}");
                this.regex = Regex.Replace(this.regex, "\\# \\w* history \\w* \\( \\w* (?<index> (-)? \\d+ ) \\w* \\) \\w* \\#", (MatchEvaluator)(match =>
                {
                    this.parameter = Convert.ToInt32(match.Groups["index"].Value, (IFormatProvider)null);
                    return "{0}";
                }), RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
            }
        }
    }
}
