using System;

namespace Microsoft.International.Converters
{
    /// <summary>Provides data for StateChanged event.</summary>
    /// <remarks>
    /// See <see cref="T:Microsoft.International.Converters.TransliteralConverter" /> for an example of using TransliteralConverter.
    /// </remarks>
    public class StateChangedEventArgs : EventArgs
    {
        /// <summary>Gets user input character.</summary>
        /// <value>User input character.</value>
        /// <remarks>
        /// See <see cref="T:Microsoft.International.Converters.TransliteralConverter" /> for an example of using TransliteralConverter.
        /// </remarks>
        public char Input { get; }

        /// <summary>
        /// Gets previous <see cref="T:Microsoft.International.Converters.State" />.
        /// </summary>
        /// <value>
        /// Previous <see cref="T:Microsoft.International.Converters.State" />.
        /// </value>
        /// <remarks>
        /// See <see cref="T:Microsoft.International.Converters.TransliteralConverter" /> for an example of using TransliteralConverter.
        /// </remarks>
        public State PreviousState { get; }

        /// <summary>
        /// Gets next <see cref="T:Microsoft.International.Converters.State" />.
        /// </summary>
        /// <value>
        /// Next <see cref="T:Microsoft.International.Converters.State" />.
        /// </value>
        /// <remarks>
        /// See <see cref="T:Microsoft.International.Converters.TransliteralConverter" /> for an example of using TransliteralConverter.
        /// </remarks>
        public State NextState { get; }

        /// <summary>
        /// Gets the <see cref="T:Microsoft.International.Converters.Transition">Transition</see> between previous state and next state.
        /// </summary>
        /// <value>
        /// The <see cref="T:Microsoft.International.Converters.Transition">Transition</see> between previous state and next state.
        /// </value>
        /// <remarks>
        /// See <see cref="T:Microsoft.International.Converters.TransliteralConverter" /> for an example of using TransliteralConverter.
        /// </remarks>
        public Transition Transition { get; }

        internal StateChangedEventArgs(char input, State previousState, State currentState, Transition transition)
        {
            Input = input;
            PreviousState = previousState;
            NextState = currentState;
            Transition = transition;
        }
    }
}
