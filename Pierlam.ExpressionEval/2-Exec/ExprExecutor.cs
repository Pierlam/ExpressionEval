using System;
using System.Collections.Generic;

namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// Execute a parsed expression.
    /// 
    /// Variables are defined only for the current execution.
    /// When a new execution starts (InitExec), the variables are removed.
    /// 
    /// Functions mapped to functionCall are set only one time for all executions.
    /// </summary>
    public class ExprExecutor
    {
        //enum CalcIntOrDouble
        //{
        //    NotDefined,
        //    IsInt,
        //    IsDouble,
        //}

        /// <summary>
        /// manage the execution of functions.
        /// </summary>
        ExprExecutorFunctionCall _exprExecutorFunctionCall;

        /// <summary>
        /// General configuration:
        ///  -operators definition: logical, comparison, calculation.
        ///  -Function Code attached to functionCall name.
        /// </summary>
        ExpressionEvalConfig _exprEvalConfig;

        /// <summary>
        /// expression data, context.
        /// the initial string expression.
        /// parse result and exec result.
        /// Contain variables defined for the execution.
        /// </summary>
        ExpressionData _expressionData;

        public ExprExecutor()
        {

            _exprExecutorFunctionCall = new ExprExecutorFunctionCall();
        }

        public void SetConfiguration(ExpressionEvalConfig exprEvalConfig)
        {
            _exprEvalConfig = exprEvalConfig;
        }

        public void SetExpressionData(ExpressionData expressionData)
        {
            _expressionData = expressionData;
        }

        /// <summary>
        /// Start the execution of the last parsed expression.
        /// Should have any error to execute it.
        /// </summary>
        /// <returns></returns>
        public ExpressionData Exec(ExpressionData expressionData)
        {
            // err, parse not executed before
            _expressionData = expressionData;
            if (_expressionData == null)
                _expressionData = new ExpressionData();

            if (_expressionData.ExprExecResult == null)
            {
                // create a new execution/evaluation result, remove the previous if it exists
                _expressionData.CreateExprExecResult();
                // propagate the parse result to the exec result
                _expressionData.ExprExecResult.ParseResult = _expressionData.ExprParseResult;
            }

            // check if the parse is present without any error
            if (!CheckParse(_expressionData))
                return _expressionData;

            // push variables definition to the result exec
            GetVarDefinitionToExecResult();

            // check that all used variables are defined with a value 
            if (!CheckVariables())
                return _expressionData;

            // check that all functionCall are linked/attached to a function body
            if (!CheckFunctionCalls())
                return _expressionData;

            // start the execution, analyze and return the list of variable to define
            ExpressionExecBase exprExecBase;
            ExecExpression(_expressionData.ExprExecResult, _expressionData.ExprParseResult.RootExpr, out exprExecBase);
            _expressionData.ExprExecResult.ExprExec = exprExecBase;
            return _expressionData;
        }

        #region Private methods.

        /// <summary>
        /// check if the parse is present without any error.
        /// </summary>
        /// <param name="expressionData"></param>
        /// <returns></returns>
        private bool CheckParse(ExpressionData expressionData)
        {
            // parse result should exists
            if (expressionData.ExprParseResult == null)
            {
                expressionData.ExprExecResult.AddErrorExec(ErrorCode.ParsedExpressionMissing);
                return false;
            }

            // parse result exists, has error?
            if (expressionData.ExprParseResult.HasError)
            {
                // push parse errors to execResult
                foreach (ExprError err in expressionData.ExprParseResult.ListError)
                    expressionData.ExprExecResult.AddError(err);
                //expressionData.ExprExecResult.AddErrorExec(ErrorCode.ParsedExpressionHasError);
                return false;
            }

            // ok the parse result is present without any error
            return true;
        }

        /// <summary>
        /// push variables definition to the result exec
        /// 
        /// </summary>
        /// <returns></returns>
        private bool GetVarDefinitionToExecResult()
        {
            _expressionData.ExprExecResult.ListExprVariable.Clear();

            foreach (ExprVariableBase exprVar in _exprEvalConfig.ListExprVariable)
            {
                _expressionData.ExprExecResult.ListExprVariable.Add(exprVar);
            }
            return true;
        }

        /// <summary>
        /// Check that all found variables in the expression are defined/ created with a value.
        /// </summary>
        /// <returns></returns>
        private bool CheckVariables()
        {
            bool errVarCreated = true;

            // scan each defined var by the parser
            foreach (ExprObjectUsedBase objectName in _expressionData.ExprParseResult.ListExprVarUsed)
            {
                ExprVariableBase variable = _expressionData.ExprExecResult.ListExprVariable.Find(v => v.Name.Equals(objectName.Name, StringComparison.InvariantCultureIgnoreCase));
                if (variable == null)
                {
                    // the variable is not created! no type and no value
                    _expressionData.ExprExecResult.AddErrorExec(ErrorCode.VariableNotDefined, "VarName", objectName.Name);
                    errVarCreated = false;
                }
            }

            return errVarCreated;
        }

        /// <summary>
        /// Check that all found functionCall in the expression are linked with a function body.
        /// </summary>
        /// <returns></returns>
        private bool CheckFunctionCalls()
        {
            // set to no error
            bool functionCallMappedRes = true;

            // scan each defined var by the parser
            foreach (ExprFunctionCallUsed functionCallUsed in _expressionData.ExprParseResult.ListExprFunctionCallUsed)
            {
                // is a functionToCall mapped to the functionCall found in the expression?
                FunctionToCallMapper functionToCall = _exprEvalConfig.ListFunctionToCallMapper.Find(f => f.FunctionCallName.Equals(functionCallUsed.Name, StringComparison.InvariantCultureIgnoreCase));
                if (functionToCall == null)
                {
                    // any function code matching the functionCall name is found!
                    _expressionData.ExprExecResult.AddErrorExec(ErrorCode.FunctionCallNotLinked, "FunctionCallName", functionCallUsed.Name);
                    functionCallMappedRes = false;
                    // check the next functionCall used/present in the expression
                    continue;
                }

                // ok the functionCall is attached to a functionCode, check the params count (the type will be checked later at execution)
                if(!CheckParamsCountMatching(functionCallUsed, functionToCall))
                    // the error is set inside the function
                    functionCallMappedRes = false;

            }

            return functionCallMappedRes;

        }

        /// <summary>
        /// Check the match of parameters between the functionCall and the attached function code.
        /// the matching of the type of each parameter will be checked later at the execution stage.
        /// </summary>
        /// <param name="functionCallUsed"></param>
        /// <param name="functionToCall"></param>
        /// <returns></returns>
        private bool CheckParamsCountMatching(ExprFunctionCallUsed functionCallUsed, FunctionToCallMapper functionToCall)
        {
            // the function code has any parameter
            if(functionToCall.Param1Type== DataType.NotDefined)
            {
                if (functionCallUsed.ParameterCount != 0)
                {                     
                    // error, the parameter count mismatch between the function call and the function code
                    _expressionData.ExprExecResult.AddErrorExec(ErrorCode.FunctionCallParamCountWrong, "FunctionCallName", functionCallUsed.Name);
                    return false;
                }
                // ok, the parameter count match
                return true;
            }

            // one parameter at least is present
            if (functionToCall.Param2Type == DataType.NotDefined)
            {
                if (functionCallUsed.ParameterCount != 1)
                {
                    // error, the parameter count mismatch between the function call and the function code
                    _expressionData.ExprExecResult.AddErrorExec(ErrorCode.FunctionCallParamCountWrong, "FunctionCallName", functionCallUsed.Name);
                    return false;
                }
                // ok, the parameter count match
                return true;
            }

            // one parameter at least is present
            if (functionToCall.Param3Type == DataType.NotDefined)
            {
                if (functionCallUsed.ParameterCount != 2)
                {
                    // error, the parameter count mismatch between the function call and the function code
                    _expressionData.ExprExecResult.AddErrorExec(ErrorCode.FunctionCallParamCountWrong, "FunctionCallName", functionCallUsed.Name);
                    return false;
                }
                // ok, the parameter count match
                return true;
            }

            // the function call has three parameters
            if (functionCallUsed.ParameterCount != 3)
            {
                // error, the parameter count mismatch between the function call and the function code
                _expressionData.ExprExecResult.AddErrorExec(ErrorCode.FunctionCallParamCountWrong, "FunctionCallName", functionCallUsed.Name);
                return false;
            }

            // ok, the parameter count match
            return true;

            // todo: enlever code de check count param dans la methode ExprExecutorFunctionCallRetBase.CheckParam()
        }

        /// <summary>
        /// start the execution, analyze and return the list of variables to create.
        /// todo: recréer un syntax tree, avec des valeurs!
        /// 
        /// -->Doit renvoyer comme résultat un objet de type ExprValueXXX, non?? (si pas d'erreur).
        /// </summary>
        /// <returns></returns>
        private bool ExecExpression(ExecResult exprExecResult, ExpressionBase expr, out ExpressionExecBase exprExecBase)
        {
            exprExecBase = null;

            //----is it a final operand (value, var or call function)?
            ExprFinalOperand finalOperand = expr as ExprFinalOperand;
            if (finalOperand != null)
                return ExecExpressionFinalOperand(exprExecResult, finalOperand, out exprExecBase);

            //----is it a comparison expression?
            ExprComparison exprComparison = expr as ExprComparison;
            if (exprComparison != null)
                // execute the expression, execute the right part, execute the left part, then exec the expr (as 2 value operands)
                return ExecExpressionComparison(exprExecResult, exprComparison, out exprExecBase);


            //----is it a logical expression (bin/2 operands)?
            ExprLogical exprLogical = expr as ExprLogical;
            if (exprLogical != null)
                return ExecExpressionLogical(exprExecResult, exprLogical, out exprExecBase);

            //----is it a NOT logical expression?
            ExprLogicalNot exprLogicalNot = expr as ExprLogicalNot;
            if (exprLogicalNot != null)
                return ExecExpressionLogicalNot(exprExecResult, exprLogicalNot, out exprExecBase);

            //----is it a calculation expression?
            ExprCalculation exprCalculation = expr as ExprCalculation;
            if (exprCalculation != null)
                // execute the expression, execute the right part, execute the left part, then exec the expr (as 2 value operands)
                return ExecExpressionCalculation(exprExecResult, exprCalculation, out exprExecBase);

            //----is it function call?
            ExprFunctionCall exprFunctionCall = expr as ExprFunctionCall;
            if (exprFunctionCall != null)
                return ExecExpressionFunctionCall(exprExecResult, exprFunctionCall, out exprExecBase);


            //----is it a setValue expression?
            // todo: future

            // todo: error, expression not yet implemented!!
            exprExecResult.AddErrorExec(ErrorCode.ExpressionTypeNotYetImplemented, "Expr", expr.GetType().ToString());
            return false;
        }

        /// <summary>
        /// Execute/evaluate each operand.
        /// Return a list of exprExec.
        /// </summary>
        /// <param name="exprExecResult"></param>
        /// <param name="listExprBase"></param>
        /// <param name="listExprExecBase"></param>
        /// <returns></returns>
        private bool ExecListExpression(ExecResult execResult, List<ExpressionBase> listExprBase, out List<ExpressionExecBase> listExprExecBase)
        {
            listExprExecBase = new List<ExpressionExecBase>();
            ExpressionExecBase exprExecBase;
            bool res = true;

            foreach (ExpressionBase exprBase in listExprBase)
            {
                // execute/evaluate the expression
                if(!ExecExpression(execResult, exprBase, out exprExecBase))
                {
                    res = false;
                    continue;
                }
                listExprExecBase.Add(exprExecBase);
            }

            return res;
        }

        private bool ExecExpressionFinalOperand(ExecResult exprExecResult, ExprFinalOperand finalOperand, out ExpressionExecBase exprExecBase)
        {
            // is the operand a variable or a call function?
            if (finalOperand.ContentType == OperandType.ObjectName)
            {
                // is it a variable?
                ExprVariableBase exprVariableBase = _expressionData.ExprExecResult.ListExprVariable.Find(v => v.Name.Equals(finalOperand.Operand, StringComparison.InvariantCultureIgnoreCase));
                if (exprVariableBase != null)
                {
                    // the operand is a string variable?
                    ExprVariableString exprVariableString = exprVariableBase as ExprVariableString;
                    if (exprVariableString != null)
                    {
                        // create a var instance, depending on the type 
                        ExprExecVarString exprExecVar = new ExprExecVarString();
                        exprExecVar.ExprVariableString = exprVariableString;
                        exprExecVar.Expr = finalOperand;

                        // set the value
                        exprExecVar.Value = exprVariableString.Value;
                        exprExecBase = exprExecVar;
                        return true;
                    }

                    // the operand is an int variable?
                    ExprVariableInt exprVariableInt = exprVariableBase as ExprVariableInt;
                    if (exprVariableInt != null)
                    {
                        // create a var instance, depending on the type 
                        ExprExecVarInt exprExecVar = new ExprExecVarInt();
                        exprExecVar.ExprVariableInt = exprVariableInt;
                        exprExecVar.Expr = finalOperand;

                        // set the value
                        exprExecVar.Value = exprVariableInt.Value;
                        exprExecBase = exprExecVar;
                        return true;
                    }


                    // the operand is a double variable?
                    ExprVariableDouble exprVariableDouble = exprVariableBase as ExprVariableDouble;
                    if (exprVariableDouble != null)
                    {
                        // create a var instance, depending on the type 
                        ExprExecVarDouble exprExecVar = new ExprExecVarDouble();
                        exprExecVar.ExprVariableDouble = exprVariableDouble;
                        exprExecVar.Expr = finalOperand;

                        // set the value
                        exprExecVar.Value = exprVariableDouble.Value;
                        exprExecBase = exprExecVar;
                        return true;
                    }

                    // the operand is a bool variable?
                    ExprVariableBool exprVariableBool = exprVariableBase as ExprVariableBool;
                    if (exprVariableBool != null)
                    {
                        // create a var instance, depending on the type 
                        ExprExecVarBool exprExecVar = new ExprExecVarBool();
                        exprExecVar.ExprVariableBool = exprVariableBool;
                        exprExecVar.Expr = finalOperand;

                        // set the value
                        exprExecVar.Value = exprVariableBool.Value;
                        exprExecBase = exprExecVar;
                        return true;
                    }

                    // todo; create an error
                    throw new Exception("The operand variable type is not yet implemented!");
                }

                // so its a function call
                // todo: rechercher dans la liste des fonctions?
                throw new Exception("The function call is not yet implemented!");
            }

            // is the operand a string value (a const string value)? 
            if (finalOperand.ContentType == OperandType.ValueString)
            {
                ExprExecValueString exprValueString = new ExprExecValueString();
                exprValueString.Value = finalOperand.Operand;
                exprExecBase = exprValueString;
                exprValueString.Expr = finalOperand;

                return true;
            }

            // is the operand an int value? 
            if (finalOperand.ContentType == OperandType.ValueInt)
            {
                ExprExecValueInt exprValueInt = new ExprExecValueInt();
                exprValueInt.Expr = finalOperand;
                exprValueInt.Value = finalOperand.ValueInt;
                exprExecBase = exprValueInt;
                return true;
            }

            // is the operand a double value? 
            if (finalOperand.ContentType == OperandType.ValueDouble)
            {
                ExprExecValueDouble exprValueDouble = new ExprExecValueDouble();
                exprValueDouble.Expr = finalOperand;
                exprValueDouble.Value = finalOperand.ValueDouble;
                exprExecBase = exprValueDouble;
                return true;
            }

            // is the operand a bool value? 
            if (finalOperand.ContentType == OperandType.ValueBool)
            {
                ExprExecValueBool exprValueBool = new ExprExecValueBool();
                exprValueBool.Expr = finalOperand;
                exprValueBool.Value = finalOperand.ValueBool;
                exprExecBase = exprValueBool;
                return true;
            }

            // todo: create an error
            throw new Exception("The operand const value is not yet implemented!");
        }

        /// <summary>
        /// execute the expression, execute the right part, execute the left part, then exec the expr (as 2 value operands)
        /// 
        /// Returns always a bool value.
        /// exp: a=12,  a>=13
        /// 
        /// managed type; int and double.
        ///  for the bool and the string type, only equals and diff are authorized.
        /// </summary>
        /// <param name="exprComparison"></param>
        /// <returns></returns>
        private bool ExecExpressionComparison(ExecResult exprExecResult, ExprComparison exprComparison, out ExpressionExecBase exprExecBase)
        {
            exprExecBase = null;

            //----first step is to decode/compile both operands
            ExpressionExecBase exprExecBaseLeft;
            ExecExpression(exprExecResult, exprComparison.ExprLeft, out exprExecBaseLeft);

            ExpressionExecBase exprExecBaseRight;
            ExecExpression(exprExecResult, exprComparison.ExprRight, out exprExecBaseRight);

            //---Are the operands boolean?
            ExprExecValueBool exprExecValueLeftBool = exprExecBaseLeft as ExprExecValueBool;
            if (exprExecValueLeftBool != null)
            {
                // decode the right operand, should be a bool value too
                ExprExecValueBool exprExecValueRightBool = exprExecBaseRight as ExprExecValueBool;
                if (exprExecValueRightBool == null)
                {
                    // the type of both operands mismatch!
                    exprExecResult.AddErrorExec(ErrorCode.ExprComparisonOperandsTypeMismatchBoolExpected, "Position", exprComparison.ExprRight.Token.Position.ToString());
                    return false;
                }

                ExprExecValueBool exprValueBoolResult = new ExprExecValueBool();

                // is the operator Equals?
                if (exprComparison.Operator == OperatorComparisonCode.Equals)
                {
                    // ok, execute the comparison
                    exprValueBoolResult.Value = exprExecValueLeftBool.Value == exprExecValueRightBool.Value;
                    exprExecBase = exprValueBoolResult;
                    return true;
                }

                // is the operator different?
                if (exprComparison.Operator == OperatorComparisonCode.Different)
                {
                    // ok, execute the comparison
                    exprValueBoolResult.Value = exprExecValueLeftBool.Value != exprExecValueRightBool.Value;
                    exprExecBase = exprValueBoolResult;
                    return true;
                }

                // other operators are not allowed on the boolean type
                exprExecResult.AddErrorExec(ErrorCode.ExprComparisonOperatorNotAllowedForBoolType, "Position", exprComparison.ExprLeft.Token.Position.ToString(), "Operator", exprComparison.Operator.ToString());

                return false;
            }

            //---Are the operands integer?
            ExprExecValueInt exprExecValueLeftInt = exprExecBaseLeft as ExprExecValueInt;
            if (exprExecValueLeftInt != null)
            {
                // decode the right operand, should be an int value too
                ExprExecValueInt exprExecValueRightInt = exprExecBaseRight as ExprExecValueInt;
                if (exprExecValueRightInt == null)
                {
                    // the type of both operands mismatch!
                    exprExecResult.AddErrorExec(ErrorCode.ExprComparisonOperandsTypeMismatchIntExpected, "Position", exprComparison.ExprRight.Token.Position.ToString());
                    return false;
                }

                ExprExecValueBool exprValueBoolResult = new ExprExecValueBool();

                // is the operator Equals?
                if (exprComparison.Operator == OperatorComparisonCode.Equals)
                {
                    // ok, execute the comparison
                    exprValueBoolResult.Value = exprExecValueLeftInt.Value == exprExecValueRightInt.Value;
                    exprExecBase = exprValueBoolResult;
                    return true;
                }

                // is the operator different?
                if (exprComparison.Operator == OperatorComparisonCode.Different)
                {
                    // ok, execute the comparison
                    exprValueBoolResult.Value = exprExecValueLeftInt.Value != exprExecValueRightInt.Value;
                    exprExecBase = exprValueBoolResult;
                    return true;
                }

                // is the operator greater than?
                if (exprComparison.Operator == OperatorComparisonCode.Greater)
                {
                    // ok, execute the comparison
                    exprValueBoolResult.Value = exprExecValueLeftInt.Value > exprExecValueRightInt.Value;
                    exprExecBase = exprValueBoolResult;
                    return true;
                }

                // is the operator lesser than?
                if (exprComparison.Operator == OperatorComparisonCode.Less)
                {
                    // ok, execute the comparison
                    exprValueBoolResult.Value = exprExecValueLeftInt.Value < exprExecValueRightInt.Value;
                    exprExecBase = exprValueBoolResult;
                    return true;
                }

                // is the operator greater or equals than?
                if (exprComparison.Operator == OperatorComparisonCode.GreaterEquals)
                {
                    // ok, execute the comparison
                    exprValueBoolResult.Value = exprExecValueLeftInt.Value >= exprExecValueRightInt.Value;
                    exprExecBase = exprValueBoolResult;
                    return true;
                }

                // is the operator lesser or equals than?
                if (exprComparison.Operator == OperatorComparisonCode.LessEquals)
                {
                    // ok, execute the comparison
                    exprValueBoolResult.Value = exprExecValueLeftInt.Value <= exprExecValueRightInt.Value;
                    exprExecBase = exprValueBoolResult;
                    return true;
                }

                // other operators are not allowed on the boolean type (impossible to be there!)
                exprExecResult.AddErrorExec(ErrorCode.ExprComparisonOperatorNotYetImplementedForIntType, "Position", exprComparison.ExprLeft.Token.Position.ToString(), "Operator", exprComparison.Operator.ToString());

                return false;
            }

            //---Are the operands double?
            ExprExecValueDouble exprExecValueLeftDouble = exprExecBaseLeft as ExprExecValueDouble;
            if (exprExecValueLeftDouble != null)
            {
                // decode the right operand, should be an int value too
                ExprExecValueDouble exprExecValueRightDouble = exprExecBaseRight as ExprExecValueDouble;
                if (exprExecValueRightDouble == null)
                {
                    // the type of both operands mismatch!
                    exprExecResult.AddErrorExec(ErrorCode.ExprComparisonOperandsTypeMismatchDoubleExpected, "Position", exprComparison.ExprRight.Token.Position.ToString());
                    return false;
                }

                // the result is always a bool (its a comparison)
                ExprExecValueBool exprValueBoolResult = new ExprExecValueBool();

                // is the operator Equals?
                if (exprComparison.Operator == OperatorComparisonCode.Equals)
                {
                    // ok, execute the comparison
                    exprValueBoolResult.Value = exprExecValueLeftDouble.Value == exprExecValueRightDouble.Value;
                    exprExecBase = exprValueBoolResult;
                    return true;
                }

                // is the operator different?
                if (exprComparison.Operator == OperatorComparisonCode.Different)
                {
                    // ok, execute the comparison
                    exprValueBoolResult.Value = exprExecValueLeftDouble.Value != exprExecValueRightDouble.Value;
                    exprExecBase = exprValueBoolResult;
                    return true;
                }

                // is the operator greater than?
                if (exprComparison.Operator == OperatorComparisonCode.Greater)
                {
                    // ok, execute the comparison
                    exprValueBoolResult.Value = exprExecValueLeftDouble.Value > exprExecValueRightDouble.Value;
                    exprExecBase = exprValueBoolResult;
                    return true;
                }

                // is the operator lesser than?
                if (exprComparison.Operator == OperatorComparisonCode.Less)
                {
                    // ok, execute the comparison
                    exprValueBoolResult.Value = exprExecValueLeftDouble.Value < exprExecValueRightDouble.Value;
                    exprExecBase = exprValueBoolResult;
                    return true;
                }

                // is the operator greater or equals than?
                if (exprComparison.Operator == OperatorComparisonCode.GreaterEquals)
                {
                    // ok, execute the comparison
                    exprValueBoolResult.Value = exprExecValueLeftDouble.Value >= exprExecValueRightDouble.Value;
                    exprExecBase = exprValueBoolResult;
                    return true;
                }

                // is the operator lesser or equals than?
                if (exprComparison.Operator == OperatorComparisonCode.LessEquals)
                {
                    // ok, execute the comparison
                    exprValueBoolResult.Value = exprExecValueLeftDouble.Value <= exprExecValueRightDouble.Value;
                    exprExecBase = exprValueBoolResult;
                    return true;
                }

                // other operators are not allowed on the boolean type (impossible to be there!)
                exprExecResult.AddErrorExec(ErrorCode.ExprComparisonOperatorNotYetImplementedForDoubleType, "Position", exprComparison.ExprLeft.Token.Position.ToString(), "Operator", exprComparison.Operator.ToString());

                return false;
            }

            //---Are the operands string?
            ExprExecValueString exprExecValueLeftString = exprExecBaseLeft as ExprExecValueString;
            if (exprExecValueLeftString != null)
            {
                // decode the right operand, should be a bool value too
                ExprExecValueString exprExecValueRightString = exprExecBaseRight as ExprExecValueString;
                if (exprExecValueRightString == null)
                {
                    // the type of both operands mismatch!
                    exprExecResult.AddErrorExec(ErrorCode.ExprComparisonOperandsTypeMismatchStringExpected, "Position", exprComparison.ExprRight.Token.Position.ToString());
                    return false;
                }

                ExprExecValueBool exprValueBoolResult = new ExprExecValueBool();

                // is the operator Equals?
                if (exprComparison.Operator == OperatorComparisonCode.Equals)
                {
                    // ok, execute the comparison
                    exprValueBoolResult.Value = exprExecValueLeftString.Value == exprExecValueRightString.Value;
                    exprExecBase = exprValueBoolResult;
                    return true;
                }

                // is the operator different?
                if (exprComparison.Operator == OperatorComparisonCode.Different)
                {
                    // ok, execute the comparison
                    exprValueBoolResult.Value = exprExecValueLeftString.Value != exprExecValueRightString.Value;
                    exprExecBase = exprValueBoolResult;
                    return true;
                }

                // other operators are not allowed on the boolean type
                exprExecResult.AddErrorExec(ErrorCode.ExprComparisonOperatorNotAllowedForStringType, "Position", exprComparison.ExprLeft.Token.Position.ToString(), "Operator", exprComparison.Operator.ToString());

                return false;
            }

            // if reached, the operand type is not yet implemented (or unknowed)
            exprExecResult.AddErrorExec(ErrorCode.ExprComparisonOperandTypeNotYetImplemented, "Position", exprComparison.ExprLeft.Token.Position.ToString(), "Token", exprExecBaseLeft.Expr.Token.ToString());
            return false;
        }

        /// <summary>
        /// Execute the logical expression.
        /// exp: (a AND b)
        /// 
        /// Only bool type are authorized.
        /// </summary>
        /// <param name="exprExecResult"></param>
        /// <param name="exprComparison"></param>
        /// <param name="exprExecBase"></param>
        /// <returns></returns>
        private bool ExecExpressionLogical(ExecResult exprExecResult, ExprLogical exprLogical, out ExpressionExecBase exprExecBase)
        {
            exprExecBase = null;

            //----first step is to execute both operands
            ExpressionExecBase exprExecBaseLeft;
            ExecExpression(exprExecResult, exprLogical.ExprLeft, out exprExecBaseLeft);

            ExpressionExecBase exprExecBaseRight;
            ExecExpression(exprExecResult, exprLogical.ExprRight, out exprExecBaseRight);

            //---Are the operands boolean type?
            ExprExecValueBool exprExecValueLeftBool = exprExecBaseLeft as ExprExecValueBool;
            if (exprExecValueLeftBool != null)
            {
                // decode the right operand, should be a bool value too
                ExprExecValueBool exprExecValueRightBool = exprExecBaseRight as ExprExecValueBool;
                if (exprExecValueRightBool == null)
                {
                    // the type of both operands mismatch!
                    exprExecResult.AddErrorExec(ErrorCode.ExprLogicalOperandsTypeMismatchBoolExpected, "Position", exprLogical.ExprRight.Token.Position.ToString());
                    return false;
                }

                ExprExecValueBool exprValueBoolResult = new ExprExecValueBool();

                // is the operator AND?
                if (exprLogical.Operator == OperatorLogicalCode.And)
                {
                    // ok, execute the comparison
                    exprValueBoolResult.Value = exprExecValueLeftBool.Value && exprExecValueRightBool.Value;
                    exprExecBase = exprValueBoolResult;
                    return true;
                }

                // is the operator OR?
                if (exprLogical.Operator == OperatorLogicalCode.Or)
                {
                    // ok, execute the comparison
                    exprValueBoolResult.Value = (exprExecValueLeftBool.Value || exprExecValueRightBool.Value);
                    exprExecBase = exprValueBoolResult;
                    return true;
                }

                // is the operator XOR?
                if (exprLogical.Operator == OperatorLogicalCode.Xor)
                {
                    // ok, execute the comparison, the operator doesn't exists so do firts a OR
                    exprValueBoolResult.Value = (exprExecValueLeftBool.Value || exprExecValueRightBool.Value);

                    // the xor case: both operands are true so the result is false
                    if (exprExecValueLeftBool.Value && exprExecValueRightBool.Value)
                        exprValueBoolResult.Value = false;

                    exprExecBase = exprValueBoolResult;
                    return true;
                }

                // other operators are not allowed on the boolean type (only bool)
                exprExecResult.AddErrorExec(ErrorCode.ExprLogicalOperatorNotAllowed, "Position", exprLogical.ExprLeft.Token.Position.ToString(), "Operator", exprLogical.Operator.ToString());

                return false;
            }


            //---Are the operands others type?  -> error
            exprExecResult.AddErrorExec(ErrorCode.ExprLogicalOperandTypeNotAllowed, "Position", exprLogical.ExprLeft.Token.Position.ToString(), "Token", exprExecBaseLeft.GetType().ToString());
            return false;
        }

        /// <summary>
        /// Not Operand.
        /// The operand must be a bool: final operand, expression that return a bool.
        /// </summary>
        /// <param name="exprExecResult"></param>
        /// <param name="exprLogicalNot"></param>
        /// <param name="exprExecBase"></param>
        /// <returns></returns>
        private bool ExecExpressionLogicalNot(ExecResult exprExecResult, ExprLogicalNot exprLogicalNot, out ExpressionExecBase exprExecBase)
        {
            exprExecBase = null;

            //----first step is to decode/compile the operand
            ExpressionExecBase exprExecOperand;
            ExecExpression(exprExecResult, exprLogicalNot.ExprBase, out exprExecOperand);

            // the operand must be a bool value
            ExprExecValueBool exprExecValueBool = exprExecOperand as ExprExecValueBool;
            if (exprExecValueBool == null)
            {
                // bool type expected for the operand inner the not logical expression, but the operand has another type
                string strPosition = "0";
                string strToken = "";
                if (exprLogicalNot.ExprBase.Token != null)
                {
                    strPosition = exprLogicalNot.ExprBase.Token.Position.ToString();
                    strToken = exprLogicalNot.ExprBase.Token.Value.ToString();
                }
                _expressionData.ExprExecResult.AddErrorExec(ErrorCode.ExprLogicalNotOperator_InnerOperandBoolTypeExpected, "Token", strToken, "Position", strPosition);
                return false;
            }

            // ok, the operand is a bool value
            // ok, execute the NOT logical
            ExprExecValueBool exprValueBoolResult = new ExprExecValueBool();
            exprValueBoolResult.Value = !(exprExecValueBool.Value);
            exprExecBase = exprValueBoolResult;
            return true;
        }

        /// <summary>
        /// Execute the calculation expression.
        ///         exp: a+b
        /// 
        /// Only int or double type are authorized.
        /// 
        ///  todo: +tard: pour les strings si opérateur +/Plus, faire une concaténation!
        /// </summary>
        /// <param name="exprExecResult"></param>
        /// <param name="exprLogicalNot"></param>
        /// <param name="exprExecBase"></param>
        /// <returns></returns>
        private bool ExecExpressionCalculation(ExecResult execResult, ExprCalculation exprCalculation, out ExpressionExecBase exprExecBase)
        {
            // the final result of the execution
            exprExecBase = null;

            // check the number of operands
            if(exprCalculation.ListExprOperand.Count > Definitions.ExprCalculationMaxOperandsCount)
            {
                execResult.AddErrorExec(ErrorCode.ExprCalculationTooManyOperands, "Content", exprExecBase.Expr.Token.Value, "Position", exprExecBase.Expr.Token.Position.ToString());
                return false;
            }

            // first execute all operands, one by one
            List<ExpressionExecBase> listExprExecBase;
            if (!ExecListExpression(execResult, exprCalculation.ListExprOperand, out listExprExecBase))
                // an error occurs
                return false;

            // check that all operand types are expected: int or double only
            if(!CheckTypeOperandExprCalculation(execResult, listExprExecBase))
                // an error occurs
                return false;

            // execute the calculation
            ExprExecutorCalculation exprExecutorCalculation = new ExprExecutorCalculation();
            return exprExecutorCalculation.Process(execResult, exprCalculation, listExprExecBase, out exprExecBase);
        }


        /// <summary>
        /// Execute a functionCall.
        /// First execute parameters and then execute the function code attached/linked.
        /// </summary>
        /// <param name="exprExecResult"></param>
        /// <param name="exprFunctionCall"></param>
        /// <param name="exprExecBase"></param>
        /// <returns></returns>
        private bool ExecExpressionFunctionCall(ExecResult exprExecResult, ExprFunctionCall exprFunctionCall, out ExpressionExecBase exprExecBase)
        {
            ExpressionExecBase exprExecParamBase;
            List<ExpressionExecBase> listExprExecParam = new List<ExpressionExecBase>();
            bool res = true;

            exprExecBase = null;

            // get the function code 
            FunctionToCallMapper functionToCallMapper = _exprEvalConfig.ListFunctionToCallMapper.Find(f => f.FunctionCallName.Equals(exprFunctionCall.FunctionName, StringComparison.InvariantCultureIgnoreCase));
            if (functionToCallMapper == null)
            {
                // error
                exprExecResult.AddErrorExec(ErrorCode.FunctionCallNotLinked, "FunctionCallName", exprFunctionCall.FunctionName);
                return false;
            }

            // execute params of the function
            foreach (ExpressionBase exprParam in exprFunctionCall.ListExprParameters)
            {
                res &= ExecExpression(exprExecResult, exprParam, out exprExecParamBase);
                listExprExecParam.Add(exprExecParamBase);
            }

            // a param execution failed
            if (!res) return false;

            // execute the function code attached to the functionCall, provide executed params
            return _exprExecutorFunctionCall.ExecExpressionFunctionCall(exprExecResult, exprFunctionCall, functionToCallMapper, listExprExecParam, out exprExecBase);
        }

        /// <summary>
        /// check that all operand types are expected: int or double only.
        /// TODO: string? for concatenation? later.
        /// 
        /// </summary>
        /// <param name="execResult"></param>
        /// <param name="listExpr"></param>
        /// <returns></returns>
        private bool CheckTypeOperandExprCalculation(ExecResult execResult, List<ExpressionExecBase> listExprExecBase)
        {
            bool ret = true;
            foreach(ExpressionExecBase exprExecBase in listExprExecBase)
            {
                // is it an int?
                ExprExecValueInt exprInt = exprExecBase as ExprExecValueInt;
                if (exprInt != null)
                    // yes!
                    continue;

                // is it a double?
                ExprExecValueDouble exprDouble = exprExecBase as ExprExecValueDouble;
                if (exprDouble == null)
                {
                    // neither an int or a double , error!
                    execResult.AddErrorExec(ErrorCode.ExprCalculationOperandTypeUnExcepted, "Content", exprExecBase.Expr.Token.Value, "Position", exprExecBase.Expr.Token.Position.ToString());
                    ret = false;
                }
            }
            return ret;
        }

        private bool CheckVariableSyntax(ExecResult exprExecResult, string varName)
        {
            if (string.IsNullOrWhiteSpace(varName))
            {
                _expressionData.ExprExecResult.AddErrorExec(ErrorCode.VarNameSyntaxWrong, "SyntaxErrorType", "IsNullOrWhiteSpace");
                return false;
            }

            // check the syntax, the first char should be: a letter, or underscore
            if (!char.IsLetter(varName[0]) && varName[0] != '_')
            {
                _expressionData.ExprExecResult.AddErrorExec(ErrorCode.VarNameSyntaxWrong, "SyntaxErrorType", "FirstCharIsWrong");
                return false;
            }

            if (varName.Length == 1)
                return true;

            // check next chars (if exists)
            for (int i = 0; i < varName.Length; i++)
            {
                if (!char.IsLetterOrDigit(varName[i]))
                {
                    _expressionData.ExprExecResult.AddErrorExec(ErrorCode.VarNameSyntaxWrong, "SyntaxErrorType", "OneCharOrMoreIsWrong");
                    return false;
                }
            }
            return true;
        }

        #endregion
    }
}
