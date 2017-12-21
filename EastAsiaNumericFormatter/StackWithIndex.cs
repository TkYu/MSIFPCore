using System.Collections.Generic;

namespace Microsoft.International.Formatters
{
    internal class StackWithIndex
    {
        private List<string> data;

        internal StackWithIndex()
        {
            this.data = new List<string>();
        }

        internal string Pop()
        {
            string str = this.data[this.data.Count - 1];
            this.data.RemoveAt(this.data.Count - 1);
            return str;
        }

        internal string Peek()
        {
            return this.data[this.data.Count - 1];
        }

        internal void Push(string item)
        {
            this.data.Add(item);
        }

        internal string this[int index]
        {
            get { return this.data[this.data.Count - index - 1]; }
        }

        internal int Count
        {
            get { return this.data.Count; }
        }
    }
}