using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pierlam.ExpressionEval;

namespace Pierlam.ExpressionEval.Test.Scanner
{
    [TestClass]
    public class Scanner_EmptyShort
    {
        [TestMethod]
        public void Empty()
        {
            ExprScanner parser = new ExprScanner();

            string expr = "";

            List<ExprToken> listTokens = parser.SplitExpr(expr);

            Assert.AreEqual(0, listTokens.Count, expr + " should contains 0 tokens");
        }

        [TestMethod]
        public void OneSpace()
        {
            ExprScanner parser = new ExprScanner();

            string expr = " ";

            List<ExprToken> listTokens = parser.SplitExpr(expr);

            Assert.AreEqual(0, listTokens.Count, expr + " should contains 0 tokens");
        }

        [TestMethod]
        public void TwoSpace()
        {
            ExprScanner parser = new ExprScanner();

            string expr = "  ";

            List<ExprToken> listTokens = parser.SplitExpr(expr);

            Assert.AreEqual(0, listTokens.Count, expr + " should contains 0 tokens");
        }

        [TestMethod]
        public void BrO()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "(";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(1, listTokens.Count, expr + " should contains 1 token");
            Assert.AreEqual("(", listTokens[0].Value);
        }

        [TestMethod]
        public void Spc_BrO()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = " (";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(1, listTokens.Count, expr + " should contains 1 token");
            Assert.AreEqual("(", listTokens[0].Value);
        }

        [TestMethod]
        public void BrO_Spc()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "( ";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(1, listTokens.Count, expr + " should contains 1 token");
            Assert.AreEqual("(", listTokens[0].Value);
        }

        [TestMethod]
        public void Spc_BrO_Spc()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = " ( ";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(1, listTokens.Count, expr + " should contains 1 token");
            Assert.AreEqual("(", listTokens[0].Value);
        }

        [TestMethod]
        public void A()
        {
            ExprScanner scanner = new ExprScanner();

            TestCommon.BuildDefaultConfig(scanner);

            string expr = "A";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(1, listTokens.Count, expr + " should contains 1 token");
            Assert.AreEqual("A", listTokens[0].Value);
        }

        [TestMethod]
        public void Spc_A()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = " A";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(1, listTokens.Count, expr + " should contains 1 token");
            Assert.AreEqual("A", listTokens[0].Value);
        }

        [TestMethod]
        public void A_Spc()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "A ";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(1, listTokens.Count, expr + " should contains 1 token");
            Assert.AreEqual("A", listTokens[0].Value);
        }

        [TestMethod]
        public void Spc_A_Spc()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = " A ";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(1, listTokens.Count, expr + " should contains 1 token");
            Assert.AreEqual("A", listTokens[0].Value);
        }

    }
}
