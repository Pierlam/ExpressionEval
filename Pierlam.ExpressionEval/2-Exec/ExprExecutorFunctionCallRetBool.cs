using System;
using System.Collections.Generic;
using System.Text;

namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// ExprExecutor, manage function call execution.
    /// Only function returning a bool value.
    /// </summary>
    public class ExprExecutorFunctionCallRetBool: ExprExecutorFunctionCallRetBase
    {
        /// <summary>
        /// Exec the function call, return a bool value.
        /// can any, one or more parameters.
        /// </summary>
        /// <param name="exprExecResult"></param>
        /// <param name="functionToCallMapper"></param>
        /// <param name="exprExecFunctionCallBool"></param>
        /// <param name="listExprExecParam"></param>
        /// <param name="exprExecBase"></param>
        /// <returns></returns>
        public bool Exec(ExecResult exprExecResult, ExprExecFunctionCallBool exprExecFunctionCallBool, List<ExpressionExecBase> listExprExecParam, out ExpressionExecBase exprExecBase)
        {
            exprExecBase = null;

            bool res;
            bool caseManaged;
            if (!ExecFuncRetBool_Params(exprExecResult, exprExecFunctionCallBool, listExprExecParam, out caseManaged, out res))
                // an error occurs
                return false;

            if(!caseManaged)
            {
                exprExecResult.AddErrorExec(ErrorCode.ExpressionTypeNotYetImplemented, "Type", "FunctionCall");
                return false;
            }

            // execute the function linked to the functionCall found in the expression
            exprExecFunctionCallBool.Value = res;
            exprExecBase = exprExecFunctionCallBool;
            return true;
        }


        //======================================================================
        #region Private methods.

        /// <summary>
        /// Execute the function code attached to the function call.
        /// 
        /// </summary>
        /// <param name="exprExecResult"></param>
        /// <param name="exprExecFunctionCallBool"></param>
        /// <param name="listExprExecParam"></param>
        /// <param name="exprExecBase"></param>
        /// <returns></returns>
        private bool ExecFuncRetBool_Params(ExecResult exprExecResult, ExprExecFunctionCallBool exprExecFunctionCallBool, List<ExpressionExecBase> listExprExecParam, out bool caseManaged, out bool res)
        {
            caseManaged = false;
            res = false;

            // not enought or too many parameter
            //if (!CheckParamsCount(exprExecResult, listExprExecParam, 1))
            //    return false;

            try
            {
                // check the parameters, according to the definition
                if(!CheckParams(exprExecResult, exprExecFunctionCallBool.FunctionToCallMapper, listExprExecParam))
                    return false;

                //===========================RetBool, any parameter
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool.Invoke();
                    caseManaged = true;
                    return true;
                }

                //===========================RetBool, one parameter
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature== MethodSignatureType.RetBool_Bool)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Bool.Invoke((listExprExecParam[0] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }

                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Int)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Int.Invoke((listExprExecParam[0] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }

                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_String)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_String.Invoke((listExprExecParam[0] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }

                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Double)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Double.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }

                //===========================RetBool, two parameters
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Bool_Bool)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Bool_Bool.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }

                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Bool_Int)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Bool_Int.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Bool_String)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Bool_String.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Bool_Double)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Bool_Double.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Int_Bool)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Int_Bool.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Int_Int)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Int_Int.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Int_String)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Int_String.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Int_Double)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Int_Double.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_String_Bool)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_String_Bool.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_String_Int)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_String_Int.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_String_String)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_String_String.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_String_Double)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_String_Double.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Double_Bool)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Double_Bool.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Double_Int)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Double_Int.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Double_String)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Double_String.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Double_Double)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Double_Double.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }

                //===========================RetBool, 3 parameters
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Bool_Bool_Bool)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Bool_Bool_Bool.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Bool_Bool_Int)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Bool_Bool_Int.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Bool_Bool_String)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Bool_Bool_String.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Bool_Bool_Double)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Bool_Bool_Double.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Bool_Int_Bool)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Bool_Int_Bool.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Bool_Int_Int)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Bool_Int_Int.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Bool_Int_String)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Bool_Int_String.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Bool_Int_Double)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Bool_Int_Double.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Bool_String_Bool)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Bool_String_Bool.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Bool_String_Int)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Bool_String_Int.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Bool_String_String)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Bool_String_String.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Bool_String_Double)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Bool_String_Double.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Bool_Double_Bool)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Bool_Double_Bool.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Bool_Double_Int)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Bool_Double_Int.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Bool_Double_String)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Bool_Double_String.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Bool_Double_Double)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Bool_Double_Double.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Int_Bool_Bool)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Int_Bool_Bool.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Int_Bool_Int)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Int_Bool_Int.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Int_Bool_String)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Int_Bool_String.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Int_Bool_Double)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Int_Bool_Double.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Int_Int_Bool)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Int_Int_Bool.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Int_Int_Int)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Int_Int_Int.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Int_Int_String)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Int_Int_String.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Int_Int_Double)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Int_Int_Double.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Int_String_Bool)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Int_String_Bool.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Int_String_Int)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Int_String_Int.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Int_String_String)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Int_String_String.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Int_String_Double)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Int_String_Double.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Int_Double_Bool)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Int_Double_Bool.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Int_Double_Int)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Int_Double_Int.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Int_Double_String)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Int_Double_String.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Int_Double_Double)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Int_Double_Double.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_String_Bool_Bool)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_String_Bool_Bool.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_String_Bool_Int)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_String_Bool_Int.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_String_Bool_String)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_String_Bool_String.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_String_Bool_Double)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_String_Bool_Double.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_String_Int_Bool)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_String_Int_Bool.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_String_Int_Int)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_String_Int_Int.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_String_Int_String)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_String_Int_String.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_String_Int_Double)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_String_Int_Double.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_String_String_Bool)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_String_String_Bool.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_String_String_Int)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_String_String_Int.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_String_String_String)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_String_String_String.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_String_String_Double)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_String_String_Double.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_String_Double_Bool)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_String_Double_Bool.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_String_Double_Int)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_String_Double_Int.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_String_Double_String)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_String_Double_String.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_String_Double_Double)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_String_Double_Double.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Double_Bool_Bool)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Double_Bool_Bool.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Double_Bool_Int)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Double_Bool_Int.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Double_Bool_String)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Double_Bool_String.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Double_Bool_Double)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Double_Bool_Double.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Double_Int_Bool)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Double_Int_Bool.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Double_Int_Int)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Double_Int_Int.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Double_Int_String)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Double_Int_String.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Double_Int_Double)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Double_Int_Double.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Double_String_Bool)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Double_String_Bool.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Double_String_Int)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Double_String_Int.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Double_String_String)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Double_String_String.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Double_String_Double)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Double_String_Double.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Double_Double_Bool)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Double_Double_Bool.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Double_Double_Int)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Double_Double_Int.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Double_Double_String)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Double_Double_String.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallBool.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Double_Double_Double)
                {
                    res = exprExecFunctionCallBool.FunctionToCallMapper.FuncBool_Double_Double_Double.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                // error occurs on executing the function
                return AddErrorExecFailed(exprExecResult, e);
            }
        }
        #endregion

    }
}
