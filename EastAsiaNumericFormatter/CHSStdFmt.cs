namespace Microsoft.International.Formatters
{
    internal class CHSStdFmt : CHFmt
    {
        protected override string[] Digits => new[]
        {
            "零",
            "壹",
            "贰",
            "叁",
            "肆",
            "伍",
            "陆",
            "柒",
            "捌",
            "玖"
        };

        protected override string Zero => "零";

        protected override string Ten => "拾";

        protected override string Hundred => "佰";

        protected override string Thousand => "仟";

        protected override string TenThousand => "万";

        protected override string HundredMillion => "亿";

        protected override string ThousandBillion => "兆";

        protected override string DecimalPoint => "点";

        protected override string Minus => "负";
    }
}