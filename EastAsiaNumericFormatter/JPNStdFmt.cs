using System.Text;

namespace Microsoft.International.Formatters
{
    internal class JPNStdFmt : JPNFmt
    {
        protected override string[] Digits => new[]
        {
            "零",
            "壱",
            "弐",
            "参",
            "四",
            "伍",
            "六",
            "七",
            "八",
            "九"
        };

        protected override string Zero => "零";

        protected override string Ten => "拾";

        protected override string Hundred => "百";

        protected override string Thousand => "阡";

        protected override string TenThousand => "萬";

        protected override string HundredMillion => "億";

        protected override string ThousandBillion => "兆";

        protected override string DecimalPoint => string.Empty;

        protected override string Minus => "-";

        protected override void ConvertIntergralStackToText(StackWithIndex stack, StringBuilder text)
        {
            while (stack.Count > 0)
            {
                string str = stack.Pop();
                text.Append(str);
            }
        }

        protected override string GetDigitText(int digit, ulong position)
        {
            if (digit == 0)
                return string.Empty;
            return this.Digits[digit] + this.GetPositionText(position);
        }
    }
}