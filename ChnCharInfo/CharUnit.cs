using System.IO;

namespace Microsoft.International.Converters.PinYinConverter
{
    internal class CharUnit
    {
        internal char Char;
        internal byte StrokeNumber;
        internal byte PinyinCount;
        internal short[] PinyinIndexList;

        internal static CharUnit Deserialize(BinaryReader binaryReader)
        {
            CharUnit charUnit = new CharUnit();
            charUnit.Char = binaryReader.ReadChar();
            charUnit.StrokeNumber = binaryReader.ReadByte();
            charUnit.PinyinCount = binaryReader.ReadByte();
            charUnit.PinyinIndexList = new short[(int)charUnit.PinyinCount];
            for (int index = 0; index < (int)charUnit.PinyinCount; ++index)
                charUnit.PinyinIndexList[index] = binaryReader.ReadInt16();
            return charUnit;
        }

        internal void Serialize(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.Char);
            binaryWriter.Write(this.StrokeNumber);
            binaryWriter.Write(this.PinyinCount);
            for (int index = 0; index < (int)this.PinyinCount; ++index)
                binaryWriter.Write(this.PinyinIndexList[index]);
        }
    }
}
