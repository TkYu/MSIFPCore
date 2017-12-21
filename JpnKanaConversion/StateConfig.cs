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
    [DesignerCategory("code")]
    [GeneratedCode("xsd", "2.0.50727.42")]
    [XmlType(AnonymousType = true)]
    [DebuggerStepThrough]
    [Serializable]
    public class StateConfig
    {
        private List<TransitionConfig> transitionConfigList;
        private string idField;

        /// <exclude />
        [XmlElement("StateTransition", Form = XmlSchemaForm.Unqualified)]
        public List<TransitionConfig> Transitions
        {
            get => transitionConfigList;
            set => transitionConfigList = value;
        }

        /// <exclude />
        [XmlAttribute]
        public string ID
        {
            get => idField;
            set => idField = value;
        }
    }
}
