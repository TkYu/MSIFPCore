using System;
using System.Globalization;

namespace Microsoft.International.Formatters
{
  /// <summary>
  /// Provides a formatter class that converts the numbers in the numeric data types
  /// to a string with local numeric representation in East Asia languages.
  /// </summary>
  /// <remarks>
  /// This class supports the following east Asia languages:
  /// 
  /// <list type="bullet">
  /// <item>
  /// Chinese-Simplified
  /// </item>
  /// <item>
  /// Chinese-Traditional
  /// </item>
  /// <item>
  /// Japanese
  /// </item>
  /// <item>
  /// Korean
  /// </item>
  /// </list>
  /// 
  /// This class supports the following format strings:
  /// <list type="bullet">
  /// <item>
  /// Standard Format(L): Also called upper-case.
  /// </item>
  /// <item>
  /// Normal Format(Ln): Also called lower-case.
  /// </item>
  /// <item>
  /// Currency Format(Lc): It's used to represent currency values.
  /// </item>
  /// <item>
  /// Transliterate Format(Lt): Represent the numeric data in the characters of digit alphabet. Only supported in Japanese.
  /// </item>
  /// </list>
  /// 
  /// In order to explain how culture and format combination works, we will take "12345" as an example.
  /// <list type="bullet">
  /// <item>
  /// Chinese-Simplified
  /// <list type="bullet">
  /// <item>
  /// Standard: 壹万贰仟叁佰肆拾伍
  /// </item>
  /// <item>
  /// Normal: 一万二千三百四十五
  /// </item>
  /// <item>
  /// Currency: 壹万贰仟叁佰肆拾伍
  /// </item>
  /// <item>
  /// Transliterate: ArgumentException will be thrown
  /// </item>
  /// </list>
  /// </item>
  /// <item>
  /// Chinese-Traditional
  /// <list type="bullet">
  /// <item>
  /// Standard: 壹萬貳仟參佰肆拾伍
  /// </item>
  /// <item>
  /// Normal: 一萬二千三百四十五
  /// </item>
  /// <item>
  /// Currency: 壹萬貳仟參佰肆拾伍
  /// </item>
  /// <item>
  /// Transliterate: ArgumentException will be thrown
  /// </item>
  /// </list>
  /// </item>
  /// <item>
  /// Japanese
  /// <list type="bullet">
  /// <item>
  /// Standard: 壱萬弐阡参百四拾伍
  /// </item>
  /// <item>
  /// Normal: 一万二千三百四十五
  /// </item>
  /// <item>
  /// Currency: ArgumentException will be thrown
  /// </item>
  /// <item>
  /// Transliterate: 一二三四五
  /// </item>
  /// </list>
  /// </item>
  /// <item>
  /// Korean
  /// <list type="bullet">
  /// <item>
  /// Standard: 일만 이천삼백사십오
  /// </item>
  /// <item>
  /// Normal: ArgumentException will be thrown
  /// </item>
  /// <item>
  /// Currency: 일만 이천삼백사십오
  /// </item>
  /// <item>
  /// Transliterate: ArgumentException will be thrown
  /// </item>
  /// </list>
  /// </item>
  /// <item>
  /// Other Languages: ArgumentException will be thrown
  /// </item>
  /// </list>
  /// Built-in numeric types are supported, including
  /// double, float, int, uint, long, ulong, short, ushort, sbyte, byte and decimal.
  /// </remarks>
  /// <example>
  /// The following code demonstrates a sample that converts the number to a string with local numeric representation in East Asian languages.
  /// <code source="../../Example_CS/Program.cs" lang="cs"></code>
  /// <code source="../../Example_VB/Main.vb" lang="vbnet"></code>
  /// <code source="../../Example_CPP/Example_CPP.cpp" lang="cpp"></code>
  /// </example>
  public class EastAsiaNumericFormatter : ICustomFormatter, IFormatProvider
  {
    /// <summary>
    /// It returns an object that implements ICustomFormatter to do the formatting.
    /// </summary>
    /// <remarks>
    /// See <see cref="T:Microsoft.International.Formatters.EastAsiaNumericFormatter" /> for an example of using EastAsiaNumericFormatter.
    /// </remarks>
    /// <param name="formatType">Format type.</param>
    /// <returns>
    /// Returns the same object if formatType parameter is <see cref="T:System.ICustomFormatter" /> type. Otherwise, return a null reference.
    /// </returns>
    public object GetFormat(Type formatType)
    {
      if (formatType == typeof (ICustomFormatter))
        return (object) this;
      return (object) null;
    }

