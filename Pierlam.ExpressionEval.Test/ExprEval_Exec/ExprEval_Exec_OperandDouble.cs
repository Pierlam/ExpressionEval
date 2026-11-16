using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pierlam.ExpressionEval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pierlam.ExpressionEval.Test.ExprEval_Exec
{
    [TestClass]
    public class ExprEval_Exec_OperandDouble
    {
        [TestMethod]
        public void Double_SepIsDot_true()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            //evaluator.SetDoubleDecimalSeparator(ExpressionEvalDef.DoubleDecimalSeparator.Dot);

            string expr = "(a = 12.45)";
            ParseResult parseResult = evaluator.Parse(expr);

            Assert.IsFalse(parseResult.HasError, "the parse should finish successfully");

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            evaluator.DefineVarDouble("a", 12.45);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            Assert.IsTrue(execResult.ResultBool, "The result value should be true");
        }


        [TestMethod]
        public void Double_SepIsDot_false()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            //evaluator.SetDoubleDecimalSeparator(ExpressionEvalDef.DoubleDecimalSeparator.Dot);

            string expr = "(a = 12.45)";
            ParseResult parseResult = evaluator.Parse(expr);

            Assert.IsFalse(parseResult.HasError, "the parse should finish successfully");

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            evaluator.DefineVarDouble("a", 15.56);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            Assert.IsFalse(execResult.ResultBool, "The result value should be false");
        }

        [TestMethod]
        public void Double_Exposant_SepIsDot_true()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            //evaluator.SetDoubleDecimalSeparator(ExpressionEvalDef.DoubleDecimalSeparator.Dot);

            string expr = "(a = 12.45E3)";
            ParseResult parseResult = evaluator.Parse(expr);

            Assert.IsFalse(parseResult.HasError, "the parse should finish successfully");

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            evaluator.DefineVarDouble("a", 12.45E3);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            Assert.IsTrue(execResult.ResultBool, "The result value should be true");
        }

        [TestMethod]
        public void Double_Exposant_SepIsDot_false()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            //evaluator.SetDoubleDecimalSeparator(ExpressionEvalDef.DoubleDecimalSeparator.Dot);

            string expr = "(a = 12.45E3)";
            ParseResult parseResult = evaluator.Parse(expr);

            Assert.IsFalse(parseResult.HasError, "the parse should finish successfully");

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            evaluator.DefineVarDouble("a", 1345);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            Assert.IsFalse(execResult.ResultBool, "The result value should be false");
        }

        [TestMethod]
        public void Double_SepIsComma_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            evaluator.SetDecimalAndFunctionSeparators(DecimalAndFunctionSeparators.ExcelLike);

            string expr = "12,45";
            ParseResult parseResult = evaluator.Parse(expr);

            Assert.IsFalse(parseResult.HasError, "the parse should finish with success");

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            Assert.IsTrue(execResult.IsResultDouble, "The result value should be a double");
            Assert.AreEqual(12.45, execResult.ResultDouble, "The result value should be 12.45");
        }

        /// <summary>
        /// dot is expected.
        /// </summary>
        [TestMethod]
        public void Double_SepIsComma_err()
        {
            ExpressionEval evaluator = new ExpressionEval();

            //evaluator.SetDoubleAndFunctionCallParameterSeparator(ExpressionEvalDef.DoubleAndFunctionCallParameterSeparator.ExcelLike);

            string expr = "12,45";
            ParseResult parseResult = evaluator.Parse(expr);

            Assert.IsTrue(parseResult.HasError, "the parse should failed");

            // todo: pour l'instant!! car traitement des appels de fct pas encore traité!
            Assert.AreEqual(ErrorCode.WrongExpression, parseResult.ListError[0].Code, "the parse should failed: ValueNumberBadFormed");

        }

        //[TestMethod]
        //public void Double_SepIsDot_err()
        //{
        //    ExpressionEval evaluator = new ExpressionEval();

        //    // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
        //    evaluator.SetLang(ExpressionEvalDef.Lang.En);

        //    //evaluator.SetDoubleDecimalSeparator(ExpressionEvalDef.DoubleDecimalSeparator.Dot);

        //    string expr = "(a = 12,45)";
        //    ExprParseResult parseResult = evaluator.Parse(expr);

        //    Assert.IsTrue(parseResult.HasError, "the parse should failed");

        //    Assert.AreEqual(ParseErrorCode.UnexpectedToken, parseResult.ListError[0].ErrCode, "the parse should failed: UnexpectedToken");

        //}
    }
}
