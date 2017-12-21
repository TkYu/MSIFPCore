using System;
using System.Collections.Generic;

namespace Microsoft.International.Converters
{
    internal class ConversionMap
    {
        private readonly SortedDictionary<string, string> conversionDictionary = new SortedDictionary<string, string>((IComparer<string>)new ConversionMap.StringOrdinalComparer());

        internal void Add(string key, string value)
        {
            conversionDictionary.Add(key, value);
        }

        internal string Convert(string key)
        {
            return conversionDictionary.TryGetValue(key, out var str) ? str : null;
        }

        private class StringOrdinalComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
            }
        }
    }
}