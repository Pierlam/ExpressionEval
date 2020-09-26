using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pierlam.ExpressionEval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pierlam.ExpressionEval.Test.TokParser
{
    /// <summary>
    /// Check operand types.
    /// </summary>
    [TestClass]
    public class TokParser_OperandType_Number
    {
        [TestMethod]
        public void CheckOperand_numberInt()
        {
            string expr = "12";
            List<ExprToken> listTokens = TestCommon.AddTokens("12");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);
            // finished with no error
            Assert.AreEqual(0, result.ListError.Count, "The tokens 12 should be decoded with success");

            // check the root node
            ExprFinalOperand rootBinExpr = result.RootExpr as ExprFinalOperand;
            Assert.IsNotNull(rootBinExpr, "The root node type should be BoolBinExprOperand");
            Assert.AreEqual("12", rootBinExpr.Operand, "The left operand should be 12");
            Assert.AreEqual(OperandType.ValueInt, rootBinExpr.ContentType, "The operand type should be a number");

        }

        [TestMethod]
        public void CheckOperand_neg_number()
        {
            string expr = "-34";
            List<ExprToken> listTokens = TestCommon.AddTokens("-34");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);
            // finished with no error
            Assert.AreEqual(0, result.ListError.Count, "The tokens -34 should be decoded with success");

            // check the root node
            ExprFinalOperand rootBinExpr = result.RootExpr as ExprFinalOperand;
            Assert.IsNotNull(rootBinExpr, "The root node type should be BoolBinExprOperand");

            Assert.AreEqual("-34", rootBinExpr.Operand, "The left operand should be -34");
            Assert.AreEqual(OperandType.ValueInt, rootBinExpr.ContentType, "The operand type should be a number");

        }

        [TestMethod]
        public void CheckOperand_double_separatorDot()
        {
            string expr = "12.34";
            List<ExprToken> listTokens = TestCommon.AddTokens("12.34");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildConfig(DecimalAndFunctionSeparators.Standard);
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);
            // finished with no error
            Assert.AreEqual(0, result.ListError.Count, "The tokens 12.34 should be decoded with success");

            // check the root node
            ExprFinalOperand rootBinExpr = result.RootExpr as ExprFinalOperand;
            Assert.IsNotNull(rootBinExpr, "The root node type should be BoolBinExprOperand");

            Assert.AreEqual("12.34", rootBinExpr.Operand, "The left operand should be 12.34");
            Assert.AreEqual(OperandType.ValueDouble, rootBinExpr.ContentType, "The operand type should be a double");
        }

        [TestMethod]
        public void CheckOperand_double_exposant_ok()
        {
            string expr = "12.34E3";
            List<ExprToken> listTokens = TestCommon.AddTokens("12.34E3");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildConfig(DecimalAndFunctionSeparators.Standard);
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);
            // finished with no error
            Assert.AreEqual(0, result.ListError.Count, "The tokens 12.34E3 should be decoded with success");

            // check the root node
            ExprFinalOperand rootBinExpr = result.RootExpr as ExprFinalOperand;
            Assert.IsNotNull(rootBinExpr, "The root node type should be BoolBinExprOperand");

            Assert.AreEqual("12.34E3", rootBinExpr.Operand, "The left operand should be 12.34E3");
            Assert.AreEqual(OperandType.ValueDouble, rootBinExpr.ContentType, "The operand type should be a double");
        }

        [TestMethod]
        public void CheckOperand_number_badformed()
        {
            string expr = "12az";
            List<ExprToken> listTokens = TestCommon.AddTokens("12az");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);
            // finished with no error
            Assert.AreEqual(1, result.ListError.Count, "The tokens 12az should be decoded with one error");

            Assert.AreEqual(ErrorCode.ValueNumberBadFormed, result.ListError[0].Code, "the parse should failed: ValueNumberBadFormed");
            //// check the root node
            //ExprFinalOperand rootBinExpr = result.RootExpr as ExprFinalOperand;
            //Assert.IsNotNull(rootBinExpr, "The root node type should be BoolBinExprOperand");

            //Assert.AreEqual("12az", rootBinExpr.Operand, "The left operand should be 12az");
            //Assert.AreEqual(OperandType.ValueNumberBadFormed, rootBinExpr.ContentType, "The operand type should be a string");
        }

    }
}
