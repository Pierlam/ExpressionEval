using System;
using System.Collections.Generic;
using System.Text;

namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// ExprExecutor, manage function call execution.
    /// Only function returning an int value.
    /// </summary>
    public class ExprExecutorFunctionCallRetString : ExprExecutorFunctionCallRetBase
    {
        /// <summary>
        /// Exec the function call, return a string value.
        /// can have any, one or more parameters.
        /// </summary>
        /// <param name="exprExecResult"></param>
        /// <param name="functionToCallMapper"></param>
        /// <param name="exprExecFunctionCallBool"></param>
        /// <param name="listExprExecParam"></param>
        /// <param name="exprExecBase"></param>
        /// <returns></returns>
        public bool Exec(ExecResult exprExecResult, ExprExecFunctionCallString exprExecFunctionCallString, List<ExpressionExecBase> listExprExecParam, out ExpressionExecBase exprExecBase)
        {
            exprExecBase = null;

            string res;
            bool caseManaged;
            if (!ExecFuncRetString_Params(exprExecResult, exprExecFunctionCallString, listExprExecParam, out caseManaged, out res))
                // an error occurs
                return false;

            if (!caseManaged)
            {
                exprExecResult.AddErrorExec(ErrorCode.ExpressionTypeNotYetImplemented, "Type", "FunctionCall");
                return false;
            }

            // execute the function linked to the functionCall found in the expression
            exprExecFunctionCallString.Value = res;
            exprExecBase = exprExecFunctionCallString;
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
        private bool ExecFuncRetString_Params(ExecResult exprExecResult, ExprExecFunctionCallString exprExecFunctionCallString, List<ExpressionExecBase> listExprExecParam, out bool caseManaged, out string res)
        {
            caseManaged = false;
            res = "";

            // not enought or too many parameter
            //if (!CheckParamsCount(exprExecResult, listExprExecParam, 1))
            //    return false;

            try
            {
                // check the parameters, according to the definition
                if (!CheckParams(exprExecResult, exprExecFunctionCallString.FunctionToCallMapper, listExprExecParam))
                    return false;

                //===========================RetString, any parameter
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString.Invoke();
                    caseManaged = true;
                    return true;
                }

                //===========================RetString, one parameter
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Bool)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Bool.Invoke((listExprExecParam[0] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }

                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Int)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Int.Invoke((listExprExecParam[0] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }

                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_String)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_String.Invoke((listExprExecParam[0] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }

                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Double)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Double.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }

                //===========================RetString, two parameters
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Bool_Bool)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Bool_Bool.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Bool_Int)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Bool_Int.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Bool_String)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Bool_String.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Bool_Double)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Bool_Double.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Int_Bool)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Int_Bool.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Int_Int)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Int_Int.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Int_String)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Int_String.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Int_Double)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Int_Double.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_String_Bool)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_String_Bool.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_String_Int)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_String_Int.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_String_String)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_String_String.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_String_Double)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_String_Double.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Double_Bool)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Double_Bool.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Double_Int)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Double_Int.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Double_String)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Double_String.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Double_Double)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Double_Double.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }

                //===========================RetString, 3 parameters
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Bool_Bool_Bool)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Bool_Bool_Bool.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Bool_Bool_Int)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Bool_Bool_Int.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Bool_Bool_String)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Bool_Bool_String.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Bool_Bool_Double)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Bool_Bool_Double.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Bool_Int_Bool)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Bool_Int_Bool.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Bool_Int_Int)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Bool_Int_Int.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Bool_Int_String)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Bool_Int_String.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Bool_Int_Double)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Bool_Int_Double.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Bool_String_Bool)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Bool_String_Bool.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Bool_String_Int)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Bool_String_Int.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Bool_String_String)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Bool_String_String.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Bool_String_Double)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Bool_String_Double.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Bool_Double_Bool)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Bool_Double_Bool.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Bool_Double_Int)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Bool_Double_Int.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Bool_Double_String)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Bool_Double_String.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Bool_Double_Double)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Bool_Double_Double.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Int_Bool_Bool)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Int_Bool_Bool.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Int_Bool_Int)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Int_Bool_Int.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Int_Bool_String)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Int_Bool_String.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Int_Bool_Double)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Int_Bool_Double.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Int_Int_Bool)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Int_Int_Bool.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Int_Int_Int)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Int_Int_Int.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Int_Int_String)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Int_Int_String.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Int_Int_Double)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Int_Int_Double.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Int_String_Bool)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Int_String_Bool.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Int_String_Int)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Int_String_Int.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Int_String_String)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Int_String_String.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Int_String_Double)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Int_String_Double.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Int_Double_Bool)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Int_Double_Bool.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Int_Double_Int)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Int_Double_Int.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Int_Double_String)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Int_Double_String.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Int_Double_Double)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Int_Double_Double.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_String_Bool_Bool)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_String_Bool_Bool.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_String_Bool_Int)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_String_Bool_Int.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_String_Bool_String)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_String_Bool_String.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_String_Bool_Double)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_String_Bool_Double.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_String_Int_Bool)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_String_Int_Bool.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_String_Int_Int)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_String_Int_Int.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_String_Int_String)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_String_Int_String.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_String_Int_Double)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_String_Int_Double.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_String_String_Bool)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_String_String_Bool.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_String_String_Int)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_String_String_Int.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_String_String_String)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_String_String_String.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_String_String_Double)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_String_String_Double.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_String_Double_Bool)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_String_Double_Bool.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_String_Double_Int)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_String_Double_Int.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_String_Double_String)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_String_Double_String.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_String_Double_Double)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_String_Double_Double.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Double_Bool_Bool)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Double_Bool_Bool.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Double_Bool_Int)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Double_Bool_Int.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Double_Bool_String)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Double_Bool_String.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Double_Bool_Double)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Double_Bool_Double.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Double_Int_Bool)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Double_Int_Bool.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Double_Int_Int)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Double_Int_Int.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Double_Int_String)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Double_Int_String.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Double_Int_Double)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Double_Int_Double.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Double_String_Bool)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Double_String_Bool.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Double_String_Int)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Double_String_Int.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Double_String_String)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Double_String_String.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Double_String_Double)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Double_String_Double.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Double_Double_Bool)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Double_Double_Bool.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Double_Double_Int)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Double_Double_Int.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Double_Double_String)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Double_Double_String.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallString.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetString_Double_Double_Double)
                {
                    res = exprExecFunctionCallString.FunctionToCallMapper.FuncString_Double_Double_Double.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
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