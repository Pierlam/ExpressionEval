using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pierlam.ExpressionEval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pierlam.ExpressionEval.Test.ExprEval_Exec
{
    /// <summary>
    /// ExprEval_Exec_FunctionCall_Basic
    /// </summary>
    [TestClass]
    public class ExprEval_Exec_ExprLogical_Not
    {
        [TestMethod]
        public void Exec_Not_OP_a_CP_True_Ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "Not(A)";
            ParseResult parseResult = evaluator.Parse(expr);

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            evaluator.DefineVarBool("a", false);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            ExprExecValueBool valueBool = execResult.ExprExec as ExprExecValueBool;
            Assert.IsNotNull(execResult, "The result value should be a bool");
            Assert.AreEqual(true, valueBool.Value, "The result value should be: true");

        }

        [TestMethod]
        public void Exec_Not_OP_a_CP_VarTypeWrong()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "Not(A)";
            ParseResult parseResult = evaluator.Parse(expr);

            //====2/prepare the execution, provide all used variables: type and value
            //ExprExecResult execResult = evaluator.InitExec();

            // define the var a as an int in place of a bool!!!
            evaluator.DefineVarInt("a", 12);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(true, execResult.HasError, "The exec of the expression should finish with success");

            // get the error
            ExprError error = execResult.ListError[0];
            Assert.AreEqual(ErrorType.Exec, error.ErrorType, "The errorType should be: Exec");
            Assert.AreEqual(ErrorCode.ExprLogicalNotOperator_InnerOperandBoolTypeExpected, error.Code, "The errCode should be: VariableNotCreated");
            ErrorParam errParam = error.ListErrorParam[0];
            Assert.AreEqual("Token", errParam.Key, "The errParam key should be: VarName");
            Assert.AreEqual("A", errParam.Value, "The errParam value should be: a");
            ErrorParam errParam2 = error.ListErrorParam[1];
            Assert.AreEqual("Position", errParam2.Key, "The errParam key should be: VarName");
            Assert.AreEqual("4", errParam2.Value, "The errParam value should be: a");
        }

    }
}