    /// <summary>
    /// Formats the object into representation of East Asian culture.
    /// </summary>
    /// <remarks>
    /// See <see cref="T:Microsoft.International.Formatters.EastAsiaNumericFormatter">EastAsiaNumericFormatter</see> for an example of using EastAsiaNumericFormatter.
    /// </remarks>
    /// <param name="format">Format type.</param>
    /// <param name="arg">Number to be formatted.</param>
    /// <param name="formatProvider">Format provider.</param>
    /// <returns>Localized string in East Asian forms.</returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// format, arg or culture is a null reference.
    /// </exception>
    /// <exception cref="T:System.ArgumentException">
    /// The specified format is not supported in this culture.
    /// </exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    /// arg is out of range.
    /// </exception>
    /// <exception cref="T:System.ArgumentException">
    /// arg is a invalid type.
    /// </exception>
    public string Format(string format, object arg, IFormatProvider formatProvider)
    {
      return EastAsiaNumericFormatter.FormatWithCulture(format, arg, formatProvider, CultureInfo.CurrentCulture);
    }

    /// <summary>
    /// Formats the object into representation of specified East Asian culture.
    /// </summary>
    /// <remarks>
    /// See <see cref="T:Microsoft.International.Formatters.EastAsiaNumericFormatter" /> for an example of using FormatWithCulture.
    /// </remarks>
    /// <param name="format">Format type.</param>
    /// <param name="arg">Number to be formatted.</param>
    /// <param name="formatProvider">Format provider.</param>
    /// <param name="culture">Culture type.</param>
    /// <returns>Localized string in East Asian forms.</returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// format, arg or culture is a null reference.
    /// </exception>
    /// <exception cref="T:System.ArgumentException">
    /// The specified format is not supported in this culture.
    /// </exception>
    /// <exception cref="T:System.ArgumentOutOfRangeException">
    /// arg is out of range.
    /// </exception>
    /// <exception cref="T:System.ArgumentException">
    /// arg is a invalid type.
    /// </exception>
    public static string FormatWithCulture(string format, object arg, IFormatProvider formatProvider, CultureInfo culture)
    {
      if (format == null)
        throw new ArgumentNullException(nameof (format));
      if (arg == null)
        throw new ArgumentNullException(nameof (arg));
      if (culture == null)
        throw new ArgumentNullException(nameof (culture));
      if (!format.Equals("L") && !format.Equals("Ln") && (!format.Equals("Lt") && !format.Equals("Lc")))
      {
        IFormattable formattable = arg as IFormattable;
        if (formattable == null)
          return arg.ToString();
        return formattable.ToString(format, formatProvider);
      }
      EastAsiaFormatter eastAsiaFormatter = EastAsiaFormatter.Create(culture, format);
      if (eastAsiaFormatter == null)
        throw new ArgumentException(Properties.Resources.INVALID_PARAMETER_COMBINATION);
      Type type = arg.GetType();
      if (type != typeof (double) && type != typeof (float) && (type != typeof (int) && type != typeof (uint)) && (type != typeof (long) && type != typeof (ulong) && (type != typeof (short) && type != typeof (ushort))) && (type != typeof (sbyte) && type != typeof (byte) && type != typeof (Decimal)))
        throw new ArgumentException(Properties.Resources.INVALID_ARGUMENT_TYPE, nameof (arg));
      double num = Convert.ToDouble(arg, (IFormatProvider) null);
      if (eastAsiaFormatter.CheckOutOfRange(num))
        throw new ArgumentOutOfRangeException(nameof (arg));
      return eastAsiaFormatter.ConvertToLocalizedText(Convert.ToDecimal(arg, (IFormatProvider) null));
    }
  }
}
