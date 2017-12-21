using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Microsoft.International.Converters
{
    /// <summary>Represents a state of the StateMachine.</summary>
    /// <remarks>
    /// See <see cref="T:Microsoft.International.Converters.TransliteralConverter" /> for an example of using TransliteralConverter.
    /// </remarks>
    public class State
    {
        private readonly List<Transition> _transitionList = new List<Transition>();
        private readonly StateMachine _stateMachine;

        /// <summary>Gets the identity of a state.</summary>
        /// <value>The identity of a state.</value>
        /// <remarks>
        /// See <see cref="T:Microsoft.International.Converters.TransliteralConverter" /> for an example of using TransliteralConverter.
        /// </remarks>
        public string Id { get; }

        /// <summary>
        /// Gets a value indicating whether the state is start state.
        /// </summary>
        /// <value>A value indicating whether the state is a start state.</value>
        /// <remarks>
        /// See <see cref="T:Microsoft.International.Converters.TransliteralConverter" /> for an example of using TransliteralConverter.
        /// </remarks>
        public bool IsStartState => Id == _stateMachine.entryState.Id;

        /// <summary>Gets the list of transitions of states.</summary>
        /// <value>The list of transitions of states.</value>
        /// <remarks>
        /// See <see cref="T:Microsoft.International.Converters.TransliteralConverter" /> for an example of using TransliteralConverter.
        /// </remarks>
        public ReadOnlyCollection<Transition> Transitions => _transitionList.AsReadOnly();

        internal State(StateMachine stateMachine, StateConfig stateConfig)
        {
            _stateMachine = stateMachine;
            Id = stateConfig.ID;
            for (int index = 0; index < stateConfig.Transitions.Count; ++index)
            {
                TransitionConfig transition = stateConfig.Transitions[index];
                string id = transition.ID;
                List<ActionConfig> actions = transition.Actions;
                List<RegexConfig> inputValidators = transition.InputValidators;
                this._transitionList.Add(new Transition(stateMachine, id, inputValidators, actions));
            }
        }
    }
}
