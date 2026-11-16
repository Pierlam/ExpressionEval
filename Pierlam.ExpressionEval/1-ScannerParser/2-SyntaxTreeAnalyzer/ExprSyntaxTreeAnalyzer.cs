using System;

namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// Expression Syntax tree analyzer.
    /// Extract the list of used variables.
    /// Do some checks: check the consistency of the expression, data, type,...
    /// Define the result data type: bool, stirng or a number (in or double).
    /// After the parse process.
    /// </summary>
    public class ExprSyntaxTreeAnalyzer
    {
        //ExprParseResult _lastExprParseResult;

        /// <summary>
        /// Analyze the syntax tree of expression.
        /// </summary>
        /// <param name="lastExprParseResult"></param>
        /// <returns></returns>
        public bool Analyze(ParseResult exprParseResult)
        {
            // no last parsed expression exists
            if (exprParseResult == null)
                return false;

            // an error occurs during the parse stage, stop
            if (exprParseResult.HasError)
                return false;

            // start the  analyze and return the list of variable to define
            return AnalyzeSyntaxTree(exprParseResult, exprParseResult.RootExpr);
        }

        #region Private methods

        /// <summary>
        /// analyze and return the list of variables and functionCalls found in the expression to define before execute it.
        /// Do also some checks.
        /// </summary>
        /// <param name="exprParseResult"></param>
        /// <param name="expr"></param>
        /// <returns></returns>
        private bool AnalyzeSyntaxTree(ParseResult result, ExpressionBase expr)
        {
            //----is it a final operand?
            ExprFinalOperand exprFinalOperand = expr as ExprFinalOperand;
            if (exprFinalOperand != null)
            {
                if (exprFinalOperand.ContentType == OperandType.ObjectName)
                {
                    // save the objectName (variable) 
                    result.AddVariable(exprFinalOperand.Operand);
                }
                return true;
            }

            //----is it a function call?
            ExprFunctionCall exprFunctionCall = expr as ExprFunctionCall;
            if (exprFunctionCall != null)
            {
                // scan parameters of the function call
                foreach (ExpressionBase exprParam in exprFunctionCall.ListExprParameters)
                {
                    AnalyzeSyntaxTree(result, exprParam);
                }
                result.AddFunctionCall(exprFunctionCall.FunctionName, exprFunctionCall.ListExprParameters.Count);
                return true;
            }

            //----is it an expression comparison?
            ExprComparison exprComparison = expr as ExprComparison;
            if (exprComparison != null)
            {
                AnalyzeSyntaxTree(result, exprComparison.ExprLeft);
                AnalyzeSyntaxTree(result, exprComparison.ExprRight);
                return true;
            }

            //----is it an expression logical?
            ExprLogical exprLogical = expr as ExprLogical;
            if (exprLogical != null)
            {
                AnalyzeSyntaxTree(result, exprLogical.ExprLeft);
                AnalyzeSyntaxTree(result, exprLogical.ExprRight);
                return true;
            }

            //----is it an expression logical NOT?
            ExprLogicalNot exprLogicalNot = expr as ExprLogicalNot;
            if (exprLogicalNot != null)
            {
                AnalyzeSyntaxTree(result, exprLogicalNot.ExprBase);
                return true;
            }

            //----is it an expression calculation?
            ExprCalculation exprCalculation = expr as ExprCalculation;
            if (exprCalculation != null)
            {
                // analyze all operands of the calculation expression
                bool res = true;
                foreach(ExpressionBase exprChild in exprCalculation.ListExprOperand)
                    res = res && AnalyzeSyntaxTree(result, exprChild);

                //AnalyzeSyntaxTree(result, exprCalculation.ExprLeft);
                //AnalyzeSyntaxTree(result, exprCalculation.ExprRight);
                return res;
            }

            //----is it a set value expression ?
            // todo:


            throw new Exception("todo: AnalyzeSyntaxTree(), expression type not yet implemented!");
        }

        #endregion
    }
}
