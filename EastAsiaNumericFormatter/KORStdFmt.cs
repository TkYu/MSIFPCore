using System.Text;

namespace Microsoft.International.Formatters
{
    internal class KORStdFmt : KORFmt
    {
        protected override void ConvertIntergralStackToText(StackWithIndex stack, StringBuilder text)
        {
            while (stack.Count > 0 && string.IsNullOrEmpty(stack.Peek()))
                stack.Pop();
            bool flag = false;
            if (stack.Peek().Equals(this.Digits[1]))
            {
                for (int index = 2; index < stack.Count && string.IsNullOrEmpty(stack[index]); ++index)
                {
                    if (index == stack.Count - 1)
                        flag = true;
                }
            }
            else
                flag = false;

            while (stack.Count > 0)
            {
                string str = stack.Pop();
                if (!string.IsNullOrEmpty(str))
                {
                    if (flag)
                        flag = false;
                    else if (!str.StartsWith(this.Digits[1]) || !str.EndsWith(this.Ten) && !str.EndsWith(this.Hundred) && !str.EndsWith(this.Thousand))
                        text.Append(str);
                    else
                        text.Append(str.Substring(this.Digits[1].Length));
                }
            }

            if ((int) text[text.Length - 1] != 32)
                return;
            text.Remove(text.Length - 1, 1);
        }
    }
}