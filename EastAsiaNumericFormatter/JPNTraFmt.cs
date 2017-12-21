using System.Text;

namespace Microsoft.International.Formatters
{
    internal class JPNTraFmt : JPNFmt
    {
        protected override string[] Digits => new[]
        {
            "〇",
            "一",
            "二",
            "三",
            "四",
            "五",
            "六",
            "七",
            "八",
            "九"
        };

        protected override string Zero => "〇";

        protected override string Ten => string.Empty;

        protected override string Hundred => string.Empty;

        protected override string Thousand => string.Empty;

        protected override string TenThousand => string.Empty;

        protected override string HundredMillion => string.Empty;

        protected override string ThousandBillion => string.Empty;

        protected override string DecimalPoint => string.Empty;

        protected override string Minus => "-";

        protected override void ConvertIntergralStackToText(StackWithIndex stack, StringBuilder text)
        {
            while (stack.Count > 0 && stack.Peek() == this.Zero)
                stack.Pop();
            while (stack.Count > 0)
                text.Append(stack.Pop());
        }

        protected override string GetDigitText(int digit, ulong position)
        {
            return this.Digits[digit];
        }
    }
}