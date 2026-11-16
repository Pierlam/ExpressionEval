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
    /// functionCall, with one simple param.
    /// </summary>
    [TestClass]
    public class ExprEval_Exec_FunctionCall_OneParam_Basic
    {
        #region Functions linked to functionCal
        /// <summary>
        /// Function linked to a functionCall in the expressionEval component.
        /// </summary>
        /// <returns></returns>
        public bool FctRetBool_P1Bool(bool val)
        {
            return !val;
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

        /// <summary>
        /// Function linked to a functionCall in the expressionEval component.
        /// </summary>
        /// <returns></returns>
        public double FctDouble_String(string s)
        {
            return s.Length * 1.5;
        }

        /// <summary>
        /// Function linked to a functionCall in the expressionEval component.
        /// </summary>
        /// <returns></returns>
        public string FctString_String(string s)
        {
            return s +"10";
        }
        #endregion

        /// <summary>
        /// </summary>
        [TestMethod]
        public void fct_OP_false_CP_retBool_true_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "fct(false)";
            ParseResult parseResult = evaluator.Parse(expr);

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();
            
            // link function body to function call
            evaluator.AttachFunction("Fct", FctRetBool_P1Bool);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value (is ExprExecFunctionCallBool override ExprExecValueBool)
            ExprExecValueBool valueBool = execResult.ExprExec as ExprExecValueBool;
            Assert.IsNotNull(execResult, "The result value should be a bool");
            Assert.AreEqual(true, valueBool.Value, "The result value should be: true");

        }

        /// <summary>
        /// bool Fct(12) est > 10, renvoie true.
        /// </summary>
        [TestMethod]
        public void fct_OP_12_CP_retBool_true_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "fct(12)";
            ParseResult parseResult = evaluator.Parse(expr);

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            // link function body to function call
            evaluator.AttachFunction("Fct", FctInt);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value (is ExprExecFunctionCallBool override ExprExecValueBool)
            ExprExecValueBool valueBool = execResult.ExprExec as ExprExecValueBool;
            Assert.IsNotNull(execResult, "The result value should be a bool");
            Assert.AreEqual(true, valueBool.Value, "The result value should be: true");
        }

        /// <summary>
        /// bool Fct(8) est <= 10, renvoie false.
        /// bool Fct(12) est > 10, renvoie true.
        /// </summary>
        [TestMethod]
        public void fct_OP_8_CP_retBool_false_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "fct(8)";
            ParseResult parseResult = evaluator.Parse(expr);

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            // link function body to function call
            evaluator.AttachFunction("Fct", FctInt);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value (is ExprExecFunctionCallBool override ExprExecValueBool)
            ExprExecValueBool valueBool = execResult.ExprExec as ExprExecValueBool;
            Assert.IsNotNull(execResult, "The result value should be a bool");
            Assert.AreEqual(false, valueBool.Value, "The result value should be: false");
        }

        /// <summary>
        /// bool Fct(8) est <= 10, renvoie false.
        /// bool Fct(12) est > 10, renvoie true.
        /// </summary>
        [TestMethod]
        public void fct_OP_a_CP_retBool_false_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "fct(a)";
            ParseResult parseResult = evaluator.Parse(expr);

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            evaluator.DefineVarInt("a", 23);

            // link function body to function call
            evaluator.AttachFunction("Fct", FctInt);

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
        public void fct_OP_a_CP_retString_P1String_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "fct(a)";
            ParseResult parseResult = evaluator.Parse(expr);

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            evaluator.DefineVarString("a", "azerty");

            // link function body to function call
            evaluator.AttachFunction("Fct", FctString_String);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value (is ExprExecFunctionCallString override ExprExecValueString)
            ExprExecValueString valueString = execResult.ExprExec as ExprExecValueString;
            Assert.IsNotNull(valueString, "The result value should be a string");
            Assert.AreEqual("azerty10", valueString.Value, "The result value should be: true");
        }

        /// <summary>
        /// </summary>
        [TestMethod]
        public void fct_OP_a_CP_retDouble_P1String_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "fct(a)";
            ParseResult parseResult = evaluator.Parse(expr);

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            // 3 letters -> return 3x1.5=4.5
            evaluator.DefineVarString("a", "abc");

            // link function body to function call
            evaluator.AttachFunction("Fct", FctDouble_String);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value (is ExprExecFunctionCallBool override ExprExecValueBool)
            ExprExecValueDouble valueDouble = execResult.ExprExec as ExprExecValueDouble;
            Assert.IsNotNull(valueDouble, "The result value should be a double");
            Assert.AreEqual(4.5, valueDouble.Value, "The result value should be: true");
        }

        /// <summary>
        /// one type parameter is wrong.
        /// </summary>
        [TestMethod]
        public void fct_OP_12_CP_retBool_paramWrong_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "fct(12)";
            ParseResult parseResult = evaluator.Parse(expr);

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            // link function body to function call
            evaluator.AttachFunction("fct", FctRetBool_P1Bool);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(true, execResult.HasError, "The exec of the expression should finish with success");

            Assert.AreEqual(ErrorCode.FunctionCallParamTypeWrong, execResult.ListError[0].Code, "The exec of the expression should finish with success");
            Assert.AreEqual("FunctionCallName", execResult.ListError[0].ListErrorParam[0].Key, "The exec of the expression should finish with success");
            Assert.AreEqual("fct", execResult.ListError[0].ListErrorParam[0].Value, "The exec of the expression should finish with success");

        }

        /// <summary>
        /// the parameter is missing.
        /// </summary>
        [TestMethod]
        public void fct_OP_CP_retBool_paramMissing_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "fct()";
            ParseResult parseResult = evaluator.Parse(expr);

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            // link function body to function call
            evaluator.AttachFunction("fct", FctRetBool_P1Bool);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.IsTrue(execResult.HasError, "The exec of the expression should finish with error");

            Assert.AreEqual(ErrorCode.FunctionCallParamCountWrong, execResult.ListError[0].Code, "The exec of the expression should finish with success");
            Assert.AreEqual("FunctionCallName", execResult.ListError[0].ListErrorParam[0].Key, "The exec of the expression should finish with success");
            Assert.AreEqual("fct", execResult.ListError[0].ListErrorParam[0].Value, "The exec of the expression should finish with success");

        }

        //    tester:	
        // bool fct(string)    const
        // bool fct(double)	    const

        // tester Fct(12) mais sur Fct() , pas de parametre.
    }
}
