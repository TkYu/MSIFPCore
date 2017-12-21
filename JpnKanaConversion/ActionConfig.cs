using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Microsoft.International.Converters
{
    /// <exclude />
    [GeneratedCode("xsd", "2.0.50727.42")]
    [XmlType(AnonymousType = true)]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [Serializable]
    public class ActionConfig
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
