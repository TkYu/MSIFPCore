using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Microsoft.International.Converters
{
    /// <exclude />
    [XmlRoot(IsNullable = false, Namespace = "")]
    [GeneratedCode("xsd", "2.0.50727.42")]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [Serializable]
    public class AutoConverterConfig
    {
        private StateMachineConfig stateMachineConfig;
        private ConversionTableConfig conersionTableConfig;
        /// <exclude />
        [XmlElement("StateMachineConfig", Form = XmlSchemaForm.Unqualified)]
        public StateMachineConfig StateMachineConfig
        {
            get => stateMachineConfig;
            set => stateMachineConfig = value;
        }

        /// <exclude />
        [XmlElement("ConversionTable", Form = XmlSchemaForm.Unqualified)]
        public ConversionTableConfig ConversionTableConfig
        {
            get => conersionTableConfig;
            set => conersionTableConfig = value;
        }
    }
}
