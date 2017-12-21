using System.Text;

namespace Microsoft.International.Formatters
{
    internal abstract class CHFmt : EastAsiaFormatter
    {
        protected override void ConvertIntergralStackToText(StackWithIndex stack, StringBuilder text)
        {
            string str1 = string.Empty;
            bool flag = true;
            while (stack.Count > 0)
            {
                string str2 = stack.Pop();
                if (str2 == this.Zero)
                {
                    if (!flag)
                        str1 = this.Zero;
                    flag = true;
                }
                else if (str2 == this.TenThousand || str2 == this.HundredMillion || str2 == this.ThousandBillion)
                {
                    text.Append(str2);
                    str1 = string.Empty;
                    flag = false;
                }
                else if (!string.IsNullOrEmpty(str2))
                {
                    text.Append(str1);
                    text.Append(str2);
                    str1 = string.Empty;
                    flag = false;
                }
            }
        }

        protected override string GetDigitText(int digit, ulong position)
        {
            if (digit == 0)
                return Zero;
            if (digit * (long) position != 10L)
                return Digits[digit] + GetPositionText(position);
            return GetPositionText(position);
        }
    }
}