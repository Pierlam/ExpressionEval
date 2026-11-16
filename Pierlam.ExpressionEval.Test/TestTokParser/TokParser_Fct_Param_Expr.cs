using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pierlam.ExpressionEval;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pierlam.ExpressionEval.Test.TokParser
{
    /// <summary>
    /// Test functionCall with simple parameter type expression.
    /// 
    /// </summary>
    [TestClass]
    public class TokParser_Fct_Param_Expr
    {
        /// <summary>
        /// A function call, with one simple parameter.
        /// fct()
        /// </summary>
        [TestMethod]
        public void fct_OP_a_Eq_b_CP_ok()
        {
            string expr = "fct(a=b)";
            List<ExprToken> listTokens = TestCommon.AddTokens("fct", "(", "a", "=", "b", ")");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            ExpressionEvalConfig config = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(config);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);

            // finished with no error
            Assert.AreEqual(0, result.ListError.Count, "The tokens should be decoded with success");

            // get the root expression
            ExprFunctionCall rootExpr = result.RootExpr as ExprFunctionCall;
            Assert.IsNotNull(rootExpr, "The root node type should be ExprFunctionCall");
            Assert.AreEqual("fct", rootExpr.FunctionName, "The function name should be: fct");
            Assert.AreEqual(1, rootExpr.ListExprParameters.Count, "The function call should have one parameter");

            // check the parameter: its a comparison expression
            ExprComparison exprComparison = rootExpr.ListExprParameters[0] as ExprComparison;
            Assert.AreEqual(OperatorComparisonCode.Equals, exprComparison.Operator, "The operator name should be: =");

            // check the left part: its a final operand: a
            ExprFinalOperand operandLeft = exprComparison.ExprLeft as ExprFinalOperand;
            Assert.AreEqual("a", operandLeft.Operand, "should be: a");
            Assert.IsTrue(operandLeft.ContentType == OperandType.ObjectName, "The type should be: ObjectName");

            // check the right part: its a final operand: a
            ExprFinalOperand operandRight = exprComparison.ExprRight as ExprFinalOperand;
            Assert.AreEqual("b", operandRight.Operand, "should be: b");
            Assert.IsTrue(operandLeft.ContentType == OperandType.ObjectName, "The type should be: ObjectName");
        }

        // todo: fct(a>12)

        // todo: fct((a=b))
        // fct(not a)
        // fct(not(a))
    }
}
