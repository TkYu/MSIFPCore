namespace Microsoft.International.Formatters
{
    internal class CHTNorFmt : CHFmt
    {
        protected override string[] Digits => new[]
        {
            "○",
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

        protected override string Zero => "○";

        protected override string Ten => "十";

        protected override string Hundred => "百";

        protected override string Thousand => "千";

        protected override string TenThousand => "萬";

        protected override string HundredMillion => "億";

        protected override string ThousandBillion => "兆";

        protected override string DecimalPoint => ".";

        protected override string Minus => "-";
    }
}