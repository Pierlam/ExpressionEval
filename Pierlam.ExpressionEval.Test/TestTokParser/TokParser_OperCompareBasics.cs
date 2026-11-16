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
    /// Basics tests on parsing comparison expressions.
    /// Don't test the scanner!  test only the decoder.
    /// 
    /// (A = B)
    /// (A <> B)
    /// 
    /// build the AST (syntax tree).
    /// </summary>
    [TestClass]
    public class TokParser_OperCompareBasics
    {
        /// <summary>
        /// test an expression without main bracket: A=B.
        /// result:
        ///   Root= BoolBinExpr
        ///     ExprLeft= BoolBinExprOperand/A
        ///     ExprRight= BoolBinExprOperand/B
        ///     Operator= =/Equal
        /// </summary>
        [TestMethod]
        public void A_Eq_B()
        {
            string expr = "A=B";
            List<ExprToken> listTokens = TestCommon.AddTokens("A", "=", "B");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);
            // finished with no error
            Assert.AreEqual(0, result.ListError.Count, "The tokens (A=B) should be decoded with success");

            //----check the root node
            ExprComparison rootBinExpr = result.RootExpr as ExprComparison;
            Assert.IsNotNull(rootBinExpr, "The root node type should be BoolBinExpr");

            //----check the left part of the root node
            ExprFinalOperand operandLeft = rootBinExpr.ExprLeft as ExprFinalOperand;
            Assert.IsNotNull(operandLeft, "The left root node type should be BoolBinExprOperand");
            Assert.AreEqual(operandLeft.Operand, "A", "The left operand should be A");

            //----check the right part of the root node
            ExprFinalOperand operandRight = rootBinExpr.ExprRight as ExprFinalOperand;
            Assert.IsNotNull(operandRight, "The left root node type should be BoolBinExprOperand");
            Assert.AreEqual(operandRight.Operand, "B", "The left operand should be B");

            // check the root node operator
            Assert.AreEqual(rootBinExpr.Operator, OperatorComparisonCode.Equals, "The root operator should be =");
        }

        /// <summary>
        /// test (A=B).
        /// result:
        ///   Root= BoolBinExpr
        ///     ExprLeft= BoolBinExprOperand/A
        ///     ExprRight= BoolBinExprOperand/B
        ///     Operator= =/Equal
        /// </summary>
        [TestMethod]
        public void Bra_A_Eq_B_Bra()
        {
            string expr = "(A=B)";
            List<ExprToken> listTokens = TestCommon.AddTokens("(", "A", "=", "B", ")");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);
            // finished with no error
            Assert.AreEqual(0, result.ListError.Count, "The tokens (A=B) should be decoded with success");
            // check the root node
            ExprComparison rootBinExpr = result.RootExpr as ExprComparison;
            Assert.IsNotNull(rootBinExpr, "The root node type should be BoolBinExpr");

            // check the left part of the root node
            ExprFinalOperand operandLeft = rootBinExpr.ExprLeft as ExprFinalOperand;
            Assert.IsNotNull(operandLeft, "The left root node type should be BoolBinExprOperand");
            Assert.AreEqual(operandLeft.Operand, "A", "The left operand should be A");

            // check the right part of the root node
            ExprFinalOperand operandRight = rootBinExpr.ExprRight as ExprFinalOperand;
            Assert.IsNotNull(operandRight, "The left root node type should be BoolBinExprOperand");
            Assert.AreEqual(operandRight.Operand, "B", "The left operand should be B");

            // check the root node operator
            Assert.AreEqual(rootBinExpr.Operator, OperatorComparisonCode.Equals, "The root operator should be =");
        }

        /// <summary>
        /// test A>=B
        /// result:
        ///   Root= BoolBinExpr
        ///     ExprLeft= BoolBinExprOperand/A
        ///     ExprRight= BoolBinExprOperand/B
        ///     Operator= =/Equal
        /// </summary>
        [TestMethod]
        public void A_GtEq_B()
        {
            string expr = "A>=B";
            List<ExprToken> listTokens = TestCommon.AddTokens("A", ">=", "B");

            // decoder, renvoie un arbre de node
            ExprTokensParser decoder = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            decoder.SetConfiguration(dictOperators);


            // decode the list of tokens
            ParseResult result = decoder.Parse(expr, listTokens);
            // finished with no error
            Assert.AreEqual(0, result.ListError.Count, "The tokens (A=B) should be decoded with success");
            // check the root node
            ExprComparison rootBinExpr = result.RootExpr as ExprComparison;
            Assert.IsNotNull(rootBinExpr, "The root node type should be BoolBinExpr");

            // check the left part of the root node
            ExprFinalOperand operandLeft = rootBinExpr.ExprLeft as ExprFinalOperand;
            Assert.IsNotNull(operandLeft, "The left root node type should be BoolBinExprOperand");
            Assert.AreEqual(operandLeft.Operand, "A", "The left operand should be A");

            // check the right part of the root node
            ExprFinalOperand operandRight = rootBinExpr.ExprRight as ExprFinalOperand;
            Assert.IsNotNull(operandRight, "The left root node type should be BoolBinExprOperand");
            Assert.AreEqual(operandRight.Operand, "B", "The left operand should be B");

            // check the root node operator
            Assert.AreEqual(rootBinExpr.Operator, OperatorComparisonCode.GreaterEquals, "The root operator should be >=");
        }


        /// <summary>
        /// test (A>=B).
        /// result:
        ///   Root= BoolBinExpr
        ///     ExprLeft= BoolBinExprOperand/A
        ///     ExprRight= BoolBinExprOperand/B
        ///     Operator= =/Equal
        /// </summary>
        [TestMethod]
        public void Bra_A_GtEq_B_Bra()
        {
            string expr = "(A>=B)";
            List<ExprToken> listTokens = TestCommon.AddTokens("(", "A", ">=", "B", ")");

            // decoder, renvoie un arbre de node
            ExprTokensParser decoder = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            decoder.SetConfiguration(dictOperators);


            // decode the list of tokens
            ParseResult result = decoder.Parse(expr, listTokens);
            // finished with no error
            Assert.AreEqual(0, result.ListError.Count, "The tokens (A=B) should be decoded with success");
            // check the root node
            ExprComparison rootBinExpr = result.RootExpr as ExprComparison;
            Assert.IsNotNull(rootBinExpr, "The root node type should be BoolBinExpr");

            // check the left part of the root node
            ExprFinalOperand operandLeft = rootBinExpr.ExprLeft as ExprFinalOperand;
            Assert.IsNotNull(operandLeft, "The left root node type should be BoolBinExprOperand");
            Assert.AreEqual(operandLeft.Operand, "A", "The left operand should be A");

            // check the right part of the root node
            ExprFinalOperand operandRight = rootBinExpr.ExprRight as ExprFinalOperand;
            Assert.IsNotNull(operandRight, "The left root node type should be BoolBinExprOperand");
            Assert.AreEqual(operandRight.Operand, "B", "The left operand should be B");

            // check the root node operator
            Assert.AreEqual(rootBinExpr.Operator, OperatorComparisonCode.GreaterEquals, "The root operator should be >=");
        }

    }
}
