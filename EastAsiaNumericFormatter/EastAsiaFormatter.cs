using System;
using System.Globalization;
using System.Text;

namespace Microsoft.International.Formatters
{
  internal abstract class EastAsiaFormatter
  {
    protected abstract string[] Digits { get; }

    protected abstract string Zero { get; }

    protected abstract string Ten { get; }

    protected abstract string Hundred { get; }

    protected abstract string Thousand { get; }

    protected abstract string TenThousand { get; }

    protected abstract string HundredMillion { get; }

    protected abstract string ThousandBillion { get; }

    protected abstract string DecimalPoint { get; }

    protected abstract string Minus { get; }

    internal static EastAsiaFormatter Create(CultureInfo culture, string format)
    {
      while (!culture.IsNeutralCulture && culture.Parent != null)
        culture = culture.Parent;
      if (culture.Equals((object) new CultureInfo("zh-CHS")))
      {
        switch (format)
        {
          case "L":
            return (EastAsiaFormatter) new CHSStdFmt();
          case "Ln":
            return (EastAsiaFormatter) new CHSNorFmt();
          case "Lc":
            return (EastAsiaFormatter) new CHSCurFmt();
          default:
            return (EastAsiaFormatter) null;
        }
      }
      else if (culture.Equals((object) new CultureInfo("zh-CHT")))
      {
        switch (format)
        {
          case "L":
            return (EastAsiaFormatter) new CHTStdFmt();
          case "Ln":
            return (EastAsiaFormatter) new CHTNorFmt();
          case "Lc":
            return (EastAsiaFormatter) new CHTCurFmt();
          default:
            return (EastAsiaFormatter) null;
        }
      }
      else if (culture.Equals((object) new CultureInfo("ja")))
      {
        switch (format)
        {
          case "L":
            return (EastAsiaFormatter) new JPNStdFmt();
          case "Ln":
            return (EastAsiaFormatter) new JPNNorFmt();
          case "Lt":
            return (EastAsiaFormatter) new JPNTraFmt();
          default:
            return (EastAsiaFormatter) null;
        }
      }
      else
      {
        if (!culture.Equals((object) new CultureInfo("ko")))
          return (EastAsiaFormatter) null;
        switch (format)
        {
          case "L":
            return (EastAsiaFormatter) new KORStdFmt();
          case "Lc":
            return (EastAsiaFormatter) new KORCurFmt();
          default:
            return (EastAsiaFormatter) null;
        }
      }
    }

    internal string ConvertToLocalizedText(Decimal num)
    {
      StringBuilder text = new StringBuilder();
      StackWithIndex stack = new StackWithIndex();
      if (num < new Decimal(0))
      {
        text.Append(this.Minus);
        num = Math.Abs(num);
      }
      num = this.Initialize(num);
      if ((long) (ulong) num == 0L)
      {
        text.Append(this.Zero);
      }
      else
      {
        this.GetIntegralStack(Math.Truncate(num), 1UL, stack);
        this.ConvertIntergralStackToText(stack, text);
      }
      num -= Math.Truncate(num);
      if (num != new Decimal(0))
      {
        text.Append(this.DecimalPoint);
        this.GetDecimalText(num, text);
      }
      return text.ToString();
    }

    /// <summary>
    /// Splits the number.
    /// Pushs every digit and its digitWeight into stack.
    /// </summary>
    /// <param name="num">the number needed to be splited.</param>
    /// <param name="position">Splits the number from this position.</param>
    /// <param name="stack">Pushs every digit and its digitWeight this stack.</param>
    protected virtual void GetIntegralStack(Decimal num, ulong position, StackWithIndex stack)
    {
      if (num < new Decimal(10000))
      {
        if (num != new Decimal(0) || (long) position == 1000000000000L)
          stack.Push(this.GetPositionText(position));
        for (int index = 0; index < 4; ++index)
        {
          int digit = (int) (num % new Decimal(10));
          ulong position1 = (ulong) Math.Pow(10.0, (double) index);
          num /= new Decimal(10);
          stack.Push(this.GetDigitText(digit, position1));
        }
      }
      else
      {
        this.GetIntegralStack(Math.Truncate(num % new Decimal(10000)), position, stack);
        this.GetIntegralStack(Math.Truncate(num / new Decimal(10000)), position * 10000UL, stack);
      }
    }

    /// <summary>
    /// Converts the digit information from the stack into a StringBuilder.
    /// </summary>
    /// <param name="stack">Stores the digits needed to be transfered.</param>
    /// <param name="text">Transfers the digits to this text.</param>
    protected abstract void ConvertIntergralStackToText(StackWithIndex stack, StringBuilder text);

    /// <summary>Adds decimal part of the number into the text.</summary>
    /// <param name="num">The decimal part of this number will be added.</param>
    /// <param name="text">Adds decimal part into this text.</param>
    protected virtual void GetDecimalText(Decimal num, StringBuilder text)
    {
      Decimal d;
      for (; num != new Decimal(0); num = d - Math.Truncate(d))
      {
        d = num * new Decimal(10);
        int int32 = Convert.ToInt32(Math.Truncate(d));
        text.Append(this.Digits[int32]);
      }
    }

    protected abstract string GetDigitText(int digit, ulong position);

    protected virtual string GetPositionText(ulong position)
    {
      switch (position)
      {
        case 1:
          return string.Empty;
        case 10:
          return this.Ten;
        case 100:
          return this.Hundred;
        case 1000:
          return this.Thousand;
        case 10000:
          return this.TenThousand;
        case 100000000:
          return this.HundredMillion;
        case 1000000000000:
          return this.ThousandBillion;
        case 10000000000000000:
          return this.TenThousand;
        default:
          throw new InvalidOperationException();
      }
    }

    protected virtual Decimal Initialize(Decimal num)
    {
      num = Math.Round(num, 15);
      return num;
    }

    protected internal virtual bool CheckOutOfRange(double num)
    {
      return num > 1.84467440737096E+19 || num < (double) long.MinValue || (double.IsNaN(num) || double.IsInfinity(num));
    }
  }
}
