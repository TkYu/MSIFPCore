using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Microsoft.International.Converters.PinYinConverter
{
    internal class CharDictionary
    {
        internal readonly byte[] Reserved = new byte[24];
        internal readonly short EndMark = short.MaxValue;
        internal int Length;
        internal int Count;
        internal short Offset;
        internal List<CharUnit> CharUnitTable;

        internal void Serialize(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.Length);
            binaryWriter.Write(this.Count);
            binaryWriter.Write(this.Offset);
            binaryWriter.Write(this.Reserved);
            for (int index = 0; index < this.Count; ++index)
                this.CharUnitTable[index].Serialize(binaryWriter);
            binaryWriter.Write(this.EndMark);
        }

        internal static CharDictionary Deserialize(BinaryReader binaryReader)
        {
            CharDictionary charDictionary = new CharDictionary();
            binaryReader.ReadInt32();
            charDictionary.Length = binaryReader.ReadInt32();
            charDictionary.Count = binaryReader.ReadInt32();
            charDictionary.Offset = binaryReader.ReadInt16();
            binaryReader.ReadBytes(24);
            charDictionary.CharUnitTable = new List<CharUnit>();
            for (int index = 0; index < charDictionary.Count; ++index)
                charDictionary.CharUnitTable.Add(CharUnit.Deserialize(binaryReader));
            var num = binaryReader.ReadInt16();
            return charDictionary;
        }

        internal CharUnit GetCharUnit(int index)
        {
            if (index < 0 || index >= this.Count)
                throw new ArgumentOutOfRangeException(nameof(index), Properties.Resources.INDEX_OUT_OF_RANGE);
            return CharUnitTable[index];
        }

        internal CharUnit GetCharUnit(char ch)
        {
            return CharUnitTable.Find(new CharUnitPredicate(ch).Match);
        }
    }

    internal class CharUnitPredicate
    {
        private readonly char ExpectedChar;

        internal CharUnitPredicate(char ch)
        {
            ExpectedChar = ch;
        }

        internal bool Match(CharUnit charUnit)
        {
            return charUnit.Char == ExpectedChar;
        }
    }
}
