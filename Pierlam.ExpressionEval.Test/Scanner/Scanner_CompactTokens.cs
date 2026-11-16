using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pierlam.ExpressionEval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pierlam.ExpressionEval.Test.Scanner
{
    [TestClass]
    public class Scanner_CompactTokens
    {
        /// <summary>
        /// Group 2 tokens to a single one.
        /// </summary>
        [TestMethod]
        public void Group_Gr_Eq()
        {
            //>, =
            string expr = ">=";
            List<ExprToken> listTokens = TestCommon.AddTokens(">", "=");


            List<string> listSpecialOperators = new List<string>();
            listSpecialOperators.Add("<>");
            listSpecialOperators.Add(">=");
            listSpecialOperators.Add("<=");

            ExprScanner parser = new ExprScanner();

            ExpressionEvalConfig evalConfig = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(evalConfig);

            List<ExprToken> listTokensGrp=parser.GroupTokens(expr, listTokens);

            Assert.AreEqual(1, listTokensGrp.Count, expr + " should contains 1 token");
            Assert.AreEqual(">=", listTokensGrp[0].Value, expr + " should contains 1 '>='");
            Assert.AreEqual(0, listTokensGrp[0].Position, expr + " should contains 1 '>='");

        }

        /// <summary>
        /// Don't Group 2 tokens to a single one.
        /// </summary>
        [TestMethod]
        public void DontGroup_Gr_Ls()
        {
            //>, =
            string expr = ">=";
            List<ExprToken> listTokens = TestCommon.AddTokens(">", "<");

            ExpressionEvalConfig exprOperators= TestCommon.BuildDefaultConfig();
            ExpressionEvalConfig evalConfig = new ExpressionEvalConfig();
            ExprScanner parser = new ExprScanner();
            parser.SetConfiguration(evalConfig);

            List<ExprToken> listTokensGrp = parser.GroupTokens(expr, listTokens);

            Assert.AreEqual(2, listTokens.Count, expr + " should contains 2 tokens");
        }

        /// <summary>
        /// Group 2 tokens to a single one.
        /// (A>=B)
        /// </summary>
        [TestMethod]
        public void Group_Bra_A_Gr_Eq_B_Bra()
        {
            //>, =
            string expr = ">=";
            List<ExprToken> listTokens = TestCommon.AddTokens("(", "A", ">");
            TestCommon.AddTokens(listTokens, "=", "B",")");

            ExprScanner parser = new ExprScanner();

            ExpressionEvalConfig evalConfig = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(evalConfig);

            List<ExprToken> listTokensGrp = parser.GroupTokens(expr, listTokens);

            Assert.AreEqual(5, listTokensGrp.Count, expr + " should contains 5 tokens");

            Assert.AreEqual(">=", listTokensGrp[2].Value, expr + " should contains '>='");
        }

    }
}
