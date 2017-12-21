using System;
using System.Text;

namespace Microsoft.International.Formatters
{
    internal class KORCurFmt : KORFmt
    {
        protected override void ConvertIntergralStackToText(StackWithIndex stack, StringBuilder text)
        {
            while (stack.Count > 0)
            {
                string str = stack.Pop();
                text.Append(str);
            }

            if ((int) text[text.Length - 1] != 32)
                return;
            text.Remove(text.Length - 1, 1);
        }

        protected override Decimal Initialize(Decimal num)
        {
            num = Math.Truncate(num * new Decimal(100)) / new Decimal(100);
            return num;
        }
    }
}
