using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Microsoft.International.Converters
{
    /// <exclude />
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [GeneratedCode("xsd", "2.0.50727.42")]
    [DebuggerStepThrough]
    [Serializable]
    public class RegexConfig
    {
        private string valueField;

        /// <remarks />
        [XmlText]
        public string Value
        {
            get => valueField;
            set => valueField = value;
        }
    }
}
