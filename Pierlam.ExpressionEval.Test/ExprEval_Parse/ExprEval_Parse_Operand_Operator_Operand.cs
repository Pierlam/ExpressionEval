using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pierlam.ExpressionEval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pierlam.ExpressionEval.Test.ExprEval_Parse
{
    /// <summary>
    /// Test expression having this shape: 
    /// operand operator operand
    /// </summary>
    [TestClass]
    public class ExprEval_Parse_Operand_Operator_Operand
    {
        /// <summary>
        /// test:
        /// (A=B)
        /// should return 
        /// </summary>
        [TestMethod]
        public void Bra_A_Eq_B_Bra()
        {
            ExpressionEval evaluator = new ExpressionEval();
            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "(A=B)";

            //-1---parse the string, return a syntax tree
            ParseResult parseResult = evaluator.Parse(expr);
            Assert.IsFalse(parseResult.HasError, "the expression process should finish successfully");

            // check the root node
            ExprComparison rootBinExpr = parseResult.RootExpr as ExprComparison;
            Assert.IsNotNull(rootBinExpr, "The root node type should be BoolBinExpr");

            // check the left part of the root node
            ExprFinalOperand operandLeft = rootBinExpr.ExprLeft as ExprFinalOperand;
            Assert.IsNotNull(operandLeft, "The left root node type should be BoolBinExprOperand");
            Assert.AreEqual(operandLeft.Operand, "A", "The left operand should be A");

            // check the right part of the root node
            ExprFinalOperand operandRight = rootBinExpr.ExprRight as ExprFinalOperand;
            Assert.IsNotNull(operandRight, "The left root node type should be BoolBinExprOperand");
            Assert.AreEqual(operandRight.Operand, "B", "The left operand should be B");

            // check the root node operator
            Assert.AreEqual(rootBinExpr.Operator, OperatorComparisonCode.Equals, "The root operator should be =");

        }

        /// <summary>
        /// test:
        /// (A=-12)  -> A equals to -12.
        ///  
        /// </summary>
        [TestMethod]
        public void Bra_A_Eq_Minus_12_Bra()
        {
            ExpressionEval evaluator = new ExpressionEval();
            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "(A=-12)";

            //-1---parse the string, return a syntax tree
            ParseResult parseResult = evaluator.Parse(expr);
            Assert.IsFalse(parseResult.HasError, "the expression process should return success");

            // check the root node
            ExprComparison rootBinExpr = parseResult.RootExpr as ExprComparison;
            Assert.IsNotNull(rootBinExpr, "The root node type should be BoolBinExpr");

            // check the left part of the root node
            ExprFinalOperand operandLeft = rootBinExpr.ExprLeft as ExprFinalOperand;
            Assert.IsNotNull(operandLeft, "The left root node type should be BoolBinExprOperand");
            Assert.AreEqual(operandLeft.Operand, "A", "The left operand should be A");

            // check the right part of the root node
            ExprFinalOperand operandRight = rootBinExpr.ExprRight as ExprFinalOperand;
            Assert.IsNotNull(operandRight, "The left root node type should be BoolBinExprOperand");
            Assert.AreEqual(operandRight.Operand, "-12", "The left operand should be -12");

            // check the root node operator
            Assert.AreEqual(rootBinExpr.Operator, OperatorComparisonCode.Equals, "The root operator should be =");

        }

    }
}
