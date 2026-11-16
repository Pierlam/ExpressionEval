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
    public class ExprEval_Exec_Basic
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

            string expr = "12";
            ParseResult parseResult = evaluator.Parse(expr);
            Assert.IsFalse(parseResult.HasError, "The parse of the expression should finish with success");

            //====execute l'expression booléenne
            ExecResult execResult = execResult = evaluator.Exec();
            Assert.IsFalse(execResult.HasError, "The init exec of the expression should failed");
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

            string expr = "12";
            ParseResult parseResult = evaluator.Parse(expr);
            Assert.IsFalse(parseResult.HasError, "The parse of the expression should finish with success");

            //====2/prepare the execution, provide all used variables: type and value

            //====3/execute l'expression booléenne
            ExecResult execResult  = evaluator.Exec();
            Assert.IsFalse(execResult.HasError, "The init exec of the expression should failed");
        }

        /// <summary>
        /// expression parse is missing.
        /// </summary>
        [TestMethod]
        public void ParseMissing_err()
        {
            ExpressionEval evaluator = new ExpressionEval();

            //====2/prepare the execution, provide all used variables: type and value

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.IsTrue(execResult.HasError, "The init exec of the expression should failed");
            Assert.AreEqual(ErrorCode.ParsedExpressionMissing, execResult.ListError[0].Code, "the error should be ParsedExpressionMissing");
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ParseFailed_ExecResultHasError()
        {
            ExpressionEval evaluator = new ExpressionEval();

            string expr = "a=";
            ParseResult parseResult = evaluator.Parse(expr);
            Assert.IsTrue(parseResult.HasError, "The parse of the expression should failed");
            Assert.AreEqual(ErrorCode.UnexpectedToken, parseResult.ListError[0].Code, "The code should be:UnexpectedToken"); 

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.IsTrue(execResult.HasError, "The init exec of the expression should failed");
            //Assert.AreEqual(ErrorCode.ParsedExpressionHasError, execResult.ListError[0].Code, "the error should be ParsedExpressionMissing");
            Assert.AreEqual(ErrorCode.UnexpectedToken, execResult.ListError[0].Code, "The code should be:UnexpectedToken, same as Parse error"); 

        }


    }
}
