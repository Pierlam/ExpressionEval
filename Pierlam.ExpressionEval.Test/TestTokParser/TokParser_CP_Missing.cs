using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pierlam.ExpressionEval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pierlam.ExpressionEval.Test.TokParser
{
    [TestClass]
    public class TokParser_CP_Missing
    {
        /// <summary>
        /// (A=12
        /// The final closing parenthesis is missing.
        /// </summary>
        [TestMethod]
        public void OP_A_Eq_12_wrong()
        {
            string expr = "(A=12";
            List<ExprToken> listTokens = TestCommon.AddTokens("(", "A", "=", "12");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);

            // should have an error
            Assert.AreEqual(1, result.ListError.Count, "Parse of the tokens (A=12 should be return an error.");

            Assert.AreEqual(ErrorCode.BadExpressionBracketOpenCloseMismatch, result.ListError[0].Code, "The error code should be: BadExpressionBracketOpenCloseMismatch");

        }

        /// <summary>
        /// A=15)
        /// The firt opening parenthesis is missing.
        /// </summary>
        [TestMethod]
        public void A_Eq_15_CP_wrong()
        {
            string expr = "A=15)";
            List<ExprToken> listTokens = TestCommon.AddTokens("A", "=", "15", ")");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);

            // should have an error
            Assert.AreEqual(1, result.ListError.Count, "Parse of the tokens (A=12 should be return an error.");

            Assert.AreEqual(ErrorCode.BadExpressionBracketOpenCloseMismatch, result.ListError[0].Code, "The error code should be: BadExpressionBracketOpenCloseMismatch");
            //Assert.AreEqual(0, result.ListError[0].Position, "The error position should be: 0");

        }

    }
}
