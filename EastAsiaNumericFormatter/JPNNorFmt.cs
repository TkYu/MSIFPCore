using System.Text;

namespace Microsoft.International.Formatters
{
    internal class JPNNorFmt : JPNFmt
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

        protected override string Ten => "十";

        protected override string Hundred => "百";

        protected override string Thousand => "千";

        protected override string TenThousand => "万";

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
            switch (digit)
            {
                case 0:
                    return string.Empty;
                case 1:
                    if ((long) position == 10L || (long) position == 100L || (long) position == 1000L)
                        return this.GetPositionText(position);
                    break;
            }

            return this.Digits[digit] + this.GetPositionText(position);
        }
    }
}
