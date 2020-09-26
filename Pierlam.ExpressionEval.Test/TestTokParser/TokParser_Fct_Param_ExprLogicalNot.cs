using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pierlam.ExpressionEval.Test.TokParser
{
    /// <summary>
    /// Test functionCall with simple parameter type expression.
    /// 
    /// </summary>
    [TestClass]
    public class TokParser_Fct_Param_ExprLogicalNot
    {
        /// <summary>
        /// A function call, with one simple parameter.
        /// fct()
        /// </summary>
        [TestMethod]
        public void fct_OP_a_Eq_b_CP_ok()
        {
            string expr = "fct(not a)";
            List<ExprToken> listTokens = TestCommon.AddTokens("fct", "(", "not", "a", ")");

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

            // check the parameter: its a logical Not expression
            ExprLogicalNot exprLogicalNot = rootExpr.ListExprParameters[0] as ExprLogicalNot;
            Assert.IsNotNull(exprLogicalNot, "The funct param should a Logical Not expression");



            // check the left part: its a final operand: a
            ExprFinalOperand paramFunc = exprLogicalNot.ExprBase as ExprFinalOperand;
            Assert.AreEqual("a", paramFunc.Operand, "should be: a");
            Assert.IsTrue(paramFunc.ContentType == OperandType.ObjectName, "The type should be: ObjectName");
        }

        // tester: Fct(Not(a))
    }
}
