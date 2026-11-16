using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pierlam.ExpressionEval.Test.ExprEval_Exec
{
    /// <summary>
    /// Test execution, from the start to the end.
    /// functionCall basic. No param.
    /// </summary>
    [TestClass]
    public class ExprEval_Exec_FunctionCall_Basic
    {
        #region Functions linked to functionCal
        /// <summary>
        /// Function linked to a functionCall in the expressionEval component.
        /// </summary>
        /// <returns></returns>
        public bool Fct()
        {
            return true;
        }

        /// <summary>
        /// Function linked to a functionCall in the expressionEval component.
        /// </summary>
        /// <returns></returns>
        public bool FctFalse()
        {
            return false;
        }

        #endregion


        [TestMethod]
        public void fct_OP_CP_retBool_true_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "fct()";
            ParseResult parseResult = evaluator.Parse(expr);

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            // link function body to function call
            evaluator.AttachFunction("Fct", Fct);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value (is ExprExecFunctionCallBool override ExprExecValueBool)
            ExprExecValueBool valueBool = execResult.ExprExec as ExprExecValueBool;
            Assert.IsNotNull(execResult, "The result value should be a bool");
            Assert.AreEqual(true, valueBool.Value, "The result value should be: true");

        }

        [TestMethod]
        public void fct_OP_CP_retBool_false_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "fct()";
            ParseResult parseResult = evaluator.Parse(expr);

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            // attach the function code FctFalse() to the function call: Fct()
            evaluator.AttachFunction("Fct", FctFalse);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value (is ExprExecFunctionCallBool override ExprExecValueBool)
            ExprExecValueBool valueBool = execResult.ExprExec as ExprExecValueBool;
            Assert.IsNotNull(execResult, "The result value should be a bool");
            Assert.AreEqual(false, valueBool.Value, "The result value should be: false");
        }

        /// <summary>
        /// Not attached/linked function code to a functionCall.
        /// </summary>
        [TestMethod]
        public void fct_OP_CP_NotAttachedFunc_err()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "fct()";
            ParseResult parseResult = evaluator.Parse(expr);

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            // link the function code FctFalse() to the function call: Fct()
            //evaluator.AddFunction("Fct", FctFalse);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            // an error occurs
            Assert.IsTrue(execResult.HasError, "The exec of the expression should failed");

            Assert.AreEqual(ErrorCode.FunctionCallNotLinked, execResult.ListError[0].Code, "The error code should be xx");
        }

        /// <summary>
        // tester, mauvais link (nom functionCall inconnue!!)
        // gestion erreur AddFunction(), renvoie juste false!!
        /// </summary>
        [TestMethod]
        public void fct_OP_CP_FuncCallNotExists_err()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "fct()";
            ParseResult parseResult = evaluator.Parse(expr);

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            // link the function code FctFalse() to the function call: Fct()
            evaluator.AttachFunction("FctDoesnotExist", FctFalse);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            // an error occurs
            Assert.IsTrue(execResult.HasError, "The exec of the expression should failed");

            Assert.AreEqual(ErrorCode.FunctionCallNotLinked, execResult.ListError[0].Code, "The error code should be xx");
        }

        // AddFunction erroné -> 

        // tester ret int, string et double.

    }
}
