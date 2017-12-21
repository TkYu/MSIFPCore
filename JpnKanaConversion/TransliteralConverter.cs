using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Microsoft.International.Converters
{
    /// <summary>
    /// <see cref="T:Microsoft.International.Converters.TransliteralConverter" /> provides a state machine
    /// to convert one string contained in <see cref="P:Microsoft.International.Converters.TransliteralConverter.Input" /> property
    /// to another character set according to the xml configuration file.
    /// <see cref="T:Microsoft.International.Converters.TransliteralConverter" /> is a method that produces transformed characters in <see cref="P:Microsoft.International.Converters.TransliteralConverter.Output" /> property, and also
    /// produces an event as a state machine transition to a different state. The transition
    /// data is configurable and read from an XML file.
    /// </summary>
    /// <remarks>
    /// <FONT size="8"><p><b>Transliteral Converter Configuration Schema</b></p></FONT>
    /// <FONT size="5">
    /// <p>The configuration specifies the conversion rules for transliteral converter.</p>
    /// <p>
    /// <pre>&lt;AutoConverterConfig&gt;</pre><br />
    /// <pre>  &lt;StateMachineConfig&gt;</pre><br />
    /// <pre>    &lt;State&gt;</pre><br />
    /// <pre>      &lt;StateTransition&gt;</pre><br />
    /// <pre>        &lt;InputValidatiors&gt;</pre><br />
    /// <pre>          &lt;Regex&gt;</pre><br />
    /// <pre>        &lt;Actions&gt;</pre><br />
    /// <pre>          &lt;Action&gt;</pre><br />
    /// <pre>  &lt;ConversionTable&gt;</pre><br />
    /// <pre>    &lt;Conversion&gt;</pre><br />
    /// </p>
    /// </FONT>
    /// <p>
    /// <table border="1" cellspacing="0" cellpadding="0" bordercolor="gray" width="100%">
    /// <thead>
    /// <tr bgcolor="gray">
    /// <th>Element</th>
    /// <th>Description</th>
    /// </tr>
    /// </thead>
    /// <tbody>
    /// <tr>
    /// <td>AutoConverterConfig</td>
    /// <td>The root element of configuration file.</td>
    /// </tr>
    /// <tr>
    /// <td>StateMachineConfig</td>
    /// <td>
    /// Represents the configuration of state machine.<br /><br />
    /// <table align="middle" border="1" cellspacing="0" cellpadding="0" bordercolor="gray" width="80%">
    /// <thead>
    /// <tr bgcolor="gray">
    /// <th>Attribute</th>
    /// <th>Description</th>
    /// </tr>
    /// </thead>
    /// <tbody>
    /// <tr>
    /// <td>EntryState</td>
    /// <td>Specifies the identify of entry state.</td>
    /// </tr>
    /// <tr>
    /// <td>CharSet</td>
    /// <td>Specifies the valid characters which can be converted.</td>
    /// </tr>
    /// </tbody>
    /// </table>
    /// <br />
    /// </td>
    /// </tr>
    /// <tr>
    /// <td>State</td>
    /// <td>Represents a state in state machine.<br /><br />
    /// <table align="middle" border="1" cellspacing="0" cellpadding="0" bordercolor="gray" width="80%">
    /// <thead>
    /// <tr bgcolor="gray">
    /// <th>Attribute</th>
    /// <th>Description</th>
    /// </tr>
    /// </thead>
    /// <tbody>
    /// <tr>
    /// <td>ID</td>
    /// <td>Specifies the identity of this state.</td>
    /// </tr>
    /// </tbody>
    /// </table>
    /// <br />
    /// </td>
    /// </tr>
    /// <tr>
    /// <td>StateTransition</td>
    /// <td>
    /// Represents a transition from current state to another.<br /><br />
    /// <table align="middle" border="1" cellspacing="0" cellpadding="0" bordercolor="gray" width="80%">
    /// <thead>
    /// <tr bgcolor="gray">
    /// <th>Attribute</th>
    /// <th>Description</th>
    /// </tr>
    /// </thead>
    /// <tbody>
    /// <tr>
    /// <td>ID</td>
    /// <td>Specifies the identity of next state.</td>
    /// </tr>
    /// </tbody>
    /// </table>
    /// <br />
    /// </td>
    /// </tr>
    /// <tr>
    /// <td>InputValidators</td>
    /// <td>Includes several regular expressions to verify user's input string. If one of the regular expressions is matched, the state machine will take actions indicated in <b>&lt;Actions&gt;</b> element.</td>
    /// </tr>
    /// <tr>
    /// <td>Regex</td>
    /// <td>Represents the regular expression to verify user's input.</td>
    /// </tr>
    /// <tr>
    /// <td>Actions</td>
    /// <td>Includes a series of actions state machine will undertake.</td>
    /// </tr>
    /// <tr>
    /// <td>Action</td>
    /// <td>
    /// Represents one of state machine's actions. The following action types are supported:<br />
    /// <list type="bullet">
    /// <item>Append(char)</item>
    /// <item>AppendInput</item>
    /// <item>ConvertToOutput</item>
    /// <item>Clear</item>
    /// </list>
    /// </td>
    /// </tr>
    /// <tr>
    /// <td>ConversionTable</td>
    /// <td>Contains the <b>&lt;Conversion&gt;</b> elements.</td></tr>
    /// <tr>
    /// <td>Conversion</td>
    /// <td>
    /// A pair of strings which represent an atomic conversion unit in source and destination character sets. <br /><br />
    /// <table align="middle" border="1" cellspacing="0" cellpadding="0" bordercolor="gray" width="80%">
    /// <thead>
    /// <tr bgcolor="gray">
    /// <th>Attribute</th>
    /// <th>Description</th>
    /// </tr>
    /// </thead>
    /// <tbody>
    /// <tr>
    /// <td>Input</td>
    /// <td>Specifies the source string to be converted.</td>
    /// </tr>
    /// <tr>
    /// <td>Output</td>
    /// <td>Specifies the conversion result.</td>
    /// </tr>
    /// </tbody>
    /// </table>
    /// <br />
    /// </td>
    /// </tr>
    /// </tbody>
    /// </table>
    /// </p>
    /// </remarks>
    /// <example>
    /// The following xml demonstrates a sample config xml with the behavior of transforming between English characters and Greek alphabet.
    /// <code source="../Code/TransliteralConverter.xml" lang="xml"></code>
    /// The following code demonstrates the behavior of <see cref="T:Microsoft.International.Converters.TransliteralConverter" />.
    /// Note, the configuration file must be named TransliteralConverter.xml and be located in the same folder with the application.
    /// <code source="../../ExampleJpnKanaConversion_CS/Program.cs" lang="cs"></code>
    /// <code source="../../ExampleJpnKanaConversion_VB/ConverterDemo.vb" lang="vbnet"></code>
    /// <code source="../../ExampleJpnKanaConversion_CPP/ExampleJpnKanaConversion_CPP.cpp" lang="cpp"></code>
    /// The preceding code produces the following output:
    /// θαεζdefg
    /// </example>
    public class TransliteralConverter
    {
        /// <summary>
        /// This <see cref="T:System.IO.TextReader" /> contains string to be converted.
        /// </summary>
        private TextReader input;
        /// <summary>
        /// This <see cref="T:System.IO.TextWriter" /> contains the result of converted string.
        /// </summary>
        private TextWriter output;
        /// <summary>
        /// This StateMachine is used to convert one character set to another.
        /// </summary>
        private StateMachine stateMachine;

        /// <summary>Occurs when state changes.</summary>
        /// <remarks>
        /// See <see cref="T:Microsoft.International.Converters.TransliteralConverter" /> for an example of using TransliteralConverter.
        /// </remarks>
        public event EventHandler<StateChangedEventArgs> StateChanged;

        /// <summary>Gets input characters.</summary>
        /// <value>Input characters.</value>
        /// <remarks>
        /// <p><see cref="T:Microsoft.International.Converters.TransliteralConverter" /> reads characters from Input property values and tries to convert them.
        /// The default value of Input will be <see cref="P:System.Console.In" />.</p>
        /// <p>See <see cref="T:Microsoft.International.Converters.TransliteralConverter" /> for an example of using TransliteralConverter.</p>
        /// </remarks>
        public TextReader Input
        {
            get
            {
                return this.input;
            }
        }

        /// <summary>Gets the result of converted string.</summary>
        /// <value>The result of converted string.</value>
        /// <remarks>
        /// <p>When conversion is possible, StateMachine puts the converted string into Output property value.
        /// The default value of Output will be <see cref="P:System.Console.Out" />.</p>
        /// <p>See <see cref="T:Microsoft.International.Converters.TransliteralConverter" /> for an example of using TransliteralConverter.</p>
        /// </remarks>
        public TextWriter Output
        {
            get
            {
                return this.output;
            }
        }

        /// <summary>
        /// Creates a new instance of TransliteralConverter using current directory as
        /// default location of configuration file, <see cref="P:System.Console.In" /> as default input and
        /// <see cref="P:System.Console.Out" /> as default output.
        /// </summary>
        /// <remarks>
        /// <p>The default input will be <see cref="P:System.Console.In" />.
        /// The default output will be <see cref="P:System.Console.Out" />.
        /// The default location of the configuration file is the current directory. If the name of configuration file
        /// is not provided, it will be "TransliteralConverter.xml". Its format can be found in <see cref="T:Microsoft.International.Converters.TransliteralConverter" />. </p>
        /// <p>See <see cref="T:Microsoft.International.Converters.TransliteralConverter" /> for an example of using TransliteralConverter.</p>
        /// </remarks>
        public TransliteralConverter()
          : this(Console.In)
        {
        }

        /// <summary>
        /// Creates a new instance using current directory as
        /// default location of configuration file and <see cref="P:System.Console.Out" /> as default output.
        /// </summary>
        /// <param name="input">This <see cref="T:System.IO.TextReader" /> contains user input to be converted</param>
        /// <remarks>
        /// <p>The default output will be <see cref="P:System.Console.Out" />.
        /// The default location of configuration file is the current directory. Its format can be found in <see cref="T:Microsoft.International.Converters.TransliteralConverter" />.</p>
        /// <p>See <see cref="T:Microsoft.International.Converters.TransliteralConverter" /> for an example of using TransliteralConverter.</p>
        /// </remarks>
        public TransliteralConverter(TextReader input)
          : this(input, Console.Out)
        {
        }

        /// <summary>
        /// Creates a new instance using current directory as
        /// default location of configuration file.
        /// </summary>
        /// <param name="input">This <see cref="T:System.IO.TextReader" /> contains user's input to be converted.</param>
        /// <param name="output">This <see cref="T:System.IO.TextWriter" /> writes a sequential series of converted characters.</param>
        /// <remarks>
        /// <p>The default location of configuration file is the current directory. Its format can be found in <see cref="T:Microsoft.International.Converters.TransliteralConverter" />.</p>
        /// <p>See <see cref="T:Microsoft.International.Converters.TransliteralConverter" /> for an example of using TransliteralConverter.</p>
        /// </remarks>
        public TransliteralConverter(TextReader input, TextWriter output)
          : this(input, output, "")
        {
        }

        /// <summary>Creates a new instance.</summary>
        /// <param name="input">This <see cref="T:System.IO.TextReader" /> contains input to be converted</param>
        /// <param name="output">This <see cref="T:System.IO.TextWriter" /> writes a sequential series of converted characters.</param>
        /// <param name="configFilePath">The name of the configuration file.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// input,output and configFilePath are null references.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// Length of configFilePath is zero(0).
        /// </exception>
        /// <remarks>
        /// <p>The format of the configuration file can be found in <see cref="T:Microsoft.International.Converters.TransliteralConverter" />.</p>
        /// <p>See <see cref="T:Microsoft.International.Converters.TransliteralConverter" /> for an example of using TransliteralConverter.</p>
        /// </remarks>
        public TransliteralConverter(TextReader input, TextWriter output, string configFilePath)
        {
            this.input = input ?? throw new ArgumentNullException(nameof(input));
            this.output = output ?? throw new ArgumentNullException(nameof(output));
            if (string.IsNullOrEmpty(configFilePath))
            {
                using (var ms = new MemoryStream(Properties.Resources.TransliteralConverterDefault))
                    LoadConfigXmlStream(ms);
            }
            else
            {
                if (!File.Exists(configFilePath))
                    throw new ArgumentException(Properties.Resources.INVALID_CONFIG_FILE_PATH, nameof(configFilePath));
                using (var fileStream = File.Open(configFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    LoadConfigXmlStream(fileStream);
            }
        }

        /// <summary>Creates a new instance.</summary>
        /// <param name="input">This <see cref="T:System.IO.TextReader" /> contains user's input to be converted</param>
        /// <param name="output">This <see cref="T:System.IO.TextWriter" /> writes a sequential series of converted characters.</param>
        /// <param name="configStream">Stream of config file.</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// input,output and configStream are null references.
        /// </exception>
        /// <remarks>
        /// See <see cref="T:Microsoft.International.Converters.TransliteralConverter" /> for an example of using TransliteralConverter.
        /// </remarks>
        public TransliteralConverter(TextReader input, TextWriter output, Stream configStream)
        {
            if (configStream == null)
                throw new ArgumentNullException(nameof(configStream));
            this.input = input ?? throw new ArgumentNullException(nameof(input));
            this.output = output ?? throw new ArgumentNullException(nameof(output));
            this.LoadConfigXmlStream(configStream);
        }

        /// <summary>
        /// Processes the data in sequence and execution is completely controlled by the user.
        /// </summary>
        /// <returns>The output of state machine.</returns>
        /// <remarks>
        /// <p>The internal state changing process doesn’t have to be ended, but it still may produce a candidate stored in the buffer.
        /// If there is no conversion possible, empty string ("") is returned.</p>
        /// <p>See <see cref="T:Microsoft.International.Converters.TransliteralConverter" /> for an example of using TransliteralConverter.</p>
        /// </remarks>
        public string Step()
        {
            return this.StepWith(Convert.ToChar(this.Input.Read()));
        }

        /// <summary>
        /// Processes the data in sequence and execution is completely controlled by the user.
        /// </summary>
        /// <param name="ch">Character to be converted.</param>
        /// <returns>Converted result of buffer.</returns>
        /// <seealso cref="M:Microsoft.International.Converters.TransliteralConverter.Step" />
        /// <remarks>
        /// See <see cref="T:Microsoft.International.Converters.TransliteralConverter" /> for an example of using TransliteralConverter.
        /// </remarks>
        public string StepWith(char ch)
        {
            return this.stateMachine.Transit(ch) + this.stateMachine.conversionMap.Convert(this.stateMachine.buffer.Content) ?? string.Empty;
        }

        /// <summary>
        /// Processes the data in sequence and execution is completely controlled by the user.
        /// </summary>
        /// <param name="s">String to be converted.</param>
        /// <returns>Converted result of buffer.</returns>
        /// <seealso cref="M:Microsoft.International.Converters.TransliteralConverter.Step" />
        /// <exception cref="T:System.ArgumentNullException">
        /// s is a null reference.
        /// </exception>
        /// <remarks>
        /// See <see cref="T:Microsoft.International.Converters.TransliteralConverter" /> for an example of using TransliteralConverter.
        /// </remarks>
        public string StepWith(string s)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char ch in s)
                stringBuilder.Append(this.stateMachine.Transit(ch));
            stringBuilder.Append(this.stateMachine.conversionMap.Convert(this.stateMachine.buffer.Content) ?? string.Empty);
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Processes the data using Transit(char ch) method in StateMachine class.
        /// </summary>
        /// <remarks>
        /// See <see cref="T:Microsoft.International.Converters.TransliteralConverter" /> for an example of using TransliteralConverter.
        /// </remarks>
        public void Run()
        {
            while (this.input.Peek() != -1)
                this.stateMachine.Transit(Convert.ToChar(this.input.Read()));
            this.stateMachine.End();
        }

        /// <summary>Called when the state changes.</summary>
        /// <param name="e">Event data including previous state and next state.</param>
        protected virtual void OnStateChanged(StateChangedEventArgs e)
        {
            StateChanged?.Invoke(this, e);
        }

        private void LoadConfigXmlStream(Stream stream)
        {
            using (var ms = new MemoryStream(Properties.Resources.AutoConverterConfig))
            {
                XmlReaderSettings settings = new XmlReaderSettings {ValidationType = ValidationType.Schema};
                XmlSchema schema = XmlSchema.Read(ms, null);
                settings.Schemas.Add(schema);
                stateMachine = new StateMachine(new XmlSerializer(typeof(AutoConverterConfig)).Deserialize(XmlReader.Create(stream, settings)) as AutoConverterConfig, output, InternalOnStateChanged);
            }
        }

        private void InternalOnStateChanged(object sender, StateChangedEventArgs e)
        {
            OnStateChanged(e);
        }
    }
}
