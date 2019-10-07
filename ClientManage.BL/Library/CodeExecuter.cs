using System;
using System.Collections;
using System.Text;
using System.Reflection;
using System.CodeDom.Compiler;

namespace ClientManage.BL.Library
{
    public class CodeExecuter
    {
        public CodeExecuter() : this(string.Empty) { }
        public CodeExecuter(string code)
        {
            _code = code;
            _references.Add("System.dll");
            _references.Add("System.Windows.Forms.dll");

            _usings.Add("System");
            _usings.Add("System.IO");
            _usings.Add("System.Windows.Forms");

#pragma warning disable 612,618
            _loCompiler = CodeDomProvider.CreateProvider("C#").CreateCompiler();
#pragma warning restore 612,618
            _loParameters = new CompilerParameters();
        }

        private string _code = string.Empty;
        private string _namespace = "BizCare.Common";
        private string _className = "DummyCodeExecuted";
        private object _returnValue;
        private Exception _runningError;
        private readonly References _references = new References();
        private readonly Usings _usings = new Usings();
        private CompilerErrorCollection _complieErrors = new CompilerErrorCollection();
        private readonly ICodeCompiler _loCompiler;
        private readonly CompilerParameters _loParameters;
        public enum ExecutionResult { Success, CompileFail, RunFail };

        public string Code
        {
            get { return _code; }
            set {
                _returnValue = null;
                _code = value;
                _runningError = null;
                _complieErrors = new CompilerErrorCollection();
            }
        }
        public string Namespace
        {
            get { return _namespace; }
            set { _namespace = value; }
        }
        public string ClassName
        {
            get { return _className; }
            set { _className = value; }
        }
        public string ExecutionCode
        {
            get { return GetExecutionCode(); }
        }
        public object ReturnValue
        {
            get { return _returnValue; }
        }
        public Exception RunningError
        {
            get { return _runningError; }
        }
        public References References
        {
            get { return _references; }
        }
        public Usings Usings
        {
            get { return _usings; }
        }
        public CompilerErrorCollection ComplieErrors
        {
            get { return _complieErrors; }
        }

        private string GetExecutionCode()
        {
            var exeCode = new StringBuilder();
            
            // *** Start by adding any referenced assemblies
            foreach (string reference in _references)
            {
                _loParameters.ReferencedAssemblies.Add(reference);
            }

            // *** Must create a fully functional assembly as a string
            foreach (string use in _usings)
            {
                exeCode.Append("using " + use + ";\r\n");
            }

            exeCode.Append("\r\nnamespace " + _namespace + " \r\n{\r\n");
            exeCode.Append("\tpublic class " + _className + " \r\n\t{\r\n");
            exeCode.Append("\t\tpublic object DynamicCode(params object[] Parameters) \r\n\t\t{\r\n");
            exeCode.Append("\t\t\t" + _code.Trim().Replace("\r\n", "\r\n\t\t\t"));
            exeCode.Append("\r\n\t\t}\r\n\t}\r\n}\r\n");

            return exeCode.ToString();
        }

        public ExecutionResult Execute()
        {               
            // *** Load the resulting assembly into memory
            _loParameters.GenerateInMemory = false;
            
            // *** Now compile the whole thing
            var loCompiled = _loCompiler.CompileAssemblyFromSource(_loParameters, this.GetExecutionCode());

            if (loCompiled.Errors.HasErrors)
            {
                _complieErrors = loCompiled.Errors;
                return ExecutionResult.CompileFail;
            }
            
            var loAssembly = loCompiled.CompiledAssembly;
            
            // *** Retrieve an obj ref – generic type only
            var loObject = loAssembly.CreateInstance(_namespace + "." + _className);

            if (loObject == null)
            {
                _runningError = new Exception("Couldn't load class");
                return ExecutionResult.RunFail;
            }
            
            var loCodeParms = new object[1];
            loCodeParms[0] = "BizCare Solutions";

            try
            {
                var loResult = loObject.GetType().InvokeMember(
                    "DynamicCode", BindingFlags.InvokeMethod,
                    null, loObject, loCodeParms);

                _returnValue = loResult;
                return ExecutionResult.Success;
            }

            catch (Exception loError)
            {
                _runningError = loError;
                return ExecutionResult.RunFail;
            }
        }
    }

    public class References : CollectionBase
    {
        public string this[int index]
        {
            get{ return List[index].ToString(); }
        }

        public void Remove(string value)
        {
            List.Remove(value);
        }

        public void Add(string value)
        {
            List.Add(value);
        }
    
    }

    public class Usings : CollectionBase
    {
        public string this[int index]
        {
            get { return List[index].ToString(); }
        }

        public void Remove(string value)
        {
            List.Remove(value);
        }

        public void Add(string value)
        {
            List.Add(value);
        }

    }
}
