using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pierlam.ExpressionEval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pierlam.ExpressionEval.Test.TokParser
{
    /// <summary>
    /// Check the bool not operator.
    /// </summary>
    [TestClass]
    public class TokParser_Operator_Not_Ok
    {
        /// <summary>
        /// not(a)
        /// should be ok.
        /// </summary>
        [TestMethod]
        public void not_OP_a_CP_ok()
        {
            string expr = "not(a)";
            List<ExprToken> listTokens = TestCommon.AddTokens("not", "(","a", ")");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);
            // finished with no error
            Assert.AreEqual(0, result.ListError.Count, "The tokens (not a) should be decoded with success");

            // check the root node
            ExprLogicalNot rootBinExpr = result.RootExpr as ExprLogicalNot;
            Assert.IsNotNull(rootBinExpr, "The root node type should be BoolBinExprNot");

            // the inner expr is an operand
            ExprFinalOperand exprOperandInner = rootBinExpr.ExprBase as ExprFinalOperand;
            Assert.IsNotNull(exprOperandInner, "The root node type should be BoolBinExprOperand");

            Assert.AreEqual("a", exprOperandInner.Operand, "The left operand should be a");
        }

        [TestMethod]
        public void OP_not_a_CP_ok()
        {
            string expr = "(not a)";
            List<ExprToken> listTokens = TestCommon.AddTokens("(", "not","a",")");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);
            // finished with no error
            Assert.AreEqual(0, result.ListError.Count, "The tokens (not a) should be decoded with success");

            // check the root node
            ExprLogicalNot rootBinExpr = result.RootExpr as ExprLogicalNot;
            Assert.IsNotNull(rootBinExpr, "The root node type should be a ExprLogicalNot");

            // the inner expr is an operand
            ExprFinalOperand exprOperandInner = rootBinExpr.ExprBase as ExprFinalOperand;
            Assert.IsNotNull(exprOperandInner, "The root node type should be BoolBinExprOperand");

            Assert.AreEqual("a", exprOperandInner.Operand, "The left operand should be a");
        }

        /// <summary>
        /// Should be ok.
        /// </summary>
        [TestMethod]
        public void OP_not_OP_a_and_CP_CP_ok()
        {
            string expr = "(not (a and b))";
            List<ExprToken> listTokens = TestCommon.AddTokens("(", "not", "(");
            TestCommon.AddTokens(listTokens, "a", "and","b");
            TestCommon.AddTokens(listTokens, ")", ")");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);
            // finished with no error
            Assert.AreEqual(0, result.ListError.Count, "The tokens (not a) should be decoded with success");

            // check the root node: Not expr
            ExprLogicalNot rootBinExpr = result.RootExpr as ExprLogicalNot;
            Assert.IsNotNull(rootBinExpr, "The root node type should be BoolBinExprNot");

            // the inner expr is a logical expr: (a and b)
            ExprLogical binExpr = rootBinExpr.ExprBase as ExprLogical;
            Assert.IsNotNull(binExpr, "The root node type should be BoolBinExpr");

            // a
            ExprFinalOperand exprOperandLeft = binExpr.ExprLeft as ExprFinalOperand;
            Assert.IsNotNull(exprOperandLeft, "The root node type should be BoolBinExprOperand");
            Assert.AreEqual("a", exprOperandLeft.Operand, "The left operand should be a");

            // b
            ExprFinalOperand exprOperandRight = binExpr.ExprRight as ExprFinalOperand;
            Assert.IsNotNull(exprOperandRight, "The root node type should be BoolBinExprOperand");
            Assert.AreEqual("b", exprOperandRight.Operand, "The right operand should be b");

            // check the operator
            Assert.AreEqual(OperatorLogicalCode.And, binExpr.Operator, "The operator should be and");
        }

        /// <summary>
        /// (ExprLeft AND/OR NOT ExprRight)
        ///
        /// (Operand AND NOT Operand)
        ///            BinExpr
        ///     L=Operand, R=Not Operand
        ///                     
        /// </summary>
        [TestMethod]
        public void OP_a_or_not_b_CP()
        {
            string expr = "(a or not b)";
            List<ExprToken> listTokens = TestCommon.AddTokens("(", "a", "or", "not", "b");
            TestCommon.AddTokens(listTokens, ")");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);
            // finished with no error
            Assert.AreEqual(0, result.ListError.Count, "The tokens (a and not b) should be decoded with success");

            // check the root node: bin expr
            ExprLogical binExpr = result.RootExpr as ExprLogical;
            Assert.IsNotNull(binExpr, "The root node type should be ExprLogical");

            // the left part is an operand: a
            ExprFinalOperand exprOperandLeft = binExpr.ExprLeft as ExprFinalOperand;
            Assert.IsNotNull(exprOperandLeft, "The root node type should be ExprFinalOperand");
            Assert.AreEqual("a", exprOperandLeft.Operand, "The left operand should be a");

            // the right part is a not expr
            ExprLogicalNot notExpr = binExpr.ExprRight as ExprLogicalNot;
            Assert.IsNotNull(notExpr, "The expr type should be ExprLogicalNot");

            // check the operator
            Assert.AreEqual(OperatorLogicalCode.Or, binExpr.Operator, "The operator should be or");

            // the inner expr in not expr is an operand
            ExprFinalOperand notExprInnerOperand = notExpr.ExprBase as ExprFinalOperand;
            Assert.IsNotNull(notExprInnerOperand, "The root node type should be ExprFinalOperand");
            Assert.AreEqual("b", notExprInnerOperand.Operand, "The not operand should be b");
        }

        /// <summary>
        /// (a or b) and not c
        ///
        ///  and
        ///     right: a or b
        ///     left:  not c
        /// </summary>
        [TestMethod]
        public void OP_a_or_b_CP_and_not_c()
        {
            string expr = "(a or b) and not c";
            List<ExprToken> listTokens = TestCommon.AddTokens("(", "a", "or", "b",")");
            TestCommon.AddTokens(listTokens, "and", "not", "c");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);
            // finished with no error
            Assert.AreEqual(0, result.ListError.Count, "The tokens (a and not b) should be decoded with success");

            // check the root node: bin expr
            ExprLogical binExpr = result.RootExpr as ExprLogical;
            Assert.IsNotNull(binExpr, "The root node type should be ExprLogical");
            // the operator is: and
            Assert.AreEqual(OperatorLogicalCode.And, binExpr.Operator, "The operator should be and");

            //----the left part is : (a or b)
            ExprLogical exprLeftLogical = binExpr.ExprLeft as ExprLogical;
            Assert.IsNotNull(exprLeftLogical, "The root node type should be exprLeftLogical");
            // the operator is: or
            Assert.AreEqual(OperatorLogicalCode.Or, exprLeftLogical.Operator, "The operator should be or");
            // a
            ExprFinalOperand exprLeftLogicalLeftOperand = exprLeftLogical.ExprLeft as ExprFinalOperand;
            Assert.AreEqual("a", exprLeftLogicalLeftOperand.Operand, "The left operand should be a");

            // b
            ExprFinalOperand exprLeftLogicalRightOperand = exprLeftLogical.ExprRight as ExprFinalOperand;
            Assert.AreEqual("b", exprLeftLogicalRightOperand.Operand, "The right operand should be b");


            //----the right part is: not(c)
            ExprLogicalNot notExpr = binExpr.ExprRight as ExprLogicalNot;
            Assert.IsNotNull(notExpr, "The expr type should be ExprLogicalNot");
            ExprFinalOperand notExprOperandFinal = notExpr.ExprBase as ExprFinalOperand;
            Assert.AreEqual("c", notExprOperandFinal.Operand, "The not operand should be c");

        }

        /// <summary>
        /// (a or b) and not(c)
        ///  same as the previous test:  (a or b) and not c
        ///  
        ///  and
        ///     right: a or b
        ///     left:  not c
        /// </summary>
        [TestMethod]
        public void OP_a_or_b_CP_and_not_OP_c_CP()
        {
            string expr = "(a or b) and not (c)";
            List<ExprToken> listTokens = TestCommon.AddTokens("(", "a", "or", "b", ")");
            TestCommon.AddTokens(listTokens, "and", "not", "(");
            TestCommon.AddTokens(listTokens, "c", ")");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);
            // finished with no error
            Assert.AreEqual(0, result.ListError.Count, "The tokens (a and not b) should be decoded with success");

            // check the root node: bin expr
            ExprLogical binExpr = result.RootExpr as ExprLogical;
            Assert.IsNotNull(binExpr, "The root node type should be ExprLogical");
            // the operator is: and
            Assert.AreEqual(OperatorLogicalCode.And, binExpr.Operator, "The operator should be and");

            //----the left part is : (a or b)
            ExprLogical exprLeftLogical = binExpr.ExprLeft as ExprLogical;
            Assert.IsNotNull(exprLeftLogical, "The root node type should be exprLeftLogical");
            // the operator is: or
            Assert.AreEqual(OperatorLogicalCode.Or, exprLeftLogical.Operator, "The operator should be or");
            // a
            ExprFinalOperand exprLeftLogicalLeftOperand = exprLeftLogical.ExprLeft as ExprFinalOperand;
            Assert.AreEqual("a", exprLeftLogicalLeftOperand.Operand, "The left operand should be a");

            // b
            ExprFinalOperand exprLeftLogicalRightOperand = exprLeftLogical.ExprRight as ExprFinalOperand;
            Assert.AreEqual("b", exprLeftLogicalRightOperand.Operand, "The right operand should be b");


            //----the right part is: not(c)
            ExprLogicalNot notExpr = binExpr.ExprRight as ExprLogicalNot;
            Assert.IsNotNull(notExpr, "The expr type should be ExprLogicalNot");
            ExprFinalOperand notExprOperandFinal = notExpr.ExprBase as ExprFinalOperand;
            Assert.AreEqual("c", notExprOperandFinal.Operand, "The not operand should be c");

        }


        /// <summary>
        /// (a or b) and not(c and d)
        ///  
        ///  Expr-AND
        ///     right: a or b
        ///     left:  Expr-NOT 
        ///                 Expr-AND
        ///                     right: c
        ///                     left:  d
        ///                 
        /// </summary>
        [TestMethod]
        public void OP_a_or_b_CP_and_not_OP_c_and_d_CP()
        {
            string expr = "(a or b) and not(c and d)";
            List<ExprToken> listTokens = TestCommon.AddTokens("(", "a", "or", "b", ")");
            TestCommon.AddTokens(listTokens, "and", "not", "(");
            TestCommon.AddTokens(listTokens, "c", "and", "d");
            TestCommon.AddTokens(listTokens, ")");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);
            // finished with no error
            Assert.AreEqual(0, result.ListError.Count, "The tokens (a and not b) should be decoded with success");

            // check the root node: bin expr
            ExprLogical binExpr = result.RootExpr as ExprLogical;
            Assert.IsNotNull(binExpr, "The root node type should be ExprLogical");
            // the operator is: and
            Assert.AreEqual(OperatorLogicalCode.And, binExpr.Operator, "The operator should be and");

            //----the left part is : (a or b)
            ExprLogical exprLeftLogical = binExpr.ExprLeft as ExprLogical;
            Assert.IsNotNull(exprLeftLogical, "The root node type should be exprLeftLogical");
            // the operator is: or
            Assert.AreEqual(OperatorLogicalCode.Or, exprLeftLogical.Operator, "The operator should be or");
            // a
            ExprFinalOperand exprLeftLogicalLeftOperand = exprLeftLogical.ExprLeft as ExprFinalOperand;
            Assert.AreEqual("a", exprLeftLogicalLeftOperand.Operand, "The left operand should be a");

            // b
            ExprFinalOperand exprLeftLogicalRightOperand = exprLeftLogical.ExprRight as ExprFinalOperand;
            Assert.AreEqual("b", exprLeftLogicalRightOperand.Operand, "The right operand should be b");


            //----the right part is: expr-NOT (c and d)
            ExprLogicalNot exprNOT = binExpr.ExprRight as ExprLogicalNot;
            Assert.IsNotNull(exprNOT, "The expr type should be ExprLogicalNot");

            // (c and d)
            ExprLogical exprNOT_exprAND = exprNOT.ExprBase as ExprLogical;
            Assert.IsNotNull(exprNOT_exprAND, "The node type should be exprNOT_exprAND");
            // the operator is: and
            Assert.AreEqual(OperatorLogicalCode.And, exprNOT_exprAND.Operator, "The operator should be and");
            // c, d
            // todo:

        }

    }
}
