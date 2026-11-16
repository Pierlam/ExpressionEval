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
    /// functionCall, with Three basic params.
    /// </summary>
    [TestClass]
    public class ExprEval_Exec_FunctionCall_ThreeParams_Basic
    {
        #region Functions linked to functionCal
        /// <summary>
        /// Function linked to a functionCall in the expressionEval component.
        /// </summary>
        /// <returns></returns>
        public bool Fct3ParamsBool(bool val, bool val2, bool val3)
        {
            return val && val2 && val3;
        }

        /// <summary>
        /// Function linked to a functionCall in the expressionEval component.
        /// </summary>
        /// <returns></returns>
        public bool Fct2ParamsBool(bool val, bool val2)
        {
            return val && val2;
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
        public void fct_OP_true_Sep_true_Sep_true_CP_retBool_true_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "Fct(true, true, true)";
            evaluator.Parse(expr);

            // link function body to function call
            Func3ParamsRetBoolMapper<bool, bool, bool> func3ParamsRetBoolMapper = new Pierlam.ExpressionEval.Func3ParamsRetBoolMapper<bool, bool, bool>();
            func3ParamsRetBoolMapper.SetFunction(Fct3ParamsBool);
            evaluator.AttachFunction("Fct", func3ParamsRetBoolMapper);

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
        public void fct_OP_true_Sep_true_Sep_false_CP_retBool_true_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "Fct(true, true, false)";
            evaluator.Parse(expr);

            // link function body to function call
            Func3ParamsRetBoolMapper<bool, bool, bool> func3ParamsRetBoolMapper = new Pierlam.ExpressionEval.Func3ParamsRetBoolMapper<bool, bool, bool>();
            func3ParamsRetBoolMapper.SetFunction(Fct3ParamsBool);
            evaluator.AttachFunction("Fct", func3ParamsRetBoolMapper);

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
        public void fct_3Params_FirstIsWrong_err()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "fct(12, true, false)";
            evaluator.Parse(expr);

            // link function body to function call
            Func3ParamsRetBoolMapper<bool, bool, bool> func3ParamsRetBoolMapper = new Pierlam.ExpressionEval.Func3ParamsRetBoolMapper<bool, bool, bool>();
            func3ParamsRetBoolMapper.SetFunction(Fct3ParamsBool);
            evaluator.AttachFunction("fct", func3ParamsRetBoolMapper);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.IsTrue(execResult.HasError, "The exec of the expression should finish with error");

            Assert.AreEqual(ErrorCode.FunctionCallParamTypeWrong, execResult.ListError[0].Code, "The exec of the expression should finish with success");
            Assert.AreEqual("FunctionCallName", execResult.ListError[0].ListErrorParam[0].Key, "The exec of the expression should finish with success");
            Assert.AreEqual("fct", execResult.ListError[0].ListErrorParam[0].Value, "The exec of the expression should finish with success");
        }

        /// <summary>
        /// param function call one missing
        /// </summary>
        [TestMethod]
        public void fct_3Params_FunctionCall_OneMissing_err()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "fct(true, true)";
            evaluator.Parse(expr);

            // link function body to function call
            Func3ParamsRetBoolMapper<bool, bool, bool> func3ParamsRetBoolMapper = new Pierlam.ExpressionEval.Func3ParamsRetBoolMapper<bool, bool, bool>();
            func3ParamsRetBoolMapper.SetFunction(Fct3ParamsBool);
            evaluator.AttachFunction("fct", func3ParamsRetBoolMapper);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.IsTrue(execResult.HasError, "The exec of the expression should finish with error");

            Assert.AreEqual(ErrorCode.FunctionCallParamCountWrong, execResult.ListError[0].Code, "The exec of the expression should finish with success");
            Assert.AreEqual("FunctionCallName", execResult.ListError[0].ListErrorParam[0].Key, "The exec of the expression should finish with success");
            Assert.AreEqual("fct", execResult.ListError[0].ListErrorParam[0].Value, "The exec of the expression should finish with success");
        }

        /// <summary>
        /// param function Code attached one missing
        /// </summary>
        [TestMethod]
        public void fct_3Params_FunctionCode_OneMissing_err()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "fct(true, true, true)";
            evaluator.Parse(expr);

            // link function body to function call
            evaluator.AttachFunction("fct", Fct2ParamsBool);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.IsTrue(execResult.HasError, "The exec of the expression should finish with error");

            Assert.AreEqual(ErrorCode.FunctionCallParamCountWrong, execResult.ListError[0].Code, "The exec of the expression should finish with success");
            Assert.AreEqual("FunctionCallName", execResult.ListError[0].ListErrorParam[0].Key, "The exec of the expression should finish with success");
            Assert.AreEqual("fct", execResult.ListError[0].ListErrorParam[0].Value, "The exec of the expression should finish with success");
        }

        // todo: tester autres fct 3 params: autres types: int, string, double,...
    }
}
