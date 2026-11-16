using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pierlam.ExpressionEval.Test.ExprEval_Exec
{
    /// <summary>
    /// Basics Test on calculation expressions.
    /// exp (a+12), 12-b,...
    /// 
    /// 12+3     
    /// 12+3+5	 
    /// 2*3  	 
    /// 2*3*4	 
    /// 2*4/3	 
    /// 2*3+4	 
    /// 4+5*6	 
    /// 2+3*4+5	 
    /// </summary>
    [TestClass]
    public class ExprEval_Exec_ExprCalculation_Basic
    {
        /// <summary>
        /// 12+3
        /// =15
        /// </summary>
        [TestMethod]
        public void Exec_12_Plus_3_Ret_15_Ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "12+3";
            ParseResult parseResult = evaluator.Parse(expr);

            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            ExprExecValueInt valueInt = execResult.ExprExec as ExprExecValueInt;
            Assert.IsNotNull(valueInt, "The result value should be an int");
            Assert.AreEqual(15, valueInt.Value, "The result value should be: 15");

        }

        [TestMethod]
        public void Exec_26dot5_Plus_4_Ret_30dot5_Ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "26.5+4";
            ParseResult parseResult = evaluator.Parse(expr);

            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            ExprExecValueDouble valueDouble = execResult.ExprExec as ExprExecValueDouble;
            Assert.IsNotNull(valueDouble, "The result value should be a bool");
            Assert.AreEqual(30.5, valueDouble.Value, "The result value should be: 30.5");

        }

        [TestMethod]
        public void Exec_13_Minus_8_Ret_5_Ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "13-8";
            ParseResult parseResult = evaluator.Parse(expr);

            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            ExprExecValueInt valueInt = execResult.ExprExec as ExprExecValueInt;
            Assert.IsNotNull(valueInt, "The result value should be a bool");
            Assert.AreEqual(5, valueInt.Value, "The result value should be: 5");

        }

        [TestMethod]
        public void Exec_Minus_4_Minus_6_Ret_Minus_10_Ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "-4-6";
            ParseResult parseResult = evaluator.Parse(expr);

            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            ExprExecValueInt valueInt = execResult.ExprExec as ExprExecValueInt;
            Assert.IsNotNull(valueInt, "The result value should be a bool");
            Assert.AreEqual(-10, valueInt.Value, "The result value should be: -10");

        }

        /// <summary>
        /// 2*4
        /// =8
        /// </summary>
        [TestMethod]
        public void Exec_2_Mul_4_Ret_8_Ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "2*4";
            ParseResult parseResult = evaluator.Parse(expr);

            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            ExprExecValueInt valueInt = execResult.ExprExec as ExprExecValueInt;
            Assert.IsNotNull(valueInt, "The result value should be a bool");
            Assert.AreEqual(8, valueInt.Value, "The result value should be: 8");
        }

        /// <summary>
        /// 2*3*4
        /// =24
        /// </summary>
        [TestMethod]
        public void Exec_2_Mul_3_Mul_4_Ret_8_Ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "2*3*4";
            ParseResult parseResult = evaluator.Parse(expr);

            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            ExprExecValueInt valueInt = execResult.ExprExec as ExprExecValueInt;
            Assert.IsNotNull(valueInt, "The result value should be a bool");
            Assert.AreEqual(24, valueInt.Value, "The result value should be: 24");
        }

        [TestMethod]
        public void Exec_Minus_2_Minus_Minus_5_Ret_3_Ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "-2 - -5";
            ParseResult parseResult = evaluator.Parse(expr);

            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            ExprExecValueInt valueInt = execResult.ExprExec as ExprExecValueInt;
            Assert.IsNotNull(valueInt, "The result value should be a bool");
            Assert.AreEqual(3, valueInt.Value, "The result value should be: 3");
        }

        [TestMethod]
        public void Exec_2dot5_mul_M5_Ret_M12dot5_Ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "2.5 * -5";
            ParseResult parseResult = evaluator.Parse(expr);

            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            ExprExecValueDouble valueDouble = execResult.ExprExec as ExprExecValueDouble;
            Assert.IsNotNull(valueDouble, "The result value should be a bool");
            Assert.AreEqual(-12.5, valueDouble.Value, "The result value should be: -12.5");
        }

        [TestMethod]
        public void Exec_10_div_3_Ret_3dot3333_Ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "10/3";
            ParseResult parseResult = evaluator.Parse(expr);

            ExecResult execResult = evaluator.Exec();
            Assert.IsFalse(execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            ExprExecValueDouble valueDouble = execResult.ExprExec as ExprExecValueDouble;
            Assert.IsNotNull(valueDouble, "The result value should be a bool");
            Assert.IsTrue(valueDouble.Value > 3.333, "The result value should be greater than 3.333");
            Assert.IsTrue(valueDouble.Value < 3.334, "The result value should be lesser than 3.334");
        }

        [TestMethod]
        public void Exec_2_mul_4_div_3_Ret_Double_Ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "2*4/3";
            ParseResult parseResult = evaluator.Parse(expr);

            ExecResult execResult = evaluator.Exec();
            Assert.IsFalse(execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            ExprExecValueDouble valueDouble = execResult.ExprExec as ExprExecValueDouble;
            Assert.IsNotNull(valueDouble, "The result value should be a bool");
            Assert.IsTrue(valueDouble.Value > 2.666, "The result value should be greater than 2.666");
            Assert.IsTrue(valueDouble.Value < 2.667, "The result value should be lesser than 2.667");
        }

        /// <summary>
        /// a+5, a is a bool, -> error: unexpected type.
        /// </summary>
        [TestMethod]
        public void Exec_aBool_plus_5_err()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "a + 5";
            ParseResult parseResult = evaluator.Parse(expr);

            evaluator.DefineVarBool("a", true);
            ExecResult execResult = evaluator.Exec();
            Assert.IsTrue(execResult.HasError, "The exec of the expression should failed");
            Assert.AreEqual(ErrorCode.ExprCalculationOperandTypeUnExcepted, execResult.ListError[0].Code, "the error should be ParsedExpressionMissing");
        }

        [TestMethod]
        public void Exec_3E2_plus_5_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            // its a double
            string expr = "3E2 + 5";
            ParseResult parseResult = evaluator.Parse(expr);

            ExecResult execResult = evaluator.Exec();
            Assert.IsFalse(execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            ExprExecValueDouble valueDouble = execResult.ExprExec as ExprExecValueDouble;
            Assert.IsNotNull(valueDouble, "The result value should be a bool");
            Assert.AreEqual(305, valueDouble.Value, "The result value should be: 305");
        }

        [TestMethod]
        public void Exec_OP_2plus_3_CP_mul_5_Ret_25_Ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "(2+3)*5";
            ParseResult parseResult = evaluator.Parse(expr);

            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            ExprExecValueInt valueInt = execResult.ExprExec as ExprExecValueInt;
            Assert.IsNotNull(valueInt, "The result value should be an int");
            Assert.AreEqual(25, valueInt.Value, "The result value should be: 25");

        }


        /// <summary>
        /// 12+3-5
        /// =15
        /// </summary>
        [TestMethod]
        public void Exec_12_Plus_3_Minus_5_Ret_10_Ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "12+3-5";
            ParseResult parseResult = evaluator.Parse(expr);

            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            ExprExecValueInt valueInt = execResult.ExprExec as ExprExecValueInt;
            Assert.IsNotNull(valueInt, "The result value should be an int");
            Assert.AreEqual(10, valueInt.Value, "The result value should be: 10");

        }

        /// <summary>
        /// 2*3+4
        /// =(2*3)+4
        /// =10
        /// </summary>
        [TestMethod]
        public void Exec_2_Mul_3_Plus_4_Ret_10_Ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "2*3+4";
            ParseResult parseResult = evaluator.Parse(expr);

            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            ExprExecValueInt valueInt = execResult.ExprExec as ExprExecValueInt;
            Assert.IsNotNull(valueInt, "The result value should be an int");
            Assert.AreEqual(10, valueInt.Value, "The result value should be: 10");

        }

        /// <summary>
        /// 4+5*6
        /// =4+(5*6)
        /// =34
        /// </summary>
        [TestMethod]
        public void Exec_4_Plus_5_Mul_6_Ret_34_Ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "4+5*6";
            ParseResult parseResult = evaluator.Parse(expr);

            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            ExprExecValueInt valueInt = execResult.ExprExec as ExprExecValueInt;
            Assert.IsNotNull(valueInt, "The result value should be an int");
            Assert.AreEqual(34, valueInt.Value, "The result value should be: 34");
        }

        /// <summary>
        /// 2+3*4+5
        /// =2+(3*4)+5
        /// =2+12+5
        /// =19
        /// </summary>
        [TestMethod]
        public void Exec_2_Plus_3_Mul_4_Plus_5_Ret_19_Ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "2+3*4+5";
            ParseResult parseResult = evaluator.Parse(expr);

            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            ExprExecValueInt valueInt = execResult.ExprExec as ExprExecValueInt;
            Assert.IsNotNull(valueInt, "The result value should be an int");
            Assert.AreEqual(19, valueInt.Value, "The result value should be: 19");
        }

        [TestMethod]
        public void Exec_2dot5_mul_M5_Plus_2_Ret_Ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "2.5 * -5 + 2";
            ParseResult parseResult = evaluator.Parse(expr);

            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            ExprExecValueDouble valueDouble = execResult.ExprExec as ExprExecValueDouble;
            Assert.IsNotNull(valueDouble, "The result value should be a bool");
            Assert.AreEqual(-10.5, valueDouble.Value, "The result value should be: -10.5");
        }


    }
}
