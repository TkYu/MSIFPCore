using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter
{
    /// <summary>提供一個工具類進行簡體中文和繁體中文之間的相互轉換。</summary>
    /// <remarks>
    ///   <br>可以通過ChineseConversionDirection參數來指定繁簡轉換的方向。</br>
    ///   如果使用者系統中安裝了Microsoft Office提供的轉換引擎，這個類別就會叫用他，否則將使用 Windows API進行轉換。與Windows API簡單的字對字轉換不同，Microsoft Office 2007的繁體/簡體轉換引擎可以按詞對詞轉換，大大提高了轉換的品質。
    /// </remarks>
    /// <example>
    ///   以下程式碼演示了繁體及簡體中文字串之間的轉換。
    ///   <code source="../../Example_CS/Program.cs" lang="cs"></code>
    ///   <code source="../../Example_VB/Main.vb" lang="vbnet"></code>
    ///   <code source="../../Example_CPP/Example_CPP.cpp" lang="cpp"></code>
    /// </example>
    public static class ChineseConverter
    {
        private static Dictionary<string, string> STCharacters;
        private static Dictionary<string, string> TSCharacters;
        /// <summary>轉換簡體中文和繁體中文字串。</summary>
        /// <param name="text">需要轉換的字串。</param>
        /// <param name="direction">轉換方式。</param>
        /// <returns>轉換的字串。</returns>
        /// <exception cref="T:System.ArgumentNullException">文本是null。</exception>
        /// <remarks>
        ///   請參閱<see cref="T:Microsoft.International.Converters.TraditionalChineseToSimplifiedConverter.ChineseConverter" />來查看使用中文轉換的例子。
        /// </remarks>
        public static string Convert(string text, ChineseConversionDirection direction)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                //OfficeConversionEngine conversionEngine = OfficeConversionEngine.Create();
                //if (conversionEngine != null)
                //    return conversionEngine.TCSCConvert(text, direction);
                uint dwMapFlags = direction == ChineseConversionDirection.TraditionalToSimplified ? 33554432U : 67108864U;
                int num1 = text.Length * 2 + 2;
                IntPtr num2 = Marshal.AllocHGlobal(num1);
                NativeMethods.LCMapString(2052, dwMapFlags, text, -1, num2, num1);
                var stringUni = Marshal.PtrToStringUni(num2);
                Marshal.FreeHGlobal(num2);
                return stringUni;
            }
            switch (direction)
            {
                //内容来自于 https://github.com/BYVoid/OpenCC
                case ChineseConversionDirection.SimplifiedToTraditional:
                    if (STCharacters == null)STCharacters = Encoding.UTF8.GetString(Properties.Resources.STCharacters)
                        .Replace("\r", "").Split('\n').Select(c => c.Split('\t'))
                        .Where(c => c.Length == 2).ToDictionary(k => k[0], v => v[1].Split(' ')[0]);
                    return FindandReplace(text, STCharacters);
                case ChineseConversionDirection.TraditionalToSimplified:
                    if (TSCharacters == null) TSCharacters = Encoding.UTF8.GetString(Properties.Resources.TSCharacters)
                        .Replace("\r", "").Split('\n').Select(c => c.Split('\t'))
                        .Where(c => c.Length == 2).ToDictionary(k => k[0], v => v[1].Split(' ')[0]);
                    return FindandReplace(text, TSCharacters);
                default:
                    return null;
            }
        }

        private static string FindandReplace(string inputText, Dictionary<string, string> placeHolderValues)
        {
            return !string.IsNullOrEmpty(inputText) ? 
                placeHolderValues.Keys.Aggregate(inputText, (current, key) => current.Replace(key, placeHolderValues[key])) : inputText;
        }
        /*
        private static string FindandReplace(string inputText, Dictionary<string, string> placeHolderValues)
        {
                    var sw = new System.Diagnostics.Stopwatch();
                    sw.Start();
                    FindandReplace(text, STCharacters);
                    sw.Stop();
                    Console.WriteLine(sw.ElapsedTicks);
                    sw.Reset();
                    sw.Start();
                    FindandReplace2(text, STCharacters);
                    sw.Stop();
                    Console.WriteLine(sw.ElapsedTicks);
            return !string.IsNullOrEmpty(inputText) ? 
                Regex.Replace(inputText, @"\{(.+?)\}", m => placeHolderValues[m.Groups[1].Value]) : inputText;
        }
        */
    }
}
