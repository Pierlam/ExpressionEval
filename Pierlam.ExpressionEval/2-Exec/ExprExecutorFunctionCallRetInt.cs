using System;
using System.Collections.Generic;
using System.Text;

namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// ExprExecutor, manage function call execution.
    /// Only function returning an int value.
    /// </summary>
    public class ExprExecutorFunctionCallRetInt : ExprExecutorFunctionCallRetBase
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
        public bool Exec(ExecResult exprExecResult, ExprExecFunctionCallInt exprExecFunctionCallInt, List<ExpressionExecBase> listExprExecParam, out ExpressionExecBase exprExecBase)
        {
            exprExecBase = null;

            int res;
            bool caseManaged;
            if (!ExecFuncRetInt_Params(exprExecResult, exprExecFunctionCallInt, listExprExecParam, out caseManaged, out res))
                // an error occurs
                return false;

            if (!caseManaged)
            {
                exprExecResult.AddErrorExec(ErrorCode.ExpressionTypeNotYetImplemented, "Type", "FunctionCall");
                return false;
            }

            // execute the function linked to the functionCall found in the expression
            exprExecFunctionCallInt.Value = res;
            exprExecBase = exprExecFunctionCallInt;
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
        private bool ExecFuncRetInt_Params(ExecResult exprExecResult, ExprExecFunctionCallInt exprExecFunctionCallInt, List<ExpressionExecBase> listExprExecParam, out bool caseManaged, out int res)
        {
            caseManaged = false;
            res = 0;

            // not enought or too many parameter
            //if (!CheckParamsCount(exprExecResult, listExprExecParam, 1))
            //    return false;

            try
            {
                // check the parameters, according to the definition
                if (!CheckParams(exprExecResult, exprExecFunctionCallInt.FunctionToCallMapper, listExprExecParam))
                    return false;

                //===========================RetInt, any parameter
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt.Invoke();
                    caseManaged = true;
                    return true;
                }

                //===========================RetInt, one parameter
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Bool)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Bool.Invoke((listExprExecParam[0] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }

                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Int)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Int.Invoke((listExprExecParam[0] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }

                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_String)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_String.Invoke((listExprExecParam[0] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }

                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetBool_Double)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Double.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }

                //===========================RetInt, two parameters
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Bool_Bool)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Bool_Bool.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Bool_Int)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Bool_Int.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Bool_String)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Bool_String.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Bool_Double)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Bool_Double.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Int_Bool)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Int_Bool.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Int_Int)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Int_Int.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Int_String)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Int_String.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Int_Double)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Int_Double.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_String_Bool)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_String_Bool.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_String_Int)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_String_Int.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_String_String)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_String_String.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_String_Double)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_String_Double.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Double_Bool)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Double_Bool.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Double_Int)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Double_Int.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Double_String)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Double_String.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Double_Double)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Double_Double.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }

                //===========================RetInt, 3 parameters
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Bool_Bool_Bool)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Bool_Bool_Bool.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Bool_Bool_Int)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Bool_Bool_Int.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Bool_Bool_String)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Bool_Bool_String.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Bool_Bool_Double)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Bool_Bool_Double.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Bool_Int_Bool)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Bool_Int_Bool.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Bool_Int_Int)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Bool_Int_Int.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Bool_Int_String)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Bool_Int_String.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Bool_Int_Double)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Bool_Int_Double.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Bool_String_Bool)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Bool_String_Bool.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Bool_String_Int)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Bool_String_Int.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Bool_String_String)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Bool_String_String.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Bool_String_Double)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Bool_String_Double.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Bool_Double_Bool)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Bool_Double_Bool.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Bool_Double_Int)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Bool_Double_Int.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Bool_Double_String)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Bool_Double_String.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Bool_Double_Double)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Bool_Double_Double.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Int_Bool_Bool)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Int_Bool_Bool.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Int_Bool_Int)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Int_Bool_Int.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Int_Bool_String)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Int_Bool_String.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Int_Bool_Double)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Int_Bool_Double.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Int_Int_Bool)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Int_Int_Bool.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Int_Int_Int)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Int_Int_Int.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Int_Int_String)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Int_Int_String.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Int_Int_Double)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Int_Int_Double.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Int_String_Bool)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Int_String_Bool.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Int_String_Int)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Int_String_Int.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Int_String_String)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Int_String_String.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Int_String_Double)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Int_String_Double.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Int_Double_Bool)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Int_Double_Bool.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Int_Double_Int)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Int_Double_Int.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Int_Double_String)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Int_Double_String.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Int_Double_Double)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Int_Double_Double.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_String_Bool_Bool)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_String_Bool_Bool.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_String_Bool_Int)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_String_Bool_Int.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_String_Bool_String)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_String_Bool_String.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_String_Bool_Double)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_String_Bool_Double.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_String_Int_Bool)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_String_Int_Bool.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_String_Int_Int)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_String_Int_Int.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_String_Int_String)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_String_Int_String.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_String_Int_Double)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_String_Int_Double.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_String_String_Bool)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_String_String_Bool.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_String_String_Int)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_String_String_Int.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_String_String_String)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_String_String_String.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_String_String_Double)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_String_String_Double.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_String_Double_Bool)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_String_Double_Bool.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_String_Double_Int)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_String_Double_Int.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_String_Double_String)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_String_Double_String.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_String_Double_Double)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_String_Double_Double.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Double_Bool_Bool)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Double_Bool_Bool.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Double_Bool_Int)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Double_Bool_Int.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Double_Bool_String)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Double_Bool_String.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Double_Bool_Double)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Double_Bool_Double.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Double_Int_Bool)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Double_Int_Bool.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Double_Int_Int)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Double_Int_Int.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Double_Int_String)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Double_Int_String.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Double_Int_Double)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Double_Int_Double.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Double_String_Bool)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Double_String_Bool.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Double_String_Int)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Double_String_Int.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Double_String_String)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Double_String_String.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Double_String_Double)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Double_String_Double.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Double_Double_Bool)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Double_Double_Bool.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Double_Double_Int)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Double_Double_Int.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Double_Double_String)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Double_Double_String.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallInt.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt_Double_Double_Double)
                {
                    res = exprExecFunctionCallInt.FunctionToCallMapper.FuncInt_Double_Double_Double.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }

                // err, not managed or not yet implemented
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
