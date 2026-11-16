using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pierlam.ExpressionEval.Test.ExprEval_Exec
{
    /// <summary>
    /// Test execution, from the start to the end.
    /// ExprEval_Exec_Var_Basic.
    /// </summary>
    [TestClass]
    public class ExprEval_Exec_Var_Basic
    {
        /// <summary>
        /// standard case
        /// parse ok
        /// InitExec
        /// Exec
        /// </summary>
        [TestMethod]
        public void ParseOk_InitExec_Exec_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            string expr = "a";
            ParseResult parseResult = evaluator.Parse(expr);
            Assert.IsFalse(parseResult.HasError, "The parse of the expression should finish with success");

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();
            //Assert.IsFalse(execResult.HasError, "The parse of the expression should finish with success");

            //=====2.1/Init var
            evaluator.DefineVarBool("a", true);

            //====3/execute l'expression booléenne
            ExecResult execResult = execResult = evaluator.Exec();
            Assert.IsFalse(execResult.HasError, "The init exec of the expression should failed");
            Assert.IsTrue(execResult.IsResultBool, "The exec result be a bool");
            Assert.IsTrue(execResult.ResultBool, "The exec result be true");

        }

        /// <summary>
        /// standard case
        /// parse ok
        /// InitExec
        /// Exec
        /// </summary>
        [TestMethod]
        public void ParseOk_InitExec_Exec_InitExec2_Exec2_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            string expr = "a";
            ParseResult parseResult = evaluator.Parse(expr);
            Assert.IsFalse(parseResult.HasError, "The parse of the expression should finish with success");

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();
            //Assert.IsFalse(execResult.HasError, "The parse of the expression should finish with success");

            //=====2.1/Init var
            evaluator.DefineVarBool("a", true);

            //====3/execute l'expression booléenne
            ExecResult execResult =  evaluator.Exec();
            Assert.IsFalse(execResult.HasError, "The init exec of the expression should failed");
            Assert.IsTrue(execResult.IsResultBool, "The exec result be a bool");
            Assert.IsTrue(execResult.ResultBool, "The exec result be true");

            //====4/prepare the execution, provide all used variables: type and value
            //execResult = evaluator.InitExec();
            Assert.IsFalse(execResult.HasError, "The parse of the expression should finish with success");

            //=====2.1/Init var
            evaluator.DefineVarInt("a", 14);

            //====3/execute l'expression booléenne
            execResult = evaluator.Exec();
            Assert.IsFalse(execResult.HasError, "The init exec of the expression should failed");
            Assert.IsTrue(execResult.IsResultInt, "The exec result be an int");
            Assert.AreEqual(14, execResult.ResultInt, "The exec result be 14");

            //====5/execute l'expression booléenne
            execResult = evaluator.Exec();
            Assert.IsFalse(execResult.HasError, "The init exec of the expression should failed");

        }

        /// <summary>
        /// DefineVar missing
        /// </summary>
        [TestMethod]
        public void ParseOk__DefVarMissing_InitExec_Exec_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            string expr = "a";
            ParseResult parseResult = evaluator.Parse(expr);
            Assert.IsFalse(parseResult.HasError, "The parse of the expression should finish with success");

            //====execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.IsTrue(execResult.HasError, "The init exec of the expression should failed");
            Assert.AreEqual(ErrorCode.VariableNotDefined, execResult.ListError[0].Code, "the error should be VariableNotCreated");
        }

        /// <summary>
        // DefineVar wrong
        /// </summary>
        [TestMethod]
        public void DefineVarIsNull_err()
        {
            ExpressionEval evaluator = new ExpressionEval();

            string expr = "a";
            ParseResult parseResult = evaluator.Parse(expr);
            Assert.IsFalse(parseResult.HasError, "The parse of the expression should finish with success");

            //====2/prepare the execution, provide all used variables: type and value
            //====2.1/Init var
            evaluator.DefineVarBool(null, true);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.IsTrue(execResult.HasError, "The init exec of the expression should failed");
            Assert.AreEqual(ErrorCode.VariableNotDefined, execResult.ListError[0].Code, "the error should be ParsedExpressionMissing");
        }

        /// <summary>
        // DefineVar wrong
        /// </summary>
        [TestMethod]
        public void DefineVarFirstCharIsWrong_err()
        {
            ExpressionEval evaluator = new ExpressionEval();

            string expr = "a";
            ParseResult parseResult = evaluator.Parse(expr);
            Assert.IsFalse(parseResult.HasError, "The parse of the expression should finish with success");

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();
            //Assert.IsFalse(execResult.HasError, "The parse of the expression should finish with success");

            //=====2.1/Init var
            evaluator.DefineVarBool("0a", true);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.IsTrue(execResult.HasError, "The init exec of the expression should failed");
            Assert.AreEqual(ErrorCode.VariableNotDefined, execResult.ListError[0].Code, "the error should be ParsedExpressionMissing");
        }

        /// <summary>
        // DefineVar wrong
        /// </summary>
        [TestMethod]
        public void DefineVarCharIsWrong_err()
        {
            ExpressionEval evaluator = new ExpressionEval();

            string expr = "a";
            ParseResult parseResult = evaluator.Parse(expr);
            Assert.IsFalse(parseResult.HasError, "The parse of the expression should finish with success");

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();
            //Assert.IsFalse(execResult.HasError, "The parse of the expression should finish with success");

            //=====2.1/Init var
            evaluator.DefineVarBool("a#b", true);
            // todo: check the ret value, false

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.IsTrue(execResult.HasError, "The init exec of the expression should failed");
            Assert.AreEqual(ErrorCode.VariableNotDefined, execResult.ListError[0].Code, "the error should be ParsedExpressionMissing");
        }

    }
}
