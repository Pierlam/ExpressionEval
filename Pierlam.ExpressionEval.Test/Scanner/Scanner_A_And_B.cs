using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pierlam.ExpressionEval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pierlam.ExpressionEval.Test.Scanner
{
    /// <summary>
    /// Test the parser.
    /// </summary>
    [TestClass]
    public class Scanner_A_And_B
    {
        [TestMethod]
        public void BrO_A_And_B_BrC_Ok()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "(A and B)";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(5, listTokens.Count, expr + " should contains 5 tokens");
            Assert.AreEqual("(", listTokens[0].Value);
            Assert.AreEqual("A", listTokens[1].Value);
            Assert.AreEqual("and", listTokens[2].Value);
            Assert.AreEqual("B", listTokens[3].Value);
            Assert.AreEqual(")", listTokens[4].Value);
        }

        [TestMethod]
        public void BrO_A_And_B_BrC_2_Ok()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = " ( A and B ) ";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(5, listTokens.Count, expr + " should contains 5 tokens");
            Assert.AreEqual("(", listTokens[0].Value);
            Assert.AreEqual("A", listTokens[1].Value);
            Assert.AreEqual("and", listTokens[2].Value);
            Assert.AreEqual("B", listTokens[3].Value);
            Assert.AreEqual(")", listTokens[4].Value);
        }

        [TestMethod]
        public void BrO_A_And_B_BrC_3_Ok()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "  (  A  and   B   )    ";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(5, listTokens.Count, expr + " should contains 5 tokens");
            Assert.AreEqual("(", listTokens[0].Value);
            Assert.AreEqual("A", listTokens[1].Value);
            Assert.AreEqual("and", listTokens[2].Value);
            Assert.AreEqual("B", listTokens[3].Value);
            Assert.AreEqual(")", listTokens[4].Value);
        }


    }

}
