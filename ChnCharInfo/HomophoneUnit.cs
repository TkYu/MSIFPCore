using System.IO;

namespace Microsoft.International.Converters.PinYinConverter
{
    internal class HomophoneUnit
    {
        internal short Count;
        internal char[] HomophoneList;

        internal static HomophoneUnit Deserialize(BinaryReader binaryReader)
        {
            HomophoneUnit homophoneUnit = new HomophoneUnit();
            homophoneUnit.Count = binaryReader.ReadInt16();
            homophoneUnit.HomophoneList = new char[(int)homophoneUnit.Count];
            for (int index = 0; index < (int)homophoneUnit.Count; ++index)
                homophoneUnit.HomophoneList[index] = binaryReader.ReadChar();
            return homophoneUnit;
        }

        internal void Serialize(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(this.Count);
            for (int index = 0; index < (int)this.Count; ++index)
                binaryWriter.Write(this.HomophoneList[index]);
        }
    }
}
