// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 17.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace TypedSignalR.Client.TypeScript.Templates
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public partial class ApiTemplate : ApiTemplateBase
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("/* THIS (.ts) FILE IS GENERATED BY TypedSignalR.Client.TypeScript */\r\n/* eslint-d" +
                    "isable */\r\n/* tslint:disable */\r\n");
            this.Write(this.ToStringHelper.ToStringWithCulture(Header));
            this.Write(@"

// components

export type Disposable = {
    dispose(): void;
}

export type HubProxyFactory<T> = {
    createHubProxy(connection: HubConnection): T;
}

export type ReceiverRegister<T> = {
    register(connection: HubConnection, receiver: T): Disposable;
}

type ReceiverMethod = {
    methodName: string,
    method: (...args: any[]) => void
}

class ReceiverMethodSubscription implements Disposable {

    public constructor(
        private connection: HubConnection,
        private receiverMethod: ReceiverMethod[]) {
    }

    public readonly dispose = () => {
        for (const it of this.receiverMethod) {
            this.connection.off(it.methodName, it.method);
        }
    }
}

// API

export type HubProxyFactoryProvider = {
");
 foreach(var hubType in HubTypes) { 
            this.Write("    (hubType: \"");
            this.Write(this.ToStringHelper.ToStringWithCulture(hubType.Name));
            this.Write("\"): HubProxyFactory<");
            this.Write(this.ToStringHelper.ToStringWithCulture(hubType.Name));
            this.Write(">;\r\n");
 } 
            this.Write("}\r\n\r\nexport const getHubProxyFactory = ((hubType: string) => {\r\n");
 foreach(var hubType in HubTypes) { 
            this.Write("    if(hubType === \"");
            this.Write(this.ToStringHelper.ToStringWithCulture(hubType.Name));
            this.Write("\") {\r\n        return ");
            this.Write(this.ToStringHelper.ToStringWithCulture(hubType.Name));
            this.Write("_HubProxyFactory.Instance;\r\n    }\r\n");
 } 
            this.Write("}) as HubProxyFactoryProvider;\r\n\r\nexport type ReceiverRegisterProvider = {\r\n");
 foreach(var receiverType in ReceiverTypes) { 
            this.Write("    (receiverType: \"");
            this.Write(this.ToStringHelper.ToStringWithCulture(receiverType.Name));
            this.Write("\"): ReceiverRegister<");
            this.Write(this.ToStringHelper.ToStringWithCulture(receiverType.Name));
            this.Write(">;\r\n");
 } 
            this.Write("}\r\n\r\nexport const getReceiverRegister = ((receiverType: string) => {\r\n");
 foreach(var receiverType in ReceiverTypes) { 
            this.Write("    if(receiverType === \"");
            this.Write(this.ToStringHelper.ToStringWithCulture(receiverType.Name));
            this.Write("\") {\r\n        return ");
            this.Write(this.ToStringHelper.ToStringWithCulture(receiverType.Name));
            this.Write("_Binder.Instance;\r\n    }\r\n");
 } 
            this.Write("}) as ReceiverRegisterProvider;\r\n\r\n// HubProxy\r\n\r\n");
 foreach(var hubType in HubTypes) { 
            this.Write("class ");
            this.Write(this.ToStringHelper.ToStringWithCulture(hubType.Name));
            this.Write("_HubProxyFactory implements HubProxyFactory<");
            this.Write(this.ToStringHelper.ToStringWithCulture(hubType.Name));
            this.Write("> {\r\n    public static Instance = new ");
            this.Write(this.ToStringHelper.ToStringWithCulture(hubType.Name));
            this.Write("_HubProxyFactory();\r\n\r\n    private constructor() {\r\n    }\r\n\r\n    public readonly " +
                    "createHubProxy = (connection: HubConnection): ");
            this.Write(this.ToStringHelper.ToStringWithCulture(hubType.Name));
            this.Write(" => {\r\n        return new ");
            this.Write(this.ToStringHelper.ToStringWithCulture(hubType.Name));
            this.Write("_HubProxy(connection);\r\n    }\r\n}\r\n\r\nclass ");
            this.Write(this.ToStringHelper.ToStringWithCulture(hubType.Name));
            this.Write("_HubProxy implements ");
            this.Write(this.ToStringHelper.ToStringWithCulture(hubType.Name));
            this.Write(" {\r\n\r\n    public constructor(private connection: HubConnection) {\r\n    }\r\n\r\n");
 foreach(var method in hubType.Methods) { 
            this.Write("    public readonly ");
            this.Write(this.ToStringHelper.ToStringWithCulture(method.Name.Format(TranspilationOptions.NamingStyle)));
            this.Write(" = async (");
            this.Write(this.ToStringHelper.ToStringWithCulture(method.ParametersToTypeScriptString(TranspilationOptions)));
            this.Write("): ");
            this.Write(this.ToStringHelper.ToStringWithCulture(method.ReturnTypeToTypeScriptString(TranspilationOptions)));
            this.Write(" => {\r\n        return await this.connection.invoke(\"");
            this.Write(this.ToStringHelper.ToStringWithCulture(method.Name));
            this.Write("\"");
            this.Write(this.ToStringHelper.ToStringWithCulture(method.Parameters.Any() ? ", " : ""));
            this.Write(this.ToStringHelper.ToStringWithCulture(string.Join(", ", method.Parameters.Select(x => x.Name))));
            this.Write(");\r\n    }\r\n");
 } 
            this.Write("}\r\n\r\n");
 } 
            this.Write("\r\n// Receiver\r\n\r\n");
 foreach(var receiverType in ReceiverTypes) { 
            this.Write("class ");
            this.Write(this.ToStringHelper.ToStringWithCulture(receiverType.Name));
            this.Write("_Binder implements ReceiverRegister<");
            this.Write(this.ToStringHelper.ToStringWithCulture(receiverType.Name));
            this.Write("> {\r\n\r\n    public static Instance = new ");
            this.Write(this.ToStringHelper.ToStringWithCulture(receiverType.Name));
            this.Write("_Binder();\r\n\r\n    private constructor() {\r\n    }\r\n\r\n    public readonly register " +
                    "= (connection: HubConnection, receiver: ");
            this.Write(this.ToStringHelper.ToStringWithCulture(receiverType.Name));
            this.Write("): Disposable => {\r\n\r\n");
 foreach(var method in receiverType.Methods) { 
            this.Write("        connection.on(\"");
            this.Write(this.ToStringHelper.ToStringWithCulture(method.Name));
            this.Write("\", receiver.");
            this.Write(this.ToStringHelper.ToStringWithCulture(method.Name.Format(TranspilationOptions.NamingStyle)));
            this.Write(");\r\n");
 } 
            this.Write("\r\n        const methodList: ReceiverMethod[] = [\r\n");
 for(int i = 0; i < receiverType.Methods.Count; i++) { 
            this.Write("            { methodName: \"");
            this.Write(this.ToStringHelper.ToStringWithCulture(receiverType.Methods[i].Name));
            this.Write("\", method: receiver.");
            this.Write(this.ToStringHelper.ToStringWithCulture(receiverType.Methods[i].Name.Format(TranspilationOptions.NamingStyle)));
            this.Write(" }");
            this.Write(this.ToStringHelper.ToStringWithCulture(i != receiverType.Methods.Count - 1 ? "," : ""));
            this.Write("\r\n");
 } 
            this.Write("        ]\r\n\r\n        return new ReceiverMethodSubscription(connection, methodList" +
                    ");\r\n    }\r\n}\r\n\r\n");
 } 
            return this.GenerationEnvironment.ToString();
        }
    }
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "17.0.0.0")]
    public class ApiTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
