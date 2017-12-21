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
    public class TransitionConfig
    {
        private List<RegexConfig> inputValidatorsField;
        private List<ActionConfig> actionsField;
        private string idField;

        /// <exclude />
        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Regex", typeof(RegexConfig), Form = XmlSchemaForm.Unqualified)]
        public List<RegexConfig> InputValidators
        {
            get => inputValidatorsField;
            set => inputValidatorsField = value;
        }

        /// <remarks />
        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Action", typeof(ActionConfig), Form = XmlSchemaForm.Unqualified)]
        public List<ActionConfig> Actions
        {
            get => actionsField;
            set => actionsField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string ID
        {
            get => idField;
            set => idField = value;
        }
    }
}