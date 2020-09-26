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
    public class TokParser_OperandType_ObjectName
    {
        [TestMethod]
        public void CheckOperand_objectname()
        {
            string expr = "a";
            List<ExprToken> listTokens = TestCommon.AddTokens("a");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);
            // finished with no error
            Assert.AreEqual(0, result.ListError.Count, "The tokens (A=B) should be decoded with success");

            // check the root node
            ExprFinalOperand rootBinExpr = result.RootExpr as ExprFinalOperand;
            Assert.IsNotNull(rootBinExpr, "The root node type should be BoolBinExprOperand");
            Assert.AreEqual("a", rootBinExpr.Operand, "The left operand should be a");
            Assert.AreEqual(OperandType.ObjectName, rootBinExpr.ContentType, "The operand type should be an object name");

        }

        // todo: function Call, exp: fct()

        // todo: function call with parameters
    }
}
