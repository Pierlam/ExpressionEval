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
    /// Test the parse of an expression containing negative number.
    /// </summary>
    [TestClass]
    public class Scanner_NegNumber
    {
        [TestMethod]
        public void Minus_12()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "-12";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(2, listTokens.Count, expr + " should contains 2 tokens");
            Assert.AreEqual("-", listTokens[0].Value);
            Assert.AreEqual("12", listTokens[1].Value);
        }

        [TestMethod]
        public void Minus_Spc_12()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "- 12";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(2, listTokens.Count, expr + " should contains 2 tokens");
            Assert.AreEqual("-", listTokens[0].Value);
            Assert.AreEqual("12", listTokens[1].Value);
        }

        [TestMethod]
        public void Spc_Minus_Spc_12_Spc()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = " - 12 ";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(2, listTokens.Count, expr + " should contains 2 tokens");
            Assert.AreEqual("-", listTokens[0].Value);
            Assert.AreEqual("12", listTokens[1].Value);
        }

        [TestMethod]
        public void a_Minus_Minus_12()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "a--12";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(4, listTokens.Count, expr + " should contains 4 tokens");
            Assert.AreEqual("a", listTokens[0].Value);
            Assert.AreEqual("-", listTokens[1].Value);
            Assert.AreEqual("-", listTokens[2].Value);
            Assert.AreEqual("12", listTokens[3].Value);
        }

        /// <summary>
        /// special case: minus a negative number.
        /// a+-12 -> a, +, -12
        /// </summary>
        [TestMethod]
        public void Group_a_Plus_Minus_12()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "a+-12";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);
            List<ExprToken> listTokensGrp = scanner.GroupTokens(expr, listTokens);

            Assert.AreEqual(3, listTokensGrp.Count, expr + " should contains 3 grouped tokens");
            Assert.AreEqual("a", listTokensGrp[0].Value);
            Assert.AreEqual("+", listTokensGrp[1].Value);
            Assert.AreEqual("-12", listTokensGrp[2].Value);
        }

        /// <summary>
        /// special case: minus a negative number.
        /// a--12 -> a, -, -12
        /// </summary>
        [TestMethod]
        public void Group_a_Minus_Minus_12()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "a--12";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);
            List<ExprToken> listTokensGrp = scanner.GroupTokens(expr, listTokens);

            Assert.AreEqual(3, listTokensGrp.Count, expr + " should contains 3 grouped tokens");
            Assert.AreEqual("a", listTokensGrp[0].Value);
            Assert.AreEqual("-", listTokensGrp[1].Value);
            Assert.AreEqual("-12", listTokensGrp[2].Value);
        }
    }
}
