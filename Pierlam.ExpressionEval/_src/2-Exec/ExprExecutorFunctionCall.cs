using System;
using System.Collections.Generic;

namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// ExprExecutor, manage function call execution.
    /// </summary>
    public class ExprExecutorFunctionCall
    {
        ExprExecutorFunctionCallRetBool _execFuncCallRetBool;

        ExprExecutorFunctionCallRetInt _execFuncCallRetInt;

        ExprExecutorFunctionCallRetString _execFuncCallRetString;

        ExprExecutorFunctionCallRetDouble _execFuncCallRetDouble;

        public ExprExecutorFunctionCall()
        {
            _execFuncCallRetBool = new ExprExecutorFunctionCallRetBool();
            _execFuncCallRetInt = new ExprExecutorFunctionCallRetInt();
            _execFuncCallRetString = new ExprExecutorFunctionCallRetString();
            _execFuncCallRetDouble = new ExprExecutorFunctionCallRetDouble();
        }
        /// <summary>
        /// Functions to call.
        /// Available for all execution of the expression.
        /// variables definition ara available only for the current execution.
        /// </summary>
        public List<FunctionToCallMapper> ListFunctionToCallMapper { get; set; }

        /// <summary>
        /// ESSAI exec FunctionParamsMapperBase: parametres genriques.
        /// function ayant 3 paramètres: Function3ParamsMapper<TP1, TP2, TP3,TRet> 
        /// 
        /// </summary>
        /// <param name="exprExecResult"></param>
        /// <param name="exprFunctionCall"></param>
        /// <param name="functionToCallMapper"></param>
        /// <param name="listExprExecParam"></param>
        /// <param name="exprExecBase"></param>
        /// <returns></returns>
        //public bool ExecExpressionFunctionCall(ExprExecResult exprExecResult, ExprFunctionCall exprFunctionCall, FunctionToCallMapper functionToCallMapper, List<ExpressionExecBase> listExprExecParam, out ExpressionExecBase exprExecBase)
        //{
        //    exprExecBase = null;

        //    // having 3 parameters?
        //    Function3ParamsMapper<TP1, TP2, TP3, TRet> func3params = functionToCallMapper.FunctionParamsMapperBase as Function3ParamsMapper<TP1, TP2, TP3, TRet>;

        //    if(functionToCallMapper.FunctionParamsMapperBase.
        //    Function3ParamsMapper<System.Boolean, bool, bool, bool> func3params = functionToCallMapper.FunctionParamsMapperBase as Function3ParamsMapper<bool, bool, bool, bool>;

        //}

        /// <summary>
        /// Execute the function linked to the functionCall.
        /// Depends on the function signature, can have any or one or parameter.
        /// </summary>
        /// <param name="exprExecResult"></param>
        /// <param name="exprFunctionCall"></param>
        /// <param name="exprExecBase"></param>
        /// <returns></returns>
        public bool ExecExpressionFunctionCall(ExecResult exprExecResult, ExprFunctionCall exprFunctionCall, FunctionToCallMapper functionToCallMapper, List<ExpressionExecBase> listExprExecParam, out ExpressionExecBase exprExecBase)
        {
            exprExecBase = null;


            //====the function return type is a bool
            if (functionToCallMapper.ReturnType == DataType.Bool)
            {
                // ExprExecutorFunctionCallRetBool
                // prepare the execution result
                ExprExecFunctionCallBool exprExecFunctionCallBool = new ExprExecFunctionCallBool();
                exprExecFunctionCallBool.ExprFunctionCall = exprFunctionCall;
                exprExecFunctionCallBool.FunctionToCallMapper = functionToCallMapper;

                return _execFuncCallRetBool.Exec(exprExecResult, exprExecFunctionCallBool, listExprExecParam, out exprExecBase);
            }

            //====the function return type is a int
            if (functionToCallMapper.ReturnType == DataType.Int)
            {
                // prepare the execution result
                ExprExecFunctionCallInt exprExecFunctionCallInt = new ExprExecFunctionCallInt();
                exprExecFunctionCallInt.ExprFunctionCall = exprFunctionCall;
                exprExecFunctionCallInt.FunctionToCallMapper = functionToCallMapper;

                return _execFuncCallRetInt.Exec(exprExecResult, exprExecFunctionCallInt, listExprExecParam, out exprExecBase);
            }

            //====the function return type is a string
            if (functionToCallMapper.ReturnType == DataType.String)
            {
                // prepare the execution result
                ExprExecFunctionCallString exprExecFunctionCallString = new ExprExecFunctionCallString();
                exprExecFunctionCallString.ExprFunctionCall = exprFunctionCall;
                exprExecFunctionCallString.FunctionToCallMapper = functionToCallMapper;

                return _execFuncCallRetString.Exec(exprExecResult, exprExecFunctionCallString, listExprExecParam, out exprExecBase);
            }

            //====the function return type is a double
            if (functionToCallMapper.ReturnType == DataType.Double)
            {
                // prepare the execution result
                ExprExecFunctionCallDouble exprExecFunctionCallDouble = new ExprExecFunctionCallDouble();
                exprExecFunctionCallDouble.ExprFunctionCall = exprFunctionCall;
                exprExecFunctionCallDouble.FunctionToCallMapper = functionToCallMapper;

                return _execFuncCallRetDouble.Exec(exprExecResult, exprExecFunctionCallDouble, listExprExecParam, out exprExecBase);
            }


            // function signature not yet implemented
            exprExecResult.AddErrorExec(ErrorCode.ExpressionTypeNotYetImplemented, "Type", "FunctionCall");

            return false;
        }

        /// <summary>
        /// error occurs on executing the function.
        /// 
        /// </summary>
        /// <param name="exprExecResult"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        //public bool AddErrorExecFailed(ExprExecResult exprExecResult, Exception e)
        //{
        //    exprExecResult.AddError(ExecErrorCode.ExprFunctionCallException, "Message", e.Message, "InnerException", e.InnerException.ToString());
        //    return false;
        //}

        //private bool CheckParamsCount(ExprExecResult exprExecResult, List<ExpressionExecBase> listExprExecParam, int nbParamExpected)
        //{
        //    if (listExprExecParam.Count != nbParamExpected)
        //    {
        //        exprExecResult.AddError(ExecErrorCode.ExprFunctionCallParamCountWrong, "ParamCountExpected", nbParamExpected.ToString(), "ParamCount", listExprExecParam.Count.ToString());
        //        return false;
        //    }

        //    // ok 
        //    return true;
        //}


        // get the single param and check the type
        //private bool GetCheckParamBool(ExprExecResult exprExecResult, ExpressionExecBase param, out ExprExecValueBool exprParamBool)
        //{
        //    exprParamBool = param as ExprExecValueBool;
        //    if (exprParamBool == null)
        //    {
        //        exprExecResult.AddError(ExecErrorCode.ExprFunctionCallParamTypeWrong, "ParamTypeExpected", "Bool", "ParamType", param.GetType().ToString());
        //        return false;
        //    }
        //    return true;
        //}

        //private bool GetCheckParamInt(ExprExecResult exprExecResult, ExpressionExecBase param, out ExprExecValueInt exprParamInt)
        //{
        //    exprParamInt = param as ExprExecValueInt;
        //    if (exprParamInt == null)
        //    {
        //        exprExecResult.AddError(ExecErrorCode.ExprFunctionCallParamTypeWrong, "ParamTypeExpected", "Int", "ParamType", param.GetType().ToString());
        //        return false;
        //    }
        //    return true;
        //}

        //private bool GetCheckParamString(ExprExecResult exprExecResult, ExpressionExecBase param, out ExprExecValueString exprParamString)
        //{
        //    exprParamString = param as ExprExecValueString;
        //    if (exprParamString == null)
        //    {
        //        exprExecResult.AddError(ExecErrorCode.ExprFunctionCallParamTypeWrong, "ParamTypeExpected", "String", "ParamType", param.GetType().ToString());
        //        return false;
        //    }
        //    return true;
        //}

        //private bool GetCheckParamDouble(ExprExecResult exprExecResult, ExpressionExecBase param, out ExprExecValueDouble exprParamDouble)
        //{
        //    exprParamDouble = param as ExprExecValueDouble;
        //    if (exprParamDouble == null)
        //    {
        //        exprExecResult.AddError(ExecErrorCode.ExprFunctionCallParamTypeWrong, "ParamTypeExpected", "Double", "ParamType", param.GetType().ToString());
        //        return false;
        //    }
        //    return true;
        //}
    }
}
