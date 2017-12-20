﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.International.Converters.PinYinConverter
{
    internal class HomophoneDictionary
    {
        internal readonly byte[] Reserved = new byte[8];
        internal readonly short EndMark = short.MaxValue;
        internal int Length;
        internal short Offset;
        internal short Count;
        internal List<HomophoneUnit> HomophoneUnitTable;

        internal void Serialize(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.Length);
            binaryWriter.Write(this.Count);
            binaryWriter.Write(this.Offset);
            binaryWriter.Write(this.Reserved);
            for (int index = 0; index < (int)this.Count; ++index)
                this.HomophoneUnitTable[index].Serialize(binaryWriter);
            binaryWriter.Write(this.EndMark);
        }

        internal static HomophoneDictionary Deserialize(BinaryReader binaryReader)
        {
            HomophoneDictionary homophoneDictionary = new HomophoneDictionary();
            binaryReader.ReadInt32();
            homophoneDictionary.Length = binaryReader.ReadInt32();
            homophoneDictionary.Count = binaryReader.ReadInt16();
            homophoneDictionary.Offset = binaryReader.ReadInt16();
            binaryReader.ReadBytes(8);
            homophoneDictionary.HomophoneUnitTable = new List<HomophoneUnit>();
            for (int index = 0; index < (int)homophoneDictionary.Count; ++index)
                homophoneDictionary.HomophoneUnitTable.Add(HomophoneUnit.Deserialize(binaryReader));
            int num = (int)binaryReader.ReadInt16();
            return homophoneDictionary;
        }

        internal HomophoneUnit GetHomophoneUnit(int index)
        {
            if (index < 0 || index >= (int)this.Count)
                throw new ArgumentOutOfRangeException(nameof(index), Properties.Resources.INDEX_OUT_OF_RANGE);
            return this.HomophoneUnitTable[index];
        }

        internal HomophoneUnit GetHomophoneUnit(PinyinDictionary pinyinDictionary, string pinyin)
        {
            return this.GetHomophoneUnit(pinyinDictionary.GetPinYinUnitIndex(pinyin));
        }
    }
}
