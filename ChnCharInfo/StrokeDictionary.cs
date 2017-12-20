using System;
using System.Collections.Generic;
using System.IO;

namespace Microsoft.International.Converters.PinYinConverter
{
    internal class StrokeDictionary
    {
        internal readonly byte[] Reserved = new byte[24];
        internal readonly short EndMark = short.MaxValue;
        internal const short MaxStrokeNumber = 48;
        internal int Length;
        internal int Count;
        internal short Offset;
        internal List<StrokeUnit> StrokeUnitTable;

        internal void Serialize(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.Length);
            binaryWriter.Write(this.Count);
            binaryWriter.Write(this.Offset);
            binaryWriter.Write(this.Reserved);
            for (int index = 0; index < this.Count; ++index)
                this.StrokeUnitTable[index].Serialize(binaryWriter);
            binaryWriter.Write(this.EndMark);
        }

        internal static StrokeDictionary Deserialize(BinaryReader binaryReader)
        {
            StrokeDictionary strokeDictionary = new StrokeDictionary();
            binaryReader.ReadInt32();
            strokeDictionary.Length = binaryReader.ReadInt32();
            strokeDictionary.Count = binaryReader.ReadInt32();
            strokeDictionary.Offset = binaryReader.ReadInt16();
            binaryReader.ReadBytes(24);
            strokeDictionary.StrokeUnitTable = new List<StrokeUnit>();
            for (int index = 0; index < strokeDictionary.Count; ++index)
                strokeDictionary.StrokeUnitTable.Add(StrokeUnit.Deserialize(binaryReader));
            int num = (int)binaryReader.ReadInt16();
            return strokeDictionary;
        }

        internal StrokeUnit GetStrokeUnitByIndex(int index)
        {
            if (index < 0 || index >= this.Count)
                throw new ArgumentOutOfRangeException(nameof(index), Properties.Resources.INDEX_OUT_OF_RANGE);
            return this.StrokeUnitTable[index];
        }

        internal StrokeUnit GetStrokeUnit(int strokeNum)
        {
            if (strokeNum <= 0 || strokeNum > 48)
                throw new ArgumentOutOfRangeException(nameof(strokeNum));
            return this.StrokeUnitTable.Find(new Predicate<StrokeUnit>(new StrokeUnitPredicate(strokeNum).Match));
        }
    }
}