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
    /// Check the bool not operator.
    /// </summary>
    [TestClass]
    public class TokParser_Operator_Comp_Bool
    {
        [TestMethod]
        public void BRA_A_And_B_BRA()
        {
            string expr = "(A and B)";
            List<ExprToken> listTokens = TestCommon.AddTokens("(", "A", "and", "B",")");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);
            // finished with no error
            Assert.AreEqual(0, result.ListError.Count, "The expr should be decoded with success");

            // check the root node, its a binary expression
            ExprLogical rootBinExpr = result.RootExpr as ExprLogical;
            Assert.IsNotNull(rootBinExpr, "The root node type should be ExprLogical");

            // check the left part of the root node
            ExprFinalOperand operandLeft = rootBinExpr.ExprLeft as ExprFinalOperand;
            Assert.IsNotNull(operandLeft, "The left root node type should be BoolBinExprOperand");
            Assert.AreEqual(operandLeft.Operand, "A", "The left operand should be A");

            // check the right part of the root node
            ExprFinalOperand operandRight = rootBinExpr.ExprRight as ExprFinalOperand;
            Assert.IsNotNull(operandRight, "The left root node type should be BoolBinExprOperand");
            Assert.AreEqual(operandRight.Operand, "B", "The left operand should be B");

            // check the root node operator
            Assert.AreEqual(rootBinExpr.Operator, OperatorLogicalCode.And, "The root operator should be and");
        }

        [TestMethod]
        public void BRA_A_And_B_Wrong()
        {
            string expr = "(A and B";
            List<ExprToken> listTokens = TestCommon.AddTokens("(", "A", "and", "B");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);
            Assert.AreEqual(1, result.ListError.Count, "The expr should be decoded with error");
            Assert.AreEqual(ErrorCode.BadExpressionBracketOpenCloseMismatch, result.ListError[0].Code, "The errorCode should be: BadExpressionBracketOpenCloseMismatch");
        }
    }
}
