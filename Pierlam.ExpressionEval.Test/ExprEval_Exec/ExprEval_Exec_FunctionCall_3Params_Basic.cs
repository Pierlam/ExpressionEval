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
    /// functionCall, with 2 basic params.
    /// </summary>
    [TestClass]
    public class ExprEval_Exec_FunctionCall_3Params_Basic
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

        public int FctP1Int_P2String_P3Double(int val, string s, double d)
        {
            return (int)(val + s.Length + d);
        }

        #endregion

        /// <summary>
        /// Test: bool fct(bool, bool, bool)
        /// return true.
        /// </summary>
        [TestMethod]
        public void fct_OP_false_Sep_false_CP_retBool_true_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "fct(true, true, true)";
            evaluator.Parse(expr);

            // link function body to function call
            var funcMapper = new Func3ParamsRetBoolMapper<bool, bool, bool>();
            funcMapper.SetFunction(Fct3ParamsBool);
            evaluator.AttachFunction("Fct", funcMapper);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value (is ExprExecFunctionCallBool override ExprExecValueBool)
            ExprExecValueBool valueBool = execResult.ExprExec as ExprExecValueBool;
            Assert.IsNotNull(execResult, "The result value should be a bool");
            Assert.AreEqual(true, valueBool.Value, "The result value should be: true");

        }

        /// <summary>
        /// Test: int fct(int, string, double)
        /// return true.
        /// </summary>
        [TestMethod]
        public void fct_OP_12_Sep_bonjour_8dot5_CP_retInt_21_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "fct(4, \"bonjour\", 8.5)";
            evaluator.Parse(expr);

            // link function body to function call
            var funcMapper = new Func3ParamsRetIntMapper<int, string, double>();
            funcMapper.SetFunction(FctP1Int_P2String_P3Double);
            evaluator.AttachFunction("Fct", funcMapper);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value (is ExprExecFunctionCallBool override ExprExecValueBool)
            ExprExecValueInt valueInt = execResult.ExprExec as ExprExecValueInt;
            Assert.IsNotNull(execResult, "The result value should be a bool");
            Assert.AreEqual(21, valueInt.Value, "The result value should be: 18");

        }

        // todo: tester autres types de parametres

    }
}
