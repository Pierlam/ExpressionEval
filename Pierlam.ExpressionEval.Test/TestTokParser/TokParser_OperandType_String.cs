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
    /// Check operand types.
    /// </summary>
    [TestClass]
    public class TokParser_OperandType_String
    {
        [TestMethod]
        public void CheckOperand_string()
        {
            string expr = "\"bon\"";
            List<ExprToken> listTokens = TestCommon.AddTokens("\"bon\"");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);
            // finished with no error
            Assert.AreEqual(0, result.ListError.Count, "The tokens 'bon' should be decoded with success");

            // check the root node
            ExprFinalOperand rootBinExpr = result.RootExpr as ExprFinalOperand;
            Assert.IsNotNull(rootBinExpr, "The root node type should be BoolBinExprOperand");

            Assert.AreEqual("\"bon\"", rootBinExpr.Operand, "The left operand should be \"bon\"");
            Assert.AreEqual(OperandType.ValueString, rootBinExpr.ContentType, "The operand type should be a string");
        }

        [TestMethod]
        public void CheckOperand_string_badformed()
        {
            string expr = "\"bon";
            List<ExprToken> listTokens = TestCommon.AddTokens("\"bon");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);
            // finished with no error
            Assert.AreEqual(1, result.ListError.Count, "The tokens 'bon should be decoded with success");

            Assert.AreEqual(ErrorCode.ValueStringBadFormed, result.ListError[0].Code, "the parse should failed: ValueNumberBadFormed");

            //// check the root node
            //ExprFinalOperand rootBinExpr = result.RootExpr as ExprFinalOperand;
            //Assert.IsNotNull(rootBinExpr, "The root node type should be BoolBinExprOperand");

            //Assert.AreEqual("\"bon", rootBinExpr.Operand, "The left operand should be \"bon");
            //Assert.AreEqual(OperandType.ValueStringBadFormed, rootBinExpr.ContentType, "The operand type should be a string");
        }

        [TestMethod]
        public void CheckOperand_string_badformed_OnlyQuote()
        {
            string expr = "\"";
            List<ExprToken> listTokens = TestCommon.AddTokens("\"");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);
            // finished with error
            Assert.AreEqual(1, result.ListError.Count, "The tokens should be decoded with error");

            Assert.AreEqual(ErrorCode.ValueStringBadFormed, result.ListError[0].Code, "the parse should failed: ValueNumberBadFormed");

            //// check the root node
            //ExprFinalOperand rootBinExpr = result.RootExpr as ExprFinalOperand;
            //Assert.IsNotNull(rootBinExpr, "The root node type should be BoolBinExprOperand");

            //Assert.AreEqual("\"", rootBinExpr.Operand, "The left operand should be '");
            //Assert.AreEqual(OperandType.ValueStringBadFormed, rootBinExpr.ContentType, "The operand type should be a string");
        }

    }
}
