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
    /// Basics tests on expression calculcation.
    /// exp: a+12, (a+12)
    /// 
    /// can be a string concatenation or a calculation, depending on the type of the variable a.
    /// return a string or an int number or a double number.
    /// ExprCalculationOrConcatenation
    /// </summary>
    [TestClass]
    public class TokParser_ExprCalculation_Basics
    {
        [TestMethod]
        public void a_Plus_12()
        {

            string expr = "a+12";
            List<ExprToken> listTokens = TestCommon.AddTokens("a", "+", "12");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);

            //----check the root node
            ExprCalculation rootExpr = result.RootExpr as ExprCalculation;
            Assert.IsNotNull(rootExpr, "The root node type should be BoolBinExpr");

            //----check the left part of the root node
            //ExprFinalOperand operandLeft = rootExpr.ExprLeft as ExprFinalOperand;
            ExprFinalOperand operandLeft = rootExpr.ListExprOperand[0] as ExprFinalOperand;
            Assert.IsNotNull(operandLeft, "The left root node type should be a final operand");
            Assert.AreEqual(operandLeft.Operand, "a", "The left operand should be A");

            //----check the right part of the root node
            //ExprFinalOperand operandRight = rootExpr.ExprRight as ExprFinalOperand;
            ExprFinalOperand operandRight = rootExpr.ListExprOperand[1] as ExprFinalOperand;

            Assert.IsNotNull(operandRight, "The left root node type should be a Final operand");
            Assert.AreEqual(operandRight.Operand, "12", "The left operand should be 12");

            // check the root node operator
            Assert.AreEqual(rootExpr.ListOperator[0].Operator, OperatorCalculationCode.Plus, "The root operator should be =");
        }

        // "bonjour" + a
        // a + b
    }
}
