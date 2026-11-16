using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pierlam.ExpressionEval.Test.ExprEval_Parse
{
    /// <summary>
    /// Expression comparison with inner calculation expressions.
    /// </summary>
    [TestClass]
    public class ExprEval_Parse_ExprComparison_ExprCalculation
    {
        [TestMethod]
        public void Expr_12_Plus_5_Ret_17_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();
            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "a > (b+5)";
            
            //-1---parse the string, return a syntax tree
            ParseResult parseResult = evaluator.Parse(expr);
            Assert.IsFalse(parseResult.HasError, "the expression process should finish successfully");

            // check the root node
            ExprComparison rootExpr = parseResult.RootExpr as ExprComparison;
            Assert.IsNotNull(rootExpr, "The root node type should be an ExprComparison");
            Assert.AreEqual(OperatorComparisonCode.Greater, rootExpr.Operator, "The operator qqhould: plus");

            //----left part
            // check the left part 
            ExprFinalOperand operandLeft = rootExpr.ExprLeft as ExprFinalOperand;
            Assert.IsNotNull(operandLeft, "The left root node type should be a ExprFinalOperand");
            Assert.AreEqual("a", operandLeft.Operand, "The left operand should be: a");

            // check the right part 
            ExprCalculation operandRight = rootExpr.ExprRight as ExprCalculation;
            Assert.IsNotNull(operandRight, "The left root node type should be an ExprCalculation");
            Assert.AreEqual(OperatorCalculationCode.Plus, operandRight.ListOperator[0].Operator, "The operator qqhould: plus");

            //----right part
            // check the left part 
            ExprFinalOperand operandRightLeft = operandRight.ListExprOperand[0] as ExprFinalOperand;
            Assert.IsNotNull(operandRightLeft, "The left root node type should be a ExprFinalOperand");
            Assert.AreEqual("b", operandRightLeft.Operand, "The left operand should be b");

            // check the right part of the root node
            ExprFinalOperand operandRightRight = operandRight.ListExprOperand[1] as ExprFinalOperand;
            Assert.IsNotNull(operandRightRight, "The left root node type should be a ExprFinalOperand");
            Assert.AreEqual(5, operandRightRight.ValueInt, "The left operand should be 5");
        }

        [TestMethod]
        public void Expr_OP_a_Minus_2_CP_Eq_7_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();
            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "(a-2) = 7";

            //-1---parse the string, return a syntax tree
            ParseResult parseResult = evaluator.Parse(expr);
            Assert.IsFalse(parseResult.HasError, "the expression process should finish successfully");

            // check the root node
            ExprComparison rootExpr = parseResult.RootExpr as ExprComparison;
            Assert.IsNotNull(rootExpr, "The root node type should be an ExprComparison");
            Assert.AreEqual(OperatorComparisonCode.Equals, rootExpr.Operator, "The operator qqhould: plus");

            //----left part (a-2)
            // check the left part 
            ExprCalculation operandLeft = rootExpr.ExprLeft as ExprCalculation;
            Assert.IsNotNull(operandLeft, "The left root node type should be an ExprCalculation");
            Assert.AreEqual(OperatorCalculationCode.Minus, operandLeft.ListOperator[0].Operator, "The operator should: minus");

            // check the right part 
            ExprFinalOperand operandLeftRight = operandLeft.ListExprOperand[0] as ExprFinalOperand;
            Assert.IsNotNull(operandLeftRight, "The left root node type should be a ExprFinalOperand");
            Assert.AreEqual("a", operandLeftRight.Operand, "The left operand should be: a");

            // check the right part of the root node
            ExprFinalOperand operandRightRight = operandLeft.ListExprOperand[1] as ExprFinalOperand;
            Assert.IsNotNull(operandRightRight, "The left root node type should be a ExprFinalOperand");
            Assert.AreEqual(2, operandRightRight.ValueInt, "The left operand should be 2");

            //----right part: 7
            // check the left part 
            ExprFinalOperand operandRight = rootExpr.ExprRight as ExprFinalOperand;
            Assert.IsNotNull(operandRight, "The left root node type should be a ExprFinalOperand");
            Assert.AreEqual(7, operandRight.ValueInt, "The left operand should be 7");
        }

    }
}
