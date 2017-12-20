using System.IO;
using System.Text;

namespace Microsoft.International.Converters.PinYinConverter
{
    internal class PinyinUnit
    {
        internal string Pinyin;

        internal static PinyinUnit Deserialize(BinaryReader binaryReader)
        {
            PinyinUnit pinyinUnit = new PinyinUnit();
            byte[] bytes = binaryReader.ReadBytes(7);
            pinyinUnit.Pinyin = Encoding.ASCII.GetString(bytes, 0, 7);
            char[] chArray = new char[1];
            pinyinUnit.Pinyin = pinyinUnit.Pinyin.TrimEnd(chArray);
            return pinyinUnit;
        }

        internal void Serialize(BinaryWriter binaryWriter)
        {
            byte[] numArray = new byte[7];
            Encoding.ASCII.GetBytes(this.Pinyin, 0, this.Pinyin.Length, numArray, 0);
            binaryWriter.Write(numArray);
        }
    }

    internal class PinyinUnitPredicate
    {
        private readonly string ExpectedPinyin;

        internal PinyinUnitPredicate(string pinyin)
        {
            ExpectedPinyin = pinyin;
        }

        internal bool Match(PinyinUnit pinyinUnit)
        {
            return string.Compare(pinyinUnit.Pinyin, ExpectedPinyin, true, System.Globalization.CultureInfo.CurrentCulture) == 0;
        }
    }
}
