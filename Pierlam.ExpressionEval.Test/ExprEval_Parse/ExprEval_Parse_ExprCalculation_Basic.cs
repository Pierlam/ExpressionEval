using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pierlam.ExpressionEval.Test.ExprEval_Parse
{
    [TestClass]
    public class ExprEval_Parse_ExprCalculation_Basic
    {
        /// <summary>
        /// test:  12+5
        /// </summary>
        [TestMethod]
        public void Expr_12_Plus_5_Ret_17_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();
            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "12+5";

            //-1---parse the string, return a syntax tree
            ParseResult parseResult = evaluator.Parse(expr);
            Assert.IsFalse(parseResult.HasError, "the expression process should finish successfully");

            // check the root node
            ExprCalculation rootExprCalc = parseResult.RootExpr as ExprCalculation;
            Assert.IsNotNull(rootExprCalc, "The root node type should be an ExprCalculation");

            // has two operands
            Assert.AreEqual(2, rootExprCalc.ListExprOperand.Count, "should have 2 operands");
            Assert.AreEqual(1, rootExprCalc.ListOperator.Count, "should have 1 operator");

            // check the left part of the root node
            //ExprFinalOperand operandLeft = rootExprCalc.ExprLeft as ExprFinalOperand;
            ExprFinalOperand operandLeft = rootExprCalc.ListExprOperand[0] as ExprFinalOperand;
            Assert.IsNotNull(operandLeft, "The left root node type should be a ExprFinalOperand");
            Assert.AreEqual(12, operandLeft.ValueInt, "The left operand should be 12");

            // check the right part of the root node
            //ExprFinalOperand operandRight = rootExprCalc.ExprRight as ExprFinalOperand;
            ExprFinalOperand operandRight = rootExprCalc.ListExprOperand[1] as ExprFinalOperand;
            Assert.IsNotNull(operandRight, "The left root node type should be a ExprFinalOperand");
            Assert.AreEqual(5, operandRight.ValueInt, "The left operand should be 5");

            // check the root node operator
            Assert.AreEqual(rootExprCalc.ListOperator[0].Operator, OperatorCalculationCode.Plus, "The root operator should be Plus");
        }

        [TestMethod]
        public void Expr_13_Minus_3_Ret_10_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();
            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "13-3";

            //-1---parse the string, return a syntax tree
            ParseResult parseResult = evaluator.Parse(expr);
            Assert.IsFalse(parseResult.HasError, "the expression process should finish successfully");

            // check the root node
            ExprCalculation rootExprCalc = parseResult.RootExpr as ExprCalculation;
            Assert.IsNotNull(rootExprCalc, "The root node type should be an ExprCalculation");

            // check the left part of the root node
            //ExprFinalOperand operandLeft = rootExprCalc.ExprLeft as ExprFinalOperand;
            ExprFinalOperand operandLeft = rootExprCalc.ListExprOperand[0] as ExprFinalOperand;
            Assert.IsNotNull(operandLeft, "The left root node type should be a ExprFinalOperand");
            Assert.AreEqual(13, operandLeft.ValueInt, "The left operand should be 13");

            // check the right part of the root node
            //ExprFinalOperand operandRight = rootExprCalc.ExprRight as ExprFinalOperand;
            ExprFinalOperand operandRight = rootExprCalc.ListExprOperand[1] as ExprFinalOperand;
            Assert.IsNotNull(operandRight, "The left root node type should be a ExprFinalOperand");
            Assert.AreEqual(3, operandRight.ValueInt, "The left operand should be 3");

            // check the root node operator
            Assert.AreEqual(rootExprCalc.ListOperator[0].Operator, OperatorCalculationCode.Minus, "The root operator should be Minus");
        }

    }
}
