using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pierlam.ExpressionEval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Pierlam.ExpressionEval.Test.ExprEval_Exec
{
    [TestClass]
    public class ExprEval_Exec_ExprLogical_And
    {
        /// <summary>
        /// a and b
        /// </summary>
        [TestMethod]
        public void Double_a_and_b_true_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            //evaluator.SetDoubleDecimalSeparator(ExpressionEvalDef.DoubleDecimalSeparator.Dot);

            string expr = "a and b";
            ParseResult parseResult = evaluator.Parse(expr);

            Assert.IsFalse(parseResult.HasError, "the parse should finish successfully");

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            evaluator.DefineVarBool("a", true);
            evaluator.DefineVarBool("b", true);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            Assert.IsTrue(execResult.IsResultBool, "The result should be a bool");
            Assert.IsTrue(execResult.ResultBool, "The result value should be true");
        }

        /// <summary>
        /// a and b
        /// </summary>
        [TestMethod]
        public void Double_a_and_b_false_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            //evaluator.SetDoubleDecimalSeparator(ExpressionEvalDef.DoubleDecimalSeparator.Dot);

            string expr = "a and b";
            ParseResult parseResult = evaluator.Parse(expr);

            Assert.IsFalse(parseResult.HasError, "the parse should finish successfully");

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            evaluator.DefineVarBool("a", false);
            evaluator.DefineVarBool("b", true);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            Assert.IsTrue(execResult.IsResultBool, "The result should be a bool");
            Assert.IsFalse(execResult.ResultBool, "The result value should be false");
        }

        /// <summary>
        /// (a and b)
        /// </summary>
        [TestMethod]
        public void Double_OP_a_and_b_CP_true_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            //evaluator.SetDoubleDecimalSeparator(ExpressionEvalDef.DoubleDecimalSeparator.Dot);

            string expr = "(a and b)";
            ParseResult parseResult = evaluator.Parse(expr);

            Assert.IsFalse(parseResult.HasError, "the parse should finish successfully");

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            evaluator.DefineVarBool("a", true);
            evaluator.DefineVarBool("b", true);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            Assert.IsTrue(execResult.IsResultBool, "The result should be a bool");
            Assert.IsTrue(execResult.ResultBool, "The result value should be true");
        }

        /// <summary>
        /// a and b
        /// </summary>
        [TestMethod]
        public void Double_and_OneVarTypeWrong_err()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            //evaluator.SetDoubleDecimalSeparator(ExpressionEvalDef.DoubleDecimalSeparator.Dot);

            string expr = "a and b";
            ParseResult parseResult = evaluator.Parse(expr);

            Assert.IsFalse(parseResult.HasError, "the parse should finish successfully");

            //====2/prepare the execution, provide all used variables: type and value
            evaluator.DefineVarInt("a", 12);
            evaluator.DefineVarBool("b", true);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.IsTrue(execResult.HasError, "The exec of the expression should finish with error");

            // todo: pas bon!! corriger
            Assert.AreEqual(ErrorCode.ExprLogicalOperandTypeNotAllowed, execResult.ListError[0].Code, "The exec of the expression should finish with success");
        }
    }
}
