using System;
using System.Collections.Generic;

namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// Execution configurator.
    /// To define variable, attache function code to functionCall
    /// Called before the executor.
    /// 
    /// Variables are defined only for the current execution.
    /// When a new execution starts (InitExec), the variables are removed.
    /// 
    /// Functions mapped to functionCall are set only one time for all executions.
    /// </summary>
    public class ExprExecConfigurator
    {
        /// <summary>
        /// General configuration:
        ///     operators definition: logical, comparison, calculation.
        /// Function Code attached to functionCall name.
        /// </summary>
        ExpressionEvalConfig _exprEvalConfig;

        /// <summary>
        /// The current expression execution result.
        /// </summary>
        private ExpressionData _expressionData;

        /// <summary>
        /// list of configuration error.
        /// Define var and attach function errors.
        /// </summary>
        private List<ExprError> _listError = new List<ExprError>();


        public ExprExecConfigurator()
        {
        }

        #region Public Define variables methods

        public void SetExpressionData(ExpressionData expressionData)
        {
            _expressionData = expressionData;
        }

        public void SetConfiguration(ExpressionEvalConfig exprEvalConfig)
        {
            _exprEvalConfig = exprEvalConfig;
        }

        /// <summary>
        /// remove all variables definition.
        /// </summary>
        public void ClearAllVarDefinition()
        {
            _exprEvalConfig.ListExprVariable.Clear();

            // remove all defineVar errors
            _listError.RemoveAll(err => err.ErrorType == ErrorType.DefineVar);
        }

        /// <summary>
        /// clear the config errors (define var, attach func)
        /// 
        /// </summary>
        public void ClearAllErrorExprConfig()
        {
            _listError.Clear();
        }

        /// <summary>
        /// Returns the list of configuration errors:
        /// wrong var definition, wring function attachment.
        /// </summary>
        /// <returns></returns>
        public List<ExprError> GetListErrorExprConfig()
        {
            return _listError;
        }

        /// <summary>
        /// Set a bool value to a variable.
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool DefineVarBool(string varName, bool value, out ExprError error)
        {
            if (!CheckVariableSyntax(varName, out error))
            {
                error.ErrorType = ErrorType.DefineVar;
                _listError.Add(error);
                return false;
            }

            // create the variable
            ExprVariableBool exprVariable = new ExprVariableBool();
            exprVariable.Name = varName;
            exprVariable.Value = value;

            // find the variable and set the type and the value
            return SaveVar(exprVariable);
        }

        /// <summary>
        /// Set an int value to a variable.
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool DefineVarInt(string varName, int value, out ExprError error)
        {
            if (!CheckVariableSyntax(varName, out error))
            {
                error.ErrorType = ErrorType.DefineVar;
                _listError.Add(error);
                return false;
            }

            // ok, now define the variable: type and value
            ExprVariableInt exprVariable = new ExprVariableInt();
            exprVariable.Name = varName;
            exprVariable.Value = value;

            // find the variable and set the type and the value
            return SaveVar(exprVariable);
        }

        /// <summary>
        /// Set a  double value to a variable.
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool DefineVarDouble(string varName, double value, out ExprError error)
        {
            if (!CheckVariableSyntax(varName, out error))
            {
                error.ErrorType = ErrorType.DefineVar;
                _listError.Add(error);
                return false;
            }

            // ok, now define the variable: type and value
            ExprVariableDouble exprVariable = new ExprVariableDouble();
            exprVariable.Name = varName;
            exprVariable.Value = value;

            // find the variable and set the type and the value
            return SaveVar(exprVariable);
        }

        /// <summary>
        /// Set a string value to a variable.
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool DefineVarString(string varName, string value, out ExprError error)
        {
            if (!CheckVariableSyntax(varName, out error))
            {
                error.ErrorType = ErrorType.DefineVar;
                _listError.Add(error);
                return false;
            }

            // ok, now define the variable: type and value
            ExprVariableString exprVariable = new ExprVariableString();
            exprVariable.Name = varName;
            exprVariable.Value = value;

            // find the variable and set the type and the value
            return SaveVar(exprVariable);
        }


        #endregion


        /// <summary>
        /// Remove all attached function code.
        /// </summary>
        public void RemoveAllFunctionAttachment()
        {
            _exprEvalConfig.ListFunctionToCallMapper.Clear();


            // remove all defineVar errors
            _listError.RemoveAll(err => err.ErrorType == ErrorType.AttachFunc);
        }

        //======================================================================
        #region Public function attachment return bool, 0 and 1 parameters

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// 
        /// Can define attachment even if functionCall is not yet defined.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool> funcBool, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            // get the name of function to map
            functionToCall.Name = funcBool.Method.Name;
            functionToCall.ReturnType = DataType.Bool;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetBool;

            // set the function to call
            functionToCall.FuncBool = funcBool;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }

        public bool AttachFunction(string functionCallName, Func<bool, bool> funcBool_Bool, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            // get the name of function to map
            functionToCall.Name = funcBool_Bool.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetBool_Bool;
            functionToCall.ReturnType = DataType.Bool;
            functionToCall.Param1Type = DataType.Bool;

            // set the function to call
            functionToCall.FuncBool_Bool = funcBool_Bool;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }

        // ret is bool
        public bool AttachFunction(string functionCallName, Func<int, bool> funcBool_Int, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            // get the name of function to map
            functionToCall.Name = funcBool_Int.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetBool_Int;
            functionToCall.ReturnType = DataType.Bool;
            functionToCall.Param1Type = DataType.Int;

            // set the function to call
            functionToCall.FuncBool_Int = funcBool_Int;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }

        public bool AttachFunction(string functionCallName, Func<string, bool> funcBool_String, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            // get the name of function to map
            functionToCall.Name = funcBool_String.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetBool_String;
            functionToCall.ReturnType = DataType.Bool;
            functionToCall.Param1Type = DataType.String;

            // set the function to call
            functionToCall.FuncBool_String = funcBool_String;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }

        public bool AttachFunction(string functionCallName, Func<double, bool> funcBool_Double, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            // get the name of function to map
            functionToCall.Name = funcBool_Double.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetBool_String;
            functionToCall.ReturnType = DataType.Bool;
            functionToCall.Param1Type = DataType.Double;

            // set the function to call
            functionToCall.FuncBool_Double = funcBool_Double;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }

        #endregion

        //======================================================================
        #region Public function attachment return int, 0 and 1 parameters

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// 
        /// Can define attachment even if functionCall is not yet defined.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int> funcInt, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            // get the name of function to map
            functionToCall.Name = funcInt.Method.Name;
            functionToCall.ReturnType = DataType.Int;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetInt;

            // set the function to call
            functionToCall.FuncInt = funcInt;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }

        public bool AttachFunction(string functionCallName, Func<bool, int> funcInt_Bool, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            // get the name of function to map
            functionToCall.Name = funcInt_Bool.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetInt_Bool;
            functionToCall.ReturnType = DataType.Int;
            functionToCall.Param1Type = DataType.Bool;

            // set the function to call
            functionToCall.FuncInt_Bool = funcInt_Bool;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }

        public bool AttachFunction(string functionCallName, Func<int, int> funcInt_Int, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            // get the name of function to map
            functionToCall.Name = funcInt_Int.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetInt_Int;
            functionToCall.ReturnType = DataType.Int;
            functionToCall.Param1Type = DataType.Int;

            // set the function to call
            functionToCall.FuncInt_Int = funcInt_Int;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }

        public bool AttachFunction(string functionCallName, Func<string, int> funcInt_String, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            // get the name of function to map
            functionToCall.Name = funcInt_String.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetInt_String;
            functionToCall.ReturnType = DataType.Int;
            functionToCall.Param1Type = DataType.String;

            // set the function to call
            functionToCall.FuncInt_String = funcInt_String;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }

        public bool AttachFunction(string functionCallName, Func<double, int> funcInt_Double, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            // get the name of function to map
            functionToCall.Name = funcInt_Double.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetInt_Double;
            functionToCall.ReturnType = DataType.Int;
            functionToCall.Param1Type = DataType.Double;

            // set the function to call
            functionToCall.FuncInt_Double = funcInt_Double;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }

        #endregion

        //======================================================================
        #region Public function attachment return string, 0 and 1 parameters

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// 
        /// Can define attachment even if functionCall is not yet defined.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string> funcString, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            // get the name of function to map
            functionToCall.Name = funcString.Method.Name;

            functionToCall.ReturnType = DataType.String;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetInt;

            // set the function to call
            functionToCall.FuncString = funcString;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }

        public bool AttachFunction(string functionCallName, Func<bool, string> funcString_Bool, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            // get the name of function to map
            functionToCall.Name = funcString_Bool.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetString_Bool;
            functionToCall.ReturnType = DataType.String;
            functionToCall.Param1Type = DataType.Bool;

            // set the function to call
            functionToCall.FuncString_Bool = funcString_Bool;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }

        public bool AttachFunction(string functionCallName, Func<int, string> funcString_Int, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            // get the name of function to map
            functionToCall.Name = funcString_Int.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetString_Int;
            functionToCall.ReturnType = DataType.String;
            functionToCall.Param1Type = DataType.Int;

            // set the function to call
            functionToCall.FuncString_Int = funcString_Int;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }

        public bool AttachFunction(string functionCallName, Func<string, string> funcString_String, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            // get the name of function to map
            functionToCall.Name = funcString_String.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetString_String;
            functionToCall.ReturnType = DataType.String;
            functionToCall.Param1Type = DataType.String;

            // set the function to call
            functionToCall.FuncString_String = funcString_String;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }

        public bool AttachFunction(string functionCallName, Func<double, string> funcString_Double, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            // get the name of function to map
            functionToCall.Name = funcString_Double.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetString_Double;
            functionToCall.ReturnType = DataType.String;
            functionToCall.Param1Type = DataType.Double;

            // set the function to call
            functionToCall.FuncString_Double = funcString_Double;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }

        #endregion

        //======================================================================
        #region Public function attachment return double, 0 and 1 parameters

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// 
        /// Can define attachment even if functionCall is not yet defined.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double> funcDouble, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            // get the name of function to map
            functionToCall.Name = funcDouble.Method.Name;
            functionToCall.ReturnType = DataType.Bool;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetDouble;

            // set the function to call
            functionToCall.FuncDouble = funcDouble;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }



        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// 
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// return type is: double, param1 type is: bool
        ///
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcDouble_Bool"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, double> funcDouble_Bool, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            // get the name of function to map
            functionToCall.Name = funcDouble_Bool.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetDouble_Bool;
            functionToCall.ReturnType = DataType.Double;
            functionToCall.Param1Type = DataType.Bool;

            // set the function to call
            functionToCall.FuncDouble_Bool = funcDouble_Bool;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// 
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// return type is: double, param1 type is: int
        ///
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcDouble_Int"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, double> funcDouble_Int, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            // get the name of function to map
            functionToCall.Name = funcDouble_Int.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetDouble_Int;
            functionToCall.ReturnType = DataType.Double;
            functionToCall.Param1Type = DataType.Int;

            // set the function to call
            functionToCall.FuncDouble_Int = funcDouble_Int;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// 
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// return type is: double, param1 type is: string
        ///
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcDouble_String"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, double> funcDouble_String, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            // get the name of function to map
            functionToCall.Name = funcDouble_String.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetDouble_String;
            functionToCall.ReturnType = DataType.Double;
            functionToCall.Param1Type = DataType.String;

            // set the function to call
            functionToCall.FuncDouble_String = funcDouble_String;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// 
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// return type is: double, param1 type is: double
        ///
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcDouble_Double"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, double> funcDouble_Double, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            // get the name of function to map
            functionToCall.Name = funcDouble_Double.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetDouble_Double;
            functionToCall.ReturnType = DataType.Double;
            functionToCall.Param1Type = DataType.Double;

            // set the function to call
            functionToCall.FuncDouble_Double = funcDouble_Double;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }
        #endregion

        //======================================================================
        #region Public function attachment return Bool, 2 parameters.

        /// <summary>
        /// Attach a function. 
        /// return: bool.
        /// 2 parameters: bool, bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool_Bool_Bool"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, bool, bool> funcBool_Bool_Bool, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcBool_Bool_Bool.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetBool_Bool_Bool;
            functionToCall.ReturnType = DataType.Bool;
            functionToCall.Param1Type = DataType.Bool;
            functionToCall.Param2Type = DataType.Bool;

            // set the function to call
            functionToCall.FuncBool_Bool_Bool = funcBool_Bool_Bool;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: bool.
        /// 2 parameters: bool, int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool_Bool_Int"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, int, bool> funcBool_Bool_Int, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcBool_Bool_Int.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetBool_Bool_Int;
            functionToCall.ReturnType = DataType.Bool;
            functionToCall.Param1Type = DataType.Bool;
            functionToCall.Param2Type = DataType.Int;

            // set the function to call
            functionToCall.FuncBool_Bool_Int = funcBool_Bool_Int;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: bool.
        /// 2 parameters: bool, string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool_Bool_String"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, string, bool> funcBool_Bool_String, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcBool_Bool_String.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetBool_Bool_String;
            functionToCall.ReturnType = DataType.Bool;
            functionToCall.Param1Type = DataType.Bool;
            functionToCall.Param2Type = DataType.String;

            // set the function to call
            functionToCall.FuncBool_Bool_String = funcBool_Bool_String;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: bool.
        /// 2 parameters: bool, double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool_Bool_Double"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, double, bool> funcBool_Bool_Double, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcBool_Bool_Double.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetBool_Bool_Double;
            functionToCall.ReturnType = DataType.Bool;
            functionToCall.Param1Type = DataType.Bool;
            functionToCall.Param2Type = DataType.Double;

            // set the function to call
            functionToCall.FuncBool_Bool_Double = funcBool_Bool_Double;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: bool.
        /// 2 parameters: int, bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool_Int_Bool"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, bool, bool> funcBool_Int_Bool, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcBool_Int_Bool.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetBool_Int_Bool;
            functionToCall.ReturnType = DataType.Bool;
            functionToCall.Param1Type = DataType.Int;
            functionToCall.Param2Type = DataType.Bool;

            // set the function to call
            functionToCall.FuncBool_Int_Bool = funcBool_Int_Bool;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: bool.
        /// 2 parameters: int, int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool_Int_Int"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, int, bool> funcBool_Int_Int, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcBool_Int_Int.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetBool_Int_Int;
            functionToCall.ReturnType = DataType.Bool;
            functionToCall.Param1Type = DataType.Int;
            functionToCall.Param2Type = DataType.Int;

            // set the function to call
            functionToCall.FuncBool_Int_Int = funcBool_Int_Int;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: bool.
        /// 2 parameters: int, string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool_Int_String"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, string, bool> funcBool_Int_String, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcBool_Int_String.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetBool_Int_String;
            functionToCall.ReturnType = DataType.Bool;
            functionToCall.Param1Type = DataType.Int;
            functionToCall.Param2Type = DataType.String;

            // set the function to call
            functionToCall.FuncBool_Int_String = funcBool_Int_String;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: bool.
        /// 2 parameters: int, double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool_Int_Double"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, double, bool> funcBool_Int_Double, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcBool_Int_Double.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetBool_Int_Double;
            functionToCall.ReturnType = DataType.Bool;
            functionToCall.Param1Type = DataType.Int;
            functionToCall.Param2Type = DataType.Double;

            // set the function to call
            functionToCall.FuncBool_Int_Double = funcBool_Int_Double;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: bool.
        /// 2 parameters: string, bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool_String_Bool"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, bool, bool> funcBool_String_Bool, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcBool_String_Bool.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetBool_String_Bool;
            functionToCall.ReturnType = DataType.Bool;
            functionToCall.Param1Type = DataType.String;
            functionToCall.Param2Type = DataType.Bool;

            // set the function to call
            functionToCall.FuncBool_String_Bool = funcBool_String_Bool;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: bool.
        /// 2 parameters: string, int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool_String_Int"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, int, bool> funcBool_String_Int, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcBool_String_Int.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetBool_String_Int;
            functionToCall.ReturnType = DataType.Bool;
            functionToCall.Param1Type = DataType.String;
            functionToCall.Param2Type = DataType.Int;

            // set the function to call
            functionToCall.FuncBool_String_Int = funcBool_String_Int;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: bool.
        /// 2 parameters: string, string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool_String_String"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, string, bool> funcBool_String_String, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcBool_String_String.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetBool_String_String;
            functionToCall.ReturnType = DataType.Bool;
            functionToCall.Param1Type = DataType.String;
            functionToCall.Param2Type = DataType.String;

            // set the function to call
            functionToCall.FuncBool_String_String = funcBool_String_String;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: bool.
        /// 2 parameters: string, double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool_String_Double"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, double, bool> funcBool_String_Double, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcBool_String_Double.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetBool_String_Double;
            functionToCall.ReturnType = DataType.Bool;
            functionToCall.Param1Type = DataType.String;
            functionToCall.Param2Type = DataType.Double;

            // set the function to call
            functionToCall.FuncBool_String_Double = funcBool_String_Double;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: bool.
        /// 2 parameters: double, bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool_Double_Bool"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, bool, bool> funcBool_Double_Bool, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcBool_Double_Bool.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetBool_Double_Bool;
            functionToCall.ReturnType = DataType.Bool;
            functionToCall.Param1Type = DataType.Double;
            functionToCall.Param2Type = DataType.Bool;

            // set the function to call
            functionToCall.FuncBool_Double_Bool = funcBool_Double_Bool;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: bool.
        /// 2 parameters: double, int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool_Double_Int"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, int, bool> funcBool_Double_Int, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcBool_Double_Int.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetBool_Double_Int;
            functionToCall.ReturnType = DataType.Bool;
            functionToCall.Param1Type = DataType.Double;
            functionToCall.Param2Type = DataType.Int;

            // set the function to call
            functionToCall.FuncBool_Double_Int = funcBool_Double_Int;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: bool.
        /// 2 parameters: double, string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool_Double_String"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, string, bool> funcBool_Double_String, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcBool_Double_String.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetBool_Double_String;
            functionToCall.ReturnType = DataType.Bool;
            functionToCall.Param1Type = DataType.Double;
            functionToCall.Param2Type = DataType.String;

            // set the function to call
            functionToCall.FuncBool_Double_String = funcBool_Double_String;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: bool.
        /// 2 parameters: double, double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool_Double_Double"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, double, bool> funcBool_Double_Double, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcBool_Double_Double.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetBool_Double_Double;
            functionToCall.ReturnType = DataType.Bool;
            functionToCall.Param1Type = DataType.Double;
            functionToCall.Param2Type = DataType.Double;

            // set the function to call
            functionToCall.FuncBool_Double_Double = funcBool_Double_Double;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }

        #endregion

        //======================================================================
        #region Public function attachment return Int, 2 parameters.

        /// <summary>
        /// Attach a function. 
        /// return: int.
        /// 2 parameters: bool, bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcInt_Bool_Bool"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, bool, int> funcInt_Bool_Bool, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcInt_Bool_Bool.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetInt_Bool_Bool;
            functionToCall.ReturnType = DataType.Int;
            functionToCall.Param1Type = DataType.Bool;
            functionToCall.Param2Type = DataType.Bool;

            // set the function to call
            functionToCall.FuncInt_Bool_Bool = funcInt_Bool_Bool;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: int.
        /// 2 parameters: bool, int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcInt_Bool_Int"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, int, int> funcInt_Bool_Int, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcInt_Bool_Int.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetInt_Bool_Int;
            functionToCall.ReturnType = DataType.Int;
            functionToCall.Param1Type = DataType.Bool;
            functionToCall.Param2Type = DataType.Int;

            // set the function to call
            functionToCall.FuncInt_Bool_Int = funcInt_Bool_Int;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: int.
        /// 2 parameters: bool, string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcInt_Bool_String"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, string, int> funcInt_Bool_String, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcInt_Bool_String.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetInt_Bool_String;
            functionToCall.ReturnType = DataType.Int;
            functionToCall.Param1Type = DataType.Bool;
            functionToCall.Param2Type = DataType.String;

            // set the function to call
            functionToCall.FuncInt_Bool_String = funcInt_Bool_String;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: int.
        /// 2 parameters: bool, double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcInt_Bool_Double"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, double, int> funcInt_Bool_Double, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcInt_Bool_Double.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetInt_Bool_Double;
            functionToCall.ReturnType = DataType.Int;
            functionToCall.Param1Type = DataType.Bool;
            functionToCall.Param2Type = DataType.Double;

            // set the function to call
            functionToCall.FuncInt_Bool_Double = funcInt_Bool_Double;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: int.
        /// 2 parameters: int, bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcInt_Int_Bool"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, bool, int> funcInt_Int_Bool, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcInt_Int_Bool.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetInt_Int_Bool;
            functionToCall.ReturnType = DataType.Int;
            functionToCall.Param1Type = DataType.Int;
            functionToCall.Param2Type = DataType.Bool;

            // set the function to call
            functionToCall.FuncInt_Int_Bool = funcInt_Int_Bool;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: int.
        /// 2 parameters: int, int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcInt_Int_Int"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, int, int> funcInt_Int_Int, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcInt_Int_Int.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetInt_Int_Int;
            functionToCall.ReturnType = DataType.Int;
            functionToCall.Param1Type = DataType.Int;
            functionToCall.Param2Type = DataType.Int;

            // set the function to call
            functionToCall.FuncInt_Int_Int = funcInt_Int_Int;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: int.
        /// 2 parameters: int, string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcInt_Int_String"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, string, int> funcInt_Int_String, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcInt_Int_String.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetInt_Int_String;
            functionToCall.ReturnType = DataType.Int;
            functionToCall.Param1Type = DataType.Int;
            functionToCall.Param2Type = DataType.String;

            // set the function to call
            functionToCall.FuncInt_Int_String = funcInt_Int_String;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: int.
        /// 2 parameters: int, double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcInt_Int_Double"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, double, int> funcInt_Int_Double, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcInt_Int_Double.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetInt_Int_Double;
            functionToCall.ReturnType = DataType.Int;
            functionToCall.Param1Type = DataType.Int;
            functionToCall.Param2Type = DataType.Double;

            // set the function to call
            functionToCall.FuncInt_Int_Double = funcInt_Int_Double;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: int.
        /// 2 parameters: string, bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcInt_String_Bool"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, bool, int> funcInt_String_Bool, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcInt_String_Bool.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetInt_String_Bool;
            functionToCall.ReturnType = DataType.Int;
            functionToCall.Param1Type = DataType.String;
            functionToCall.Param2Type = DataType.Bool;

            // set the function to call
            functionToCall.FuncInt_String_Bool = funcInt_String_Bool;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: int.
        /// 2 parameters: string, int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcInt_String_Int"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, int, int> funcInt_String_Int, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcInt_String_Int.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetInt_String_Int;
            functionToCall.ReturnType = DataType.Int;
            functionToCall.Param1Type = DataType.String;
            functionToCall.Param2Type = DataType.Int;

            // set the function to call
            functionToCall.FuncInt_String_Int = funcInt_String_Int;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: int.
        /// 2 parameters: string, string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcInt_String_String"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, string, int> funcInt_String_String, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcInt_String_String.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetInt_String_String;
            functionToCall.ReturnType = DataType.Int;
            functionToCall.Param1Type = DataType.String;
            functionToCall.Param2Type = DataType.String;

            // set the function to call
            functionToCall.FuncInt_String_String = funcInt_String_String;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: int.
        /// 2 parameters: string, double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcInt_String_Double"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, double, int> funcInt_String_Double, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcInt_String_Double.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetInt_String_Double;
            functionToCall.ReturnType = DataType.Int;
            functionToCall.Param1Type = DataType.String;
            functionToCall.Param2Type = DataType.Double;

            // set the function to call
            functionToCall.FuncInt_String_Double = funcInt_String_Double;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: int.
        /// 2 parameters: double, bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcInt_Double_Bool"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, bool, int> funcInt_Double_Bool, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcInt_Double_Bool.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetInt_Double_Bool;
            functionToCall.ReturnType = DataType.Int;
            functionToCall.Param1Type = DataType.Double;
            functionToCall.Param2Type = DataType.Bool;

            // set the function to call
            functionToCall.FuncInt_Double_Bool = funcInt_Double_Bool;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: int.
        /// 2 parameters: double, int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcInt_Double_Int"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, int, int> funcInt_Double_Int, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcInt_Double_Int.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetInt_Double_Int;
            functionToCall.ReturnType = DataType.Int;
            functionToCall.Param1Type = DataType.Double;
            functionToCall.Param2Type = DataType.Int;

            // set the function to call
            functionToCall.FuncInt_Double_Int = funcInt_Double_Int;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: int.
        /// 2 parameters: double, string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcInt_Double_String"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, string, int> funcInt_Double_String, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcInt_Double_String.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetInt_Double_String;
            functionToCall.ReturnType = DataType.Int;
            functionToCall.Param1Type = DataType.Double;
            functionToCall.Param2Type = DataType.String;

            // set the function to call
            functionToCall.FuncInt_Double_String = funcInt_Double_String;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: int.
        /// 2 parameters: double, double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcInt_Double_Double"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, double, int> funcInt_Double_Double, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcInt_Double_Double.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetInt_Double_Double;
            functionToCall.ReturnType = DataType.Int;
            functionToCall.Param1Type = DataType.Double;
            functionToCall.Param2Type = DataType.Double;

            // set the function to call
            functionToCall.FuncInt_Double_Double = funcInt_Double_Double;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }

        #endregion

        //======================================================================
        #region Public function attachment return String, 2 parameters.


        /// <summary>
        /// Attach a function. 
        /// return: string.
        /// 2 parameters: bool, bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcString_Bool_Bool"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, bool, string> funcString_Bool_Bool, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcString_Bool_Bool.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetString_Bool_Bool;
            functionToCall.ReturnType = DataType.String;
            functionToCall.Param1Type = DataType.Bool;
            functionToCall.Param2Type = DataType.Bool;

            // set the function to call
            functionToCall.FuncString_Bool_Bool = funcString_Bool_Bool;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: string.
        /// 2 parameters: bool, int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcString_Bool_Int"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, int, string> funcString_Bool_Int, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcString_Bool_Int.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetString_Bool_Int;
            functionToCall.ReturnType = DataType.String;
            functionToCall.Param1Type = DataType.Bool;
            functionToCall.Param2Type = DataType.Int;

            // set the function to call
            functionToCall.FuncString_Bool_Int = funcString_Bool_Int;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: string.
        /// 2 parameters: bool, string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcString_Bool_String"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, string, string> funcString_Bool_String, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcString_Bool_String.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetString_Bool_String;
            functionToCall.ReturnType = DataType.String;
            functionToCall.Param1Type = DataType.Bool;
            functionToCall.Param2Type = DataType.String;

            // set the function to call
            functionToCall.FuncString_Bool_String = funcString_Bool_String;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: string.
        /// 2 parameters: bool, double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcString_Bool_Double"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, double, string> funcString_Bool_Double, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcString_Bool_Double.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetString_Bool_Double;
            functionToCall.ReturnType = DataType.String;
            functionToCall.Param1Type = DataType.Bool;
            functionToCall.Param2Type = DataType.Double;

            // set the function to call
            functionToCall.FuncString_Bool_Double = funcString_Bool_Double;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: string.
        /// 2 parameters: int, bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcString_Int_Bool"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, bool, string> funcString_Int_Bool, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcString_Int_Bool.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetString_Int_Bool;
            functionToCall.ReturnType = DataType.String;
            functionToCall.Param1Type = DataType.Int;
            functionToCall.Param2Type = DataType.Bool;

            // set the function to call
            functionToCall.FuncString_Int_Bool = funcString_Int_Bool;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: string.
        /// 2 parameters: int, int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcString_Int_Int"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, int, string> funcString_Int_Int, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcString_Int_Int.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetString_Int_Int;
            functionToCall.ReturnType = DataType.String;
            functionToCall.Param1Type = DataType.Int;
            functionToCall.Param2Type = DataType.Int;

            // set the function to call
            functionToCall.FuncString_Int_Int = funcString_Int_Int;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: string.
        /// 2 parameters: int, string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcString_Int_String"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, string, string> funcString_Int_String, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcString_Int_String.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetString_Int_String;
            functionToCall.ReturnType = DataType.String;
            functionToCall.Param1Type = DataType.Int;
            functionToCall.Param2Type = DataType.String;

            // set the function to call
            functionToCall.FuncString_Int_String = funcString_Int_String;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: string.
        /// 2 parameters: int, double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcString_Int_Double"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, double, string> funcString_Int_Double, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcString_Int_Double.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetString_Int_Double;
            functionToCall.ReturnType = DataType.String;
            functionToCall.Param1Type = DataType.Int;
            functionToCall.Param2Type = DataType.Double;

            // set the function to call
            functionToCall.FuncString_Int_Double = funcString_Int_Double;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: string.
        /// 2 parameters: string, bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcString_String_Bool"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, bool, string> funcString_String_Bool, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcString_String_Bool.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetString_String_Bool;
            functionToCall.ReturnType = DataType.String;
            functionToCall.Param1Type = DataType.String;
            functionToCall.Param2Type = DataType.Bool;

            // set the function to call
            functionToCall.FuncString_String_Bool = funcString_String_Bool;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: string.
        /// 2 parameters: string, int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcString_String_Int"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, int, string> funcString_String_Int, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcString_String_Int.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetString_String_Int;
            functionToCall.ReturnType = DataType.String;
            functionToCall.Param1Type = DataType.String;
            functionToCall.Param2Type = DataType.Int;

            // set the function to call
            functionToCall.FuncString_String_Int = funcString_String_Int;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: string.
        /// 2 parameters: string, string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcString_String_String"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, string, string> funcString_String_String, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcString_String_String.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetString_String_String;
            functionToCall.ReturnType = DataType.String;
            functionToCall.Param1Type = DataType.String;
            functionToCall.Param2Type = DataType.String;

            // set the function to call
            functionToCall.FuncString_String_String = funcString_String_String;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: string.
        /// 2 parameters: string, double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcString_String_Double"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, double, string> funcString_String_Double, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcString_String_Double.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetString_String_Double;
            functionToCall.ReturnType = DataType.String;
            functionToCall.Param1Type = DataType.String;
            functionToCall.Param2Type = DataType.Double;

            // set the function to call
            functionToCall.FuncString_String_Double = funcString_String_Double;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: string.
        /// 2 parameters: double, bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcString_Double_Bool"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, bool, string> funcString_Double_Bool, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcString_Double_Bool.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetString_Double_Bool;
            functionToCall.ReturnType = DataType.String;
            functionToCall.Param1Type = DataType.Double;
            functionToCall.Param2Type = DataType.Bool;

            // set the function to call
            functionToCall.FuncString_Double_Bool = funcString_Double_Bool;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: string.
        /// 2 parameters: double, int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcString_Double_Int"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, int, string> funcString_Double_Int, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcString_Double_Int.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetString_Double_Int;
            functionToCall.ReturnType = DataType.String;
            functionToCall.Param1Type = DataType.Double;
            functionToCall.Param2Type = DataType.Int;

            // set the function to call
            functionToCall.FuncString_Double_Int = funcString_Double_Int;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: string.
        /// 2 parameters: double, string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcString_Double_String"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, string, string> funcString_Double_String, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcString_Double_String.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetString_Double_String;
            functionToCall.ReturnType = DataType.String;
            functionToCall.Param1Type = DataType.Double;
            functionToCall.Param2Type = DataType.String;

            // set the function to call
            functionToCall.FuncString_Double_String = funcString_Double_String;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: string.
        /// 2 parameters: double, double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcString_Double_Double"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, double, string> funcString_Double_Double, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcString_Double_Double.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetString_Double_Double;
            functionToCall.ReturnType = DataType.String;
            functionToCall.Param1Type = DataType.Double;
            functionToCall.Param2Type = DataType.Double;

            // set the function to call
            functionToCall.FuncString_Double_Double = funcString_Double_Double;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }

        #endregion


        //======================================================================
        #region Public function attachment return Double, 2 parameters.

        /// <summary>
        /// Attach a function. 
        /// return: double.
        /// 2 parameters: bool, bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcDouble_Bool_Bool"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, bool, double> funcDouble_Bool_Bool, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcDouble_Bool_Bool.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetDouble_Bool_Bool;
            functionToCall.ReturnType = DataType.Double;
            functionToCall.Param1Type = DataType.Bool;
            functionToCall.Param2Type = DataType.Bool;

            // set the function to call
            functionToCall.FuncDouble_Bool_Bool = funcDouble_Bool_Bool;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: double.
        /// 2 parameters: bool, int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcDouble_Bool_Int"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, int, double> funcDouble_Bool_Int, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcDouble_Bool_Int.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetDouble_Bool_Int;
            functionToCall.ReturnType = DataType.Double;
            functionToCall.Param1Type = DataType.Bool;
            functionToCall.Param2Type = DataType.Int;

            // set the function to call
            functionToCall.FuncDouble_Bool_Int = funcDouble_Bool_Int;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: double.
        /// 2 parameters: bool, string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcDouble_Bool_String"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, string, double> funcDouble_Bool_String, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcDouble_Bool_String.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetDouble_Bool_String;
            functionToCall.ReturnType = DataType.Double;
            functionToCall.Param1Type = DataType.Bool;
            functionToCall.Param2Type = DataType.String;

            // set the function to call
            functionToCall.FuncDouble_Bool_String = funcDouble_Bool_String;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: double.
        /// 2 parameters: bool, double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcDouble_Bool_Double"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, double, double> funcDouble_Bool_Double, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcDouble_Bool_Double.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetDouble_Bool_Double;
            functionToCall.ReturnType = DataType.Double;
            functionToCall.Param1Type = DataType.Bool;
            functionToCall.Param2Type = DataType.Double;

            // set the function to call
            functionToCall.FuncDouble_Bool_Double = funcDouble_Bool_Double;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: double.
        /// 2 parameters: int, bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcDouble_Int_Bool"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, bool, double> funcDouble_Int_Bool, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcDouble_Int_Bool.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetDouble_Int_Bool;
            functionToCall.ReturnType = DataType.Double;
            functionToCall.Param1Type = DataType.Int;
            functionToCall.Param2Type = DataType.Bool;

            // set the function to call
            functionToCall.FuncDouble_Int_Bool = funcDouble_Int_Bool;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: double.
        /// 2 parameters: int, int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcDouble_Int_Int"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, int, double> funcDouble_Int_Int, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcDouble_Int_Int.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetDouble_Int_Int;
            functionToCall.ReturnType = DataType.Double;
            functionToCall.Param1Type = DataType.Int;
            functionToCall.Param2Type = DataType.Int;

            // set the function to call
            functionToCall.FuncDouble_Int_Int = funcDouble_Int_Int;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: double.
        /// 2 parameters: int, string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcDouble_Int_String"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, string, double> funcDouble_Int_String, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcDouble_Int_String.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetDouble_Int_String;
            functionToCall.ReturnType = DataType.Double;
            functionToCall.Param1Type = DataType.Int;
            functionToCall.Param2Type = DataType.String;

            // set the function to call
            functionToCall.FuncDouble_Int_String = funcDouble_Int_String;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: double.
        /// 2 parameters: int, double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcDouble_Int_Double"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, double, double> funcDouble_Int_Double, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcDouble_Int_Double.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetDouble_Int_Double;
            functionToCall.ReturnType = DataType.Double;
            functionToCall.Param1Type = DataType.Int;
            functionToCall.Param2Type = DataType.Double;

            // set the function to call
            functionToCall.FuncDouble_Int_Double = funcDouble_Int_Double;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: double.
        /// 2 parameters: string, bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcDouble_String_Bool"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, bool, double> funcDouble_String_Bool, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcDouble_String_Bool.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetDouble_String_Bool;
            functionToCall.ReturnType = DataType.Double;
            functionToCall.Param1Type = DataType.String;
            functionToCall.Param2Type = DataType.Bool;

            // set the function to call
            functionToCall.FuncDouble_String_Bool = funcDouble_String_Bool;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: double.
        /// 2 parameters: string, int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcDouble_String_Int"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, int, double> funcDouble_String_Int, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcDouble_String_Int.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetDouble_String_Int;
            functionToCall.ReturnType = DataType.Double;
            functionToCall.Param1Type = DataType.String;
            functionToCall.Param2Type = DataType.Int;

            // set the function to call
            functionToCall.FuncDouble_String_Int = funcDouble_String_Int;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: double.
        /// 2 parameters: string, string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcDouble_String_String"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, string, double> funcDouble_String_String, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcDouble_String_String.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetDouble_String_String;
            functionToCall.ReturnType = DataType.Double;
            functionToCall.Param1Type = DataType.String;
            functionToCall.Param2Type = DataType.String;

            // set the function to call
            functionToCall.FuncDouble_String_String = funcDouble_String_String;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: double.
        /// 2 parameters: string, double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcDouble_String_Double"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, double, double> funcDouble_String_Double, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcDouble_String_Double.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetDouble_String_Double;
            functionToCall.ReturnType = DataType.Double;
            functionToCall.Param1Type = DataType.String;
            functionToCall.Param2Type = DataType.Double;

            // set the function to call
            functionToCall.FuncDouble_String_Double = funcDouble_String_Double;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: double.
        /// 2 parameters: double, bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcDouble_Double_Bool"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, bool, double> funcDouble_Double_Bool, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcDouble_Double_Bool.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetDouble_Double_Bool;
            functionToCall.ReturnType = DataType.Double;
            functionToCall.Param1Type = DataType.Double;
            functionToCall.Param2Type = DataType.Bool;

            // set the function to call
            functionToCall.FuncDouble_Double_Bool = funcDouble_Double_Bool;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: double.
        /// 2 parameters: double, int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcDouble_Double_Int"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, int, double> funcDouble_Double_Int, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcDouble_Double_Int.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetDouble_Double_Int;
            functionToCall.ReturnType = DataType.Double;
            functionToCall.Param1Type = DataType.Double;
            functionToCall.Param2Type = DataType.Int;

            // set the function to call
            functionToCall.FuncDouble_Double_Int = funcDouble_Double_Int;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: double.
        /// 2 parameters: double, string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcDouble_Double_String"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, string, double> funcDouble_Double_String, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcDouble_Double_String.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetDouble_Double_String;
            functionToCall.ReturnType = DataType.Double;
            functionToCall.Param1Type = DataType.Double;
            functionToCall.Param2Type = DataType.String;

            // set the function to call
            functionToCall.FuncDouble_Double_String = funcDouble_Double_String;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        /// <summary>
        /// Attach a function. 
        /// return: double.
        /// 2 parameters: double, double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcDouble_Double_Double"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, double, double> funcDouble_Double_Double, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;
            functionToCall.Name = funcDouble_Double_Double.Method.Name;

            // set the signature
            functionToCall.MethodSignature = MethodSignatureType.RetDouble_Double_Double;
            functionToCall.ReturnType = DataType.Double;
            functionToCall.Param1Type = DataType.Double;
            functionToCall.Param2Type = DataType.Double;

            // set the function to call
            functionToCall.FuncDouble_Double_Double = funcDouble_Double_Double;

            // if an attachment exists, replace it
            return AttachFunctionToCall(functionToCall);
        }


        #endregion

        // function attachchemnt, 3 and more parameters
        // todo:

        /// <summary>
        /// Generate a FunctionToCallMapper object.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcParamsMapper"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, FunctionParamsMapperBase funcParamsMapperBase, out ExprError error)
        {
            // check the syntax of the functionCall
            if (!CheckFunctionCallSyntax(functionCallName, out error))
                return false;

            // check if the function is not already attached
            // todo:

            FunctionToCallMapper functionToCall = new FunctionToCallMapper();
            functionToCall.FunctionCallName = functionCallName;


            //====Function having 3 parameters
            if (funcParamsMapperBase.ParamsCount== 3)
            {
                ExprExecFunction3ParamsConfigurator exprExecFunction3ParamsConfigurator = new ExprExecFunction3ParamsConfigurator();
                if(funcParamsMapperBase.ReturnType == DataType.Bool)
                    return exprExecFunction3ParamsConfigurator.AttachFunctionRetBool(_exprEvalConfig, funcParamsMapperBase, functionToCall, out error);

                if (funcParamsMapperBase.ReturnType == DataType.Int)
                    return exprExecFunction3ParamsConfigurator.AttachFunctionRetInt(_exprEvalConfig, funcParamsMapperBase, functionToCall, out error);

                if (funcParamsMapperBase.ReturnType == DataType.String)
                    return exprExecFunction3ParamsConfigurator.AttachFunctionRetString(_exprEvalConfig, funcParamsMapperBase, functionToCall, out error);

                if (funcParamsMapperBase.ReturnType == DataType.Double)
                    return exprExecFunction3ParamsConfigurator.AttachFunctionRetDouble(_exprEvalConfig, funcParamsMapperBase, functionToCall, out error);

                error = new ExprError();
                error.Code = ErrorCode.FunctionCall3ParamsNotManaged;
                error.AddParam("RetType", funcParamsMapperBase.ReturnType.ToString());
                return false;
            }

            //====Function having 4 parameters
            if (funcParamsMapperBase.ParamsCount == 4) { }

            // not managed or not yet implemented
            return false;
        }

        //======================================================================
        #region Privates methods

        /// <summary>
        /// Set variable definition.
        /// Variable definition scope is global to the component.
        /// So it's available for all expressions the component evaluate.
        /// If already exists, replace it with the new value (and the new type if its different!!).
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SaveVar(ExprVariableBase variable)
        {
            // check if the var not already exists, by the name
            ExprVariableBase exprVariableBase = _exprEvalConfig.ListExprVariable.Find(v => v.Name.Equals(variable.Name, StringComparison.InvariantCultureIgnoreCase));
            if (exprVariableBase != null)
            {
                // remove it (will be renew, the type can change)
                _exprEvalConfig.ListExprVariable.Remove(exprVariableBase);
            }

            _exprEvalConfig.ListExprVariable.Add(variable);
            return true;
        }

        /// <summary>
        /// Add a function to call linked to a functionCall used in the expression.
        /// The link is done by the functionCall name.
        /// If already exists, replace it with the function code.
        /// </summary>
        /// <param name="functionToCall"></param>
        /// <returns></returns>
        private bool AttachFunctionToCall(FunctionToCallMapper functionToCall)
        {
            // check if the linked functionCall has not already a function to call mapped
            FunctionToCallMapper functionToCallAttached = _exprEvalConfig.ListFunctionToCallMapper.Find(ftm => ftm.FunctionCallName.Equals(functionToCall.FunctionCallName, StringComparison.InvariantCultureIgnoreCase));
            // a function is already linked to the functionCall
            if (functionToCallAttached != null)
                // remove it (to replace it)
                _exprEvalConfig.ListFunctionToCallMapper.Remove(functionToCallAttached);

            _exprEvalConfig.ListFunctionToCallMapper.Add(functionToCall);
            return true;
        }

        /// <summary>
        /// Check the syntax of a variable defined.
        /// </summary>
        /// <param name="exprExecResult"></param>
        /// <param name="varName"></param>
        /// <returns></returns>
        private bool CheckVariableSyntax(string varName, out ExprError error)
        {
            if (string.IsNullOrWhiteSpace(varName))
            {
                //error = ExprError.CreateError(ErrorCode.VarNameSyntaxWrong, "SyntaxErrorType", "IsNullOrWhiteSpace");
                error= ExprError.CreateError(ErrorCode.VarNameSyntaxWrong, "SyntaxErrorType", "IsNullOrWhiteSpace");
                return false;
            }

            // check the syntax, the first char should be: a letter, or underscore
            if (!char.IsLetter(varName[0]) && varName[0] != '_')
            {
                error = ExprError.CreateError(ErrorCode.VarNameSyntaxWrong, "SyntaxErrorType", "FirstCharIsWrong");
                return false;
            }

            error = null;
            if (varName.Length == 1)
                return true;

            // check next chars (if exists)
            for (int i = 0; i < varName.Length; i++)
            {
                if (!char.IsLetterOrDigit(varName[i]))
                {
                    error = ExprError.CreateError(ErrorCode.VarNameSyntaxWrong, "SyntaxErrorType", "OneCharOrMoreIsWrong");
                    return false;
                }
            }
            return true;
        }

        private bool CheckFunctionCallSyntax(string functionCallName, out ExprError error)
        {
            if (string.IsNullOrWhiteSpace(functionCallName))
            {
                // ExprObjectSetError
                error = ExprError.CreateError(ErrorCode.FunctionCallNameSyntaxWrong, "SyntaxErrorType", "IsNullOrWhiteSpace");
                error.ErrorType = ErrorType.AttachFunc;
                return false;
            }

            // check the syntax, the first char should be: a letter, or underscore
            if (!char.IsLetter(functionCallName[0]) && functionCallName[0] != '_')
            {
                error = ExprError.CreateError(ErrorCode.FunctionCallNameSyntaxWrong, "SyntaxErrorType", "FirstCharIsWrong");
                error.ErrorType = ErrorType.AttachFunc;
                return false;
            }

            error = null;
            if (functionCallName.Length == 1)
                return true;

            // check next chars (if exists)
            for (int i = 0; i < functionCallName.Length; i++)
            {
                if (!char.IsLetterOrDigit(functionCallName[i]))
                {
                    error = ExprError.CreateError(ErrorCode.FunctionCallNameSyntaxWrong, "SyntaxErrorType", "OneCharOrMoreIsWrong");
                    error.ErrorType = ErrorType.AttachFunc;
                    return false;
                }
            }
            return true;
        }

        #endregion
    }
}
