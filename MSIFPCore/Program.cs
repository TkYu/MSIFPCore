using System;
using Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter;

namespace MSIFPCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ChineseConverter.Convert("头发发财",ChineseConversionDirection.SimplifiedToTraditional));
        }
    }
}
