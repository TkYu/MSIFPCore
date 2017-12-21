namespace Microsoft.International.Converters
{
    internal class Action
    {
        internal ActionCommand Command { get; }

        internal object Parameter { get; }

        internal Action(ActionCommand command)
            : this(command, null)
        {
        }

        internal Action(ActionCommand command, object parameter)
        {
            Command = command;
            Parameter = parameter;
        }
    }
}
