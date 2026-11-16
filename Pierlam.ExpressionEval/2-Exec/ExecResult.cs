using System.Collections.Generic;

namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// Expression execution result.
    /// </summary>
    public class ExecResult
    {
        public ExecResult()
        {
            ListError = new List<ExprError>();
            ListExprVariable = new List<ExprVariableBase>();
        }

        /// <summary>
        /// The parsed expression to execute.
        /// Must have any error.
        /// </summary>
        public ParseResult ParseResult { get; set; }

        /// <summary>
        /// List of errors occurs during the license, parse, the setVar or func 
        /// and then during the execution/evaluation of the expression.
        /// </summary>
        public List<ExprError> ListError { get; private set; }

        /// <summary>
        /// List of defined variable: type and value.
        /// </summary>
        public List<ExprVariableBase> ListExprVariable { get; private set; }

        /// <summary>
        /// The final expression execution result.
        /// </summary>
        public ExpressionExecBase ExprExec { get; set; }

        /// <summary>
        /// The final expression execution result, if its a boolean value.
        /// </summary>
        public bool ResultBool
        {
            get
            {
                ExprExecValueBool exprExecBool = ExprExec as ExprExecValueBool;
                if (exprExecBool == null) return false;
                return exprExecBool.Value;
            }
        }

        /// <summary>
        /// The final expression execution result, if its an int value.
        /// </summary>
        public int ResultInt
        {
            get
            {
                ExprExecValueInt exprExecInt = ExprExec as ExprExecValueInt;
                if (exprExecInt == null)
                    // return a non-significant value
                    return 0;
                return exprExecInt.Value;
            }
        }

        /// <summary>
        /// The final expression execution result, if its a string value.
        /// </summary>
        public string ResultString
        {
            get
            {
                ExprExecValueString exprExecString = ExprExec as ExprExecValueString;
                if (exprExecString == null)
                    // return a non-significant value
                    return "";
                return exprExecString.Value;
            }
        }

        /// <summary>
        /// The final expression execution result, if its a double value.
        /// </summary>
        public double ResultDouble
        {
            get
            {
                ExprExecValueDouble exprExecDouble = ExprExec as ExprExecValueDouble;
                if (exprExecDouble == null)
                    // return a non-significant value
                    return 0;
                return exprExecDouble.Value;
            }
        }

        /// <summary>
        /// Return true if the result is a boolean value
        /// </summary>
        public bool IsResultBool
        {
            get
            {
                // is the result a boolean value?
                ExprExecValueBool exprExecBool = ExprExec as ExprExecValueBool;

                if (exprExecBool != null) return true;
                return false;
            }
        }

        /// <summary>
        /// Return true if the result is a int value
        /// </summary>
        public bool IsResultInt
        {
            get
            {
                // is the result an integer value?
                ExprExecValueInt exprExecInt = ExprExec as ExprExecValueInt;

                if (exprExecInt != null) return true;
                return false;
            }
        }

        /// <summary>
        /// Return true if the result is a string value
        /// </summary>
        public bool IsResultString
        {
            get
            {
                // is the result a string value?
                ExprExecValueString exprExecString = ExprExec as ExprExecValueString;

                if (exprExecString != null) return true;
                return false;
            }
        }

        /// <summary>
        /// Return true if the result is a double value
        /// </summary>
        public bool IsResultDouble
        {
            get
            {
                // is the result an integer value?
                ExprExecValueDouble exprExecDouble = ExprExec as ExprExecValueDouble;

                if (exprExecDouble != null) return true;
                return false;
            }
        }

        /// <summary>
        /// Return true is at least one error exists.
        /// </summary>
        public bool HasError
        {
            get
            {
                if (ListError.Count > 0) return true;
                return false;
            }
        }

        public void AddError(ExprError error)
        {
            if(error!=null)
                ListError.Add(error);
        }

        /// <summary>
        /// Add an execution error.
        /// </summary>
        /// <param name="errCode"></param>
        /// <returns></returns>
        public ExprError AddErrorExec(ErrorCode errCode)
        {
            ExprError error = new ExprError();
            error.ErrorType = ErrorType.Exec;
            error.Code = errCode;

            ListError.Add(error);
            return error;
        }

        /// <summary>
        /// Add an execution error, with an error parameter.
        /// </summary>
        /// <param name="errCode"></param>
        /// <param name="paramKey"></param>
        /// <param name="paramValue"></param>
        /// <returns></returns>
        public ExprError AddErrorExec(ErrorCode errCode, string paramKey, string paramValue)
        {
            ExprError error = new ExprError();
            error.ErrorType = ErrorType.Exec;
            error.Code = errCode;

            if (string.IsNullOrEmpty(paramKey))
                paramKey = "Param1";
            if (string.IsNullOrEmpty(paramValue))
                paramKey = "(null)";

            ErrorParam errorParam = new ErrorParam();
            errorParam.Key = paramKey;
            errorParam.Value = paramValue;

            error.ListErrorParam.Add(errorParam);
            ListError.Add(error);
            return error;
        }

        public ExprError AddErrorExec(ErrorCode errCode, string paramKey, string paramValue, string paramKey2, string paramValue2)
        {
            ExprError error = AddErrorExec(errCode, paramKey, paramValue);
            if (string.IsNullOrEmpty(paramKey2))
                paramKey = "Param2";
            if (string.IsNullOrEmpty(paramValue2))
                paramKey = "(null)";

            ErrorParam errorParam = new ErrorParam();
            errorParam.Key = paramKey2;
            errorParam.Value = paramValue2;

            error.ListErrorParam.Add(errorParam);
            return error;
        }
    }
}