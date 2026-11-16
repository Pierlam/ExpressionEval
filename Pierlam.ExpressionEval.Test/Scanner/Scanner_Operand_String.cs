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

    public class Scanner_Operand_String
    {
        [TestMethod]
        public void A_STR_s_STR_c()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "a 's' c";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(3, listTokens.Count, expr + " should contains 3 tokens");
            Assert.AreEqual("a", listTokens[0].Value);
            Assert.AreEqual("'s'", listTokens[1].Value);
            Assert.AreEqual("c", listTokens[2].Value);
        }

        [TestMethod]
        public void A_STR_QsQ_STR_c()
        {
            ExprScanner scanner = new ExprScanner();
            TestCommon.BuildDefaultConfig(scanner);

            string expr = "a \"s\" c";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(3, listTokens.Count, expr + " should contains 3 tokens");
            Assert.AreEqual("a", listTokens[0].Value);
            Assert.AreEqual("\"s\"", listTokens[1].Value);
            Assert.AreEqual("c", listTokens[2].Value);
        }

        [TestMethod]
        public void A_STR_s_s_s_STR_c()
        {
            ExpressionEvalConfig config = TestCommon.BuildDefaultConfig();
            config.SetStringTagCode(StringTagCode.Quote);

            ExprScanner scanner = new ExprScanner();
            scanner.SetConfiguration(config);

            string expr = "a 's s s' c";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(3, listTokens.Count, expr + " should contains 3 tokens");
            Assert.AreEqual("a", listTokens[0].Value);
            Assert.AreEqual("'s s s'", listTokens[1].Value);
            Assert.AreEqual("c", listTokens[2].Value);
        }

        /// <summary>
        /// The string end tag is missing!
        /// </summary>
        [TestMethod]
        public void A_STR_s_c()
        {
            ExprScanner scanner = new ExprScanner();

            // todo: parametriser stringtag: Quote ou DoubleQuote
            ExpressionEvalConfig  config= TestCommon.BuildDefaultConfig();
            config.SetStringTagCode(StringTagCode.Quote);
            scanner.SetConfiguration(config);


            string expr = "a 's c";

            List<ExprToken> listTokens = scanner.SplitExpr(expr);

            Assert.AreEqual(2, listTokens.Count, expr + " should contains 2 tokens");
            Assert.AreEqual("a", listTokens[0].Value);
            Assert.AreEqual("'s c", listTokens[1].Value);
        }

    }
}
