using System;

namespace Microsoft.International.Formatters
{
  internal abstract class JPNFmt : EastAsiaFormatter
  {
    protected override Decimal Initialize(Decimal num)
    {
      return Math.Truncate(num);
    }

    protected internal override bool CheckOutOfRange(double num)
    {
      if (num >= 1E+16 || num < 0.0)
        return true;
      return base.CheckOutOfRange(num);
    }
  }
}
