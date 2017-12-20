using System;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.International.Converters.PinYinConverter
{
    internal class PinyinDictionary
    {
        internal readonly byte[] Reserved = new byte[8];
        internal readonly short EndMark = short.MaxValue;
        internal short Length;
        internal short Count;
        internal short Offset;
        internal List<PinyinUnit> PinyinUnitTable;

        internal void Serialize(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.Length);
            binaryWriter.Write(this.Count);
            binaryWriter.Write(this.Offset);
            binaryWriter.Write(this.Reserved);
            for (int index = 0; index < (int)this.Count; ++index)
                this.PinyinUnitTable[index].Serialize(binaryWriter);
            binaryWriter.Write(this.EndMark);
        }

        internal static PinyinDictionary Deserialize(BinaryReader binaryReader)
        {
            PinyinDictionary pinyinDictionary = new PinyinDictionary();
            binaryReader.ReadInt32();
            pinyinDictionary.Length = binaryReader.ReadInt16();
            pinyinDictionary.Count = binaryReader.ReadInt16();
            pinyinDictionary.Offset = binaryReader.ReadInt16();
            binaryReader.ReadBytes(8);
            pinyinDictionary.PinyinUnitTable = new List<PinyinUnit>();
            for (int index = 0; index < (int)pinyinDictionary.Count; ++index)
                pinyinDictionary.PinyinUnitTable.Add(PinyinUnit.Deserialize(binaryReader));
            int num = (int)binaryReader.ReadInt16();
            return pinyinDictionary;
        }

        internal int GetPinYinUnitIndex(string pinyin)
        {
            return PinyinUnitTable.FindIndex(new PinyinUnitPredicate(pinyin).Match);
        }

        internal PinyinUnit GetPinYinUnit(string pinyin)
        {
            return PinyinUnitTable.Find(new PinyinUnitPredicate(pinyin).Match);
        }

        internal PinyinUnit GetPinYinUnitByIndex(int index)
        {
            if (index < 0 || index >= (int)this.Count)
                throw new ArgumentOutOfRangeException(nameof(index), Properties.Resources.INDEX_OUT_OF_RANGE);
            return this.PinyinUnitTable[index];
        }
    }
}
