using System.IO;

namespace Microsoft.International.Converters.PinYinConverter
{
    internal class StrokeUnit
    {
        internal byte StrokeNumber;
        internal short CharCount;
        internal char[] CharList;

        internal static StrokeUnit Deserialize(BinaryReader binaryReader)
        {
            var strokeUnit = new StrokeUnit
            {
                StrokeNumber = binaryReader.ReadByte(),
                CharCount = binaryReader.ReadInt16()
            };
            strokeUnit.CharList = new char[(int)strokeUnit.CharCount];
            for (int index = 0; index < (int)strokeUnit.CharCount; ++index)
                strokeUnit.CharList[index] = binaryReader.ReadChar();
            return strokeUnit;
        }

        internal void Serialize(BinaryWriter binaryWriter)
        {
            if (CharCount == 0)
                return;
            binaryWriter.Write(StrokeNumber);
            binaryWriter.Write(CharCount);
            binaryWriter.Write(CharList);
        }
    }

    internal class StrokeUnitPredicate
    {
        private readonly int ExpectedStrokeNum;

        internal StrokeUnitPredicate(int strokeNum)
        {
            ExpectedStrokeNum = strokeNum;
        }

        internal bool Match(StrokeUnit strokeUnit)
        {
            return strokeUnit.StrokeNumber == ExpectedStrokeNum;
        }
    }
}
