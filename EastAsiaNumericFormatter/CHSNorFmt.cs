namespace Microsoft.International.Formatters
{
    internal class CHSNorFmt : CHFmt
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

        protected override string HundredMillion => "亿";

        protected override string ThousandBillion => "兆";

        protected override string DecimalPoint => "点";

        protected override string Minus => "负";
    }
}