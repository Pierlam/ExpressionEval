using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pierlam.ExpressionEval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pierlam.ExpressionEval.Test.ExprEval_Exec
{
    [TestClass]
    public class ExprEval_Exec_ExprComparison_Int
    {
        [TestMethod]
        public void Exec_A_Eq_B_Int_True_Ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "(A=B)";
            ParseResult parseResult = evaluator.Parse(expr);

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            evaluator.DefineVarInt("a", 10);
            evaluator.DefineVarInt("b", 10);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            ExprExecValueBool valueBool = execResult.ExprExec as ExprExecValueBool;
            Assert.IsNotNull(valueBool, "The result value should be a bool");
            Assert.AreEqual(true, valueBool.Value, "The result value should be: true");

        }



        [TestMethod]
        public void Exec_A_Eq_B_Int_False_Ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "(A=B)";
            ParseResult parseResult = evaluator.Parse(expr);

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            evaluator.DefineVarInt("a", 10);
            evaluator.DefineVarInt("b", 12);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            ExprExecValueBool valueBool = execResult.ExprExec as ExprExecValueBool;
            Assert.IsNotNull(valueBool, "The result value should be a bool");
            Assert.AreEqual(false, valueBool.Value, "The result value should be: false");

        }

        [TestMethod]
        public void Exec_A_Diff_B_Int_True_Ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "(A<>B)";
            ParseResult parseResult = evaluator.Parse(expr);

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            evaluator.DefineVarInt("a", 10);
            evaluator.DefineVarInt("b", 12);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            ExprExecValueBool valueBool = execResult.ExprExec as ExprExecValueBool;
            Assert.IsNotNull(valueBool, "The result value should be a bool");
            Assert.AreEqual(true, valueBool.Value, "The result value should be: true");

        }

        [TestMethod]
        public void Exec_A_Diff_B_Int_False_Ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "(A<>B)";
            ParseResult parseResult = evaluator.Parse(expr);

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            evaluator.DefineVarInt("a", 12);
            evaluator.DefineVarInt("b", 12);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            ExprExecValueBool valueBool = execResult.ExprExec as ExprExecValueBool;
            Assert.IsNotNull(valueBool, "The result value should be a bool");
            Assert.AreEqual(false, valueBool.Value, "The result value should be: false");

        }


        [TestMethod]
        public void Exec_A_Gr_B_Int_True_Ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "(A>B)";
            ParseResult parseResult = evaluator.Parse(expr);

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            evaluator.DefineVarInt("a", 12);
            evaluator.DefineVarInt("b", 10);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            ExprExecValueBool valueBool = execResult.ExprExec as ExprExecValueBool;
            Assert.IsNotNull(valueBool, "The result value should be a bool");
            Assert.AreEqual(true, valueBool.Value, "The result value should be: true");
        }

        [TestMethod]
        public void Exec_A_Gr_B_Int_False_Ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "(A>B)";
            ParseResult parseResult = evaluator.Parse(expr);

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            evaluator.DefineVarInt("a", 12);
            evaluator.DefineVarInt("b", 23);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            ExprExecValueBool valueBool = execResult.ExprExec as ExprExecValueBool;
            Assert.IsNotNull(valueBool, "The result value should be a bool");
            Assert.AreEqual(false, valueBool.Value, "The result value should be: false");
        }

        // test: (a=b)
        // a is a bool, b is an int -> error.

    }
}
