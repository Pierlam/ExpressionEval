using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pierlam.ExpressionEval.Test.ExprEval_Parse
{
    [TestClass]
    public class ExprEval_Parse_ExprCalculation_3Operands
    {
        /// <summary>
        /// test:  4+5+1
        /// </summary>
        [TestMethod]
        public void Expr_4_Plus_5_Plus_1_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();
            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "4+5-1";

            //-1---parse the string, return a syntax tree
            ParseResult parseResult = evaluator.Parse(expr);
            Assert.IsFalse(parseResult.HasError, "the expression process should finish successfully");

            // check the root node
            ExprCalculation rootExprCalc = parseResult.RootExpr as ExprCalculation;
            Assert.IsNotNull(rootExprCalc, "The root node type should be an ExprCalculation");

            // the calc expr should contains 3 operands and 2 operators
            Assert.AreEqual(3, rootExprCalc.ListExprOperand.Count, "The ExprCalculation should contains 3 operands");
            Assert.AreEqual(2, rootExprCalc.ListOperator.Count, "The ExprCalculation should contains 2 operators");

            // check (just) the last operator: -/minus
            ExprOperatorCalculation operatorTwo = rootExprCalc.ListOperator[1]  as ExprOperatorCalculation;
            Assert.IsNotNull(operatorTwo, "The left root node type should be a ExprFinalOperand");
            Assert.AreEqual(OperatorCalculationCode.Minus, operatorTwo.Operator, "The Second operator should be: -/minus");

            // check (just) the last operand: 1
            ExprFinalOperand operandThree = rootExprCalc.ListExprOperand[2] as ExprFinalOperand;
            Assert.IsNotNull(operandThree, "The left root node type should be a ExprFinalOperand");
            Assert.AreEqual(1, operandThree.ValueInt, "The left operand should be 11");
        }

        /// <summary>
        /// test:  4+5+1
        /// </summary>
        [TestMethod]
        public void Expr_4_Mul_5_Plus_1_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();
            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "4*5-1";

            //-1---parse the string, return a syntax tree
            ParseResult parseResult = evaluator.Parse(expr);
            Assert.IsFalse(parseResult.HasError, "the expression process should finish successfully");

            // check the root node
            ExprCalculation rootExprCalc = parseResult.RootExpr as ExprCalculation;
            Assert.IsNotNull(rootExprCalc, "The root node type should be an ExprCalculation");

            // the calc expr should contains 3 operands and 2 operators
            Assert.AreEqual(3, rootExprCalc.ListExprOperand.Count, "The ExprCalculation should contains 3 operands");
            Assert.AreEqual(2, rootExprCalc.ListOperator.Count, "The ExprCalculation should contains 2 operators");

            // check (just) the fisrt operator: */Mul
            ExprOperatorCalculation operatorTwo = rootExprCalc.ListOperator[0] as ExprOperatorCalculation;
            Assert.IsNotNull(operatorTwo, "The left root node type should be a ExprFinalOperand");
            Assert.AreEqual(OperatorCalculationCode.Multiplication, operatorTwo.Operator, "The Second operator should be: *");

            // check (just) the last operand: 1
            ExprFinalOperand operandThree = rootExprCalc.ListExprOperand[2] as ExprFinalOperand;
            Assert.IsNotNull(operandThree, "The left root node type should be a ExprFinalOperand");
            Assert.AreEqual(1, operandThree.ValueInt, "The left operand should be 11");

        }

    }
}
