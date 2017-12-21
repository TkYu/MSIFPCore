namespace Microsoft.International.Formatters
{
    internal abstract class KORFmt : EastAsiaFormatter
    {
        protected override string[] Digits => new[]
        {
            "영",
            "일",
            "이",
            "삼",
            "사",
            "오",
            "육",
            "칠",
            "팔",
            "구"
        };

        protected override string Zero => "영";

        protected override string Ten => "십";

        protected override string Hundred => "백";

        protected override string Thousand => "천";

        protected override string TenThousand => "만 ";

        protected override string HundredMillion => "억 ";

        protected override string ThousandBillion => "조 ";

        protected override string DecimalPoint => " 점 ";

        protected override string Minus => "음수 ";

        protected override string GetDigitText(int digit, ulong position)
        {
            if (digit == 0)
                return string.Empty;
            return this.Digits[digit] + this.GetPositionText(position);
        }
    }
}