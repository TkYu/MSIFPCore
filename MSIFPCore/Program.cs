using System;
using System.Diagnostics;
using System.Globalization;
using Microsoft.International.Converters;
using Microsoft.International.Formatters;

namespace MSIFPCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The representation for number 123.45 in Japanese Standard format is " + EastAsiaNumericFormatter.FormatWithCulture("L", 123.45, null, new CultureInfo("ja")));
        }
    }
}
