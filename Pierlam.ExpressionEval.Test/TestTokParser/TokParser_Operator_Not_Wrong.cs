using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pierlam.ExpressionEval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pierlam.ExpressionEval.Test.TokParser
{
    [TestClass]
    public class TokParser_Operator_Not_Wrong
    {
        /// <summary>
        /// (a not not b) -->error.
        /// 
        /// </summary>
        [TestMethod]
        public void OP_a_not_not_b_CP_wrong()
        {
            string expr = "(a not not b)";
            List<ExprToken> listTokens = TestCommon.AddTokens("(", "a", "not", "not", "b");
            TestCommon.AddTokens(listTokens, ")");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);
            Assert.AreEqual(1, result.ListError.Count, "Should failed");

            // todo: revoir le code d'erreur renvoyé
            Assert.AreEqual(ErrorCode.ExprNotBeforeNotIsUnanthorized, result.ListError[0].Code, "The expr should be decoded with error");
        }
        // string expr = "(a = not b)";  -> erreur!
        [TestMethod]
        public void BRA_a_Eq_not_b_BRA()
        {
            string expr = "(a = not b)";
            List<ExprToken> listTokens = TestCommon.AddTokens("(", "a", "=");
            TestCommon.AddTokens(listTokens, "not", "b", ")");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);
            Assert.AreEqual(1, result.ListError.Count, "The expr should be decoded with error");
            Assert.AreEqual(ErrorCode.UnexpectedTokenBeforeNot, result.ListError[0].Code, "The expr should be decoded with error");
        }

        /// <summary>
        /// //string expr = "(a or b) not c)";  -> erreur
        /// 
        /// an open bracket is missing!
        /// </summary>
        [TestMethod]
        public void OP_a_or_b_CP_not_c_CP()
        {
            string expr = "(a or b) not c)";
            List<ExprToken> listTokens = TestCommon.AddTokens("(", "a", "or");
            TestCommon.AddTokens(listTokens, "b", ")", "not");
            TestCommon.AddTokens(listTokens, "c", ")");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);
            Assert.AreEqual(1, result.ListError.Count, "The expr should be decoded with error");
            Assert.AreEqual(ErrorCode.UnexpectedTokenBeforeNot, result.ListError[0].Code, "The expr should be decoded with error");
        }

        //  NOT NOT ??  non, pas géré, renvoie une erreur.

    }
}
