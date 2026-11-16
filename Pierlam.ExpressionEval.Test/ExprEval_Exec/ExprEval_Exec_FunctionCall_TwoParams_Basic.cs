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
    /// functionCall, with two basic params.
    /// </summary>
    [TestClass]
    public class ExprEval_Exec_FunctionCall_TwoParams_Basic
    {
        #region Functions linked to functionCal
        /// <summary>
        /// Function linked to a functionCall in the expressionEval component.
        /// </summary>
        /// <returns></returns>
        public bool Fct2ParamsBool(bool val, bool val2)
        {
            return val&val2;
        }

        public bool FctP1Int_P2String(int val, string s)
        {
            if (val > 9 && s.Length > 2) return true;

            return false;
        }

        /// <summary>
        /// Function linked to a functionCall in the expressionEval component.
        /// </summary>
        /// <returns></returns>
        public bool FctFalse()
        {
            return false;
        }

        /// <summary>
        /// Function linked to a functionCall in the expressionEval component.
        /// </summary>
        /// <returns></returns>
        public bool FctInt(int v)
        {
            if (v > 10)
                return true;
            else
                return false;
        }

        #endregion

        /// <summary>
        /// </summary>
        [TestMethod]
        public void fct_OP_false_Sep_false_CP_retBool_true_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "fct(true, true)";
            evaluator.Parse(expr);

            // link function body to function call
            evaluator.AttachFunction("Fct", Fct2ParamsBool);

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
        public void fct_OP_10_Sep_bonjour_CP_retBool_true_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);
            evaluator.SetStringTagCode(StringTagCode.Quote);

            string expr = "fct(10, 'bonjour')";
            evaluator.Parse(expr);

            // link function body to function call
            evaluator.AttachFunction("Fct", FctP1Int_P2String);

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
        public void functionCall_oneParamMissing_err()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);
            evaluator.SetStringTagCode(StringTagCode.Quote);

            // the fct expect 2 params!
            string expr = "fct(10)";
            evaluator.Parse(expr);

            // link function body to function call
            evaluator.AttachFunction("Fct", FctP1Int_P2String);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.IsTrue(execResult.HasError, "The exec of the expression should finish with error");

            Assert.AreEqual(ErrorCode.FunctionCallParamCountWrong, execResult.ListError[0].Code, "The exec of the expression should finish with error");
        }

        /// <summary>
        /// </summary>
        [TestMethod]
        public void functionCall_TooManyParams_err()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);
            evaluator.SetStringTagCode(StringTagCode.Quote);

            string expr = "fct(10,12)";
            evaluator.Parse(expr);

            // link function body to function call
            evaluator.AttachFunction("Fct", FctInt);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.IsTrue(execResult.HasError, "The exec of the expression should finish with error");

            Assert.AreEqual(ErrorCode.FunctionCallParamCountWrong, execResult.ListError[0].Code, "The exec of the expression should finish with error");
        }

        /// <summary>
        /// </summary>
        [TestMethod]
        public void functionCall_paramTypeWrong_err()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);
            evaluator.SetStringTagCode(StringTagCode.Quote);

            string expr = "fct('bonjour')";
            evaluator.Parse(expr);

            // link function body to function call
            evaluator.AttachFunction("Fct", FctInt);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.IsTrue(execResult.HasError, "The exec of the expression should finish with error");

            Assert.AreEqual(ErrorCode.FunctionCallParamTypeWrong, execResult.ListError[0].Code, "The exec of the expression should finish with error");
        }

    }
}
