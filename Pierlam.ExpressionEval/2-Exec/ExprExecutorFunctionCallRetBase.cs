using System;
using System.Collections.Generic;
using System.Text;

namespace Pierlam.ExpressionEval
{
    public abstract class ExprExecutorFunctionCallRetBase
    {
        /// <summary>
        /// error occurs on executing the function.
        /// 
        /// </summary>
        /// <param name="exprExecResult"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public bool AddErrorExecFailed(ExecResult exprExecResult, Exception e)
        {
            string innerException = "";
            if (e.InnerException != null)
                innerException = e.InnerException.ToString();
            exprExecResult.AddErrorExec(ErrorCode.FunctionCallExecException, "Message", e.Message, "InnerException", innerException);
            return false;
        }

        /// <summary>
        /// 
        /// check the parameters, according to the definition.
        /// </summary>
        /// <param name="exprExecResult"></param>
        /// <param name="functionToCallMapper"></param>
        /// <param name="listExprExecParam"></param>
        /// <returns></returns>
        public bool CheckParams(ExecResult exprExecResult, FunctionToCallMapper functionToCallMapper, List<ExpressionExecBase> listExprExecParam)
        {
            bool res;

            // check param1
            res = CheckParam(exprExecResult, functionToCallMapper, listExprExecParam, 1, functionToCallMapper.Param1Type);
            if (functionToCallMapper.Param1Type == DataType.NotDefined) return res;

            // check param2
            res &= CheckParam(exprExecResult, functionToCallMapper, listExprExecParam, 2, functionToCallMapper.Param2Type);
            if (functionToCallMapper.Param2Type == DataType.NotDefined) return res;

            // check param3
            res &= CheckParam(exprExecResult, functionToCallMapper, listExprExecParam, 3, functionToCallMapper.Param3Type);
            //if (functionToCallMapper.Param2Type == DataType.NotDefined) return res;

            // check others params
            // todo:
            return res;
        }

        /// <summary>
        /// Check one parameter of a function call.
        /// </summary>
        /// <param name="exprExecResult"></param>
        /// <param name="functionToCallMapper"></param>
        /// <param name="listExprExecParam"></param>
        /// <param name="paramNum"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        private bool CheckParam(ExecResult exprExecResult, FunctionToCallMapper functionToCallMapper, List<ExpressionExecBase> listExprExecParam, int paramNum, DataType dataType)
        {
            // check param
            //if (dataType == DataType.NotDefined)
            //{
            //    ici();

            //    // any parameter
            //    if (listExprExecParam.Count > paramNum)
            //    {
            //        // error! too many parameters provided
            //        exprExecResult.AddError(ExecErrorCode.ExprFunctionCallParamCountWrong, "ParamExpectedCount", (paramNum).ToString(), "ParamFoundCount", listExprExecParam.Count.ToString());
            //        return false;
            //    }

            //    // the param type is set to NotDefined
            //    return true;
            //}

            //// at least one parameter is expected
            //if (listExprExecParam.Count < paramNum)
            //{
            //    // errror! not enought provided parameters
            //    exprExecResult.AddError(ExecErrorCode.ExprFunctionCallParamCountWrong, "ParamExpectedCount", (paramNum).ToString(), "ParamFoundCount", listExprExecParam.Count.ToString());
            //    return false;
            //}

            if (dataType == DataType.NotDefined)
                return true;

            // check param, should be a bool
            if (dataType == DataType.Bool)
            {
                // check the type of the param
                ExprExecValueBool exprParamBool;
                if (!GetCheckParamBool(exprExecResult, functionToCallMapper.FunctionCallName, listExprExecParam[paramNum - 1], out exprParamBool))
                    return false;

                // the param1 is ok
                return true;
            }

            // check param, should be an int
            if (dataType == DataType.Int)
            {
                // check the type of the param
                ExprExecValueInt exprParamInt;
                if (!GetCheckParamInt(exprExecResult, functionToCallMapper.FunctionCallName, listExprExecParam[paramNum - 1], out exprParamInt))
                    return false;

                // the param1 is ok
                return true;
            }

            // string
            if (dataType == DataType.String)
            {
                // check the type of the param
                ExprExecValueString exprParamString;
                if (!GetCheckParamString(exprExecResult, functionToCallMapper.FunctionCallName, listExprExecParam[paramNum - 1], out exprParamString))
                    return false;

                // the param is ok
                return true;
            }


            // check param, should be a double
            // check the type of the param
            ExprExecValueDouble exprParamDouble;
            if (!GetCheckParamDouble(exprExecResult, functionToCallMapper.FunctionCallName, listExprExecParam[paramNum - 1], out exprParamDouble))
                return false;

            // the param is ok
            return true;
        }


        // get the single param and check the type
        public bool GetCheckParamBool(ExecResult exprExecResult, string functionCallName, ExpressionExecBase param, out ExprExecValueBool exprParamBool)
        {
            exprParamBool = param as ExprExecValueBool;
            if (exprParamBool == null)
            {
                exprExecResult.AddErrorExec(ErrorCode.FunctionCallParamTypeWrong, "FunctionCallName", functionCallName, "ParamTypeExpected", "bool"); //, "ParamType", param.GetType().ToString());
                return false;
            }
            return true;
        }

        public bool GetCheckParamInt(ExecResult exprExecResult, string functionCallName, ExpressionExecBase param, out ExprExecValueInt exprParamInt)
        {
            exprParamInt = param as ExprExecValueInt;
            if (exprParamInt == null)
            {
                exprExecResult.AddErrorExec(ErrorCode.FunctionCallParamTypeWrong, "FunctionCallName", functionCallName, "ParamTypeExpected", "int"); //, "ParamType", param.GetType().ToString());
                return false;
            }
            return true;
        }

        public bool GetCheckParamString(ExecResult exprExecResult, string functionCallName, ExpressionExecBase param, out ExprExecValueString exprParamString)
        {
            exprParamString = param as ExprExecValueString;
            if (exprParamString == null)
            {
                exprExecResult.AddErrorExec(ErrorCode.FunctionCallParamTypeWrong, "FunctionCallName", functionCallName, "ParamTypeExpected", "string"); //, "ParamType", param.GetType().ToString());
                return false;
            }
            return true;
        }

        public bool GetCheckParamDouble(ExecResult exprExecResult, string functionCallName, ExpressionExecBase param, out ExprExecValueDouble exprParamDouble)
        {
            exprParamDouble = param as ExprExecValueDouble;
            if (exprParamDouble == null)
            {
                exprExecResult.AddErrorExec(ErrorCode.FunctionCallParamTypeWrong, "FunctionCallName", functionCallName, "ParamTypeExpected", "double"); //, "ParamType", param.GetType().ToString());
                return false;
            }
            return true;
        }
    }
}
