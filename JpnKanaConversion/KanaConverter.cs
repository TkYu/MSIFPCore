﻿using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Microsoft.International.Converters
{
    /// <summary>
    /// <see cref="T:Microsoft.International.Converters.KanaConverter" /> provides predefined conversions for Japanese.
    /// </summary>
    /// <example>
    /// The following code demonstrates how to use <see cref="T:Microsoft.International.Converters.KanaConverter" /> class.
    /// <code source="../../ExampleJpnKanaConvHelper_CS/Program.cs" lang="cs"></code>
    /// <code source="../../ExampleJpnKanaConvHelper_VB/HelperDemo.vb" lang="vbnet"></code>
    /// <code source="../../ExampleJpnKanaConvHelper_CPP/ExampleJpnKanaConvHelper_CPP.cpp" lang="cpp"></code>
    /// The codes above produces the following result:
    /// うぁった
    /// </example>
    public static class KanaConverter
    {
        private static string Convert(string input, string configName)
        {
            var sb = new StringBuilder();
            using (TextReader input1 = new StringReader(input))
            using (TextWriter output = new StringWriter(sb, null))
            using (Stream manifestResourceStream = new MemoryStream((byte[])Properties.Resources.ResourceManager.GetObject(configName.Replace(".xml",""))))
            {
                //Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Microsoft.International.Converters." + configName);
                new TransliteralConverter(input1, output, manifestResourceStream).Run();
            }
            return sb.ToString();
        }

        /// <summary>Converts characters from hiragana to katakana.</summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>Converted string.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// input is a null reference.
        /// </exception>
        /// <remarks>
        /// See <see cref="T:Microsoft.International.Converters.KanaConverter" /> for an example of using KanaConverter.<br />
        /// Click <a href="..\Code\HiraganaToKatakana.xml">here</a> to get the full configuration file for this conversion.<br /><br />
        /// The following table contains all conversions for this method.<br />
        /// <table align="center" border="1" cellspacing="0" cellpadding="0" bordercolor="black" width="80%">
        /// <tr><td colspan="4" align="center"> Hiragana       </td><td colspan="2" align="center"> Katakana   </td></tr>
        /// <tr><td align="center"> Codepoint </td><td align="center"> Character </td><td align="center"> Codepoint </td><td align="center"> Character </td><td align="center"> Codepoint </td><td align="center"> Character </td></tr>
        /// <tr><td align="center"> U+3041 </td><td align="center"> ぁ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30A1 </td><td align="center"> ァ </td></tr>
        /// <tr><td align="center"> U+3042 </td><td align="center"> あ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30A2 </td><td align="center"> ア </td></tr>
        /// <tr><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30A3 </td><td align="center"> ィ </td></tr>
        /// <tr><td align="center"> U+3044 </td><td align="center"> い </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30A4 </td><td align="center"> イ </td></tr>
        /// <tr><td align="center"> U+3045 </td><td align="center"> ぅ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30A5 </td><td align="center"> ゥ </td></tr>
        /// <tr><td align="center"> U+3046 </td><td align="center"> う </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30A6 </td><td align="center"> ウ </td></tr>
        /// <tr><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30A7 </td><td align="center"> ェ </td></tr>
        /// <tr><td align="center"> U+3048 </td><td align="center"> え </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30A8 </td><td align="center"> エ </td></tr>
        /// <tr><td align="center"> U+3049 </td><td align="center"> ぉ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30A9 </td><td align="center"> ォ </td></tr>
        /// <tr><td align="center"> U+304A </td><td align="center"> お </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30AA </td><td align="center"> オ </td></tr>
        /// <tr><td align="center"> U+304B </td><td align="center"> か </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30AB </td><td align="center"> カ </td></tr>
        /// <tr><td align="center"> U+304B </td><td align="center"> か </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30AC </td><td align="center"> ガ </td></tr>
        /// <tr><td align="center"> U+304C </td><td align="center"> が </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30AC </td><td align="center"> ガ </td></tr>
        /// <tr><td align="center"> U+304D </td><td align="center"> き </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30AD </td><td align="center"> キ </td></tr>
        /// <tr><td align="center"> U+304D </td><td align="center"> き </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30AE </td><td align="center"> ギ </td></tr>
        /// <tr><td align="center"> U+304E </td><td align="center"> ぎ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30AE </td><td align="center"> ギ </td></tr>
        /// <tr><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30AF </td><td align="center"> ク </td></tr>
        /// <tr><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30B0 </td><td align="center"> グ </td></tr>
        /// <tr><td align="center"> U+3050 </td><td align="center"> ぐ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30B0 </td><td align="center"> グ </td></tr>
        /// <tr><td align="center"> U+3051 </td><td align="center"> け </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30B1 </td><td align="center"> ケ </td></tr>
        /// <tr><td align="center"> U+3051 </td><td align="center"> け </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30B2 </td><td align="center"> ゲ </td></tr>
        /// <tr><td align="center"> U+3052 </td><td align="center"> げ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30B2 </td><td align="center"> ゲ </td></tr>
        /// <tr><td align="center"> U+3053 </td><td align="center"> こ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30B3 </td><td align="center"> コ </td></tr>
        /// <tr><td align="center"> U+3053 </td><td align="center"> こ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30B4 </td><td align="center"> ゴ </td></tr>
        /// <tr><td align="center"> U+3054 </td><td align="center"> ご </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30B4 </td><td align="center"> ゴ </td></tr>
        /// <tr><td align="center"> U+3055 </td><td align="center"> さ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30B5 </td><td align="center"> サ </td></tr>
        /// <tr><td align="center"> U+3055 </td><td align="center"> さ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30B6 </td><td align="center"> ザ </td></tr>
        /// <tr><td align="center"> U+3056 </td><td align="center"> ざ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30B6 </td><td align="center"> ザ </td></tr>
        /// <tr><td align="center"> U+3057 </td><td align="center"> し </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30B7 </td><td align="center"> シ </td></tr>
        /// <tr><td align="center"> U+3057 </td><td align="center"> し </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30B8 </td><td align="center"> ジ </td></tr>
        /// <tr><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30B8 </td><td align="center"> ジ </td></tr>
        /// <tr><td align="center"> U+3059 </td><td align="center"> す </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30B9 </td><td align="center"> ス </td></tr>
        /// <tr><td align="center"> U+3059 </td><td align="center"> す </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30BA </td><td align="center"> ズ </td></tr>
        /// <tr><td align="center"> U+305A </td><td align="center"> ず </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30BA </td><td align="center"> ズ </td></tr>
        /// <tr><td align="center"> U+305B </td><td align="center"> せ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30BB </td><td align="center"> セ </td></tr>
        /// <tr><td align="center"> U+305B </td><td align="center"> せ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30BC </td><td align="center"> ゼ </td></tr>
        /// <tr><td align="center"> U+305C </td><td align="center"> ぜ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30BC </td><td align="center"> ゼ </td></tr>
        /// <tr><td align="center"> U+305D </td><td align="center"> そ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30BD </td><td align="center"> ソ </td></tr>
        /// <tr><td align="center"> U+305D </td><td align="center"> そ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30BE </td><td align="center"> ゾ </td></tr>
        /// <tr><td align="center"> U+305E </td><td align="center"> ぞ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30BE </td><td align="center"> ゾ </td></tr>
        /// <tr><td align="center"> U+305F </td><td align="center"> た </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30BF </td><td align="center"> タ </td></tr>
        /// <tr><td align="center"> U+305F </td><td align="center"> た </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30C0 </td><td align="center"> ダ </td></tr>
        /// <tr><td align="center"> U+3060 </td><td align="center"> だ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30C0 </td><td align="center"> ダ </td></tr>
        /// <tr><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30C1 </td><td align="center"> チ </td></tr>
        /// <tr><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30C2 </td><td align="center"> ヂ </td></tr>
        /// <tr><td align="center"> U+3062 </td><td align="center"> ぢ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30C2 </td><td align="center"> ヂ </td></tr>
        /// <tr><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30C3 </td><td align="center"> ッ </td></tr>
        /// <tr><td align="center"> U+3064 </td><td align="center"> つ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30C4 </td><td align="center"> ツ </td></tr>
        /// <tr><td align="center"> U+3064 </td><td align="center"> つ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30C5 </td><td align="center"> ヅ </td></tr>
        /// <tr><td align="center"> U+3065 </td><td align="center"> づ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30C5 </td><td align="center"> ヅ </td></tr>
        /// <tr><td align="center"> U+3066 </td><td align="center"> て </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30C6 </td><td align="center"> テ </td></tr>
        /// <tr><td align="center"> U+3066 </td><td align="center"> て </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30C7 </td><td align="center"> デ </td></tr>
        /// <tr><td align="center"> U+3067 </td><td align="center"> で </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30C7 </td><td align="center"> デ </td></tr>
        /// <tr><td align="center"> U+3068 </td><td align="center"> と </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30C8 </td><td align="center"> ト </td></tr>
        /// <tr><td align="center"> U+3068 </td><td align="center"> と </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30C9 </td><td align="center"> ド </td></tr>
        /// <tr><td align="center"> U+3069 </td><td align="center"> ど </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30C9 </td><td align="center"> ド </td></tr>
        /// <tr><td align="center"> U+306A </td><td align="center"> な </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30CA </td><td align="center"> ナ </td></tr>
        /// <tr><td align="center"> U+306B </td><td align="center"> に </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30CB </td><td align="center"> ニ </td></tr>
        /// <tr><td align="center"> U+306C </td><td align="center"> ぬ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30CC </td><td align="center"> ヌ </td></tr>
        /// <tr><td align="center"> U+306D </td><td align="center"> ね </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30CD </td><td align="center"> ネ </td></tr>
        /// <tr><td align="center"> U+306E </td><td align="center"> の </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30CE </td><td align="center"> ノ </td></tr>
        /// <tr><td align="center"> U+306F </td><td align="center"> は </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30CF </td><td align="center"> ハ </td></tr>
        /// <tr><td align="center"> U+306F </td><td align="center"> は </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30D0 </td><td align="center"> バ </td></tr>
        /// <tr><td align="center"> U+3070 </td><td align="center"> ば </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30D0 </td><td align="center"> バ </td></tr>
        /// <tr><td align="center"> U+306F </td><td align="center"> は </td><td align="center"> U+309A </td><td align="center"> *2 </td><td align="center"> U+30D1 </td><td align="center"> パ </td></tr>
        /// <tr><td align="center"> U+3071 </td><td align="center"> ぱ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30D1 </td><td align="center"> パ </td></tr>
        /// <tr><td align="center"> U+3072 </td><td align="center"> ひ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30D2 </td><td align="center"> ヒ </td></tr>
        /// <tr><td align="center"> U+3072 </td><td align="center"> ひ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30D3 </td><td align="center"> ビ </td></tr>
        /// <tr><td align="center"> U+3073 </td><td align="center"> び </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30D3 </td><td align="center"> ビ </td></tr>
        /// <tr><td align="center"> U+3072 </td><td align="center"> ひ </td><td align="center"> U+309A </td><td align="center"> *2 </td><td align="center"> U+30D4 </td><td align="center"> ピ </td></tr>
        /// <tr><td align="center"> U+3074 </td><td align="center"> ぴ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30D4 </td><td align="center"> ピ </td></tr>
        /// <tr><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30D5 </td><td align="center"> フ </td></tr>
        /// <tr><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30D6 </td><td align="center"> ブ </td></tr>
        /// <tr><td align="center"> U+3076 </td><td align="center"> ぶ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30D6 </td><td align="center"> ブ </td></tr>
        /// <tr><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> U+309A </td><td align="center"> *2 </td><td align="center"> U+30D7 </td><td align="center"> プ </td></tr>
        /// <tr><td align="center"> U+3077 </td><td align="center"> ぷ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30D7 </td><td align="center"> プ </td></tr>
        /// <tr><td align="center"> U+3078 </td><td align="center"> へ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30D8 </td><td align="center"> ヘ </td></tr>
        /// <tr><td align="center"> U+3078 </td><td align="center"> へ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30D9 </td><td align="center"> ベ </td></tr>
        /// <tr><td align="center"> U+3079 </td><td align="center"> べ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30D9 </td><td align="center"> ベ </td></tr>
        /// <tr><td align="center"> U+3078 </td><td align="center"> へ </td><td align="center"> U+309A </td><td align="center"> *2 </td><td align="center"> U+30DA </td><td align="center"> ペ </td></tr>
        /// <tr><td align="center"> U+307A </td><td align="center"> ぺ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30DA </td><td align="center"> ペ </td></tr>
        /// <tr><td align="center"> U+307B </td><td align="center"> ほ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30DB </td><td align="center"> ホ </td></tr>
        /// <tr><td align="center"> U+307B </td><td align="center"> ほ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30DC </td><td align="center"> ボ </td></tr>
        /// <tr><td align="center"> U+307C </td><td align="center"> ぼ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30DC </td><td align="center"> ボ </td></tr>
        /// <tr><td align="center"> U+307B </td><td align="center"> ほ </td><td align="center"> U+309A </td><td align="center"> *2 </td><td align="center"> U+30DD </td><td align="center"> ポ </td></tr>
        /// <tr><td align="center"> U+307D </td><td align="center"> ぽ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30DD </td><td align="center"> ポ </td></tr>
        /// <tr><td align="center"> U+307E </td><td align="center"> ま </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30DE </td><td align="center"> マ </td></tr>
        /// <tr><td align="center"> U+307F </td><td align="center"> み </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30DF </td><td align="center"> ミ </td></tr>
        /// <tr><td align="center"> U+3080 </td><td align="center"> む </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30E0 </td><td align="center"> ム </td></tr>
        /// <tr><td align="center"> U+3081 </td><td align="center"> め </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30E1 </td><td align="center"> メ </td></tr>
        /// <tr><td align="center"> U+3082 </td><td align="center"> も </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30E2 </td><td align="center"> モ </td></tr>
        /// <tr><td align="center"> U+3083 </td><td align="center"> ゃ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30E3 </td><td align="center"> ャ </td></tr>
        /// <tr><td align="center"> U+3084 </td><td align="center"> や </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30E4 </td><td align="center"> ヤ </td></tr>
        /// <tr><td align="center"> U+3085 </td><td align="center"> ゅ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30E5 </td><td align="center"> ュ </td></tr>
        /// <tr><td align="center"> U+3086 </td><td align="center"> ゆ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30E6 </td><td align="center"> ユ </td></tr>
        /// <tr><td align="center"> U+3087 </td><td align="center"> ょ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30E7 </td><td align="center"> ョ </td></tr>
        /// <tr><td align="center"> U+3088 </td><td align="center"> よ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30E8 </td><td align="center"> ヨ </td></tr>
        /// <tr><td align="center"> U+3089 </td><td align="center"> ら </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30E9 </td><td align="center"> ラ </td></tr>
        /// <tr><td align="center"> U+308A </td><td align="center"> り </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30EA </td><td align="center"> リ </td></tr>
        /// <tr><td align="center"> U+308B </td><td align="center"> る </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30EB </td><td align="center"> ル </td></tr>
        /// <tr><td align="center"> U+308C </td><td align="center"> れ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30EC </td><td align="center"> レ </td></tr>
        /// <tr><td align="center"> U+308D </td><td align="center"> ろ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30ED </td><td align="center"> ロ </td></tr>
        /// <tr><td align="center"> U+308E </td><td align="center"> ゎ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30EE </td><td align="center"> ヮ </td></tr>
        /// <tr><td align="center"> U+308F </td><td align="center"> わ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30EF </td><td align="center"> ワ </td></tr>
        /// <tr><td align="center"> U+3090 </td><td align="center"> ゐ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30F0 </td><td align="center"> ヰ </td></tr>
        /// <tr><td align="center"> U+3091 </td><td align="center"> ゑ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30F1 </td><td align="center"> ヱ </td></tr>
        /// <tr><td align="center"> U+3092 </td><td align="center"> を </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30F2 </td><td align="center"> ヲ </td></tr>
        /// <tr><td align="center"> U+3093 </td><td align="center"> ん </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30F3 </td><td align="center"> ン </td></tr>
        /// <tr><td align="center"> U+3046 </td><td align="center"> う </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30F4 </td><td align="center"> ヴ </td></tr>
        /// <tr><td align="center"> U+3094 </td><td align="center"> ゔ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30F4 </td><td align="center"> ヴ </td></tr>
        /// <tr><td align="center"> U+3095 </td><td align="center"> ゕ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30F5 </td><td align="center"> ヵ </td></tr>
        /// <tr><td align="center"> U+3096 </td><td align="center"> ゖ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30F6 </td><td align="center"> ヶ </td></tr>
        /// <tr><td align="center"> U+308F </td><td align="center"> わ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30F7 </td><td align="center"> ヷ </td></tr>
        /// <tr><td align="center"> U+3090 </td><td align="center"> ゐ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30F8 </td><td align="center"> ヸ </td></tr>
        /// <tr><td align="center"> U+3091 </td><td align="center"> ゑ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30F9 </td><td align="center"> ヹ </td></tr>
        /// <tr><td align="center"> U+3092 </td><td align="center"> を </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30FA </td><td align="center"> ヺ </td></tr>
        /// <tr><td align="center"> U+309D </td><td align="center"> ゝ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30FD </td><td align="center"> ヽ </td></tr>
        /// <tr><td align="center"> U+309D </td><td align="center"> ゝ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30FE </td><td align="center"> ヾ </td></tr>
        /// <tr><td align="center"> U+309E </td><td align="center"> ゞ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30FE </td><td align="center"> ヾ </td></tr>
        /// </table>
        ///  *1 COMBINING KATAKANA-HIRAGANA VOICED SOUND MARK <br />
        ///  *2 COMBINING KATAKANA-HIRAGANA SEMI-VOICED SOUND MARK
        /// </remarks>
        public static string HiraganaToKatakana(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            return Convert(input, "HiraganaToKatakana.xml");
        }

        /// <summary>Converts characters from katakana to hiragana.</summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>Converted string.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// input is a null reference.
        /// </exception>
        /// <remarks>
        /// See <see cref="T:Microsoft.International.Converters.KanaConverter" /> for an example of using KanaConverter.<br />
        /// Click <a href="..\Code\KatakanaToHiragana.xml">here</a> to get the full configuration file for this conversion.<br /><br />
        /// The following table contains all conversions for this method.<br />
        /// <table align="center" border="1" cellspacing="0" cellpadding="0" bordercolor="black" width="80%">
        /// <tr><td colspan="4" align="center"> Katakana       </td><td colspan="2" align="center"> Hiragana    </td></tr>
        /// <tr><td align="center"> Codepoint </td><td align="center"> Character </td><td align="center"> Codepoint </td><td align="center"> Character </td><td align="center"> Codepoint </td><td align="center"> Character  </td></tr>
        /// <tr><td align="center"> U+30A1 </td><td align="center"> ァ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3041 </td><td align="center"> ぁ  </td></tr>
        /// <tr><td align="center"> U+30A2 </td><td align="center"> ア </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3042 </td><td align="center"> あ  </td></tr>
        /// <tr><td align="center"> U+30A3 </td><td align="center"> ィ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3043 </td><td align="center"> ぃ  </td></tr>
        /// <tr><td align="center"> U+30A4 </td><td align="center"> イ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3044 </td><td align="center"> い  </td></tr>
        /// <tr><td align="center"> U+30A5 </td><td align="center"> ゥ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3045 </td><td align="center"> ぅ  </td></tr>
        /// <tr><td align="center"> U+30A6 </td><td align="center"> ウ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3046 </td><td align="center"> う  </td></tr>
        /// <tr><td align="center"> U+30A7 </td><td align="center"> ェ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3047 </td><td align="center"> ぇ  </td></tr>
        /// <tr><td align="center"> U+30A8 </td><td align="center"> エ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3048 </td><td align="center"> え  </td></tr>
        /// <tr><td align="center"> U+30A9 </td><td align="center"> ォ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3049 </td><td align="center"> ぉ  </td></tr>
        /// <tr><td align="center"> U+30AA </td><td align="center"> オ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+304A </td><td align="center"> お  </td></tr>
        /// <tr><td align="center"> U+30AB </td><td align="center"> カ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+304B </td><td align="center"> か  </td></tr>
        /// <tr><td align="center"> U+30AB </td><td align="center"> カ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+304C </td><td align="center"> が  </td></tr>
        /// <tr><td align="center"> U+30AC </td><td align="center"> ガ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+304C </td><td align="center"> が  </td></tr>
        /// <tr><td align="center"> U+30AD </td><td align="center"> キ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+304D </td><td align="center"> き  </td></tr>
        /// <tr><td align="center"> U+30AD </td><td align="center"> キ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+304E </td><td align="center"> ぎ  </td></tr>
        /// <tr><td align="center"> U+30AE </td><td align="center"> ギ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+304E </td><td align="center"> ぎ  </td></tr>
        /// <tr><td align="center"> U+30AF </td><td align="center"> ク </td><td align="center"> </td><td align="center"> </td><td align="center"> U+304F </td><td align="center"> く  </td></tr>
        /// <tr><td align="center"> U+30AF </td><td align="center"> ク </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+3050 </td><td align="center"> ぐ  </td></tr>
        /// <tr><td align="center"> U+30B0 </td><td align="center"> グ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3050 </td><td align="center"> ぐ  </td></tr>
        /// <tr><td align="center"> U+30B1 </td><td align="center"> ケ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3051 </td><td align="center"> け  </td></tr>
        /// <tr><td align="center"> U+30B1 </td><td align="center"> ケ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+3052 </td><td align="center"> げ  </td></tr>
        /// <tr><td align="center"> U+30B2 </td><td align="center"> ゲ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3052 </td><td align="center"> げ  </td></tr>
        /// <tr><td align="center"> U+30B3 </td><td align="center"> コ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3053 </td><td align="center"> こ  </td></tr>
        /// <tr><td align="center"> U+30B3 </td><td align="center"> コ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+3054 </td><td align="center"> ご  </td></tr>
        /// <tr><td align="center"> U+30B4 </td><td align="center"> ゴ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3054 </td><td align="center"> ご  </td></tr>
        /// <tr><td align="center"> U+30B5 </td><td align="center"> サ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3055 </td><td align="center"> さ  </td></tr>
        /// <tr><td align="center"> U+30B5 </td><td align="center"> サ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+3056 </td><td align="center"> ざ  </td></tr>
        /// <tr><td align="center"> U+30B6 </td><td align="center"> ザ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3056 </td><td align="center"> ざ  </td></tr>
        /// <tr><td align="center"> U+30B7 </td><td align="center"> シ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3057 </td><td align="center"> し  </td></tr>
        /// <tr><td align="center"> U+30B7 </td><td align="center"> シ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+3058 </td><td align="center"> じ  </td></tr>
        /// <tr><td align="center"> U+30B8 </td><td align="center"> ジ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3058 </td><td align="center"> じ  </td></tr>
        /// <tr><td align="center"> U+30B9 </td><td align="center"> ス </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3059 </td><td align="center"> す  </td></tr>
        /// <tr><td align="center"> U+30B9 </td><td align="center"> ス </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+305A </td><td align="center"> ず  </td></tr>
        /// <tr><td align="center"> U+30BA </td><td align="center"> ズ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+305A </td><td align="center"> ず  </td></tr>
        /// <tr><td align="center"> U+30BB </td><td align="center"> セ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+305B </td><td align="center"> せ  </td></tr>
        /// <tr><td align="center"> U+30BB </td><td align="center"> セ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+305C </td><td align="center"> ぜ  </td></tr>
        /// <tr><td align="center"> U+30BC </td><td align="center"> ゼ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+305C </td><td align="center"> ぜ  </td></tr>
        /// <tr><td align="center"> U+30BD </td><td align="center"> ソ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+305D </td><td align="center"> そ  </td></tr>
        /// <tr><td align="center"> U+30BD </td><td align="center"> ソ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+305E </td><td align="center"> ぞ  </td></tr>
        /// <tr><td align="center"> U+30BE </td><td align="center"> ゾ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+305E </td><td align="center"> ぞ  </td></tr>
        /// <tr><td align="center"> U+30BF </td><td align="center"> タ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+305F </td><td align="center"> た  </td></tr>
        /// <tr><td align="center"> U+30BF </td><td align="center"> タ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+3060 </td><td align="center"> だ  </td></tr>
        /// <tr><td align="center"> U+30C0 </td><td align="center"> ダ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3060 </td><td align="center"> だ  </td></tr>
        /// <tr><td align="center"> U+30C1 </td><td align="center"> チ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3061 </td><td align="center"> ち  </td></tr>
        /// <tr><td align="center"> U+30C1 </td><td align="center"> チ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+3062 </td><td align="center"> ぢ  </td></tr>
        /// <tr><td align="center"> U+30C2 </td><td align="center"> ヂ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3062 </td><td align="center"> ぢ  </td></tr>
        /// <tr><td align="center"> U+30C3 </td><td align="center"> ッ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3063 </td><td align="center"> っ  </td></tr>
        /// <tr><td align="center"> U+30C4 </td><td align="center"> ツ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3064 </td><td align="center"> つ  </td></tr>
        /// <tr><td align="center"> U+30C4 </td><td align="center"> ツ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+3065 </td><td align="center"> づ  </td></tr>
        /// <tr><td align="center"> U+30C5 </td><td align="center"> ヅ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3065 </td><td align="center"> づ  </td></tr>
        /// <tr><td align="center"> U+30C6 </td><td align="center"> テ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3066 </td><td align="center"> て  </td></tr>
        /// <tr><td align="center"> U+30C6 </td><td align="center"> テ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+3067 </td><td align="center"> で  </td></tr>
        /// <tr><td align="center"> U+30C7 </td><td align="center"> デ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3067 </td><td align="center"> で  </td></tr>
        /// <tr><td align="center"> U+30C8 </td><td align="center"> ト </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3068 </td><td align="center"> と  </td></tr>
        /// <tr><td align="center"> U+30C8 </td><td align="center"> ト </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+3069 </td><td align="center"> ど  </td></tr>
        /// <tr><td align="center"> U+30C9 </td><td align="center"> ド </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3069 </td><td align="center"> ど  </td></tr>
        /// <tr><td align="center"> U+30CA </td><td align="center"> ナ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+306A </td><td align="center"> な  </td></tr>
        /// <tr><td align="center"> U+30CB </td><td align="center"> ニ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+306B </td><td align="center"> に  </td></tr>
        /// <tr><td align="center"> U+30CC </td><td align="center"> ヌ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+306C </td><td align="center"> ぬ  </td></tr>
        /// <tr><td align="center"> U+30CD </td><td align="center"> ネ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+306D </td><td align="center"> ね  </td></tr>
        /// <tr><td align="center"> U+30CE </td><td align="center"> ノ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+306E </td><td align="center"> の  </td></tr>
        /// <tr><td align="center"> U+30CF </td><td align="center"> ハ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+306F </td><td align="center"> は  </td></tr>
        /// <tr><td align="center"> U+30CF </td><td align="center"> ハ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+3070 </td><td align="center"> ば  </td></tr>
        /// <tr><td align="center"> U+30D0 </td><td align="center"> バ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3070 </td><td align="center"> ば  </td></tr>
        /// <tr><td align="center"> U+30CF </td><td align="center"> ハ </td><td align="center"> U+309A </td><td align="center"> *2 </td><td align="center"> U+3071 </td><td align="center"> ぱ  </td></tr>
        /// <tr><td align="center"> U+30D1 </td><td align="center"> パ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3071 </td><td align="center"> ぱ  </td></tr>
        /// <tr><td align="center"> U+30D2 </td><td align="center"> ヒ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3072 </td><td align="center"> ひ  </td></tr>
        /// <tr><td align="center"> U+30D2 </td><td align="center"> ヒ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+3073 </td><td align="center"> び  </td></tr>
        /// <tr><td align="center"> U+30D3 </td><td align="center"> ビ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3073 </td><td align="center"> び  </td></tr>
        /// <tr><td align="center"> U+30D2 </td><td align="center"> ヒ </td><td align="center"> U+309A </td><td align="center"> *2 </td><td align="center"> U+3074 </td><td align="center"> ぴ  </td></tr>
        /// <tr><td align="center"> U+30D4 </td><td align="center"> ピ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3074 </td><td align="center"> ぴ  </td></tr>
        /// <tr><td align="center"> U+30D5 </td><td align="center"> フ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3075 </td><td align="center"> ふ  </td></tr>
        /// <tr><td align="center"> U+30D5 </td><td align="center"> フ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+3076 </td><td align="center"> ぶ  </td></tr>
        /// <tr><td align="center"> U+30D6 </td><td align="center"> ブ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3076 </td><td align="center"> ぶ  </td></tr>
        /// <tr><td align="center"> U+30D5 </td><td align="center"> フ </td><td align="center"> U+309A </td><td align="center"> *2 </td><td align="center"> U+3077 </td><td align="center"> ぷ  </td></tr>
        /// <tr><td align="center"> U+30D7 </td><td align="center"> プ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3077 </td><td align="center"> ぷ  </td></tr>
        /// <tr><td align="center"> U+30D8 </td><td align="center"> ヘ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3078 </td><td align="center"> へ  </td></tr>
        /// <tr><td align="center"> U+30D8 </td><td align="center"> ヘ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+3079 </td><td align="center"> べ  </td></tr>
        /// <tr><td align="center"> U+30D9 </td><td align="center"> ベ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3079 </td><td align="center"> べ  </td></tr>
        /// <tr><td align="center"> U+30D8 </td><td align="center"> ヘ </td><td align="center"> U+309A </td><td align="center"> *2 </td><td align="center"> U+307A </td><td align="center"> ぺ  </td></tr>
        /// <tr><td align="center"> U+30DA </td><td align="center"> ペ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+307A </td><td align="center"> ぺ  </td></tr>
        /// <tr><td align="center"> U+30DB </td><td align="center"> ホ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+307B </td><td align="center"> ほ  </td></tr>
        /// <tr><td align="center"> U+30DB </td><td align="center"> ホ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+307C </td><td align="center"> ぼ  </td></tr>
        /// <tr><td align="center"> U+30DC </td><td align="center"> ボ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+307C </td><td align="center"> ぼ  </td></tr>
        /// <tr><td align="center"> U+30DB </td><td align="center"> ホ </td><td align="center"> U+309A </td><td align="center"> *2 </td><td align="center"> U+307D </td><td align="center"> ぽ  </td></tr>
        /// <tr><td align="center"> U+30DD </td><td align="center"> ポ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+307D </td><td align="center"> ぽ  </td></tr>
        /// <tr><td align="center"> U+30DE </td><td align="center"> マ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+307E </td><td align="center"> ま  </td></tr>
        /// <tr><td align="center"> U+30DF </td><td align="center"> ミ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+307F </td><td align="center"> み  </td></tr>
        /// <tr><td align="center"> U+30E0 </td><td align="center"> ム </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3080 </td><td align="center"> む  </td></tr>
        /// <tr><td align="center"> U+30E1 </td><td align="center"> メ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3081 </td><td align="center"> め  </td></tr>
        /// <tr><td align="center"> U+30E2 </td><td align="center"> モ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3082 </td><td align="center"> も  </td></tr>
        /// <tr><td align="center"> U+30E3 </td><td align="center"> ャ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3083 </td><td align="center"> ゃ  </td></tr>
        /// <tr><td align="center"> U+30E4 </td><td align="center"> ヤ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3084 </td><td align="center"> や  </td></tr>
        /// <tr><td align="center"> U+30E5 </td><td align="center"> ュ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3085 </td><td align="center"> ゅ  </td></tr>
        /// <tr><td align="center"> U+30E6 </td><td align="center"> ユ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3086 </td><td align="center"> ゆ  </td></tr>
        /// <tr><td align="center"> U+30E7 </td><td align="center"> ョ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3087 </td><td align="center"> ょ  </td></tr>
        /// <tr><td align="center"> U+30E8 </td><td align="center"> ヨ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3088 </td><td align="center"> よ  </td></tr>
        /// <tr><td align="center"> U+30E9 </td><td align="center"> ラ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3089 </td><td align="center"> ら  </td></tr>
        /// <tr><td align="center"> U+30EA </td><td align="center"> リ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+308A </td><td align="center"> り  </td></tr>
        /// <tr><td align="center"> U+30EB </td><td align="center"> ル </td><td align="center"> </td><td align="center"> </td><td align="center"> U+308B </td><td align="center"> る  </td></tr>
        /// <tr><td align="center"> U+30EC </td><td align="center"> レ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+308C </td><td align="center"> れ  </td></tr>
        /// <tr><td align="center"> U+30ED </td><td align="center"> ロ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+308D </td><td align="center"> ろ  </td></tr>
        /// <tr><td align="center"> U+30EE </td><td align="center"> ヮ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+308E </td><td align="center"> ゎ  </td></tr>
        /// <tr><td align="center"> U+30EF </td><td align="center"> ワ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+308F </td><td align="center"> わ  </td></tr>
        /// <tr><td align="center"> U+30F0 </td><td align="center"> ヰ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3090 </td><td align="center"> ゐ  </td></tr>
        /// <tr><td align="center"> U+30F1 </td><td align="center"> ヱ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3091 </td><td align="center"> ゑ  </td></tr>
        /// <tr><td align="center"> U+30F2 </td><td align="center"> ヲ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3092 </td><td align="center"> を  </td></tr>
        /// <tr><td align="center"> U+30F3 </td><td align="center"> ン </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3093 </td><td align="center"> ん  </td></tr>
        /// <tr><td align="center"> U+30A6 </td><td align="center"> ウ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+3094 </td><td align="center"> ゔ  </td></tr>
        /// <tr><td align="center"> U+30F4 </td><td align="center"> ヴ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3094 </td><td align="center"> ゔ  </td></tr>
        /// <tr><td align="center"> U+30F5 </td><td align="center"> ヵ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3095 </td><td align="center"> ゕ  </td></tr>
        /// <tr><td align="center"> U+30F6 </td><td align="center"> ヶ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3096 </td><td align="center"> ゖ  </td></tr>
        /// <tr><td align="center"> U+30FD </td><td align="center"> ヽ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+309D </td><td align="center"> ゝ  </td></tr>
        /// <tr><td align="center"> U+30FD </td><td align="center"> ヽ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+309E </td><td align="center"> ゞ  </td></tr>
        /// <tr><td align="center"> U+30FE </td><td align="center"> ヾ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+309E </td><td align="center"> ゞ  </td></tr>
        /// </table>
        ///  *1 COMBINING KATAKANA-HIRAGANA VOICED SOUND MARK <br />
        ///  *2 COMBINING KATAKANA-HIRAGANA SEMI-VOICED SOUND MARK
        /// </remarks>
        public static string KatakanaToHiragana(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            return KanaConverter.Convert(input, "KatakanaToHiragana.xml");
        }

        /// <summary>
        /// Converts characters from katakana to half-width katakana.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>Converted string.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// input is a null reference.
        /// </exception>
        /// <remarks>
        /// See <see cref="T:Microsoft.International.Converters.KanaConverter" /> for an example of using KanaConverter.<br />
        /// Click <a href="..\Code\KatakanaToHalfwidthKatakana.xml">here</a> to get the full configuration file for this conversion.<br /><br />
        /// The following table contains all conversions for this method.<br />
        /// <table align="center" border="1" cellspacing="0" cellpadding="0" bordercolor="black" width="80%">
        /// <tr><td colspan="4" align="center"> Katakana       </td><td colspan="4" align="center"> Halfwidth Katakana       </td></tr>
        /// <tr><td align="center"> Codepoint </td><td align="center"> Character </td><td align="center"> Codepoint </td><td align="center"> Character </td><td align="center"> Codepoint </td><td align="center"> Character </td><td align="center"> Codepoint </td><td align="center"> Character </td></tr>
        /// <tr><td align="center"> U+30A1 </td><td align="center"> ァ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF67 </td><td align="center"> ｧ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30A2 </td><td align="center"> ア </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF71 </td><td align="center"> ｱ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30A3 </td><td align="center"> ィ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF68 </td><td align="center"> ｨ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30A4 </td><td align="center"> イ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF72 </td><td align="center"> ｲ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30A5 </td><td align="center"> ゥ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF69 </td><td align="center"> ｩ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30A6 </td><td align="center"> ウ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF73 </td><td align="center"> ｳ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30A7 </td><td align="center"> ェ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF6A </td><td align="center"> ｪ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30A8 </td><td align="center"> エ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF74 </td><td align="center"> ｴ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30A9 </td><td align="center"> ォ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF6B </td><td align="center"> ｫ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30AA </td><td align="center"> オ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF75 </td><td align="center"> ｵ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30AB </td><td align="center"> カ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF76 </td><td align="center"> ｶ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30AB </td><td align="center"> カ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF76 </td><td align="center"> ｶ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30AC </td><td align="center"> ガ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF76 </td><td align="center"> ｶ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30AD </td><td align="center"> キ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF77 </td><td align="center"> ｷ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30AD </td><td align="center"> キ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF77 </td><td align="center"> ｷ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30AE </td><td align="center"> ギ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF77 </td><td align="center"> ｷ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30AF </td><td align="center"> ク </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF78 </td><td align="center"> ｸ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30AF </td><td align="center"> ク </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF78 </td><td align="center"> ｸ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30B0 </td><td align="center"> グ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF78 </td><td align="center"> ｸ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30B1 </td><td align="center"> ケ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF79 </td><td align="center"> ｹ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30B1 </td><td align="center"> ケ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF79 </td><td align="center"> ｹ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30B2 </td><td align="center"> ゲ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF79 </td><td align="center"> ｹ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30B3 </td><td align="center"> コ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF7A </td><td align="center"> ｺ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30B3 </td><td align="center"> コ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF7A </td><td align="center"> ｺ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30B4 </td><td align="center"> ゴ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF7A </td><td align="center"> ｺ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30B5 </td><td align="center"> サ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF7B </td><td align="center"> ｻ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30B5 </td><td align="center"> サ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF7B </td><td align="center"> ｻ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30B6 </td><td align="center"> ザ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF7B </td><td align="center"> ｻ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30B7 </td><td align="center"> シ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF7C </td><td align="center"> ｼ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30B7 </td><td align="center"> シ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF7C </td><td align="center"> ｼ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30B8 </td><td align="center"> ジ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF7C </td><td align="center"> ｼ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30B9 </td><td align="center"> ス </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF7D </td><td align="center"> ｽ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30B9 </td><td align="center"> ス </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF7D </td><td align="center"> ｽ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30BA </td><td align="center"> ズ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF7D </td><td align="center"> ｽ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30BB </td><td align="center"> セ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF7E </td><td align="center"> ｾ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30BB </td><td align="center"> セ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF7E </td><td align="center"> ｾ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30BC </td><td align="center"> ゼ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF7E </td><td align="center"> ｾ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30BD </td><td align="center"> ソ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF7F </td><td align="center"> ｿ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30BD </td><td align="center"> ソ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF7F </td><td align="center"> ｿ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30BE </td><td align="center"> ゾ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF7F </td><td align="center"> ｿ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30BF </td><td align="center"> タ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF80 </td><td align="center"> ﾀ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30BF </td><td align="center"> タ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF80 </td><td align="center"> ﾀ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30C0 </td><td align="center"> ダ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF80 </td><td align="center"> ﾀ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30C1 </td><td align="center"> チ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF81 </td><td align="center"> ﾁ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30C1 </td><td align="center"> チ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF81 </td><td align="center"> ﾁ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30C2 </td><td align="center"> ヂ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF81 </td><td align="center"> ﾁ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30C3 </td><td align="center"> ッ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF6F </td><td align="center"> ｯ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30C4 </td><td align="center"> ツ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF82 </td><td align="center"> ﾂ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30C4 </td><td align="center"> ツ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF82 </td><td align="center"> ﾂ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30C5 </td><td align="center"> ヅ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF82 </td><td align="center"> ﾂ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30C6 </td><td align="center"> テ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF83 </td><td align="center"> ﾃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30C6 </td><td align="center"> テ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF83 </td><td align="center"> ﾃ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30C7 </td><td align="center"> デ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF83 </td><td align="center"> ﾃ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30C8 </td><td align="center"> ト </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF84 </td><td align="center"> ﾄ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30C8 </td><td align="center"> ト </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF84 </td><td align="center"> ﾄ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30C9 </td><td align="center"> ド </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF84 </td><td align="center"> ﾄ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30CA </td><td align="center"> ナ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF85 </td><td align="center"> ﾅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30CB </td><td align="center"> ニ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF86 </td><td align="center"> ﾆ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30CC </td><td align="center"> ヌ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF87 </td><td align="center"> ﾇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30CD </td><td align="center"> ネ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF88 </td><td align="center"> ﾈ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30CE </td><td align="center"> ノ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF89 </td><td align="center"> ﾉ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30CF </td><td align="center"> ハ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8A </td><td align="center"> ﾊ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30CF </td><td align="center"> ハ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF8A </td><td align="center"> ﾊ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30D0 </td><td align="center"> バ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8A </td><td align="center"> ﾊ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30CF </td><td align="center"> ハ </td><td align="center"> U+309A </td><td align="center"> *2 </td><td align="center"> U+FF8A </td><td align="center"> ﾊ </td><td align="center"> U+FF9F </td><td align="center"> ﾟ </td></tr>
        /// <tr><td align="center"> U+30D1 </td><td align="center"> パ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8A </td><td align="center"> ﾊ </td><td align="center"> U+FF9F </td><td align="center"> ﾟ </td></tr>
        /// <tr><td align="center"> U+30D2 </td><td align="center"> ヒ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8B </td><td align="center"> ﾋ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30D2 </td><td align="center"> ヒ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF8B </td><td align="center"> ﾋ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30D3 </td><td align="center"> ビ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8B </td><td align="center"> ﾋ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30D2 </td><td align="center"> ヒ </td><td align="center"> U+309A </td><td align="center"> *2 </td><td align="center"> U+FF8B </td><td align="center"> ﾋ </td><td align="center"> U+FF9F </td><td align="center"> ﾟ </td></tr>
        /// <tr><td align="center"> U+30D4 </td><td align="center"> ピ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8B </td><td align="center"> ﾋ </td><td align="center"> U+FF9F </td><td align="center"> ﾟ </td></tr>
        /// <tr><td align="center"> U+30D5 </td><td align="center"> フ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8C </td><td align="center"> ﾌ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30D5 </td><td align="center"> フ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF8C </td><td align="center"> ﾌ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30D6 </td><td align="center"> ブ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8C </td><td align="center"> ﾌ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30D5 </td><td align="center"> フ </td><td align="center"> U+309A </td><td align="center"> *2 </td><td align="center"> U+FF8C </td><td align="center"> ﾌ </td><td align="center"> U+FF9F </td><td align="center"> ﾟ </td></tr>
        /// <tr><td align="center"> U+30D7 </td><td align="center"> プ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8C </td><td align="center"> ﾌ </td><td align="center"> U+FF9F </td><td align="center"> ﾟ </td></tr>
        /// <tr><td align="center"> U+30D8 </td><td align="center"> ヘ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8D </td><td align="center"> ﾍ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30D8 </td><td align="center"> ヘ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF8D </td><td align="center"> ﾍ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30D9 </td><td align="center"> ベ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8D </td><td align="center"> ﾍ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30D8 </td><td align="center"> ヘ </td><td align="center"> U+309A </td><td align="center"> *2 </td><td align="center"> U+FF8D </td><td align="center"> ﾍ </td><td align="center"> U+FF9F </td><td align="center"> ﾟ </td></tr>
        /// <tr><td align="center"> U+30DA </td><td align="center"> ペ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8D </td><td align="center"> ﾍ </td><td align="center"> U+FF9F </td><td align="center"> ﾟ </td></tr>
        /// <tr><td align="center"> U+30DB </td><td align="center"> ホ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8E </td><td align="center"> ﾎ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30DB </td><td align="center"> ホ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF8E </td><td align="center"> ﾎ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30DC </td><td align="center"> ボ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8E </td><td align="center"> ﾎ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30DB </td><td align="center"> ホ </td><td align="center"> U+309A </td><td align="center"> *2 </td><td align="center"> U+FF8E </td><td align="center"> ﾎ </td><td align="center"> U+FF9F </td><td align="center"> ﾟ </td></tr>
        /// <tr><td align="center"> U+30DD </td><td align="center"> ポ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8E </td><td align="center"> ﾎ </td><td align="center"> U+FF9F </td><td align="center"> ﾟ </td></tr>
        /// <tr><td align="center"> U+30DE </td><td align="center"> マ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8F </td><td align="center"> ﾏ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30DF </td><td align="center"> ミ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF90 </td><td align="center"> ﾐ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30E0 </td><td align="center"> ム </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF91 </td><td align="center"> ﾑ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30E1 </td><td align="center"> メ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF92 </td><td align="center"> ﾒ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30E2 </td><td align="center"> モ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF93 </td><td align="center"> ﾓ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30E3 </td><td align="center"> ャ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF6C </td><td align="center"> ｬ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30E4 </td><td align="center"> ヤ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF94 </td><td align="center"> ﾔ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30E5 </td><td align="center"> ュ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF6D </td><td align="center"> ｭ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30E6 </td><td align="center"> ユ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF95 </td><td align="center"> ﾕ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30E7 </td><td align="center"> ョ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF6E </td><td align="center"> ｮ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30E8 </td><td align="center"> ヨ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF96 </td><td align="center"> ﾖ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30E9 </td><td align="center"> ラ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF97 </td><td align="center"> ﾗ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30EA </td><td align="center"> リ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF98 </td><td align="center"> ﾘ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30EB </td><td align="center"> ル </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF99 </td><td align="center"> ﾙ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30EC </td><td align="center"> レ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF9A </td><td align="center"> ﾚ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30ED </td><td align="center"> ロ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF9B </td><td align="center"> ﾛ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30EF </td><td align="center"> ワ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF9C </td><td align="center"> ﾜ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30F7 </td><td align="center"> ヷ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF9C </td><td align="center"> ﾜ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30F2 </td><td align="center"> ヲ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF66 </td><td align="center"> ｦ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30F2 </td><td align="center"> ヲ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF66 </td><td align="center"> ｦ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30FA </td><td align="center"> ヺ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF66 </td><td align="center"> ｦ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30F3 </td><td align="center"> ン </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF9D </td><td align="center"> ﾝ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+30A6 </td><td align="center"> ウ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF73 </td><td align="center"> ｳ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30F4 </td><td align="center"> ヴ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF73 </td><td align="center"> ｳ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// </table>
        ///  *1 COMBINING KATAKANA-HIRAGANA VOICED SOUND MARK <br />
        ///  *2 COMBINING KATAKANA-HIRAGANA SEMI-VOICED SOUND MARK
        /// </remarks>
        public static string KatakanaToHalfwidthKatakana(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            return KanaConverter.Convert(input, "KatakanaToHalfwidthKatakana.xml");
        }

        /// <summary>
        /// Converts characters from hiragana to half-width katakana.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>Converted string.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// input is a null reference.
        /// </exception>
        /// <remarks>
        /// See <see cref="T:Microsoft.International.Converters.KanaConverter" /> for an example of using KanaConverter.<br />
        /// Click <a href="..\Code\HiraganaToHalfwidthKatakana.xml">here</a> to get the full configuration file for this conversion.<br /><br />
        /// The following table contains all conversions for this method.<br />
        /// <table align="center" border="1" cellspacing="0" cellpadding="0" bordercolor="black" width="80%">
        /// <tr><td colspan="4" align="center"> Hiragana       </td><td colspan="4" align="center"> Halfwidth Katakana       </td></tr>
        /// <tr><td align="center"> Codepoint </td><td align="center"> Character </td><td align="center"> Codepoint </td><td align="center"> Character </td><td align="center"> Codepoint </td><td align="center"> Character </td><td align="center"> Codepoint </td><td align="center"> Character </td></tr>
        /// <tr><td align="center"> U+3041 </td><td align="center"> ぁ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF67 </td><td align="center"> ｧ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3042 </td><td align="center"> あ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF71 </td><td align="center"> ｱ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF68 </td><td align="center"> ｨ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3044 </td><td align="center"> い </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF72 </td><td align="center"> ｲ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3045 </td><td align="center"> ぅ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF69 </td><td align="center"> ｩ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3046 </td><td align="center"> う </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF73 </td><td align="center"> ｳ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF6A </td><td align="center"> ｪ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3048 </td><td align="center"> え </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF74 </td><td align="center"> ｴ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3049 </td><td align="center"> ぉ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF6B </td><td align="center"> ｫ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+304A </td><td align="center"> お </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF75 </td><td align="center"> ｵ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+304B </td><td align="center"> か </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF76 </td><td align="center"> ｶ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+304B </td><td align="center"> か </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF76 </td><td align="center"> ｶ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+304C </td><td align="center"> が </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF76 </td><td align="center"> ｶ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+304D </td><td align="center"> き </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF77 </td><td align="center"> ｷ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+304D </td><td align="center"> き </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF77 </td><td align="center"> ｷ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+304E </td><td align="center"> ぎ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF77 </td><td align="center"> ｷ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF78 </td><td align="center"> ｸ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF78 </td><td align="center"> ｸ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+3050 </td><td align="center"> ぐ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF78 </td><td align="center"> ｸ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+3051 </td><td align="center"> け </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF79 </td><td align="center"> ｹ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3051 </td><td align="center"> け </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF79 </td><td align="center"> ｹ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+3052 </td><td align="center"> げ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF79 </td><td align="center"> ｹ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+3053 </td><td align="center"> こ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF7A </td><td align="center"> ｺ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3053 </td><td align="center"> こ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF7A </td><td align="center"> ｺ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+3054 </td><td align="center"> ご </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF7A </td><td align="center"> ｺ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+3055 </td><td align="center"> さ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF7B </td><td align="center"> ｻ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3055 </td><td align="center"> さ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF7B </td><td align="center"> ｻ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+3056 </td><td align="center"> ざ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF7B </td><td align="center"> ｻ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+3057 </td><td align="center"> し </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF7C </td><td align="center"> ｼ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3057 </td><td align="center"> し </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF7C </td><td align="center"> ｼ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF7C </td><td align="center"> ｼ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+3059 </td><td align="center"> す </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF7D </td><td align="center"> ｽ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3059 </td><td align="center"> す </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF7D </td><td align="center"> ｽ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+305A </td><td align="center"> ず </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF7D </td><td align="center"> ｽ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+305B </td><td align="center"> せ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF7E </td><td align="center"> ｾ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+305B </td><td align="center"> せ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF7E </td><td align="center"> ｾ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+305C </td><td align="center"> ぜ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF7E </td><td align="center"> ｾ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+305D </td><td align="center"> そ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF7F </td><td align="center"> ｿ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+305D </td><td align="center"> そ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF7F </td><td align="center"> ｿ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+305E </td><td align="center"> ぞ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF7F </td><td align="center"> ｿ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+305F </td><td align="center"> た </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF80 </td><td align="center"> ﾀ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+305F </td><td align="center"> た </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF80 </td><td align="center"> ﾀ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+3060 </td><td align="center"> だ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF80 </td><td align="center"> ﾀ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF81 </td><td align="center"> ﾁ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF81 </td><td align="center"> ﾁ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+3062 </td><td align="center"> ぢ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF81 </td><td align="center"> ﾁ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF6F </td><td align="center"> ｯ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3064 </td><td align="center"> つ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF82 </td><td align="center"> ﾂ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3064 </td><td align="center"> つ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF82 </td><td align="center"> ﾂ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+3065 </td><td align="center"> づ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF82 </td><td align="center"> ﾂ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+3066 </td><td align="center"> て </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF83 </td><td align="center"> ﾃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3066 </td><td align="center"> て </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF83 </td><td align="center"> ﾃ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+3067 </td><td align="center"> で </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF83 </td><td align="center"> ﾃ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+3068 </td><td align="center"> と </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF84 </td><td align="center"> ﾄ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3068 </td><td align="center"> と </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF84 </td><td align="center"> ﾄ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+3069 </td><td align="center"> ど </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF84 </td><td align="center"> ﾄ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+306A </td><td align="center"> な </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF85 </td><td align="center"> ﾅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+306B </td><td align="center"> に </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF86 </td><td align="center"> ﾆ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+306C </td><td align="center"> ぬ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF87 </td><td align="center"> ﾇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+306D </td><td align="center"> ね </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF88 </td><td align="center"> ﾈ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+306E </td><td align="center"> の </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF89 </td><td align="center"> ﾉ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+306F </td><td align="center"> は </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8A </td><td align="center"> ﾊ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+306F </td><td align="center"> は </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF8A </td><td align="center"> ﾊ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+3070 </td><td align="center"> ば </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8A </td><td align="center"> ﾊ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+306F </td><td align="center"> は </td><td align="center"> U+309A </td><td align="center"> *2 </td><td align="center"> U+FF8A </td><td align="center"> ﾊ </td><td align="center"> U+FF9F </td><td align="center"> ﾟ </td></tr>
        /// <tr><td align="center"> U+3071 </td><td align="center"> ぱ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8A </td><td align="center"> ﾊ </td><td align="center"> U+FF9F </td><td align="center"> ﾟ </td></tr>
        /// <tr><td align="center"> U+3072 </td><td align="center"> ひ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8B </td><td align="center"> ﾋ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3072 </td><td align="center"> ひ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF8B </td><td align="center"> ﾋ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+3073 </td><td align="center"> び </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8B </td><td align="center"> ﾋ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+3072 </td><td align="center"> ひ </td><td align="center"> U+309A </td><td align="center"> *2 </td><td align="center"> U+FF8B </td><td align="center"> ﾋ </td><td align="center"> U+FF9F </td><td align="center"> ﾟ </td></tr>
        /// <tr><td align="center"> U+3074 </td><td align="center"> ぴ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8B </td><td align="center"> ﾋ </td><td align="center"> U+FF9F </td><td align="center"> ﾟ </td></tr>
        /// <tr><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8C </td><td align="center"> ﾌ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF8C </td><td align="center"> ﾌ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+3076 </td><td align="center"> ぶ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8C </td><td align="center"> ﾌ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> U+309A </td><td align="center"> *2 </td><td align="center"> U+FF8C </td><td align="center"> ﾌ </td><td align="center"> U+FF9F </td><td align="center"> ﾟ </td></tr>
        /// <tr><td align="center"> U+3077 </td><td align="center"> ぷ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8C </td><td align="center"> ﾌ </td><td align="center"> U+FF9F </td><td align="center"> ﾟ </td></tr>
        /// <tr><td align="center"> U+3078 </td><td align="center"> へ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8D </td><td align="center"> ﾍ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3078 </td><td align="center"> へ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF8D </td><td align="center"> ﾍ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+3079 </td><td align="center"> べ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8D </td><td align="center"> ﾍ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+3078 </td><td align="center"> へ </td><td align="center"> U+309A </td><td align="center"> *2 </td><td align="center"> U+FF8D </td><td align="center"> ﾍ </td><td align="center"> U+FF9F </td><td align="center"> ﾟ </td></tr>
        /// <tr><td align="center"> U+307A </td><td align="center"> ぺ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8D </td><td align="center"> ﾍ </td><td align="center"> U+FF9F </td><td align="center"> ﾟ </td></tr>
        /// <tr><td align="center"> U+307B </td><td align="center"> ほ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8E </td><td align="center"> ﾎ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+307B </td><td align="center"> ほ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF8E </td><td align="center"> ﾎ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+307C </td><td align="center"> ぼ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8E </td><td align="center"> ﾎ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+307B </td><td align="center"> ほ </td><td align="center"> U+309A </td><td align="center"> *2 </td><td align="center"> U+FF8E </td><td align="center"> ﾎ </td><td align="center"> U+FF9F </td><td align="center"> ﾟ </td></tr>
        /// <tr><td align="center"> U+307D </td><td align="center"> ぽ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8E </td><td align="center"> ﾎ </td><td align="center"> U+FF9F </td><td align="center"> ﾟ </td></tr>
        /// <tr><td align="center"> U+307E </td><td align="center"> ま </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF8F </td><td align="center"> ﾏ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+307F </td><td align="center"> み </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF90 </td><td align="center"> ﾐ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3080 </td><td align="center"> む </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF91 </td><td align="center"> ﾑ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3081 </td><td align="center"> め </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF92 </td><td align="center"> ﾒ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3082 </td><td align="center"> も </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF93 </td><td align="center"> ﾓ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3083 </td><td align="center"> ゃ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF6C </td><td align="center"> ｬ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3084 </td><td align="center"> や </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF94 </td><td align="center"> ﾔ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3085 </td><td align="center"> ゅ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF6D </td><td align="center"> ｭ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3086 </td><td align="center"> ゆ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF95 </td><td align="center"> ﾕ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3087 </td><td align="center"> ょ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF6E </td><td align="center"> ｮ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3088 </td><td align="center"> よ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF96 </td><td align="center"> ﾖ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3089 </td><td align="center"> ら </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF97 </td><td align="center"> ﾗ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+308A </td><td align="center"> り </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF98 </td><td align="center"> ﾘ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+308B </td><td align="center"> る </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF99 </td><td align="center"> ﾙ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+308C </td><td align="center"> れ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF9A </td><td align="center"> ﾚ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+308D </td><td align="center"> ろ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF9B </td><td align="center"> ﾛ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+308F </td><td align="center"> わ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF9C </td><td align="center"> ﾜ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3092 </td><td align="center"> を </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF66 </td><td align="center"> ｦ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3093 </td><td align="center"> ん </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF9D </td><td align="center"> ﾝ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> U+3046 </td><td align="center"> う </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF73 </td><td align="center"> ｳ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+3094 </td><td align="center"> ゔ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF73 </td><td align="center"> ｳ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+30F4 </td><td align="center"> ヴ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+FF73 </td><td align="center"> ｳ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+308F </td><td align="center"> わ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF73 </td><td align="center"> ｳ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// <tr><td align="center"> U+3092 </td><td align="center"> を </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+FF9C </td><td align="center"> ﾜ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td></tr>
        /// </table>
        ///  *1 COMBINING KATAKANA-HIRAGANA VOICED SOUND MARK <br />
        ///  *2 COMBINING KATAKANA-HIRAGANA SEMI-VOICED SOUND MARK
        /// </remarks>
        public static string HiraganaToHalfwidthKatakana(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            return KanaConverter.Convert(input, "HiraganaToHalfwidthKatakana.xml");
        }

        /// <summary>
        /// Converts characters from half-width katakana to katakana.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>Converted string.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// input is a null reference.
        /// </exception>
        /// <remarks>
        /// See <see cref="T:Microsoft.International.Converters.KanaConverter" /> for an example of using KanaConverter.<br />
        /// Click <a href="..\Code\HalfwidthKatakanaToKatakana.xml">here</a> to get the full configuration file for this conversion.<br /><br />
        /// The following table contains all conversions for this method.<br />
        /// <table align="center" border="1" cellspacing="0" cellpadding="0" bordercolor="black" width="80%">
        /// <tr><td colspan="4" align="center"> Halfwidth Katakana       </td><td colspan="2" align="center"> Katakana   </td></tr>
        /// <tr><td align="center"> Codepoint </td><td align="center"> Character </td><td align="center"> Codepoint </td><td align="center"> Character </td><td align="center"> Codepoint </td><td align="center"> Character </td></tr>
        /// <tr><td align="center"> U+FF67 </td><td align="center"> ｧ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30A1 </td><td align="center"> ァ </td></tr>
        /// <tr><td align="center"> U+FF71 </td><td align="center"> ｱ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30A2 </td><td align="center"> ア </td></tr>
        /// <tr><td align="center"> U+FF68 </td><td align="center"> ｨ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30A3 </td><td align="center"> ィ </td></tr>
        /// <tr><td align="center"> U+FF72 </td><td align="center"> ｲ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30A4 </td><td align="center"> イ </td></tr>
        /// <tr><td align="center"> U+FF69 </td><td align="center"> ｩ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30A5 </td><td align="center"> ゥ </td></tr>
        /// <tr><td align="center"> U+FF73 </td><td align="center"> ｳ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30A6 </td><td align="center"> ウ </td></tr>
        /// <tr><td align="center"> U+FF6A </td><td align="center"> ｪ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30A7 </td><td align="center"> ェ </td></tr>
        /// <tr><td align="center"> U+FF74 </td><td align="center"> ｴ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30A8 </td><td align="center"> エ </td></tr>
        /// <tr><td align="center"> U+FF6B </td><td align="center"> ｫ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30A9 </td><td align="center"> ォ </td></tr>
        /// <tr><td align="center"> U+FF75 </td><td align="center"> ｵ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30AA </td><td align="center"> オ </td></tr>
        /// <tr><td align="center"> U+FF76 </td><td align="center"> ｶ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30AB </td><td align="center"> カ </td></tr>
        /// <tr><td align="center"> U+FF76 </td><td align="center"> ｶ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30AC </td><td align="center"> ガ </td></tr>
        /// <tr><td align="center"> U+FF76 </td><td align="center"> ｶ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+30AC </td><td align="center"> ガ </td></tr>
        /// <tr><td align="center"> U+FF77 </td><td align="center"> ｷ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30AD </td><td align="center"> キ </td></tr>
        /// <tr><td align="center"> U+FF77 </td><td align="center"> ｷ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30AE </td><td align="center"> ギ </td></tr>
        /// <tr><td align="center"> U+FF77 </td><td align="center"> ｷ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+30AE </td><td align="center"> ギ </td></tr>
        /// <tr><td align="center"> U+FF78 </td><td align="center"> ｸ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30AF </td><td align="center"> ク </td></tr>
        /// <tr><td align="center"> U+FF78 </td><td align="center"> ｸ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30B0 </td><td align="center"> グ </td></tr>
        /// <tr><td align="center"> U+FF78 </td><td align="center"> ｸ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+30B0 </td><td align="center"> グ </td></tr>
        /// <tr><td align="center"> U+FF79 </td><td align="center"> ｹ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30B1 </td><td align="center"> ケ </td></tr>
        /// <tr><td align="center"> U+FF79 </td><td align="center"> ｹ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30B2 </td><td align="center"> ゲ </td></tr>
        /// <tr><td align="center"> U+FF79 </td><td align="center"> ｹ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+30B2 </td><td align="center"> ゲ </td></tr>
        /// <tr><td align="center"> U+FF7A </td><td align="center"> ｺ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30B3 </td><td align="center"> コ </td></tr>
        /// <tr><td align="center"> U+FF7A </td><td align="center"> ｺ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30B4 </td><td align="center"> ゴ </td></tr>
        /// <tr><td align="center"> U+FF7A </td><td align="center"> ｺ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+30B4 </td><td align="center"> ゴ </td></tr>
        /// <tr><td align="center"> U+FF7B </td><td align="center"> ｻ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30B5 </td><td align="center"> サ </td></tr>
        /// <tr><td align="center"> U+FF7B </td><td align="center"> ｻ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30B6 </td><td align="center"> ザ </td></tr>
        /// <tr><td align="center"> U+FF7B </td><td align="center"> ｻ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+30B6 </td><td align="center"> ザ </td></tr>
        /// <tr><td align="center"> U+FF7C </td><td align="center"> ｼ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30B7 </td><td align="center"> シ </td></tr>
        /// <tr><td align="center"> U+FF7C </td><td align="center"> ｼ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30B8 </td><td align="center"> ジ </td></tr>
        /// <tr><td align="center"> U+FF7C </td><td align="center"> ｼ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+30B8 </td><td align="center"> ジ </td></tr>
        /// <tr><td align="center"> U+FF7D </td><td align="center"> ｽ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30B9 </td><td align="center"> ス </td></tr>
        /// <tr><td align="center"> U+FF7D </td><td align="center"> ｽ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30BA </td><td align="center"> ズ </td></tr>
        /// <tr><td align="center"> U+FF7D </td><td align="center"> ｽ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+30BA </td><td align="center"> ズ </td></tr>
        /// <tr><td align="center"> U+FF7E </td><td align="center"> ｾ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30BB </td><td align="center"> セ </td></tr>
        /// <tr><td align="center"> U+FF7E </td><td align="center"> ｾ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30BC </td><td align="center"> ゼ </td></tr>
        /// <tr><td align="center"> U+FF7E </td><td align="center"> ｾ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+30BC </td><td align="center"> ゼ </td></tr>
        /// <tr><td align="center"> U+FF7F </td><td align="center"> ｿ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30BD </td><td align="center"> ソ </td></tr>
        /// <tr><td align="center"> U+FF7F </td><td align="center"> ｿ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30BE </td><td align="center"> ゾ </td></tr>
        /// <tr><td align="center"> U+FF7F </td><td align="center"> ｿ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+30BE </td><td align="center"> ゾ </td></tr>
        /// <tr><td align="center"> U+FF80 </td><td align="center"> ﾀ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30BF </td><td align="center"> タ </td></tr>
        /// <tr><td align="center"> U+FF80 </td><td align="center"> ﾀ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30C0 </td><td align="center"> ダ </td></tr>
        /// <tr><td align="center"> U+FF80 </td><td align="center"> ﾀ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+30C0 </td><td align="center"> ダ </td></tr>
        /// <tr><td align="center"> U+FF81 </td><td align="center"> ﾁ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30C1 </td><td align="center"> チ </td></tr>
        /// <tr><td align="center"> U+FF81 </td><td align="center"> ﾁ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30C2 </td><td align="center"> ヂ </td></tr>
        /// <tr><td align="center"> U+FF81 </td><td align="center"> ﾁ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+30C2 </td><td align="center"> ヂ </td></tr>
        /// <tr><td align="center"> U+FF6F </td><td align="center"> ｯ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30C3 </td><td align="center"> ッ </td></tr>
        /// <tr><td align="center"> U+FF82 </td><td align="center"> ﾂ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30C4 </td><td align="center"> ツ </td></tr>
        /// <tr><td align="center"> U+FF82 </td><td align="center"> ﾂ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30C5 </td><td align="center"> ヅ </td></tr>
        /// <tr><td align="center"> U+FF82 </td><td align="center"> ﾂ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+30C5 </td><td align="center"> ヅ </td></tr>
        /// <tr><td align="center"> U+FF83 </td><td align="center"> ﾃ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30C6 </td><td align="center"> テ </td></tr>
        /// <tr><td align="center"> U+FF83 </td><td align="center"> ﾃ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30C7 </td><td align="center"> デ </td></tr>
        /// <tr><td align="center"> U+FF83 </td><td align="center"> ﾃ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+30C7 </td><td align="center"> デ </td></tr>
        /// <tr><td align="center"> U+FF84 </td><td align="center"> ﾄ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30C8 </td><td align="center"> ト </td></tr>
        /// <tr><td align="center"> U+FF84 </td><td align="center"> ﾄ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30C9 </td><td align="center"> ド </td></tr>
        /// <tr><td align="center"> U+FF84 </td><td align="center"> ﾄ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+30C9 </td><td align="center"> ド </td></tr>
        /// <tr><td align="center"> U+FF85 </td><td align="center"> ﾅ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30CA </td><td align="center"> ナ </td></tr>
        /// <tr><td align="center"> U+FF86 </td><td align="center"> ﾆ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30CB </td><td align="center"> ニ </td></tr>
        /// <tr><td align="center"> U+FF87 </td><td align="center"> ﾇ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30CC </td><td align="center"> ヌ </td></tr>
        /// <tr><td align="center"> U+FF88 </td><td align="center"> ﾈ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30CD </td><td align="center"> ネ </td></tr>
        /// <tr><td align="center"> U+FF89 </td><td align="center"> ﾉ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30CE </td><td align="center"> ノ </td></tr>
        /// <tr><td align="center"> U+FF8A </td><td align="center"> ﾊ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30CF </td><td align="center"> ハ </td></tr>
        /// <tr><td align="center"> U+FF8A </td><td align="center"> ﾊ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30D0 </td><td align="center"> バ </td></tr>
        /// <tr><td align="center"> U+FF8A </td><td align="center"> ﾊ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+30D0 </td><td align="center"> バ </td></tr>
        /// <tr><td align="center"> U+FF8A </td><td align="center"> ﾊ </td><td align="center"> U+309A </td><td align="center"> *2 </td><td align="center"> U+30D1 </td><td align="center"> パ </td></tr>
        /// <tr><td align="center"> U+FF8A </td><td align="center"> ﾊ </td><td align="center"> U+FF9F </td><td align="center"> ﾟ </td><td align="center"> U+30D1 </td><td align="center"> パ </td></tr>
        /// <tr><td align="center"> U+FF8B </td><td align="center"> ﾋ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30D2 </td><td align="center"> ヒ </td></tr>
        /// <tr><td align="center"> U+FF8B </td><td align="center"> ﾋ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30D3 </td><td align="center"> ビ </td></tr>
        /// <tr><td align="center"> U+FF8B </td><td align="center"> ﾋ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+30D3 </td><td align="center"> ビ </td></tr>
        /// <tr><td align="center"> U+FF8B </td><td align="center"> ﾋ </td><td align="center"> U+309A </td><td align="center"> *2 </td><td align="center"> U+30D4 </td><td align="center"> ピ </td></tr>
        /// <tr><td align="center"> U+FF8B </td><td align="center"> ﾋ </td><td align="center"> U+FF9F </td><td align="center"> ﾟ </td><td align="center"> U+30D4 </td><td align="center"> ピ </td></tr>
        /// <tr><td align="center"> U+FF8C </td><td align="center"> ﾌ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30D5 </td><td align="center"> フ </td></tr>
        /// <tr><td align="center"> U+FF8C </td><td align="center"> ﾌ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30D6 </td><td align="center"> ブ </td></tr>
        /// <tr><td align="center"> U+FF8C </td><td align="center"> ﾌ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+30D6 </td><td align="center"> ブ </td></tr>
        /// <tr><td align="center"> U+FF8C </td><td align="center"> ﾌ </td><td align="center"> U+309A </td><td align="center"> *2 </td><td align="center"> U+30D7 </td><td align="center"> プ </td></tr>
        /// <tr><td align="center"> U+FF8C </td><td align="center"> ﾌ </td><td align="center"> U+FF9F </td><td align="center"> ﾟ </td><td align="center"> U+30D7 </td><td align="center"> プ </td></tr>
        /// <tr><td align="center"> U+FF8D </td><td align="center"> ﾍ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30D8 </td><td align="center"> ヘ </td></tr>
        /// <tr><td align="center"> U+FF8D </td><td align="center"> ﾍ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30D9 </td><td align="center"> ベ </td></tr>
        /// <tr><td align="center"> U+FF8D </td><td align="center"> ﾍ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+30D9 </td><td align="center"> ベ </td></tr>
        /// <tr><td align="center"> U+FF8D </td><td align="center"> ﾍ </td><td align="center"> U+309A </td><td align="center"> *2 </td><td align="center"> U+30DA </td><td align="center"> ペ </td></tr>
        /// <tr><td align="center"> U+FF8D </td><td align="center"> ﾍ </td><td align="center"> U+FF9F </td><td align="center"> ﾟ </td><td align="center"> U+30DA </td><td align="center"> ペ </td></tr>
        /// <tr><td align="center"> U+FF8E </td><td align="center"> ﾎ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30DB </td><td align="center"> ホ </td></tr>
        /// <tr><td align="center"> U+FF8E </td><td align="center"> ﾎ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30DC </td><td align="center"> ボ </td></tr>
        /// <tr><td align="center"> U+FF8E </td><td align="center"> ﾎ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+30DC </td><td align="center"> ボ </td></tr>
        /// <tr><td align="center"> U+FF8E </td><td align="center"> ﾎ </td><td align="center"> U+309A </td><td align="center"> *2 </td><td align="center"> U+30DD </td><td align="center"> ポ </td></tr>
        /// <tr><td align="center"> U+FF8E </td><td align="center"> ﾎ </td><td align="center"> U+FF9F </td><td align="center"> ﾟ </td><td align="center"> U+30DD </td><td align="center"> ポ </td></tr>
        /// <tr><td align="center"> U+FF8F </td><td align="center"> ﾏ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30DE </td><td align="center"> マ </td></tr>
        /// <tr><td align="center"> U+FF90 </td><td align="center"> ﾐ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30DF </td><td align="center"> ミ </td></tr>
        /// <tr><td align="center"> U+FF91 </td><td align="center"> ﾑ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30E0 </td><td align="center"> ム </td></tr>
        /// <tr><td align="center"> U+FF92 </td><td align="center"> ﾒ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30E1 </td><td align="center"> メ </td></tr>
        /// <tr><td align="center"> U+FF93 </td><td align="center"> ﾓ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30E2 </td><td align="center"> モ </td></tr>
        /// <tr><td align="center"> U+FF6C </td><td align="center"> ｬ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30E3 </td><td align="center"> ャ </td></tr>
        /// <tr><td align="center"> U+FF94 </td><td align="center"> ﾔ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30E4 </td><td align="center"> ヤ </td></tr>
        /// <tr><td align="center"> U+FF6D </td><td align="center"> ｭ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30E5 </td><td align="center"> ュ </td></tr>
        /// <tr><td align="center"> U+FF95 </td><td align="center"> ﾕ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30E6 </td><td align="center"> ユ </td></tr>
        /// <tr><td align="center"> U+FF6E </td><td align="center"> ｮ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30E7 </td><td align="center"> ョ </td></tr>
        /// <tr><td align="center"> U+FF96 </td><td align="center"> ﾖ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30E8 </td><td align="center"> ヨ </td></tr>
        /// <tr><td align="center"> U+FF97 </td><td align="center"> ﾗ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30E9 </td><td align="center"> ラ </td></tr>
        /// <tr><td align="center"> U+FF98 </td><td align="center"> ﾘ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30EA </td><td align="center"> リ </td></tr>
        /// <tr><td align="center"> U+FF99 </td><td align="center"> ﾙ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30EB </td><td align="center"> ル </td></tr>
        /// <tr><td align="center"> U+FF9A </td><td align="center"> ﾚ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30EC </td><td align="center"> レ </td></tr>
        /// <tr><td align="center"> U+FF9B </td><td align="center"> ﾛ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30ED </td><td align="center"> ロ </td></tr>
        /// <tr><td align="center"> U+FF9C </td><td align="center"> ﾜ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30EF </td><td align="center"> ワ </td></tr>
        /// <tr><td align="center"> U+FF66 </td><td align="center"> ｦ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30F2 </td><td align="center"> ヲ </td></tr>
        /// <tr><td align="center"> U+FF9D </td><td align="center"> ﾝ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+30F3 </td><td align="center"> ン </td></tr>
        /// <tr><td align="center"> U+FF73 </td><td align="center"> ｳ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30F4 </td><td align="center"> ヴ </td></tr>
        /// <tr><td align="center"> U+FF73 </td><td align="center"> ｳ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+30F4 </td><td align="center"> ヴ </td></tr>
        /// <tr><td align="center"> U+FF9C </td><td align="center"> ﾜ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30F7 </td><td align="center"> ヷ </td></tr>
        /// <tr><td align="center"> U+FF9C </td><td align="center"> ﾜ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+30F7 </td><td align="center"> ヷ </td></tr>
        /// <tr><td align="center"> U+FF66 </td><td align="center"> ｦ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+30FA </td><td align="center"> ヺ </td></tr>
        /// <tr><td align="center"> U+FF66 </td><td align="center"> ｦ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+30FA </td><td align="center"> ヺ </td></tr>
        /// </table>
        ///  *1 COMBINING KATAKANA-HIRAGANA VOICED SOUND MARK <br />
        ///  *2 COMBINING KATAKANA-HIRAGANA SEMI-VOICED SOUND MARK
        /// </remarks>
        public static string HalfwidthKatakanaToKatakana(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            return KanaConverter.Convert(input, "HalfwidthKatakanaToKatakana.xml");
        }

        /// <summary>Converts characters from romaji to kiragana.</summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>Converted string.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// input is a null reference.
        /// </exception>
        /// <remarks>
        /// See <see cref="T:Microsoft.International.Converters.KanaConverter" /> for an example of using KanaConverter.<br />
        /// Click <a href="..\Code\RomajiToHiragana.xml">here</a> to get the full configuration file for this conversion.<br /><br />
        /// The following table contains all conversions for this method.<br />
        /// <table align="center" border="1" cellspacing="0" cellpadding="0" bordercolor="black" width="80%">
        /// <tr><td align="center"> Romaji </td><td colspan="6" align="center"> Hiragana           </td></tr>
        /// <tr><td align="center"> a </td><td align="center"> U+3042 </td><td align="center"> あ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> la </td><td align="center"> U+3043 </td><td align="center"> ぁ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> xa </td><td align="center"> U+3043 </td><td align="center"> ぁ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> li </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> lyi </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> xi </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> xyi </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> i </td><td align="center"> U+3044 </td><td align="center"> い </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> yi </td><td align="center"> U+3044 </td><td align="center"> い </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ye </td><td align="center"> U+3044 </td><td align="center"> い </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> lu </td><td align="center"> U+3045 </td><td align="center"> ぅ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> xu </td><td align="center"> U+3045 </td><td align="center"> ぅ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> u </td><td align="center"> U+3046 </td><td align="center"> う </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> whu </td><td align="center"> U+3046 </td><td align="center"> う </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> wu </td><td align="center"> U+3046 </td><td align="center"> う </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> wha </td><td align="center"> U+3046 </td><td align="center"> う </td><td align="center"> U+3041 </td><td align="center"> ぁ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> wi </td><td align="center"> U+3046 </td><td align="center"> う </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> we </td><td align="center"> U+3046 </td><td align="center"> う </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> whe </td><td align="center"> U+3045 </td><td align="center"> う </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> who </td><td align="center"> U+3045 </td><td align="center"> う </td><td align="center"> U+3049 </td><td align="center"> ぉ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> le </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> lye </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> xe </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> xye </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> e </td><td align="center"> U+3048 </td><td align="center"> え </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> lo </td><td align="center"> U+3049 </td><td align="center"> ぉ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> xo </td><td align="center"> U+3049 </td><td align="center"> ぉ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> o </td><td align="center"> U+304A </td><td align="center"> お </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ka </td><td align="center"> U+304B </td><td align="center"> か </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ga </td><td align="center"> U+304C </td><td align="center"> が </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ki </td><td align="center"> U+304D </td><td align="center"> き </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> kyi </td><td align="center"> U+304D </td><td align="center"> き </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> kye </td><td align="center"> U+304D </td><td align="center"> き </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> kya </td><td align="center"> U+304D </td><td align="center"> き </td><td align="center"> U+3083 </td><td align="center"> ゃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> kyu </td><td align="center"> U+304D </td><td align="center"> き </td><td align="center"> U+3085 </td><td align="center"> ゅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> kyo </td><td align="center"> U+304D </td><td align="center"> き </td><td align="center"> U+3087 </td><td align="center"> ょ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> gi </td><td align="center"> U+304E </td><td align="center"> ぎ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> gyi </td><td align="center"> U+304E </td><td align="center"> ぎ </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> gye </td><td align="center"> U+304E </td><td align="center"> ぎ </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> gya </td><td align="center"> U+304E </td><td align="center"> ぎ </td><td align="center"> U+3083 </td><td align="center"> ゃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> gyu </td><td align="center"> U+304E </td><td align="center"> ぎ </td><td align="center"> U+3085 </td><td align="center"> ゅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> gyo </td><td align="center"> U+304E </td><td align="center"> ぎ </td><td align="center"> U+3087 </td><td align="center"> ょ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> cu </td><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ku </td><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> qu </td><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> kwa </td><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> U+3041 </td><td align="center"> ぁ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> qa </td><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> U+3041 </td><td align="center"> ぁ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> qwa </td><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> U+3041 </td><td align="center"> ぁ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> qi </td><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> qwi </td><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> qyi </td><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> qwu </td><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> U+3045 </td><td align="center"> ぅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> qe </td><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> qo </td><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> U+3049 </td><td align="center"> ぉ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> qya </td><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> U+3083 </td><td align="center"> ゃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> qyu </td><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> U+3085 </td><td align="center"> ゅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> gu </td><td align="center"> U+3050 </td><td align="center"> ぐ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> gwa </td><td align="center"> U+3050 </td><td align="center"> ぐ </td><td align="center"> U+3041 </td><td align="center"> ぁ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> gwi </td><td align="center"> U+3050 </td><td align="center"> ぐ </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> gwu </td><td align="center"> U+3050 </td><td align="center"> ぐ </td><td align="center"> U+3045 </td><td align="center"> ぅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> gwe </td><td align="center"> U+3050 </td><td align="center"> ぐ </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> gwo </td><td align="center"> U+3050 </td><td align="center"> ぐ </td><td align="center"> U+3049 </td><td align="center"> ぉ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ke </td><td align="center"> U+3051 </td><td align="center"> け </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ge </td><td align="center"> U+3052 </td><td align="center"> げ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> co </td><td align="center"> U+3053 </td><td align="center"> こ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ko </td><td align="center"> U+3053 </td><td align="center"> こ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> go </td><td align="center"> U+3054 </td><td align="center"> ご </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> sa </td><td align="center"> U+3055 </td><td align="center"> さ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> za </td><td align="center"> U+3056 </td><td align="center"> ざ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ci </td><td align="center"> U+3057 </td><td align="center"> し </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> shi </td><td align="center"> U+3057 </td><td align="center"> し </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> si </td><td align="center"> U+3057 </td><td align="center"> し </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> syi </td><td align="center"> U+3057 </td><td align="center"> し </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> she </td><td align="center"> U+3057 </td><td align="center"> し </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> sye </td><td align="center"> U+3057 </td><td align="center"> し </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> sha </td><td align="center"> U+3057 </td><td align="center"> し </td><td align="center"> U+3083 </td><td align="center"> ゃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> sya </td><td align="center"> U+3057 </td><td align="center"> し </td><td align="center"> U+3083 </td><td align="center"> ゃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> shu </td><td align="center"> U+3057 </td><td align="center"> し </td><td align="center"> U+3085 </td><td align="center"> ゅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> syu </td><td align="center"> U+3057 </td><td align="center"> し </td><td align="center"> U+3085 </td><td align="center"> ゅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> syo </td><td align="center"> U+3057 </td><td align="center"> し </td><td align="center"> U+3087 </td><td align="center"> ょ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> sho </td><td align="center"> U+3057 </td><td align="center"> し </td><td align="center"> U+3087 </td><td align="center"> ょ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ji </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> zi </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> jyi </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> zyi </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> je </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> jye </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> zye </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ja </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> U+3083 </td><td align="center"> ゃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> jya </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> U+3083 </td><td align="center"> ゃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> zya </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> U+3083 </td><td align="center"> ゃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ju </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> U+3085 </td><td align="center"> ゅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> jyu </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> U+3085 </td><td align="center"> ゅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> zyu </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> U+3085 </td><td align="center"> ゅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> jo </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> U+3087 </td><td align="center"> ょ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> jyo </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> U+3087 </td><td align="center"> ょ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> zyo </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> U+3087 </td><td align="center"> ょ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> su </td><td align="center"> U+3059 </td><td align="center"> す </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> swa </td><td align="center"> U+3059 </td><td align="center"> す </td><td align="center"> U+3041 </td><td align="center"> ぁ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> swi </td><td align="center"> U+3059 </td><td align="center"> す </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> swu </td><td align="center"> U+3059 </td><td align="center"> す </td><td align="center"> U+3045 </td><td align="center"> ぅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> swe </td><td align="center"> U+3059 </td><td align="center"> す </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> swo </td><td align="center"> U+3059 </td><td align="center"> す </td><td align="center"> U+3049 </td><td align="center"> ぉ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> zu </td><td align="center"> U+305A </td><td align="center"> ず </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ce </td><td align="center"> U+305B </td><td align="center"> せ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> se </td><td align="center"> U+305B </td><td align="center"> せ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ze </td><td align="center"> U+305C </td><td align="center"> ぜ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> so </td><td align="center"> U+305D </td><td align="center"> そ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> zo </td><td align="center"> U+305E </td><td align="center"> ぞ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ta </td><td align="center"> U+305F </td><td align="center"> た </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> da </td><td align="center"> U+3060 </td><td align="center"> だ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> chi </td><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ti </td><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> cyi </td><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> tyi </td><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> che </td><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> cye </td><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> tye </td><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> cha </td><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> U+3083 </td><td align="center"> ゃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> tya </td><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> U+3083 </td><td align="center"> ゃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> chu </td><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> U+3085 </td><td align="center"> ゅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> cyu </td><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> U+3085 </td><td align="center"> ゅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> tyu </td><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> U+3085 </td><td align="center"> ゅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> cho </td><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> U+3087 </td><td align="center"> ょ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> cyo </td><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> U+3087 </td><td align="center"> ょ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> tyo </td><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> U+3087 </td><td align="center"> ょ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> di </td><td align="center"> U+3062 </td><td align="center"> ぢ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> dyi </td><td align="center"> U+3062 </td><td align="center"> ぢ </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> dye </td><td align="center"> U+3062 </td><td align="center"> ぢ </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> dya </td><td align="center"> U+3062 </td><td align="center"> ぢ </td><td align="center"> U+3083 </td><td align="center"> ゃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> dyu </td><td align="center"> U+3062 </td><td align="center"> ぢ </td><td align="center"> U+3085 </td><td align="center"> ゅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> dyo </td><td align="center"> U+3062 </td><td align="center"> ぢ </td><td align="center"> U+3087 </td><td align="center"> ょ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ltsu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> xtu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> tsu </td><td align="center"> U+3064 </td><td align="center"> つ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> tu </td><td align="center"> U+3064 </td><td align="center"> つ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> tsa </td><td align="center"> U+3064 </td><td align="center"> つ </td><td align="center"> U+3041 </td><td align="center"> ぁ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> tsi </td><td align="center"> U+3064 </td><td align="center"> つ </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> tse </td><td align="center"> U+3064 </td><td align="center"> つ </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> tso </td><td align="center"> U+3064 </td><td align="center"> つ </td><td align="center"> U+3049 </td><td align="center"> ぉ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> du </td><td align="center"> U+3065 </td><td align="center"> づ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> te </td><td align="center"> U+3066 </td><td align="center"> て </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> thi </td><td align="center"> U+3066 </td><td align="center"> て </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> the </td><td align="center"> U+3066 </td><td align="center"> て </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> tha </td><td align="center"> U+3066 </td><td align="center"> て </td><td align="center"> U+3083 </td><td align="center"> ゃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> thu </td><td align="center"> U+3066 </td><td align="center"> て </td><td align="center"> U+3085 </td><td align="center"> ゅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> tho </td><td align="center"> U+3066 </td><td align="center"> て </td><td align="center"> U+3087 </td><td align="center"> ょ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> de </td><td align="center"> U+3067 </td><td align="center"> で </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> dhi </td><td align="center"> U+3067 </td><td align="center"> で </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> dhe </td><td align="center"> U+3067 </td><td align="center"> で </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> dha </td><td align="center"> U+3067 </td><td align="center"> で </td><td align="center"> U+3083 </td><td align="center"> ゃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> dhu </td><td align="center"> U+3067 </td><td align="center"> で </td><td align="center"> U+3085 </td><td align="center"> ゅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> dho </td><td align="center"> U+3067 </td><td align="center"> で </td><td align="center"> U+3087 </td><td align="center"> ょ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> to </td><td align="center"> U+3068 </td><td align="center"> と </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> twa </td><td align="center"> U+3068 </td><td align="center"> と </td><td align="center"> U+3041 </td><td align="center"> ぁ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> twi </td><td align="center"> U+3068 </td><td align="center"> と </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> twu </td><td align="center"> U+3068 </td><td align="center"> と </td><td align="center"> U+3045 </td><td align="center"> ぅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> twe </td><td align="center"> U+3068 </td><td align="center"> と </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> two </td><td align="center"> U+3068 </td><td align="center"> と </td><td align="center"> U+3049 </td><td align="center"> ぉ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> do </td><td align="center"> U+3069 </td><td align="center"> ど </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> dwa </td><td align="center"> U+3069 </td><td align="center"> ど </td><td align="center"> U+3041 </td><td align="center"> ぁ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> dwi </td><td align="center"> U+3069 </td><td align="center"> ど </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> dwu </td><td align="center"> U+3069 </td><td align="center"> ど </td><td align="center"> U+3045 </td><td align="center"> ぅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> dwe </td><td align="center"> U+3069 </td><td align="center"> ど </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> dwo </td><td align="center"> U+3069 </td><td align="center"> ど </td><td align="center"> U+3049 </td><td align="center"> ぉ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> na </td><td align="center"> U+306A </td><td align="center"> な </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ni </td><td align="center"> U+306B </td><td align="center"> に </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> nyi </td><td align="center"> U+306B </td><td align="center"> に </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> nye </td><td align="center"> U+306B </td><td align="center"> に </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> nya </td><td align="center"> U+306B </td><td align="center"> に </td><td align="center"> U+3083 </td><td align="center"> ゃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> nyu </td><td align="center"> U+306B </td><td align="center"> に </td><td align="center"> U+3085 </td><td align="center"> ゅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> nyo </td><td align="center"> U+306B </td><td align="center"> に </td><td align="center"> U+3087 </td><td align="center"> ょ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> nu </td><td align="center"> U+306C </td><td align="center"> ぬ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ne </td><td align="center"> U+306D </td><td align="center"> ね </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> no </td><td align="center"> U+306E </td><td align="center"> の </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ha </td><td align="center"> U+306F </td><td align="center"> は </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ba </td><td align="center"> U+3070 </td><td align="center"> ば </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> pa </td><td align="center"> U+3071 </td><td align="center"> ぱ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> hi </td><td align="center"> U+3072 </td><td align="center"> ひ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> hyi </td><td align="center"> U+3072 </td><td align="center"> ひ </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> hye </td><td align="center"> U+3072 </td><td align="center"> ひ </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> hya </td><td align="center"> U+3072 </td><td align="center"> ひ </td><td align="center"> U+3083 </td><td align="center"> ゃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> hyu </td><td align="center"> U+3072 </td><td align="center"> ひ </td><td align="center"> U+3085 </td><td align="center"> ゅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> hyo </td><td align="center"> U+3072 </td><td align="center"> ひ </td><td align="center"> U+3087 </td><td align="center"> ょ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> bi </td><td align="center"> U+3073 </td><td align="center"> び </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> byi </td><td align="center"> U+3073 </td><td align="center"> び </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> bye </td><td align="center"> U+3073 </td><td align="center"> び </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> bya </td><td align="center"> U+3073 </td><td align="center"> び </td><td align="center"> U+3083 </td><td align="center"> ゃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> byu </td><td align="center"> U+3073 </td><td align="center"> び </td><td align="center"> U+3085 </td><td align="center"> ゅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> byo </td><td align="center"> U+3073 </td><td align="center"> び </td><td align="center"> U+3087 </td><td align="center"> ょ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> pi </td><td align="center"> U+3074 </td><td align="center"> ぴ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> pyi </td><td align="center"> U+3074 </td><td align="center"> ぴ </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> pye </td><td align="center"> U+3074 </td><td align="center"> ぴ </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> pya </td><td align="center"> U+3074 </td><td align="center"> ぴ </td><td align="center"> U+3083 </td><td align="center"> ゃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> pyu </td><td align="center"> U+3074 </td><td align="center"> ぴ </td><td align="center"> U+3085 </td><td align="center"> ゅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> pyo </td><td align="center"> U+3074 </td><td align="center"> ぴ </td><td align="center"> U+3087 </td><td align="center"> ょ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> fu </td><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> hu </td><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> fa </td><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> U+3041 </td><td align="center"> ぁ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> fwa </td><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> U+3041 </td><td align="center"> ぁ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> fi </td><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> fwi </td><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> fyi </td><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> fwu </td><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> U+3045 </td><td align="center"> ぅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> fe </td><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> fo </td><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> U+3049 </td><td align="center"> ぉ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> fwo </td><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> U+3049 </td><td align="center"> ぉ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> fya </td><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> U+3083 </td><td align="center"> ゃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> fyu </td><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> U+3085 </td><td align="center"> ゅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> fyo </td><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> U+3087 </td><td align="center"> ょ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> bu </td><td align="center"> U+3076 </td><td align="center"> ぶ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> pu </td><td align="center"> U+3071 </td><td align="center"> ぷ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> he </td><td align="center"> U+3078 </td><td align="center"> へ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> be </td><td align="center"> U+3079 </td><td align="center"> べ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> pe </td><td align="center"> U+307A </td><td align="center"> ぺ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ho </td><td align="center"> U+307B </td><td align="center"> ほ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> bo </td><td align="center"> U+307C </td><td align="center"> ぼ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> po </td><td align="center"> U+307D </td><td align="center"> ぽ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ma </td><td align="center"> U+307E </td><td align="center"> ま </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> mi </td><td align="center"> U+307F </td><td align="center"> み </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> myi </td><td align="center"> U+307F </td><td align="center"> み </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> mye </td><td align="center"> U+307F </td><td align="center"> み </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> mya </td><td align="center"> U+307F </td><td align="center"> み </td><td align="center"> U+3083 </td><td align="center"> ゃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> myu </td><td align="center"> U+307F </td><td align="center"> み </td><td align="center"> U+3085 </td><td align="center"> ゅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> myo </td><td align="center"> U+307F </td><td align="center"> み </td><td align="center"> U+3087 </td><td align="center"> ょ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> mu </td><td align="center"> U+3080 </td><td align="center"> む </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> me </td><td align="center"> U+3081 </td><td align="center"> め </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> mo </td><td align="center"> U+3082 </td><td align="center"> も </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> lya </td><td align="center"> U+3083 </td><td align="center"> ゃ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> xya </td><td align="center"> U+3083 </td><td align="center"> ゃ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ya </td><td align="center"> U+3084 </td><td align="center"> や </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> lyu </td><td align="center"> U+3085 </td><td align="center"> ゅ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> xyu </td><td align="center"> U+3085 </td><td align="center"> ゅ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> yu </td><td align="center"> U+3086 </td><td align="center"> ゆ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> lyo </td><td align="center"> U+3087 </td><td align="center"> ょ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> xyo </td><td align="center"> U+3087 </td><td align="center"> ょ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> yo </td><td align="center"> U+3088 </td><td align="center"> よ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ra </td><td align="center"> U+3089 </td><td align="center"> ら </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ri </td><td align="center"> U+308A </td><td align="center"> り </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ryi </td><td align="center"> U+308A </td><td align="center"> り </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> rye </td><td align="center"> U+308A </td><td align="center"> り </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> rya </td><td align="center"> U+308A </td><td align="center"> り </td><td align="center"> U+3083 </td><td align="center"> ゃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ryu </td><td align="center"> U+308A </td><td align="center"> り </td><td align="center"> U+3085 </td><td align="center"> ゅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ryo </td><td align="center"> U+308A </td><td align="center"> り </td><td align="center"> U+3087 </td><td align="center"> ょ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ru </td><td align="center"> U+308B </td><td align="center"> る </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> re </td><td align="center"> U+308C </td><td align="center"> れ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ro </td><td align="center"> U+308D </td><td align="center"> ろ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> lwa </td><td align="center"> U+308E </td><td align="center"> ゎ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> xwa </td><td align="center"> U+308E </td><td align="center"> ゎ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> wa </td><td align="center"> U+309F </td><td align="center"> わ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> wyi </td><td align="center"> U+3090 </td><td align="center"> ゐ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> wye </td><td align="center"> U+3091 </td><td align="center"> ゑ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> wo </td><td align="center"> U+3092 </td><td align="center"> を </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> nn </td><td align="center"> U+3093 </td><td align="center"> ん </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> xn </td><td align="center"> U+3093 </td><td align="center"> ん </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> vu </td><td align="center"> U+3094 </td><td align="center"> ゔ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> va </td><td align="center"> U+3094 </td><td align="center"> ゔ </td><td align="center"> U+3041 </td><td align="center"> ぁ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> vi </td><td align="center"> U+3094 </td><td align="center"> ゔ </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> vyi </td><td align="center"> U+3094 </td><td align="center"> ゔ </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ve </td><td align="center"> U+3094 </td><td align="center"> ゔ </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> vye </td><td align="center"> U+3094 </td><td align="center"> ゔ </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> vo </td><td align="center"> U+3094 </td><td align="center"> ゔ </td><td align="center"> U+3049 </td><td align="center"> ぉ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> vya </td><td align="center"> U+3094 </td><td align="center"> ゔ </td><td align="center"> U+3083 </td><td align="center"> ゃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> vyu </td><td align="center"> U+3094 </td><td align="center"> ゔ </td><td align="center"> U+3085 </td><td align="center"> ゅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> vyo </td><td align="center"> U+3095 </td><td align="center"> ゔ </td><td align="center"> U+3087 </td><td align="center"> ょ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> lka </td><td align="center"> U+3095 </td><td align="center"> ヵ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> xka </td><td align="center"> U+3096 </td><td align="center"> ヵ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> lke </td><td align="center"> U+3096 </td><td align="center"> ヶ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> xke </td><td align="center"> U+3096 </td><td align="center"> ヶ </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> qyo </td><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> U+3087 </td><td align="center"> ょ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> lla </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3043 </td><td align="center"> ぁ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> xxa </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3043 </td><td align="center"> ぁ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> lli </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> llyi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> xxi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> xxyi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3043 </td><td align="center"> ぃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> yyi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3044 </td><td align="center"> い </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> yye </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3044 </td><td align="center"> い </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> llu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3045 </td><td align="center"> ぅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> xxu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3045 </td><td align="center"> ぅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> wwhu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3046 </td><td align="center"> う </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> wwu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3046 </td><td align="center"> う </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> wwha </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3046 </td><td align="center"> う </td><td align="center"> U+3041 </td><td align="center"> ぁ </td></tr>
        /// <tr><td align="center"> wwi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3046 </td><td align="center"> う </td><td align="center"> U+3043 </td><td align="center"> ぃ </td></tr>
        /// <tr><td align="center"> wwe </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3046 </td><td align="center"> う </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> wwhe </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3045 </td><td align="center"> う </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> wwho </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3045 </td><td align="center"> う </td><td align="center"> U+3049 </td><td align="center"> ぉ </td></tr>
        /// <tr><td align="center"> lle </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> llye </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> xxe </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> xxye </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3047 </td><td align="center"> ぇ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> llo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3049 </td><td align="center"> ぉ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> xxo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3049 </td><td align="center"> ぉ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> kka </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+304B </td><td align="center"> か </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> gga </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+304C </td><td align="center"> が </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> kki </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+304D </td><td align="center"> き </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> kkyi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+304D </td><td align="center"> き </td><td align="center"> U+3043 </td><td align="center"> ぃ </td></tr>
        /// <tr><td align="center"> kkye </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+304D </td><td align="center"> き </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> kkya </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+304D </td><td align="center"> き </td><td align="center"> U+3083 </td><td align="center"> ゃ </td></tr>
        /// <tr><td align="center"> kkyu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+304D </td><td align="center"> き </td><td align="center"> U+3085 </td><td align="center"> ゅ </td></tr>
        /// <tr><td align="center"> kkyo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+304D </td><td align="center"> き </td><td align="center"> U+3087 </td><td align="center"> ょ </td></tr>
        /// <tr><td align="center"> ggi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+304E </td><td align="center"> ぎ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ggyi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+304E </td><td align="center"> ぎ </td><td align="center"> U+3043 </td><td align="center"> ぃ </td></tr>
        /// <tr><td align="center"> ggye </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+304E </td><td align="center"> ぎ </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> ggya </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+304E </td><td align="center"> ぎ </td><td align="center"> U+3083 </td><td align="center"> ゃ </td></tr>
        /// <tr><td align="center"> ggyu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+304E </td><td align="center"> ぎ </td><td align="center"> U+3085 </td><td align="center"> ゅ </td></tr>
        /// <tr><td align="center"> ggyo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+304E </td><td align="center"> ぎ </td><td align="center"> U+3087 </td><td align="center"> ょ </td></tr>
        /// <tr><td align="center"> ccu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> kku </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> qqu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> kkwa </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> U+3041 </td><td align="center"> ぁ </td></tr>
        /// <tr><td align="center"> qqa </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> U+3041 </td><td align="center"> ぁ </td></tr>
        /// <tr><td align="center"> qqwa </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> U+3041 </td><td align="center"> ぁ </td></tr>
        /// <tr><td align="center"> qqi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> U+3043 </td><td align="center"> ぃ </td></tr>
        /// <tr><td align="center"> qqwi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> U+3043 </td><td align="center"> ぃ </td></tr>
        /// <tr><td align="center"> qqyi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> U+3043 </td><td align="center"> ぃ </td></tr>
        /// <tr><td align="center"> qqwu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> U+3045 </td><td align="center"> ぅ </td></tr>
        /// <tr><td align="center"> qqe </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> qqo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> U+3049 </td><td align="center"> ぉ </td></tr>
        /// <tr><td align="center"> qqya </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> U+3083 </td><td align="center"> ゃ </td></tr>
        /// <tr><td align="center"> qqyu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> U+3085 </td><td align="center"> ゅ </td></tr>
        /// <tr><td align="center"> ggu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3050 </td><td align="center"> ぐ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ggwa </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3050 </td><td align="center"> ぐ </td><td align="center"> U+3041 </td><td align="center"> ぁ </td></tr>
        /// <tr><td align="center"> ggwi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3050 </td><td align="center"> ぐ </td><td align="center"> U+3043 </td><td align="center"> ぃ </td></tr>
        /// <tr><td align="center"> ggwu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3050 </td><td align="center"> ぐ </td><td align="center"> U+3045 </td><td align="center"> ぅ </td></tr>
        /// <tr><td align="center"> ggwe </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3050 </td><td align="center"> ぐ </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> ggwo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3050 </td><td align="center"> ぐ </td><td align="center"> U+3049 </td><td align="center"> ぉ </td></tr>
        /// <tr><td align="center"> kke </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3051 </td><td align="center"> け </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> gge </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3052 </td><td align="center"> げ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> cco </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3053 </td><td align="center"> こ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> kko </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3053 </td><td align="center"> こ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ggo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3054 </td><td align="center"> ご </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ssa </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3055 </td><td align="center"> さ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> zza </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3056 </td><td align="center"> ざ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> cci </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3057 </td><td align="center"> し </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> sshi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3057 </td><td align="center"> し </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ssi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3057 </td><td align="center"> し </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ssyi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3057 </td><td align="center"> し </td><td align="center"> U+3043 </td><td align="center"> ぃ </td></tr>
        /// <tr><td align="center"> sshe </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3057 </td><td align="center"> し </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> ssye </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3057 </td><td align="center"> し </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> ssha </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3057 </td><td align="center"> し </td><td align="center"> U+3083 </td><td align="center"> ゃ </td></tr>
        /// <tr><td align="center"> ssya </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3057 </td><td align="center"> し </td><td align="center"> U+3083 </td><td align="center"> ゃ </td></tr>
        /// <tr><td align="center"> sshu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3057 </td><td align="center"> し </td><td align="center"> U+3085 </td><td align="center"> ゅ </td></tr>
        /// <tr><td align="center"> ssyu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3057 </td><td align="center"> し </td><td align="center"> U+3085 </td><td align="center"> ゅ </td></tr>
        /// <tr><td align="center"> ssyo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3057 </td><td align="center"> し </td><td align="center"> U+3087 </td><td align="center"> ょ </td></tr>
        /// <tr><td align="center"> ssho </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3057 </td><td align="center"> し </td><td align="center"> U+3087 </td><td align="center"> ょ </td></tr>
        /// <tr><td align="center"> Jji </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> zzi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> Jjyi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> U+3043 </td><td align="center"> ぃ </td></tr>
        /// <tr><td align="center"> zzyi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> U+3043 </td><td align="center"> ぃ </td></tr>
        /// <tr><td align="center"> jje </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> jjye </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> zzye </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> jja </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> U+3083 </td><td align="center"> ゃ </td></tr>
        /// <tr><td align="center"> jjya </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> U+3083 </td><td align="center"> ゃ </td></tr>
        /// <tr><td align="center"> zzya </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> U+3083 </td><td align="center"> ゃ </td></tr>
        /// <tr><td align="center"> jju </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> U+3085 </td><td align="center"> ゅ </td></tr>
        /// <tr><td align="center"> jjyu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> U+3085 </td><td align="center"> ゅ </td></tr>
        /// <tr><td align="center"> zzyu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> U+3085 </td><td align="center"> ゅ </td></tr>
        /// <tr><td align="center"> jjo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> U+3087 </td><td align="center"> ょ </td></tr>
        /// <tr><td align="center"> jjyo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> U+3087 </td><td align="center"> ょ </td></tr>
        /// <tr><td align="center"> zzyo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3058 </td><td align="center"> じ </td><td align="center"> U+3087 </td><td align="center"> ょ </td></tr>
        /// <tr><td align="center"> ssu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3059 </td><td align="center"> す </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> sswa </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3059 </td><td align="center"> す </td><td align="center"> U+3041 </td><td align="center"> ぁ </td></tr>
        /// <tr><td align="center"> sswi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3059 </td><td align="center"> す </td><td align="center"> U+3043 </td><td align="center"> ぃ </td></tr>
        /// <tr><td align="center"> sswu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3059 </td><td align="center"> す </td><td align="center"> U+3045 </td><td align="center"> ぅ </td></tr>
        /// <tr><td align="center"> sswe </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3059 </td><td align="center"> す </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> sswo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3059 </td><td align="center"> す </td><td align="center"> U+3049 </td><td align="center"> ぉ </td></tr>
        /// <tr><td align="center"> zzu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+305A </td><td align="center"> ず </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> cce </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+305B </td><td align="center"> せ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> sse </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+305B </td><td align="center"> せ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> zze </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+305C </td><td align="center"> ぜ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> sso </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+305D </td><td align="center"> そ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> zzo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+305E </td><td align="center"> ぞ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> tta </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+305F </td><td align="center"> た </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> dda </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3060 </td><td align="center"> だ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> cchi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> Tti </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ccyi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> U+3043 </td><td align="center"> ぃ </td></tr>
        /// <tr><td align="center"> ttyi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> U+3043 </td><td align="center"> ぃ </td></tr>
        /// <tr><td align="center"> cche </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> ccye </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> ttye </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> ccha </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> U+3083 </td><td align="center"> ゃ </td></tr>
        /// <tr><td align="center"> ttya </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> U+3083 </td><td align="center"> ゃ </td></tr>
        /// <tr><td align="center"> cchu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> U+3085 </td><td align="center"> ゅ </td></tr>
        /// <tr><td align="center"> ccyu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> U+3085 </td><td align="center"> ゅ </td></tr>
        /// <tr><td align="center"> ttyu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> U+3085 </td><td align="center"> ゅ </td></tr>
        /// <tr><td align="center"> ccho </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> U+3087 </td><td align="center"> ょ </td></tr>
        /// <tr><td align="center"> ccyo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> U+3087 </td><td align="center"> ょ </td></tr>
        /// <tr><td align="center"> ttyo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3061 </td><td align="center"> ち </td><td align="center"> U+3087 </td><td align="center"> ょ </td></tr>
        /// <tr><td align="center"> Ddi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3062 </td><td align="center"> ぢ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ddyi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3062 </td><td align="center"> ぢ </td><td align="center"> U+3043 </td><td align="center"> ぃ </td></tr>
        /// <tr><td align="center"> ddye </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3062 </td><td align="center"> ぢ </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> ddya </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3062 </td><td align="center"> ぢ </td><td align="center"> U+3083 </td><td align="center"> ゃ </td></tr>
        /// <tr><td align="center"> ddyu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3062 </td><td align="center"> ぢ </td><td align="center"> U+3085 </td><td align="center"> ゅ </td></tr>
        /// <tr><td align="center"> ddyo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3062 </td><td align="center"> ぢ </td><td align="center"> U+3087 </td><td align="center"> ょ </td></tr>
        /// <tr><td align="center"> xxtu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ttsu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3064 </td><td align="center"> つ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ttu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3064 </td><td align="center"> つ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ttsa </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3064 </td><td align="center"> つ </td><td align="center"> U+3041 </td><td align="center"> ぁ </td></tr>
        /// <tr><td align="center"> ttsi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3064 </td><td align="center"> つ </td><td align="center"> U+3043 </td><td align="center"> ぃ </td></tr>
        /// <tr><td align="center"> ttse </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3064 </td><td align="center"> つ </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> ttso </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3064 </td><td align="center"> つ </td><td align="center"> U+3049 </td><td align="center"> ぉ </td></tr>
        /// <tr><td align="center"> ddu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3065 </td><td align="center"> づ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> tte </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3066 </td><td align="center"> て </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> tthi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3066 </td><td align="center"> て </td><td align="center"> U+3043 </td><td align="center"> ぃ </td></tr>
        /// <tr><td align="center"> tthe </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3066 </td><td align="center"> て </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> ttha </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3066 </td><td align="center"> て </td><td align="center"> U+3083 </td><td align="center"> ゃ </td></tr>
        /// <tr><td align="center"> tthu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3066 </td><td align="center"> て </td><td align="center"> U+3085 </td><td align="center"> ゅ </td></tr>
        /// <tr><td align="center"> ttho </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3066 </td><td align="center"> て </td><td align="center"> U+3087 </td><td align="center"> ょ </td></tr>
        /// <tr><td align="center"> dde </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3067 </td><td align="center"> で </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ddhi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3067 </td><td align="center"> で </td><td align="center"> U+3043 </td><td align="center"> ぃ </td></tr>
        /// <tr><td align="center"> ddhe </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3067 </td><td align="center"> で </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> ddha </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3067 </td><td align="center"> で </td><td align="center"> U+3083 </td><td align="center"> ゃ </td></tr>
        /// <tr><td align="center"> ddhu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3067 </td><td align="center"> で </td><td align="center"> U+3085 </td><td align="center"> ゅ </td></tr>
        /// <tr><td align="center"> ddho </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3067 </td><td align="center"> で </td><td align="center"> U+3087 </td><td align="center"> ょ </td></tr>
        /// <tr><td align="center"> tto </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3068 </td><td align="center"> と </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ttwa </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3068 </td><td align="center"> と </td><td align="center"> U+3041 </td><td align="center"> ぁ </td></tr>
        /// <tr><td align="center"> ttwi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3068 </td><td align="center"> と </td><td align="center"> U+3043 </td><td align="center"> ぃ </td></tr>
        /// <tr><td align="center"> ttwu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3068 </td><td align="center"> と </td><td align="center"> U+3045 </td><td align="center"> ぅ </td></tr>
        /// <tr><td align="center"> ttwe </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3068 </td><td align="center"> と </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> ttwo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3068 </td><td align="center"> と </td><td align="center"> U+3049 </td><td align="center"> ぉ </td></tr>
        /// <tr><td align="center"> ddo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3069 </td><td align="center"> ど </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ddwa </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3069 </td><td align="center"> ど </td><td align="center"> U+3041 </td><td align="center"> ぁ </td></tr>
        /// <tr><td align="center"> ddwi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3069 </td><td align="center"> ど </td><td align="center"> U+3043 </td><td align="center"> ぃ </td></tr>
        /// <tr><td align="center"> ddwu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3069 </td><td align="center"> ど </td><td align="center"> U+3045 </td><td align="center"> ぅ </td></tr>
        /// <tr><td align="center"> ddwe </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3069 </td><td align="center"> ど </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> ddwo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3069 </td><td align="center"> ど </td><td align="center"> U+3049 </td><td align="center"> ぉ </td></tr>
        /// <tr><td align="center"> nna </td><td align="center"> U+3093 </td><td align="center"> ん </td><td align="center"> U+3042 </td><td align="center"> あ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> nni </td><td align="center"> U+3093 </td><td align="center"> ん </td><td align="center"> U+3044 </td><td align="center"> い </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> nnyi </td><td align="center"> U+3093 </td><td align="center"> ん </td><td align="center"> U+3044 </td><td align="center"> い </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> nnye </td><td align="center"> U+3093 </td><td align="center"> ん </td><td align="center"> U+3044 </td><td align="center"> い </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> nnya </td><td align="center"> U+3093 </td><td align="center"> ん </td><td align="center"> U+3084 </td><td align="center"> や </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> nnyu </td><td align="center"> U+3093 </td><td align="center"> ん </td><td align="center"> U+3086 </td><td align="center"> ゆ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> nnyo </td><td align="center"> U+3093 </td><td align="center"> ん </td><td align="center"> U+3088 </td><td align="center"> よ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> nnu </td><td align="center"> U+3093 </td><td align="center"> ん </td><td align="center"> U+3046 </td><td align="center"> う </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> nne </td><td align="center"> U+3093 </td><td align="center"> ん </td><td align="center"> U+3048 </td><td align="center"> え </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> nno </td><td align="center"> U+3093 </td><td align="center"> ん </td><td align="center"> U+304A </td><td align="center"> お </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> hha </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+306F </td><td align="center"> は </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> bba </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3070 </td><td align="center"> ば </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ppa </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3071 </td><td align="center"> ぱ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> hhi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3072 </td><td align="center"> ひ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> hhyi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3072 </td><td align="center"> ひ </td><td align="center"> U+3043 </td><td align="center"> ぃ </td></tr>
        /// <tr><td align="center"> hhye </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3072 </td><td align="center"> ひ </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> hhya </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3072 </td><td align="center"> ひ </td><td align="center"> U+3083 </td><td align="center"> ゃ </td></tr>
        /// <tr><td align="center"> hhyu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3072 </td><td align="center"> ひ </td><td align="center"> U+3085 </td><td align="center"> ゅ </td></tr>
        /// <tr><td align="center"> hhyo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3072 </td><td align="center"> ひ </td><td align="center"> U+3087 </td><td align="center"> ょ </td></tr>
        /// <tr><td align="center"> bbi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3073 </td><td align="center"> び </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> bbyi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3073 </td><td align="center"> び </td><td align="center"> U+3043 </td><td align="center"> ぃ </td></tr>
        /// <tr><td align="center"> bbye </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3073 </td><td align="center"> び </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> bbya </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3073 </td><td align="center"> び </td><td align="center"> U+3083 </td><td align="center"> ゃ </td></tr>
        /// <tr><td align="center"> bbyu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3073 </td><td align="center"> び </td><td align="center"> U+3085 </td><td align="center"> ゅ </td></tr>
        /// <tr><td align="center"> bbyo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3073 </td><td align="center"> び </td><td align="center"> U+3087 </td><td align="center"> ょ </td></tr>
        /// <tr><td align="center"> ppi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3074 </td><td align="center"> ぴ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ppyi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3074 </td><td align="center"> ぴ </td><td align="center"> U+3043 </td><td align="center"> ぃ </td></tr>
        /// <tr><td align="center"> ppye </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3074 </td><td align="center"> ぴ </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> ppya </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3074 </td><td align="center"> ぴ </td><td align="center"> U+3083 </td><td align="center"> ゃ </td></tr>
        /// <tr><td align="center"> ppyu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3074 </td><td align="center"> ぴ </td><td align="center"> U+3085 </td><td align="center"> ゅ </td></tr>
        /// <tr><td align="center"> ppyo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3074 </td><td align="center"> ぴ </td><td align="center"> U+3087 </td><td align="center"> ょ </td></tr>
        /// <tr><td align="center"> ffu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> hhu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ffa </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> U+3041 </td><td align="center"> ぁ </td></tr>
        /// <tr><td align="center"> ffwa </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> U+3041 </td><td align="center"> ぁ </td></tr>
        /// <tr><td align="center"> ffi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> U+3043 </td><td align="center"> ぃ </td></tr>
        /// <tr><td align="center"> ffwi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> U+3043 </td><td align="center"> ぃ </td></tr>
        /// <tr><td align="center"> ffyi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> U+3043 </td><td align="center"> ぃ </td></tr>
        /// <tr><td align="center"> ffwu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> U+3045 </td><td align="center"> ぅ </td></tr>
        /// <tr><td align="center"> ffe </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> ffo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> U+3049 </td><td align="center"> ぉ </td></tr>
        /// <tr><td align="center"> ffwo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> U+3049 </td><td align="center"> ぉ </td></tr>
        /// <tr><td align="center"> ffya </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> U+3083 </td><td align="center"> ゃ </td></tr>
        /// <tr><td align="center"> ffyu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> U+3085 </td><td align="center"> ゅ </td></tr>
        /// <tr><td align="center"> ffyo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3075 </td><td align="center"> ふ </td><td align="center"> U+3087 </td><td align="center"> ょ </td></tr>
        /// <tr><td align="center"> bbu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3076 </td><td align="center"> ぶ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ppu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3071 </td><td align="center"> ぷ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> hhe </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3078 </td><td align="center"> へ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> bbe </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3079 </td><td align="center"> べ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ppe </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+307A </td><td align="center"> ぺ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> hho </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+307B </td><td align="center"> ほ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> bbo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+307C </td><td align="center"> ぼ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> ppo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+307D </td><td align="center"> ぽ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> mma </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+307E </td><td align="center"> ま </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> mmi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+307F </td><td align="center"> み </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> mmyi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+307F </td><td align="center"> み </td><td align="center"> U+3043 </td><td align="center"> ぃ </td></tr>
        /// <tr><td align="center"> mmye </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+307F </td><td align="center"> み </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> mmya </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+307F </td><td align="center"> み </td><td align="center"> U+3083 </td><td align="center"> ゃ </td></tr>
        /// <tr><td align="center"> mmyu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+307F </td><td align="center"> み </td><td align="center"> U+3085 </td><td align="center"> ゅ </td></tr>
        /// <tr><td align="center"> mmyo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+307F </td><td align="center"> み </td><td align="center"> U+3087 </td><td align="center"> ょ </td></tr>
        /// <tr><td align="center"> mmu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3080 </td><td align="center"> む </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> mme </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3081 </td><td align="center"> め </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> mmo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3082 </td><td align="center"> も </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> llya </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3083 </td><td align="center"> ゃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> xxya </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3083 </td><td align="center"> ゃ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> yya </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3084 </td><td align="center"> や </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> llyu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3085 </td><td align="center"> ゅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> xxyu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3085 </td><td align="center"> ゅ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> yyu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3086 </td><td align="center"> ゆ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> llyo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3087 </td><td align="center"> ょ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> xxyo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3087 </td><td align="center"> ょ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> yyo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3088 </td><td align="center"> よ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> rra </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3089 </td><td align="center"> ら </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> rri </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+308A </td><td align="center"> り </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> rryi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+308A </td><td align="center"> り </td><td align="center"> U+3043 </td><td align="center"> ぃ </td></tr>
        /// <tr><td align="center"> rrye </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+308A </td><td align="center"> り </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> rrya </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+308A </td><td align="center"> り </td><td align="center"> U+3083 </td><td align="center"> ゃ </td></tr>
        /// <tr><td align="center"> rryu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+308A </td><td align="center"> り </td><td align="center"> U+3085 </td><td align="center"> ゅ </td></tr>
        /// <tr><td align="center"> rryo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+308A </td><td align="center"> り </td><td align="center"> U+3087 </td><td align="center"> ょ </td></tr>
        /// <tr><td align="center"> rru </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+308B </td><td align="center"> る </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> rre </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+308C </td><td align="center"> れ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> rro </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+308D </td><td align="center"> ろ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> llwa </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+308E </td><td align="center"> ゎ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> xxwa </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+308E </td><td align="center"> ゎ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> wwa </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+309F </td><td align="center"> わ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> wwyi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3090 </td><td align="center"> ゐ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> wwye </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3091 </td><td align="center"> ゑ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> wwo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3092 </td><td align="center"> を </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> n </td><td align="center"> U+3093 </td><td align="center"> ん </td><td align="center"> </td><td align="center"> </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> xxn </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3093 </td><td align="center"> ん </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> vvu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3094 </td><td align="center"> ゔ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> vva </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+30F4 </td><td align="center"> ヴ </td><td align="center"> U+3041 </td><td align="center"> ぁ </td></tr>
        /// <tr><td align="center"> vvi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+30F4 </td><td align="center"> ヴ </td><td align="center"> U+3043 </td><td align="center"> ぃ </td></tr>
        /// <tr><td align="center"> vvyi </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+30F4 </td><td align="center"> ヴ </td><td align="center"> U+3043 </td><td align="center"> ぃ </td></tr>
        /// <tr><td align="center"> vve </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+30F4 </td><td align="center"> ヴ </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> vvye </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+30F4 </td><td align="center"> ヴ </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> vvo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+30F4 </td><td align="center"> ヴ </td><td align="center"> U+3049 </td><td align="center"> ぉ </td></tr>
        /// <tr><td align="center"> vvya </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+30F4 </td><td align="center"> ヴ </td><td align="center"> U+3083 </td><td align="center"> ゃ </td></tr>
        /// <tr><td align="center"> vvyu </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+30F4 </td><td align="center"> ヴ </td><td align="center"> U+3085 </td><td align="center"> ゅ </td></tr>
        /// <tr><td align="center"> vvyo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+30F4 </td><td align="center"> ヴ </td><td align="center"> U+3087 </td><td align="center"> ょ </td></tr>
        /// <tr><td align="center"> llka </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3095 </td><td align="center"> ヵ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> xxka </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3096 </td><td align="center"> ヵ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> llke </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3096 </td><td align="center"> ヶ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> xxke </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+3096 </td><td align="center"> ヶ </td><td align="center"> </td><td align="center"> </td></tr>
        /// <tr><td align="center"> qqyo </td><td align="center"> U+3063 </td><td align="center"> っ </td><td align="center"> U+304F </td><td align="center"> く </td><td align="center"> U+3087 </td><td align="center"> ょ </td></tr>
        /// </table>
        /// </remarks>
        public static string RomajiToHiragana(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            return Convert(input, "RomajiToHiragana.xml");
        }

        /// <summary>
        /// Converts characters from half-width katakana to hiragana.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns>Converted string.</returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// input is a null reference.
        /// </exception>
        /// <remarks>
        /// See <see cref="T:Microsoft.International.Converters.KanaConverter" /> for an example of using KanaConverter.<br />
        /// Click <a href="..\Code\HalfwidthKatakanaToHiragana.xml">here</a> to get the full configuration file for this conversion.<br /><br />
        /// The following table contains all conversions for this method.<br />
        /// <table align="center" border="1" cellspacing="0" cellpadding="0" bordercolor="black" width="80%">
        /// <tr><td colspan="4" align="center">Halfwidth Katakana</td><td colspan="2" align="center"> Hiragana   </td></tr>
        /// <tr><td align="center"> Codepoint </td><td align="center"> Character </td><td align="center"> Codepoint </td><td align="center"> Character </td><td align="center"> Codepoint </td><td align="center"> Character </td></tr>
        /// <tr><td align="center"> U+FF67 </td><td align="center"> ｧ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3041 </td><td align="center"> ぁ </td></tr>
        /// <tr><td align="center"> U+FF71 </td><td align="center"> ｱ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3042 </td><td align="center"> あ </td></tr>
        /// <tr><td align="center"> U+FF68 </td><td align="center"> ｨ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3043 </td><td align="center"> ぃ </td></tr>
        /// <tr><td align="center"> U+FF72 </td><td align="center"> ｲ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3044 </td><td align="center"> い </td></tr>
        /// <tr><td align="center"> U+FF69 </td><td align="center"> ｩ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3045 </td><td align="center"> ぅ </td></tr>
        /// <tr><td align="center"> U+FF73 </td><td align="center"> ｳ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3046 </td><td align="center"> う </td></tr>
        /// <tr><td align="center"> U+FF6A </td><td align="center"> ｪ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3047 </td><td align="center"> ぇ </td></tr>
        /// <tr><td align="center"> U+FF74 </td><td align="center"> ｴ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3048 </td><td align="center"> え </td></tr>
        /// <tr><td align="center"> U+FF6B </td><td align="center"> ｫ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3049 </td><td align="center"> ぉ </td></tr>
        /// <tr><td align="center"> U+FF75 </td><td align="center"> ｵ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+304A </td><td align="center"> お </td></tr>
        /// <tr><td align="center"> U+FF76 </td><td align="center"> ｶ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+304B </td><td align="center"> か </td></tr>
        /// <tr><td align="center"> U+FF76 </td><td align="center"> ｶ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+304C </td><td align="center"> が </td></tr>
        /// <tr><td align="center"> U+FF76 </td><td align="center"> ｶ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+304C </td><td align="center"> が </td></tr>
        /// <tr><td align="center"> U+FF77 </td><td align="center"> ｷ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+304D </td><td align="center"> き </td></tr>
        /// <tr><td align="center"> U+FF77 </td><td align="center"> ｷ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+304E </td><td align="center"> ぎ </td></tr>
        /// <tr><td align="center"> U+FF77 </td><td align="center"> ｷ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+304E </td><td align="center"> ぎ </td></tr>
        /// <tr><td align="center"> U+FF78 </td><td align="center"> ｸ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+304F </td><td align="center"> く </td></tr>
        /// <tr><td align="center"> U+FF78 </td><td align="center"> ｸ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+3050 </td><td align="center"> ぐ </td></tr>
        /// <tr><td align="center"> U+FF78 </td><td align="center"> ｸ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+3050 </td><td align="center"> ぐ </td></tr>
        /// <tr><td align="center"> U+FF79 </td><td align="center"> ｹ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3051 </td><td align="center"> け </td></tr>
        /// <tr><td align="center"> U+FF79 </td><td align="center"> ｹ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+3052 </td><td align="center"> げ </td></tr>
        /// <tr><td align="center"> U+FF79 </td><td align="center"> ｹ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+3052 </td><td align="center"> げ </td></tr>
        /// <tr><td align="center"> U+FF7A </td><td align="center"> ｺ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3053 </td><td align="center"> こ </td></tr>
        /// <tr><td align="center"> U+FF7A </td><td align="center"> ｺ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+3054 </td><td align="center"> ご </td></tr>
        /// <tr><td align="center"> U+FF7A </td><td align="center"> ｺ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+3054 </td><td align="center"> ご </td></tr>
        /// <tr><td align="center"> U+FF7B </td><td align="center"> ｻ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3055 </td><td align="center"> さ </td></tr>
        /// <tr><td align="center"> U+FF7B </td><td align="center"> ｻ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+3056 </td><td align="center"> ざ </td></tr>
        /// <tr><td align="center"> U+FF7B </td><td align="center"> ｻ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+3056 </td><td align="center"> ざ </td></tr>
        /// <tr><td align="center"> U+FF7C </td><td align="center"> ｼ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3057 </td><td align="center"> し </td></tr>
        /// <tr><td align="center"> U+FF7C </td><td align="center"> ｼ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+3058 </td><td align="center"> じ </td></tr>
        /// <tr><td align="center"> U+FF7C </td><td align="center"> ｼ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+3058 </td><td align="center"> じ </td></tr>
        /// <tr><td align="center"> U+FF7D </td><td align="center"> ｽ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3059 </td><td align="center"> す </td></tr>
        /// <tr><td align="center"> U+FF7D </td><td align="center"> ｽ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+305A </td><td align="center"> ず </td></tr>
        /// <tr><td align="center"> U+FF7D </td><td align="center"> ｽ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+305A </td><td align="center"> ず </td></tr>
        /// <tr><td align="center"> U+FF7E </td><td align="center"> ｾ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+305B </td><td align="center"> せ </td></tr>
        /// <tr><td align="center"> U+FF7E </td><td align="center"> ｾ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+305C </td><td align="center"> ぜ </td></tr>
        /// <tr><td align="center"> U+FF7E </td><td align="center"> ｾ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+305C </td><td align="center"> ぜ </td></tr>
        /// <tr><td align="center"> U+FF7F </td><td align="center"> ｿ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+305D </td><td align="center"> そ </td></tr>
        /// <tr><td align="center"> U+FF7F </td><td align="center"> ｿ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+305E </td><td align="center"> ぞ </td></tr>
        /// <tr><td align="center"> U+FF7F </td><td align="center"> ｿ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+305E </td><td align="center"> ぞ </td></tr>
        /// <tr><td align="center"> U+FF80 </td><td align="center"> ﾀ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+305F </td><td align="center"> た </td></tr>
        /// <tr><td align="center"> U+FF80 </td><td align="center"> ﾀ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+3060 </td><td align="center"> だ </td></tr>
        /// <tr><td align="center"> U+FF80 </td><td align="center"> ﾀ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+3060 </td><td align="center"> だ </td></tr>
        /// <tr><td align="center"> U+FF81 </td><td align="center"> ﾁ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3061 </td><td align="center"> ち </td></tr>
        /// <tr><td align="center"> U+FF81 </td><td align="center"> ﾁ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+3062 </td><td align="center"> ぢ </td></tr>
        /// <tr><td align="center"> U+FF81 </td><td align="center"> ﾁ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+3062 </td><td align="center"> ぢ </td></tr>
        /// <tr><td align="center"> U+FF6F </td><td align="center"> ｯ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3063 </td><td align="center"> っ </td></tr>
        /// <tr><td align="center"> U+FF82 </td><td align="center"> ﾂ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3064 </td><td align="center"> つ </td></tr>
        /// <tr><td align="center"> U+FF82 </td><td align="center"> ﾂ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+3065 </td><td align="center"> づ </td></tr>
        /// <tr><td align="center"> U+FF82 </td><td align="center"> ﾂ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+3065 </td><td align="center"> づ </td></tr>
        /// <tr><td align="center"> U+FF83 </td><td align="center"> ﾃ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3066 </td><td align="center"> て </td></tr>
        /// <tr><td align="center"> U+FF83 </td><td align="center"> ﾃ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+3067 </td><td align="center"> で </td></tr>
        /// <tr><td align="center"> U+FF83 </td><td align="center"> ﾃ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+3067 </td><td align="center"> で </td></tr>
        /// <tr><td align="center"> U+FF84 </td><td align="center"> ﾄ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3068 </td><td align="center"> と </td></tr>
        /// <tr><td align="center"> U+FF84 </td><td align="center"> ﾄ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+3069 </td><td align="center"> ど </td></tr>
        /// <tr><td align="center"> U+FF84 </td><td align="center"> ﾄ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+3069 </td><td align="center"> ど </td></tr>
        /// <tr><td align="center"> U+FF85 </td><td align="center"> ﾅ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+306A </td><td align="center"> な </td></tr>
        /// <tr><td align="center"> U+FF86 </td><td align="center"> ﾆ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+306B </td><td align="center"> に </td></tr>
        /// <tr><td align="center"> U+FF87 </td><td align="center"> ﾇ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+306C </td><td align="center"> ぬ </td></tr>
        /// <tr><td align="center"> U+FF88 </td><td align="center"> ﾈ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+306D </td><td align="center"> ね </td></tr>
        /// <tr><td align="center"> U+FF89 </td><td align="center"> ﾉ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+306E </td><td align="center"> の </td></tr>
        /// <tr><td align="center"> U+FF8A </td><td align="center"> ﾊ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+306F </td><td align="center"> は </td></tr>
        /// <tr><td align="center"> U+FF8A </td><td align="center"> ﾊ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+3070 </td><td align="center"> ば </td></tr>
        /// <tr><td align="center"> U+FF8A </td><td align="center"> ﾊ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+3070 </td><td align="center"> ば </td></tr>
        /// <tr><td align="center"> U+FF8A </td><td align="center"> ﾊ </td><td align="center"> U+309A </td><td align="center"> *2 </td><td align="center"> U+3071 </td><td align="center"> ぱ </td></tr>
        /// <tr><td align="center"> U+FF8A </td><td align="center"> ﾊ </td><td align="center"> U+FF9F </td><td align="center"> ﾟ </td><td align="center"> U+3071 </td><td align="center"> ぱ </td></tr>
        /// <tr><td align="center"> U+FF8B </td><td align="center"> ﾋ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3072 </td><td align="center"> ひ </td></tr>
        /// <tr><td align="center"> U+FF8B </td><td align="center"> ﾋ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+3073 </td><td align="center"> び </td></tr>
        /// <tr><td align="center"> U+FF8B </td><td align="center"> ﾋ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+3073 </td><td align="center"> び </td></tr>
        /// <tr><td align="center"> U+FF8B </td><td align="center"> ﾋ </td><td align="center"> U+309A </td><td align="center"> *2 </td><td align="center"> U+3074 </td><td align="center"> ぴ </td></tr>
        /// <tr><td align="center"> U+FF8B </td><td align="center"> ﾋ </td><td align="center"> U+FF9F </td><td align="center"> ﾟ </td><td align="center"> U+3074 </td><td align="center"> ぴ </td></tr>
        /// <tr><td align="center"> U+FF8C </td><td align="center"> ﾌ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3075 </td><td align="center"> ふ </td></tr>
        /// <tr><td align="center"> U+FF8C </td><td align="center"> ﾌ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+3076 </td><td align="center"> ぶ </td></tr>
        /// <tr><td align="center"> U+FF8C </td><td align="center"> ﾌ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+3076 </td><td align="center"> ぶ </td></tr>
        /// <tr><td align="center"> U+FF8C </td><td align="center"> ﾌ </td><td align="center"> U+309A </td><td align="center"> *2 </td><td align="center"> U+3077 </td><td align="center"> ぷ </td></tr>
        /// <tr><td align="center"> U+FF8C </td><td align="center"> ﾌ </td><td align="center"> U+FF9F </td><td align="center"> ﾟ </td><td align="center"> U+3077 </td><td align="center"> ぷ </td></tr>
        /// <tr><td align="center"> U+FF8D </td><td align="center"> ﾍ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3078 </td><td align="center"> へ </td></tr>
        /// <tr><td align="center"> U+FF8D </td><td align="center"> ﾍ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+3079 </td><td align="center"> べ </td></tr>
        /// <tr><td align="center"> U+FF8D </td><td align="center"> ﾍ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+3079 </td><td align="center"> べ </td></tr>
        /// <tr><td align="center"> U+FF8D </td><td align="center"> ﾍ </td><td align="center"> U+309A </td><td align="center"> *2 </td><td align="center"> U+307A </td><td align="center"> ぺ </td></tr>
        /// <tr><td align="center"> U+FF8D </td><td align="center"> ﾍ </td><td align="center"> U+FF9F </td><td align="center"> ﾟ </td><td align="center"> U+307A </td><td align="center"> ぺ </td></tr>
        /// <tr><td align="center"> U+FF8E </td><td align="center"> ﾎ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+307B </td><td align="center"> ほ </td></tr>
        /// <tr><td align="center"> U+FF8E </td><td align="center"> ﾎ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+307C </td><td align="center"> ぼ </td></tr>
        /// <tr><td align="center"> U+FF8E </td><td align="center"> ﾎ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+307C </td><td align="center"> ぼ </td></tr>
        /// <tr><td align="center"> U+FF8E </td><td align="center"> ﾎ </td><td align="center"> U+309A </td><td align="center"> *2 </td><td align="center"> U+307D </td><td align="center"> ぽ </td></tr>
        /// <tr><td align="center"> U+FF8E </td><td align="center"> ﾎ </td><td align="center"> U+FF9F </td><td align="center"> ﾟ </td><td align="center"> U+307D </td><td align="center"> ぽ </td></tr>
        /// <tr><td align="center"> U+FF8F </td><td align="center"> ﾏ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+307E </td><td align="center"> ま </td></tr>
        /// <tr><td align="center"> U+FF90 </td><td align="center"> ﾐ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+307F </td><td align="center"> み </td></tr>
        /// <tr><td align="center"> U+FF91 </td><td align="center"> ﾑ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3080 </td><td align="center"> む </td></tr>
        /// <tr><td align="center"> U+FF92 </td><td align="center"> ﾒ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3081 </td><td align="center"> め </td></tr>
        /// <tr><td align="center"> U+FF93 </td><td align="center"> ﾓ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3082 </td><td align="center"> も </td></tr>
        /// <tr><td align="center"> U+FF6C </td><td align="center"> ｬ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3083 </td><td align="center"> ゃ </td></tr>
        /// <tr><td align="center"> U+FF94 </td><td align="center"> ﾔ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3084 </td><td align="center"> や </td></tr>
        /// <tr><td align="center"> U+FF6D </td><td align="center"> ｭ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3085 </td><td align="center"> ゅ </td></tr>
        /// <tr><td align="center"> U+FF95 </td><td align="center"> ﾕ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3086 </td><td align="center"> ゆ </td></tr>
        /// <tr><td align="center"> U+FF6E </td><td align="center"> ｮ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3087 </td><td align="center"> ょ </td></tr>
        /// <tr><td align="center"> U+FF96 </td><td align="center"> ﾖ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3088 </td><td align="center"> よ </td></tr>
        /// <tr><td align="center"> U+FF97 </td><td align="center"> ﾗ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3089 </td><td align="center"> ら </td></tr>
        /// <tr><td align="center"> U+FF98 </td><td align="center"> ﾘ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+308A </td><td align="center"> り </td></tr>
        /// <tr><td align="center"> U+FF99 </td><td align="center"> ﾙ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+308B </td><td align="center"> る </td></tr>
        /// <tr><td align="center"> U+FF9A </td><td align="center"> ﾚ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+308C </td><td align="center"> れ </td></tr>
        /// <tr><td align="center"> U+FF9B </td><td align="center"> ﾛ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+308D </td><td align="center"> ろ </td></tr>
        /// <tr><td align="center"> U+FF9C </td><td align="center"> ﾜ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+308F </td><td align="center"> わ </td></tr>
        /// <tr><td align="center"> U+FF66 </td><td align="center"> ｦ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3092 </td><td align="center"> を </td></tr>
        /// <tr><td align="center"> U+FF9D </td><td align="center"> ﾝ </td><td align="center"> </td><td align="center"> </td><td align="center"> U+3093 </td><td align="center"> ん </td></tr>
        /// <tr><td align="center"> U+FF73 </td><td align="center"> ｳ </td><td align="center"> U+3099 </td><td align="center"> *1 </td><td align="center"> U+3094 </td><td align="center"> ゔ </td></tr>
        /// <tr><td align="center"> U+FF73 </td><td align="center"> ｳ </td><td align="center"> U+FF9E </td><td align="center"> ﾞ </td><td align="center"> U+3094 </td><td align="center"> ゔ </td></tr>
        /// </table>
        /// *1 COMBINING KATAKANA-HIRAGANA VOICED SOUND MARK <br />
        /// *2 COMBINING KATAKANA-HIRAGANA SEMI-VOICED SOUND MARK
        /// </remarks>
        public static string HalfwidthKatakanaToHiragana(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            return Convert(input, "HalfwidthKatakanaToHiragana.xml");
        }
    }
}
