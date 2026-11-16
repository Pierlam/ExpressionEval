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
    /// test function without parameter.
    /// </summary>
    [TestClass]
    public class Scanner_Fct
    {
        [TestMethod]
        public void BO_Fct_BO_BC_BC()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "( fct())";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(5, listTokens.Count, expr + " should contains 5 tokens");
            Assert.AreEqual("(", listTokens[0].Value);
            Assert.AreEqual("fct", listTokens[1].Value);
            Assert.AreEqual("(", listTokens[2].Value);
            Assert.AreEqual(")", listTokens[3].Value);
            Assert.AreEqual(")", listTokens[4].Value);
        }

        [TestMethod]
        public void Fct_OneParam()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "( fct(a))";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(6, listTokens.Count, expr + " should contains 6 tokens");
            Assert.AreEqual("(", listTokens[0].Value);
            Assert.AreEqual("fct", listTokens[1].Value);
            Assert.AreEqual("(", listTokens[2].Value);
            Assert.AreEqual("a", listTokens[3].Value);
            Assert.AreEqual(")", listTokens[4].Value);
            Assert.AreEqual(")", listTokens[5].Value);
        }

        [TestMethod]
        public void Fct_TwoParam()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            // todo: seulement si le parametre FunctionCallAvailable est à true!!
            // et si le separator est défini a std  (DoubleAndFunctionCallParameterSeparator= Std)
            string expr = "( fct(a,b))";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(8, listTokens.Count, expr + " should contains 8 tokens");
            Assert.AreEqual("(", listTokens[0].Value);
            Assert.AreEqual("fct", listTokens[1].Value);
            Assert.AreEqual("(", listTokens[2].Value);
            Assert.AreEqual("a", listTokens[3].Value);
            Assert.AreEqual(",", listTokens[4].Value);
            Assert.AreEqual("b", listTokens[5].Value);
            Assert.AreEqual(")", listTokens[6].Value);
            Assert.AreEqual(")", listTokens[7].Value);
        }

    }
}
