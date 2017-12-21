using System;

namespace Microsoft.International.Formatters
{
    internal class CHTCurFmt : CHFmt
    {
        protected override string[] Digits => new[]
        {
            "零",
            "壹",
            "貳",
            "參",
            "肆",
            "伍",
            "陸",
            "柒",
            "捌",
            "玖"
        };

        protected override string Zero => "零";

        protected override string Ten => "拾";

        protected override string Hundred => "佰";

        protected override string Thousand => "仟";

        protected override string TenThousand => "萬";

        protected override string HundredMillion => "億";

        protected override string ThousandBillion => "兆";

        protected override string DecimalPoint => "點";

        protected override string Minus => "負";

        protected override Decimal Initialize(Decimal num)
        {
            num = Math.Truncate(num * new Decimal(100)) / new Decimal(100);
            return num;
        }
    }
}
