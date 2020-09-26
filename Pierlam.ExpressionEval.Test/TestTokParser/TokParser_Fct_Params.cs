using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pierlam.ExpressionEval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pierlam.ExpressionEval.Test.TokParser
{
    /// <summary>
    /// Test functionCall with simple one, two or more parameters.
    /// (basic type).
    /// 
    /// </summary>
    [TestClass]
    public class TokParser_Fct_Params
    {
        /// <summary>
        /// A function call, without any parameter.
        /// fct()
        /// </summary>
        [TestMethod]
        public void fct_OP_a_sep_b_CP_ok()
        {
            string expr = "fct(a,b)";
            List<ExprToken> listTokens = TestCommon.AddTokens("fct", "(", "a", ",", "b");
            TestCommon.AddTokens(listTokens, ")");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
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
            Assert.AreEqual(2, rootExpr.ListExprParameters.Count, "The function call should have one parameter");

            // check the parameter: its a final operand: name and type!!
            ExprFinalOperand paraFunction = rootExpr.ListExprParameters[0] as ExprFinalOperand;
            Assert.AreEqual("a", paraFunction.Operand, "The parameter name should be: a");
            Assert.IsTrue(paraFunction.ContentType == OperandType.ObjectName, "The parameter type should be: ObjectName");

            // check the parameter 2: its a final operand: name and type!!
            ExprFinalOperand paraFunction2 = rootExpr.ListExprParameters[1] as ExprFinalOperand;
            Assert.AreEqual("b", paraFunction2.Operand, "The parameter name should be: b");
            Assert.IsTrue(paraFunction2.ContentType == OperandType.ObjectName, "The parameter type should be: ObjectName");
        }

        /// <summary>
        /// A function call, without any parameter.
        /// fct()
        /// </summary>
        [TestMethod]
        public void fct_OP_a_sep_12_sep_b_CP_ok()
        {
            string expr = "fct(a,12,b)";
            List<ExprToken> listTokens = TestCommon.AddTokens("fct", "(", "a", ",", "12");
            TestCommon.AddTokens(listTokens, ",", "b", ")");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
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
            Assert.AreEqual(3, rootExpr.ListExprParameters.Count, "The function call should have one parameter");

            // check the parameter: its a final operand: name and type!!
            ExprFinalOperand paraFunction = rootExpr.ListExprParameters[0] as ExprFinalOperand;
            Assert.AreEqual("a", paraFunction.Operand, "The parameter name should be: a");
            Assert.IsTrue(paraFunction.ContentType == OperandType.ObjectName, "The parameter type should be: ObjectName");

            // check the parameter 2: its a final operand: name and type!!
            ExprFinalOperand paraFunction2 = rootExpr.ListExprParameters[1] as ExprFinalOperand;
            Assert.AreEqual("12", paraFunction2.Operand, "The parameter name should be: 12");
            Assert.IsTrue(paraFunction2.ContentType == OperandType.ValueInt, "The parameter type should be: an int");

            // check the parameter 2: its a final operand: name and type!!
            ExprFinalOperand paraFunction3 = rootExpr.ListExprParameters[2] as ExprFinalOperand;
            Assert.AreEqual("b", paraFunction3.Operand, "The parameter name should be: b");
            Assert.IsTrue(paraFunction3.ContentType == OperandType.ObjectName, "The parameter type should be: ObjectName");

        }

    }
}
