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
    /// Basics tests on functionCall.
    /// any or one parameter (basic type).
    /// 
    /// TestTokParser_Fct_Params
    /// </summary>
    [TestClass]
    public class TokParser_Fct_Basic
    {
        /// <summary>
        /// A function call, without any parameter.
        /// fct()
        /// </summary>
        [TestMethod]
        public void fct_OP_CP_ok()
        {
            string expr = "fct()";
            List<ExprToken> listTokens = TestCommon.AddTokens("fct", "(",")");

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
            Assert.AreEqual(0, rootExpr.ListExprParameters.Count, "The function call should have any parameter");
        }

        /// <summary>
        /// A function call, with one simple parameter.
        /// fct()
        /// </summary>
        [TestMethod]
        public void fct_BO_a_BC_ok()
        {
            string expr = "fct(a)";
            List<ExprToken> listTokens = TestCommon.AddTokens("fct", "(", "a", ")");

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
            Assert.AreEqual(1, rootExpr.ListExprParameters.Count, "The function call should have one parameter");

            // check the parameter: its a final operand: name and type!!
            ExprFinalOperand paraFunction = rootExpr.ListExprParameters[0] as ExprFinalOperand;
            Assert.AreEqual("a", paraFunction.Operand, "The parameter name should be: a");
            Assert.IsTrue(paraFunction.ContentType == OperandType.ObjectName, "The parameter type should be: ObjectName");
        }

        /// <summary>
        /// A function call, without any parameter.
        /// fct()
        /// </summary>
        [TestMethod]
        public void fct_BO_12_BC_ok()
        {
            string expr = "fct(12)";
            List<ExprToken> listTokens = TestCommon.AddTokens("fct", "(", "12", ")");

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
            Assert.AreEqual(1, rootExpr.ListExprParameters.Count, "The function call should have one parameter");

            // check the parameter: its a final operand: name and type!!
            ExprFinalOperand const12 = rootExpr.ListExprParameters[0] as ExprFinalOperand;
            Assert.AreEqual("12", const12.Operand, "The parameter name should be: 12");
            Assert.IsTrue(const12.ContentType == OperandType.ValueInt, "The parameter type should be: int");
        }

        /// <summary>
        /// A function call, without any parameter.
        /// fct()
        /// </summary>
        [TestMethod]
        public void a_Gt_fct_OP_CP_ok()
        {
            string expr = "a > fct()";
            List<ExprToken> listTokens = TestCommon.AddTokens("a", ">", "fct", "(", ")");

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
            ExprComparison exprComparison = result.RootExpr as ExprComparison;
            Assert.IsNotNull(exprComparison, "The root node type should be Comparison");

            //----check the left part of the root node
            ExprFinalOperand operandLeft = exprComparison.ExprLeft as ExprFinalOperand;
            Assert.IsNotNull(operandLeft, "The left root node type should be BoolBinExprOperand");
            Assert.AreEqual(operandLeft.Operand, "a", "The left operand should be A");


            //----check the right part of the comparison: the function call
            ExprFunctionCall exprFunction = exprComparison.ExprRight as ExprFunctionCall;
            Assert.IsNotNull(exprFunction, "The root node type should be ExprFunctionCall");
            Assert.AreEqual("fct", exprFunction.FunctionName, "The function name should be: fct");
            Assert.AreEqual(0, exprFunction.ListExprParameters.Count, "The function call should have any parameter");
        }

        /// <summary>
        /// A function call, without any parameter.
        /// fct()
        /// </summary>
        [TestMethod]
        public void Gt_fct_OP_Eq_a()
        {
            string expr = "fct() = a";
            List<ExprToken> listTokens = TestCommon.AddTokens("fct", "(", ")", "=", "a");

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
            ExprComparison exprComparison = result.RootExpr as ExprComparison;
            Assert.IsNotNull(exprComparison, "The root node type should be Comparison");

            //----check the left part of the comparison: the function call
            ExprFunctionCall exprFunction = exprComparison.ExprLeft as ExprFunctionCall;
            Assert.IsNotNull(exprFunction, "The root node type should be ExprFunctionCall");
            Assert.AreEqual("fct", exprFunction.FunctionName, "The function name should be: fct");
            Assert.AreEqual(0, exprFunction.ListExprParameters.Count, "The function call should have any parameter");

            //----check the left part of the root node
            ExprFinalOperand operandLeft = exprComparison.ExprRight as ExprFinalOperand;
            Assert.IsNotNull(operandLeft, "The left root node type should be BoolBinExprOperand");
            Assert.AreEqual(operandLeft.Operand, "a", "The left operand should be A");

        }

        /// <summary>
        /// A function call, without any parameter.
        /// fct()
        /// </summary>
        [TestMethod]
        public void a_Gt_fct_OP_b_CP_ok()
        {
            string expr = "a > fct(b)";
            List<ExprToken> listTokens = TestCommon.AddTokens("a", ">", "fct", "(", "b");
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
            ExprComparison exprComparison = result.RootExpr as ExprComparison;
            Assert.IsNotNull(exprComparison, "The root node type should be Comparison");

            //----check the left part of the root node
            ExprFinalOperand operandLeft = exprComparison.ExprLeft as ExprFinalOperand;
            Assert.IsNotNull(operandLeft, "The left root node type should be BoolBinExprOperand");
            Assert.AreEqual(operandLeft.Operand, "a", "The left operand should be A");


            //----check the right part of the comparison: the function call
            ExprFunctionCall exprFunction = exprComparison.ExprRight as ExprFunctionCall;
            Assert.IsNotNull(exprFunction, "The root node type should be ExprFunctionCall");
            Assert.AreEqual("fct", exprFunction.FunctionName, "The function name should be: fct");
            Assert.AreEqual(1, exprFunction.ListExprParameters.Count, "The function call should have one parameter");

            // check the parameter: its a final operand
            ExprFinalOperand paraFunction = exprFunction.ListExprParameters[0] as ExprFinalOperand;
            Assert.AreEqual("b", paraFunction.Operand, "The parameter name should be: a");
            Assert.IsTrue(paraFunction.ContentType == OperandType.ObjectName, "The parameter type should be: ObjectName");
        }

        /// <summary>
        /// A function call
        /// fct()
        /// </summary>
        [TestMethod]
        public void fct_OP_a_CP_Ge_b_ok()
        {
            string expr = "fct(a) >= b";
            List<ExprToken> listTokens = TestCommon.AddTokens("fct", "(", "a", ")", ">=");
            TestCommon.AddTokens(listTokens, "b");

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
            ExprComparison exprComparison = result.RootExpr as ExprComparison;
            Assert.IsNotNull(exprComparison, "The root node type should be Comparison");


            //----check the left part of the comparison: the function call
            ExprFunctionCall exprFunction = exprComparison.ExprLeft as ExprFunctionCall;
            Assert.IsNotNull(exprFunction, "The root node type should be ExprFunctionCall");
            Assert.AreEqual("fct", exprFunction.FunctionName, "The function name should be: fct");
            Assert.AreEqual(1, exprFunction.ListExprParameters.Count, "The function call should have one parameter");

            // check the parameter: its a final operand
            ExprFinalOperand paraFunction = exprFunction.ListExprParameters[0] as ExprFinalOperand;
            Assert.AreEqual("a", paraFunction.Operand, "The parameter name should be: a");
            Assert.IsTrue(paraFunction.ContentType == OperandType.ObjectName, "The parameter type should be: ObjectName");

            //----check the right part of the root node
            ExprFinalOperand operandRight = exprComparison.ExprRight as ExprFinalOperand;
            Assert.IsNotNull(operandRight, "The left root node type should be BoolBinExprOperand");
            Assert.AreEqual(operandRight.Operand, "b", "The left operand should be A");

        }

        // tester avec opérateur logique : a And fct(b)
        /// <summary>
        /// A function call
        /// fct()
        /// </summary>
        [TestMethod]
        public void fct_OP_a_CP_And_b_ok()
        {
            string expr = "fct(a) And b";
            List<ExprToken> listTokens = TestCommon.AddTokens("fct", "(", "a", ")", "And");
            TestCommon.AddTokens(listTokens, "b");

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
            ExprLogical exprLogical = result.RootExpr as ExprLogical;
            Assert.IsNotNull(exprLogical, "The root node type should be Logical");


            //----check the left part of the comparison: the function call
            ExprFunctionCall exprFunction = exprLogical.ExprLeft as ExprFunctionCall;
            Assert.IsNotNull(exprFunction, "The root node type should be ExprFunctionCall");
            Assert.AreEqual("fct", exprFunction.FunctionName, "The function name should be: fct");
            Assert.AreEqual(1, exprFunction.ListExprParameters.Count, "The function call should have one parameter");

            // check the parameter: its a final operand
            ExprFinalOperand paraFunction = exprFunction.ListExprParameters[0] as ExprFinalOperand;
            Assert.AreEqual("a", paraFunction.Operand, "The parameter name should be: a");
            Assert.IsTrue(paraFunction.ContentType == OperandType.ObjectName, "The parameter type should be: ObjectName");

            //----check the right part of the root node
            ExprFinalOperand operandRight = exprLogical.ExprRight as ExprFinalOperand;
            Assert.IsNotNull(operandRight, "The left root node type should be BoolBinExprOperand");
            Assert.AreEqual(operandRight.Operand, "b", "The left operand should be A");

        }

        // todo: tester appel function avec un param valeur constante: int, double, string, bool.

        // todo: tester avec 2 parametres simples
        //... fonction imbriquée,...
    }
}
