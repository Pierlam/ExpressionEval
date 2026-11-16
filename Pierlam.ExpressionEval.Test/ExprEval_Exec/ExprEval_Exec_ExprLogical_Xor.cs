using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pierlam.ExpressionEval.Test.ExprEval_Exec
{
    [TestClass]
    public class ExprEval_Exec_ExprLogical_Xor
    {
        /// <summary>
        /// a and b
        /// </summary>
        [TestMethod]
        public void Double_a_xor_b_true_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            string expr = "a xor b";
            ParseResult parseResult = evaluator.Parse(expr);

            Assert.IsFalse(parseResult.HasError, "the parse should finish successfully");

            //====2/prepare the execution, provide all used variables: type and value
            evaluator.DefineVarBool("a", true);
            evaluator.DefineVarBool("b", true);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            Assert.IsTrue(execResult.IsResultBool, "The result should be a bool");
            // true xor true return false!!
            Assert.IsFalse(execResult.ResultBool, "The result value should be false");
        }

        /// <summary>
        /// a and b
        /// </summary>
        [TestMethod]
        public void Double_a_xor_b_false_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            //evaluator.SetDoubleDecimalSeparator(ExpressionEvalDef.DoubleDecimalSeparator.Dot);

            string expr = "a xor b";
            ParseResult parseResult = evaluator.Parse(expr);

            Assert.IsFalse(parseResult.HasError, "the parse should finish successfully");

            //====2/prepare the execution, provide all used variables: type and value
            evaluator.DefineVarBool("a", false);
            evaluator.DefineVarBool("b", true);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();
            Assert.AreEqual(false, execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            Assert.IsTrue(execResult.IsResultBool, "The result should be a bool");
            Assert.IsTrue(execResult.ResultBool, "The result value should be true");
        }

    }
}
