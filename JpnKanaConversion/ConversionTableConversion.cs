using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Microsoft.International.Converters
{
    /// <exclude />
    [XmlType(AnonymousType = true)]
    [DebuggerStepThrough]
    [GeneratedCode("xsd", "2.0.50727.42")]
    [DesignerCategory("code")]
    [Serializable]
    public class ConversionTableConversion
    {
        private string inputField;
        private string outputField;

        /// <remarks />
        [XmlAttribute]
        public string Input
        {
            get => inputField;
            set => inputField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string Output
        {
            get => outputField;
            set => outputField = value;
        }
    }
}
