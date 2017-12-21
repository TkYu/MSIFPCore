using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Microsoft.International.Converters
{
    /// <exclude />
    [XmlType(AnonymousType = true)]
    [GeneratedCode("xsd", "2.0.50727.42")]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [Serializable]
    public class StateMachineConfig
    {
        private List<StateConfig> stateConfigList;
        private string entryStateField;
        private string charSetField;

        /// <exclude />
        [XmlElement("State", Form = XmlSchemaForm.Unqualified)]
        public List<StateConfig> States
        {
            get => stateConfigList;
            set => stateConfigList = value;
        }

        /// <exclude />
        [XmlAttribute]
        public string EntryState
        {
            get => entryStateField;
            set => entryStateField = value;
        }

        /// <exclude />
        [XmlAttribute]
        public string CharSet
        {
            get => charSetField;
            set => charSetField = value;
        }
    }
}
