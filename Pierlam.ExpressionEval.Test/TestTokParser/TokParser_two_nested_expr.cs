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
    /// Check some two nested expr in a main expr.
    /// exp: ((a and b) and (c or d))
    /// </summary>
    [TestClass]
    public class TokParser_two_nested_expr
    {
        [TestMethod]
        public void BRA_BRA_a_and_b_BRA_and_BRA_c_or_d_BRA_BRA()
        {
            string expr = "((a and b) and (c or d))";
            List<ExprToken> listTokens = TestCommon.AddTokens("(", "(", "a");
            TestCommon.AddTokens(listTokens, "and", "b", ")");
            TestCommon.AddTokens(listTokens, "and", "(", "c");
            TestCommon.AddTokens(listTokens, "or", "d", ")");
            TestCommon.AddTokens(listTokens, ")");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
           parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);
            // finished with no error
            Assert.AreEqual(0, result.ListError.Count, "The tokens (not a) should be decoded with success");

            // check the root node: bin expr
            ExprLogical binExpr = result.RootExpr as ExprLogical;
            Assert.IsNotNull(binExpr, "The root node type should be ExprLogical");

            // left and right are expr
            ExprLogical leftBinExpr = binExpr.ExprLeft as ExprLogical;
            Assert.IsNotNull(leftBinExpr, "The left node type should be ExprLogical");

            ExprLogical rightBinExpr = binExpr.ExprRight as ExprLogical;
            Assert.IsNotNull(rightBinExpr, "The right node type should be ExprLogical");
            Assert.AreEqual(OperatorLogicalCode.And, binExpr.Operator, "The operator should be and");


            //----left : a and b
            ExprFinalOperand leftLeftOperand = leftBinExpr.ExprLeft as ExprFinalOperand;
            Assert.IsNotNull(leftLeftOperand, "The node type should be BoolBinExprOperand");
            Assert.AreEqual("a", leftLeftOperand.Operand, "The not operand should be a");

            ExprFinalOperand leftRightOperand = leftBinExpr.ExprRight as ExprFinalOperand;
            Assert.IsNotNull(leftRightOperand, "The node type should be BoolBinExprOperand");
            Assert.AreEqual("b", leftRightOperand.Operand, "The not operand should be b");

            Assert.AreEqual(OperatorLogicalCode.And, leftBinExpr.Operator, "The operator should be and");

            //----right:  c or d
            ExprFinalOperand rightLeftOperand = rightBinExpr.ExprLeft as ExprFinalOperand;
            Assert.IsNotNull(rightLeftOperand, "The node type should be BoolBinExprOperand");
            Assert.AreEqual("c", rightLeftOperand.Operand, "The not operand should be a");

            ExprFinalOperand rightRightOperand = rightBinExpr.ExprRight as ExprFinalOperand;
            Assert.IsNotNull(rightRightOperand, "The node type should be BoolBinExprOperand");
            Assert.AreEqual("d", rightRightOperand.Operand, "The not operand should be b");

            Assert.AreEqual(OperatorLogicalCode.Or, rightBinExpr.Operator, "The operator should be and");
        }

        /// <summary>
        /// ((a and b) > (b or c)). 
        /// d'un point de vue strict, doit fonctionner, exp: true>false
        /// </summary>
        [TestMethod]
        public void BRA_BRA_a_and_b_BRA_Gt_BRA_c_or_d_BRA_BRA()
        {
            string expr = "((a and b) > (c or d))";
            List<ExprToken> listTokens = TestCommon.AddTokens("(", "(", "a");
            TestCommon.AddTokens(listTokens, "and", "b", ")");
            TestCommon.AddTokens(listTokens, ">", "(", "c");
            TestCommon.AddTokens(listTokens, "or", "d", ")");
            TestCommon.AddTokens(listTokens, ")");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);
            // finished with no error
            Assert.AreEqual(0, result.ListError.Count, "The tokens (not a) should be decoded with success");

            // check the root node: bin expr
            ExprComparison binExpr = result.RootExpr as ExprComparison;
            Assert.IsNotNull(binExpr, "The root node type should be BoolBinExpr");

            // left and right are expr
            ExprLogical leftBinExpr = binExpr.ExprLeft as ExprLogical;
            Assert.IsNotNull(leftBinExpr, "The left node type should be BoolBinExpr");

            ExprLogical rightBinExpr = binExpr.ExprRight as ExprLogical;
            Assert.IsNotNull(rightBinExpr, "The right node type should be BoolBinExpr");


            Assert.AreEqual(OperatorComparisonCode.Greater, binExpr.Operator, "The operator should be > (greater)");
        }


        /// <summary>
        /// ((a=b) and c)
        /// </summary>
        [TestMethod]
        public void BRA_BRA_a_Eq_b_BRA_and_c_BRA()
        {
            string expr = "((a = b) and c)";
            List<ExprToken> listTokens = TestCommon.AddTokens("(", "(", "a");
            TestCommon.AddTokens(listTokens, "=", "b", ")");
            TestCommon.AddTokens(listTokens, "and", "c", ")");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);
            // finished with no error
            Assert.AreEqual(0, result.ListError.Count, "The tokens should be decoded with success");

            // check the root node: bin expr
            ExprLogical binExpr = result.RootExpr as ExprLogical;
            Assert.IsNotNull(binExpr, "The root node type should be BoolBinExpr");
            Assert.AreEqual(OperatorLogicalCode.And, binExpr.Operator, "The operator should be > (greater)");

            // left is an expr: (a=b)
            ExprComparison leftBinExpr = binExpr.ExprLeft as ExprComparison;
            Assert.IsNotNull(leftBinExpr, "The left node type should be BoolBinExpr");

            ExprFinalOperand leftLeftOperand = leftBinExpr.ExprLeft as ExprFinalOperand;
            Assert.IsNotNull(leftLeftOperand, "The node type should be BoolBinExprOperand");
            Assert.AreEqual("a", leftLeftOperand.Operand, "The not operand should be a");

            ExprFinalOperand leftRightOperand = leftBinExpr.ExprRight as ExprFinalOperand;
            Assert.IsNotNull(leftRightOperand, "The node type should be BoolBinExprOperand");
            Assert.AreEqual("b", leftRightOperand.Operand, "The not operand should be b");

            Assert.AreEqual(OperatorComparisonCode.Equals, leftBinExpr.Operator, "The operator should be and");
            
            // right is an operand: c
            ExprFinalOperand rightOperand = binExpr.ExprRight as ExprFinalOperand;
            Assert.IsNotNull(rightOperand, "The node type should be BoolBinExprOperand");
            Assert.AreEqual("c", rightOperand.Operand, "The not operand should be c");

        }

        // todo: rajouter tests:
        // 	(a and (b or c))

    }
}
