using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Microsoft.International.Converters
{
    /// <exclude />
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [GeneratedCode("xsd", "2.0.50727.42")]
    [XmlType(AnonymousType = true)]
    [Serializable]
    public class ConversionTableConfig
    {
        private ConversionTableConversion[] itemsField;

        /// <remarks />
        [XmlElement("Conversion", Form = XmlSchemaForm.Unqualified)]
        public ConversionTableConversion[] Items
        {
            get => itemsField;
            set => itemsField = value;
        }
    }
}
