using System.Text;

namespace Microsoft.International.Converters
{
    internal class StateMachineBuffer
    {
        private readonly StringBuilder history = new StringBuilder();

        internal string Content => history.ToString();

        internal void Append(char ch)
        {
            history.Append(ch);
        }

        internal char? GetChar(int index)
        {
            index += history.Length;
            if (index < 0 || index >= history.Length)
                return new char?();
            return history[index];
        }

        internal bool IsEmpty => history.Length == 0;

        internal void Clear()
        {
            history.Length = 0;
        }
    }
}
