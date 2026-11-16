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
    /// test the full evaluator, from the expression in the string to output binary tree.
    /// Do some basic tests here.
    /// TestFullEval_Operand_Operator_Operand
    /// TestExprEval_Parse_Basic
    /// </summary>
    [TestClass]
    public class ExprEval_Parse_Basic
    {
        [TestMethod]
        public void ExprIsNull()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = null;

            ParseResult decodeResult = evaluator.Parse(expr);
            Assert.IsTrue(decodeResult.HasError, "the expression process should fail");
        }

        [TestMethod]
        public void ExprIsBlank()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "   ";

            ParseResult decodeResult = evaluator.Parse(expr);
            Assert.IsTrue(decodeResult.HasError, "the expression process should fail");
        }

        [TestMethod]
        public void ExprIsA()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "A";

            ParseResult parseResult = evaluator.Parse(expr);
            Assert.IsFalse(parseResult.HasError, "the expression process should finish successfully");

            // check the syntax tree
            // check the root node
            ExprFinalOperand rootBinExprOperand = parseResult.RootExpr as ExprFinalOperand;
            Assert.IsNotNull(rootBinExprOperand, "The root node type should be a ExprFinalOperand");
            Assert.AreEqual(rootBinExprOperand.Operand, "A", "The left operand should be A");
        }

        [TestMethod]
        public void Expr_Minus_6_Ret_Minus_6_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();
            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "-6";

            //-1---parse the string, return a syntax tree
            ParseResult parseResult = evaluator.Parse(expr);
            Assert.IsFalse(parseResult.HasError, "the expression process should finish successfully");

            // check the root node
            ExprFinalOperand rootExpr = parseResult.RootExpr as ExprFinalOperand;
            Assert.IsNotNull(rootExpr, "The root node type should be a ExprFinalOperand");
            Assert.AreEqual(-6, rootExpr.ValueInt, "The left operand should be -6");
        }


        [TestMethod]
        public void Expr_3E4_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();
            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);


            // its a double!
            string expr = "3E4";

            //-1---parse the string, return a syntax tree
            ParseResult parseResult = evaluator.Parse(expr);
            Assert.IsFalse(parseResult.HasError, "the expression process should finish successfully");

            // check the root node
            ExprFinalOperand rootExpr = parseResult.RootExpr as ExprFinalOperand;
            Assert.IsNotNull(rootExpr, "The root node type should be a ExprFinalOperand");
            Assert.AreEqual(3E4, rootExpr.ValueDouble, "The left operand should be 3E4");
        }

        [TestMethod]
        public void Expr_M2dot5E3_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();
            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);


            // its a double!
            string expr = "-2.5E3";

            //-1---parse the string, return a syntax tree
            ParseResult parseResult = evaluator.Parse(expr);
            Assert.IsFalse(parseResult.HasError, "the expression process should finish successfully");

            // check the root node
            ExprFinalOperand rootExpr = parseResult.RootExpr as ExprFinalOperand;
            Assert.IsNotNull(rootExpr, "The root node type should be a ExprFinalOperand");
            Assert.AreEqual(-2.5E3, rootExpr.ValueDouble, "The left operand should be -2.5E3");
        }
    }
}
