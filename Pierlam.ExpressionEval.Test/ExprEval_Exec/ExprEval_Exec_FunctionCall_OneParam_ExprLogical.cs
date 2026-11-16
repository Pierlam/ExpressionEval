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
    /// functionCall, with one param: expr logical
    /// Exp: fct(a and b)
    /// </summary>
    [TestClass]
    public class ExprEval_Exec_FunctionCall_OneParam_ExprLogical
    {
        #region Functions linked to functionCal
        /// <summary>
        /// Function linked to a functionCall in the expressionEval component.
        /// </summary>
        /// <returns></returns>
        public bool Fct(bool val)
        {
            return !val;
        }
        #endregion

        /// <summary>
        /// </summary>
        [TestMethod]
        public void fct_OP_a_and_b_CP_retBool_true_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "fct(a and b)";
            ParseResult parseResult = evaluator.Parse(expr);

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            evaluator.DefineVarBool("a", true);
            evaluator.DefineVarBool("b", false);

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

        /// <summary>
        /// </summary>
        [TestMethod]
        public void fct_OP_a_and_b_CP_retBool_false_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "fct(a and b)";
            ParseResult parseResult = evaluator.Parse(expr);

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            evaluator.DefineVarBool("a", true);
            evaluator.DefineVarBool("b", true);

            // link function body to function call
            evaluator.AttachFunction("Fct", Fct);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value (is ExprExecFunctionCallBool override ExprExecValueBool)
            ExprExecValueBool valueBool = execResult.ExprExec as ExprExecValueBool;
            Assert.IsNotNull(execResult, "The result value should be a bool");
            Assert.AreEqual(false, valueBool.Value, "The result value should be: false");

        }

        /// <summary>
        /// </summary>
        [TestMethod]
        public void fct_OP_OP_a_and_b_CP_CP_retBool_false_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "fct((a and b))";
            ParseResult parseResult = evaluator.Parse(expr);

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            evaluator.DefineVarBool("a", true);
            evaluator.DefineVarBool("b", true);

            // link function body to function call
            evaluator.AttachFunction("Fct", Fct);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value (is ExprExecFunctionCallBool override ExprExecValueBool)
            ExprExecValueBool valueBool = execResult.ExprExec as ExprExecValueBool;
            Assert.IsNotNull(execResult, "The result value should be a bool");
            Assert.AreEqual(false, valueBool.Value, "The result value should be: false");

        }

        /// <summary>
        /// </summary>
        [TestMethod]
        public void fct_OP_OP_a_and_b_CP_CP_retBool_true_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "fct((a and b))";
            ParseResult parseResult = evaluator.Parse(expr);

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            evaluator.DefineVarBool("a", true);
            evaluator.DefineVarBool("b", false);

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

    }
}
