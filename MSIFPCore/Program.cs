using System;
using Microsoft.International.Converters;

namespace MSIFPCore
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "arigatougozaimasu";
            string output = KanaConverter.RomajiToHiragana(input);
            Console.WriteLine(output);
        }
    }
}
