using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevApp
{
    public enum ReturnType
    {
        Bool,
        String,
        Int,
        Double
    }
    public class FunctionToCall
    {
        public string Name { get; set; }
        // return type
        public ReturnType ReturnType { get; set; }

        public ReturnType Param1Type { get; set; }
        
        public Func<bool> FuncBool { get; set; }

        public Func<int> FuncInt { get; set; }
        public Func<int, int> FuncIntRetInt { get; set; }
       
    }

    public class FunctionToCallMapper<TP1, TRet>
    {
        public FunctionToCallMapper()
        {
        }

        /// <summary>
        /// Get return and parameter infos:
        /// bool Boolean
        /// int  Int32.
        /// </summary>
        /// <param name="func"></param>
        public void AddFunction(Func<TP1, TRet> func)
        {
            // get the type of the generic return value
            Type typeRet = func.Method.ReturnType;
            string typeRetName = typeRet.Name;

            // get the type of the parameter 1
            // Int32 pour int
            ParameterInfo[] parameterInfos = func.Method.GetParameters();
            Type typeP1= parameterInfos[0].ParameterType;
            string typeP1Name = typeP1.Name;

            // selon le type, créér un mapper avec la bonne signature
            // todo:
        }
    }

    /// <summary>
    /// to test how to implement functionCall.
    /// 
    /// </summary>
    public class ExprEvalTest
    {
        //public delegate TResult Func<in T, out TResult>(T arg);

        // list of function body
        List<FunctionToCall> _listFunctionToCall = new List<FunctionToCall>();


        public void AddFunction(Func<bool> funcBool)
        {
            FunctionToCall functionToCall = new FunctionToCall();
            functionToCall.ReturnType = ReturnType.Bool;
            functionToCall.FuncBool = funcBool;
            functionToCall.Name = funcBool.Method.Name;
            _listFunctionToCall.Add(functionToCall);
        }

        public void AddFunction(Func<int> funcInt)
        {
            FunctionToCall functionToCall = new FunctionToCall();
            functionToCall.ReturnType = ReturnType.Int;
            functionToCall.FuncInt = funcInt;
            functionToCall.Name = funcInt.Method.Name;
            _listFunctionToCall.Add(functionToCall);
        }

        public void AddFunction(Func<int,int> funcIntRetInt)
        {
            FunctionToCall functionToCall = new FunctionToCall();
            functionToCall.ReturnType = ReturnType.Int;
            functionToCall.Param1Type = ReturnType.Int;
            functionToCall.FuncIntRetInt = funcIntRetInt;
            functionToCall.Name = funcIntRetInt.Method.Name;
            _listFunctionToCall.Add(functionToCall);
        }

        public bool ExecFunc(string functionName)
        {
            FunctionToCall functionToCall = _listFunctionToCall.Where(f => f.Name.Equals(functionName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            if (functionToCall == null)
                return false;

            return functionToCall.FuncBool.Invoke();
        }

        public int ExecFunc(string functionName, int param1)
        {
            FunctionToCall functionToCall = _listFunctionToCall.Where(f => f.Name.Equals(functionName, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            if (functionToCall == null)
                return 0;

            return functionToCall.FuncIntRetInt.Invoke(param1);
        }
    }
}
