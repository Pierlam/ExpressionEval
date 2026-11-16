using System;
using System.Collections.Generic;
using System.Text;

namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// ExprExecutor, manage function call execution.
    /// Only function returning a double value.
    /// </summary>
    public class ExprExecutorFunctionCallRetDouble : ExprExecutorFunctionCallRetBase
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
        public bool Exec(ExecResult exprExecResult, ExprExecFunctionCallDouble exprExecFunctionCallDouble, List<ExpressionExecBase> listExprExecParam, out ExpressionExecBase exprExecBase)
        {
            exprExecBase = null;

            double res;
            bool caseManaged;
            if (!ExecFuncRetDouble_Params(exprExecResult, exprExecFunctionCallDouble, listExprExecParam, out caseManaged, out res))
                // an error occurs
                return false;

            if (!caseManaged)
            {
                exprExecResult.AddErrorExec(ErrorCode.ExpressionTypeNotYetImplemented, "Type", "FunctionCall");
                return false;
            }

            // execute the function linked to the functionCall found in the expression
            exprExecFunctionCallDouble.Value = res;
            exprExecBase = exprExecFunctionCallDouble;
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
        private bool ExecFuncRetDouble_Params(ExecResult exprExecResult, ExprExecFunctionCallDouble exprExecFunctionCallDouble, List<ExpressionExecBase> listExprExecParam, out bool caseManaged, out double res)
        {
            caseManaged = false;
            res = 0;

            // not enought or too many parameter
            //if (!CheckParamsCount(exprExecResult, listExprExecParam, 1))
            //    return false;

            try
            {
                // check the parameters, according to the definition
                if (!CheckParams(exprExecResult, exprExecFunctionCallDouble.FunctionToCallMapper, listExprExecParam))
                    return false;

                //===========================RetDouble, any parameter
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetInt)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncInt.Invoke();
                    caseManaged = true;
                    return true;
                }

                //===========================RetDouble, one parameter
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Bool)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Bool.Invoke((listExprExecParam[0] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }

                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Int)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Int.Invoke((listExprExecParam[0] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }

                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_String)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_String.Invoke((listExprExecParam[0] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }

                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Double)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Double.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }

                //===========================RetDouble, two parameters
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Bool_Bool)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Bool_Bool.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Bool_Int)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Bool_Int.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Bool_String)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Bool_String.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Bool_Double)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Bool_Double.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Int_Bool)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Int_Bool.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Int_Int)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Int_Int.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Int_String)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Int_String.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Int_Double)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Int_Double.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_String_Bool)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_String_Bool.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_String_Int)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_String_Int.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_String_String)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_String_String.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_String_Double)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_String_Double.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Double_Bool)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Double_Bool.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Double_Int)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Double_Int.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Double_String)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Double_String.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Double_Double)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Double_Double.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }

                //===========================RetDouble, 3 parameters
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Bool_Bool_Bool)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Bool_Bool_Bool.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Bool_Bool_Int)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Bool_Bool_Int.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Bool_Bool_String)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Bool_Bool_String.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Bool_Bool_Double)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Bool_Bool_Double.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Bool_Int_Bool)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Bool_Int_Bool.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Bool_Int_Int)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Bool_Int_Int.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Bool_Int_String)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Bool_Int_String.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Bool_Int_Double)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Bool_Int_Double.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Bool_String_Bool)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Bool_String_Bool.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Bool_String_Int)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Bool_String_Int.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Bool_String_String)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Bool_String_String.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Bool_String_Double)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Bool_String_Double.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Bool_Double_Bool)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Bool_Double_Bool.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Bool_Double_Int)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Bool_Double_Int.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Bool_Double_String)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Bool_Double_String.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Bool_Double_Double)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Bool_Double_Double.Invoke((listExprExecParam[0] as ExprExecValueBool).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Int_Bool_Bool)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Int_Bool_Bool.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Int_Bool_Int)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Int_Bool_Int.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Int_Bool_String)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Int_Bool_String.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Int_Bool_Double)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Int_Bool_Double.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Int_Int_Bool)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Int_Int_Bool.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Int_Int_Int)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Int_Int_Int.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Int_Int_String)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Int_Int_String.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Int_Int_Double)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Int_Int_Double.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Int_String_Bool)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Int_String_Bool.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Int_String_Int)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Int_String_Int.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Int_String_String)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Int_String_String.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Int_String_Double)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Int_String_Double.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Int_Double_Bool)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Int_Double_Bool.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Int_Double_Int)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Int_Double_Int.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Int_Double_String)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Int_Double_String.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Int_Double_Double)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Int_Double_Double.Invoke((listExprExecParam[0] as ExprExecValueInt).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_String_Bool_Bool)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_String_Bool_Bool.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_String_Bool_Int)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_String_Bool_Int.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_String_Bool_String)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_String_Bool_String.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_String_Bool_Double)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_String_Bool_Double.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_String_Int_Bool)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_String_Int_Bool.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_String_Int_Int)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_String_Int_Int.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_String_Int_String)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_String_Int_String.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_String_Int_Double)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_String_Int_Double.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_String_String_Bool)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_String_String_Bool.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_String_String_Int)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_String_String_Int.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_String_String_String)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_String_String_String.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_String_String_Double)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_String_String_Double.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_String_Double_Bool)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_String_Double_Bool.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_String_Double_Int)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_String_Double_Int.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_String_Double_String)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_String_Double_String.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_String_Double_Double)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_String_Double_Double.Invoke((listExprExecParam[0] as ExprExecValueString).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Double_Bool_Bool)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Double_Bool_Bool.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Double_Bool_Int)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Double_Bool_Int.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Double_Bool_String)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Double_Bool_String.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Double_Bool_Double)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Double_Bool_Double.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueBool).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Double_Int_Bool)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Double_Int_Bool.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Double_Int_Int)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Double_Int_Int.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Double_Int_String)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Double_Int_String.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Double_Int_Double)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Double_Int_Double.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueInt).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Double_String_Bool)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Double_String_Bool.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Double_String_Int)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Double_String_Int.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Double_String_String)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Double_String_String.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Double_String_Double)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Double_String_Double.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueString).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Double_Double_Bool)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Double_Double_Bool.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueBool).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Double_Double_Int)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Double_Double_Int.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueInt).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Double_Double_String)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Double_Double_String.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueString).Value);
                    caseManaged = true;
                    return true;
                }
                if (exprExecFunctionCallDouble.FunctionToCallMapper.MethodSignature == MethodSignatureType.RetDouble_Double_Double_Double)
                {
                    res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Double_Double_Double.Invoke((listExprExecParam[0] as ExprExecValueDouble).Value, (listExprExecParam[1] as ExprExecValueDouble).Value, (listExprExecParam[2] as ExprExecValueDouble).Value);
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

        ////======================================================================
        //#region Private Exec function ret Double, any or one parameter.

        ///// <summary>
        ///// Execute the function code attached to the function call.
        ///// 
        ///// Return type: Double, No Param.
        ///// </summary>
        ///// <param name="exprExecResult"></param>
        ///// <param name="exprExecFunctionCallDouble"></param>
        ///// <param name="exprExecBase"></param>
        ///// <returns></returns>
        //private bool ExecFuncRetDouble(ExprExecResult exprExecResult, ExprExecFunctionCallDouble exprExecFunctionCallDouble, out ExpressionExecBase exprExecBase)
        //{
        //    exprExecBase = null;

        //    try
        //    {

        //        // execute the function linked to the functionCall found in the expression
        //        double res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble.Invoke();
        //        exprExecFunctionCallDouble.Value = res;
        //        exprExecBase = exprExecFunctionCallDouble;
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        // error occurs on executing the function
        //        return AddErrorExecFailed(exprExecResult, e);
        //    }
        //}


        ///// <summary>
        ///// Execute the function code attached to the function call.
        ///// 
        ///// Return type: double, Param1 type: bool 
        ///// </summary>
        ///// <param name="exprExecResult"></param>
        ///// <param name="exprExecFunctionCallDouble"></param>
        ///// <param name="listExprExecParam"></param>
        ///// <param name="exprExecBase"></param>
        ///// <returns></returns>
        //private bool ExecFuncRetDouble_Bool(ExprExecResult exprExecResult, ExprExecFunctionCallDouble exprExecFunctionCallDouble, List<ExpressionExecBase> listExprExecParam, out ExpressionExecBase exprExecBase)
        //{
        //    exprExecBase = null;

        //    // not enought or too many parameter
        //    if (!CheckParamsCount(exprExecResult, listExprExecParam, 1))
        //        return false;

        //    try
        //    {
        //        // get the single param and check the type
        //        ExprExecValueBool exprParamBool;
        //        if (!GetCheckParamBool(exprExecResult, listExprExecParam[0], out exprParamBool))
        //            return false;

        //        // execute the function linked to the functionCall found in the expression
        //        double res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Bool.Invoke(exprParamBool.Value);
        //        exprExecFunctionCallDouble.Value = res;
        //        exprExecBase = exprExecFunctionCallDouble;
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        // error occurs on executing the function
        //        return AddErrorExecFailed(exprExecResult, e);
        //    }
        //}

        ///// <summary>
        ///// Execute the function code attached to the function call.
        ///// 
        ///// Return type: double, Param1 type: int 
        ///// </summary>
        ///// <param name="exprExecResult"></param>
        ///// <param name="exprExecFunctionCallDouble"></param>
        ///// <param name="listExprExecParam"></param>
        ///// <param name="exprExecBase"></param>
        ///// <returns></returns>
        //private bool ExecFuncRetDouble_Int(ExprExecResult exprExecResult, ExprExecFunctionCallDouble exprExecFunctionCallDouble, List<ExpressionExecBase> listExprExecParam, out ExpressionExecBase exprExecBase)
        //{
        //    exprExecBase = null;

        //    // not enought or too many parameter
        //    if (!CheckParamsCount(exprExecResult, listExprExecParam, 1))
        //        return false;

        //    try
        //    {
        //        // get the single param and check the type
        //        ExprExecValueInt exprParamInt;
        //        if (!GetCheckParamInt(exprExecResult, listExprExecParam[0], out exprParamInt))
        //            return false;

        //        // execute the function linked to the functionCall found in the expression
        //        double res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Int.Invoke(exprParamInt.Value);
        //        exprExecFunctionCallDouble.Value = res;
        //        exprExecBase = exprExecFunctionCallDouble;
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        // error occurs on executing the function
        //        return AddErrorExecFailed(exprExecResult, e);
        //    }
        //}

        ///// <summary>
        ///// Execute the function code attached to the function call.
        ///// 
        ///// Return type: double, Param1 type: string 
        ///// </summary>
        ///// <param name="exprExecResult"></param>
        ///// <param name="exprExecFunctionCallDouble"></param>
        ///// <param name="listExprExecParam"></param>
        ///// <param name="exprExecBase"></param>
        ///// <returns></returns>
        //private bool ExecFuncRetDouble_String(ExprExecResult exprExecResult, ExprExecFunctionCallDouble exprExecFunctionCallDouble, List<ExpressionExecBase> listExprExecParam, out ExpressionExecBase exprExecBase)
        //{
        //    exprExecBase = null;

        //    // not enought or too many parameter
        //    if (!CheckParamsCount(exprExecResult, listExprExecParam, 1))
        //        return false;

        //    try
        //    {
        //        // get the single param and check the type
        //        ExprExecValueString exprParamString;
        //        if (!GetCheckParamString(exprExecResult, listExprExecParam[0], out exprParamString))
        //            return false;

        //        // execute the function linked to the functionCall found in the expression
        //        double res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_String.Invoke(exprParamString.Value);
        //        exprExecFunctionCallDouble.Value = res;
        //        exprExecBase = exprExecFunctionCallDouble;
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        // error occurs on executing the function
        //        return AddErrorExecFailed(exprExecResult, e);
        //    }
        //}

        ///// <summary>
        ///// Execute the function code attached to the function call.
        ///// 
        ///// Return type: double, Param1 type: double 
        ///// </summary>
        ///// <param name="exprExecResult"></param>
        ///// <param name="exprExecFunctionCallDouble"></param>
        ///// <param name="listExprExecParam"></param>
        ///// <param name="exprExecBase"></param>
        ///// <returns></returns>
        //private bool ExecFuncRetDouble_Double(ExprExecResult exprExecResult, ExprExecFunctionCallDouble exprExecFunctionCallDouble, List<ExpressionExecBase> listExprExecParam, out ExpressionExecBase exprExecBase)
        //{
        //    exprExecBase = null;

        //    // not enought or too many parameter
        //    if (!CheckParamsCount(exprExecResult, listExprExecParam, 1))
        //        return false;

        //    try
        //    {
        //        // get the single param and check the type
        //        ExprExecValueDouble exprParamDouble;
        //        if (!GetCheckParamDouble(exprExecResult, listExprExecParam[0], out exprParamDouble))
        //            return false;

        //        // execute the function linked to the functionCall found in the expression
        //        double res = exprExecFunctionCallDouble.FunctionToCallMapper.FuncDouble_Double.Invoke(exprParamDouble.Value);
        //        exprExecFunctionCallDouble.Value = res;
        //        exprExecBase = exprExecFunctionCallDouble;
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        // error occurs on executing the function
        //        return AddErrorExecFailed(exprExecResult, e);
        //    }
        //}

        //// todo:  add others with params
        //#endregion
    }
}