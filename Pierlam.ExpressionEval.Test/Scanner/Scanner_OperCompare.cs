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
    /// Test the parse of an expression containing comparison operators.
    /// </summary>
    [TestClass]
    public class Scanner_OperCompare
    {
        [TestMethod]
        public void A_Eq_B()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "(A=B)";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(5, listTokens.Count, expr + " should contains 5 tokens");
            Assert.AreEqual("(", listTokens[0].Value);
            Assert.AreEqual("A", listTokens[1].Value);
            Assert.AreEqual("=", listTokens[2].Value);
            Assert.AreEqual("B", listTokens[3].Value);
            Assert.AreEqual(")", listTokens[4].Value);
        }

        [TestMethod]
        public void Spc_A_Spc_Eq_Spc_B_Spc()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "( A = B )";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(5, listTokens.Count, expr + " should contains 5 tokens");
            Assert.AreEqual("(", listTokens[0].Value);
            Assert.AreEqual("A", listTokens[1].Value);
            Assert.AreEqual("=", listTokens[2].Value);
            Assert.AreEqual("B", listTokens[3].Value);
            Assert.AreEqual(")", listTokens[4].Value);
        }

        [TestMethod]
        public void Spc_A_Eq_Spc_B_Spc()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "( A= B )";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(5, listTokens.Count, expr + " should contains 5 tokens");
            Assert.AreEqual("(", listTokens[0].Value);
            Assert.AreEqual("A", listTokens[1].Value);
            Assert.AreEqual("=", listTokens[2].Value);
            Assert.AreEqual("B", listTokens[3].Value);
            Assert.AreEqual(")", listTokens[4].Value);
        }

        [TestMethod]
        public void Spc_A_Spc_Eq_B_Spc()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "( A =B )";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(5, listTokens.Count, expr + " should contains 5 tokens");
            Assert.AreEqual("(", listTokens[0].Value);
            Assert.AreEqual("A", listTokens[1].Value);
            Assert.AreEqual("=", listTokens[2].Value);
            Assert.AreEqual("B", listTokens[3].Value);
            Assert.AreEqual(")", listTokens[4].Value);
        }

        [TestMethod]
        public void A_Gt_B()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "(A>B)";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(5, listTokens.Count, expr + " should contains 5 tokens");
            Assert.AreEqual("(", listTokens[0].Value);
            Assert.AreEqual("A", listTokens[1].Value);
            Assert.AreEqual(">", listTokens[2].Value);
            Assert.AreEqual("B", listTokens[3].Value);
            Assert.AreEqual(")", listTokens[4].Value);
        }

        [TestMethod]
        public void Spc_A_Spc_Gt_B_Spc()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "( A > B )";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(5, listTokens.Count, expr + " should contains 5 tokens");
            Assert.AreEqual("(", listTokens[0].Value);
            Assert.AreEqual("A", listTokens[1].Value);
            Assert.AreEqual(">", listTokens[2].Value);
            Assert.AreEqual("B", listTokens[3].Value);
            Assert.AreEqual(")", listTokens[4].Value);
        }

        [TestMethod]
        public void A_GtEq_B()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "(A>=B)";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(6, listTokens.Count, expr + " should contains 5 tokens");
            Assert.AreEqual("(", listTokens[0].Value);
            Assert.AreEqual("A", listTokens[1].Value);
            Assert.AreEqual(">", listTokens[2].Value);
            Assert.AreEqual("=", listTokens[3].Value);
            Assert.AreEqual("B", listTokens[4].Value);
            Assert.AreEqual(")", listTokens[5].Value);
        }

        [TestMethod]
        public void Spc_A__Spc_GtEq_Spc_B_Spc()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "( A >= B )";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(6, listTokens.Count, expr + " should contains 6 tokens");
            Assert.AreEqual("(", listTokens[0].Value);
            Assert.AreEqual("A", listTokens[1].Value);
            Assert.AreEqual(">", listTokens[2].Value);
            Assert.AreEqual("=", listTokens[3].Value);
            Assert.AreEqual("B", listTokens[4].Value);
            Assert.AreEqual(")", listTokens[5].Value);
        }

        [TestMethod]
        public void Spc_A__Spc_Gt_Spc_Eq_Spc_B_Spc()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "( A > = B )";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(6, listTokens.Count, expr + " should contains 6 tokens");
            Assert.AreEqual("(", listTokens[0].Value);
            Assert.AreEqual("A", listTokens[1].Value);
            Assert.AreEqual(">", listTokens[2].Value);
            Assert.AreEqual("=", listTokens[3].Value);
            Assert.AreEqual("B", listTokens[4].Value);
            Assert.AreEqual(")", listTokens[5].Value);
        }

        [TestMethod]
        public void A_Lt_B()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "(A<B)";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(5, listTokens.Count, expr + " should contains 5 tokens");
            Assert.AreEqual("(", listTokens[0].Value);
            Assert.AreEqual("A", listTokens[1].Value);
            Assert.AreEqual("<", listTokens[2].Value);
            Assert.AreEqual("B", listTokens[3].Value);
            Assert.AreEqual(")", listTokens[4].Value);
        }

        [TestMethod]
        public void Spc_A_Spc_Lt_B_Spc()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "( A < B )";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(5, listTokens.Count, expr + " should contains 5 tokens");
            Assert.AreEqual("(", listTokens[0].Value);
            Assert.AreEqual("A", listTokens[1].Value);
            Assert.AreEqual("<", listTokens[2].Value);
            Assert.AreEqual("B", listTokens[3].Value);
            Assert.AreEqual(")", listTokens[4].Value);
        }

        [TestMethod]
        public void A_LtEq_B()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "(A<=B)";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(6, listTokens.Count, expr + " should contains 6 tokens");
            Assert.AreEqual("(", listTokens[0].Value);
            Assert.AreEqual("A", listTokens[1].Value);
            Assert.AreEqual("<", listTokens[2].Value);
            Assert.AreEqual("=", listTokens[3].Value);
            Assert.AreEqual("B", listTokens[4].Value);
            Assert.AreEqual(")", listTokens[5].Value);
        }

        [TestMethod]
        public void Spc_A__Spc_LtEq_Spc_B_Spc()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "( A <= B )";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(6, listTokens.Count, expr + " should contains 6 tokens");
            Assert.AreEqual("(", listTokens[0].Value);
            Assert.AreEqual("A", listTokens[1].Value);
            Assert.AreEqual("<", listTokens[2].Value);
            Assert.AreEqual("=", listTokens[3].Value);
            Assert.AreEqual("B", listTokens[4].Value);
            Assert.AreEqual(")", listTokens[5].Value);
        }

        [TestMethod]
        public void Spc_A__Spc_Lt_Spc_Eq_Spc_B_Spc()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "( A < = B )";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(6, listTokens.Count, expr + " should contains 6 tokens");
            Assert.AreEqual("(", listTokens[0].Value);
            Assert.AreEqual("A", listTokens[1].Value);
            Assert.AreEqual("<", listTokens[2].Value);
            Assert.AreEqual("=", listTokens[3].Value);
            Assert.AreEqual("B", listTokens[4].Value);
            Assert.AreEqual(")", listTokens[5].Value);
        }

        [TestMethod]
        public void A_LtGt_B()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "(A<>B)";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(6, listTokens.Count, expr + " should contains 6 tokens");
            Assert.AreEqual("(", listTokens[0].Value);
            Assert.AreEqual("A", listTokens[1].Value);
            Assert.AreEqual("<", listTokens[2].Value);
            Assert.AreEqual(">", listTokens[3].Value);
            Assert.AreEqual("B", listTokens[4].Value);
            Assert.AreEqual(")", listTokens[5].Value);
        }

        [TestMethod]
        public void Spc_A__Spc_LtGt_Spc_B_Spc()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "( A <> B )";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(6, listTokens.Count, expr + " should contains 6 tokens");
            Assert.AreEqual("(", listTokens[0].Value);
            Assert.AreEqual("A", listTokens[1].Value);
            Assert.AreEqual("<", listTokens[2].Value);
            Assert.AreEqual(">", listTokens[3].Value);
            Assert.AreEqual("B", listTokens[4].Value);
            Assert.AreEqual(")", listTokens[5].Value);
        }

        [TestMethod]
        public void Spc_A__Spc_Lt_Spc_Gt_Spc_B_Spc()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "( A < > B )";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(6, listTokens.Count, expr + " should contains 6 tokens");
            Assert.AreEqual("(", listTokens[0].Value);
            Assert.AreEqual("A", listTokens[1].Value);
            Assert.AreEqual("<", listTokens[2].Value);
            Assert.AreEqual(">", listTokens[3].Value);
            Assert.AreEqual("B", listTokens[4].Value);
            Assert.AreEqual(")", listTokens[5].Value);
        }


    }
}
