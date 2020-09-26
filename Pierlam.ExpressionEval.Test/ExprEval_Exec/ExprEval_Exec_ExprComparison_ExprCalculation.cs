using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pierlam.ExpressionEval.Test.ExprEval_Exec
{
    /// <summary>
    /// Expression comparison with inner calculation expressions.
    /// </summary>
    [TestClass]
    public class ExprEval_Exec_ExprComparison_ExprCalculation
    {
        // ExprEval_Parse_ExprComparison_ExprCalculation
        [TestMethod]
        public void Exec_a_gt_OP_b_Plus_5_CP_retTrue_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            evaluator.SetLang(Language.En);

            string expr = "a > (b+5)";
            ParseResult parseResult = evaluator.Parse(expr);

            evaluator.DefineVarInt("a", 10);
            evaluator.DefineVarInt("b", 2);

            ExecResult execResult = evaluator.Exec();
            Assert.IsFalse(execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            ExprExecValueBool valueBool = execResult.ExprExec as ExprExecValueBool;
            Assert.IsNotNull(valueBool, "The result value should be a bool");
            Assert.AreEqual(true, valueBool.Value, "The result value should be: true");
        }

        // ExprEval_Parse_ExprComparison_ExprCalculation
        [TestMethod]
        public void Exec_a_gt_OP_b_Plus_5_CP_retFalse_ok()
        {
            ExpressionEval evaluator = new ExpressionEval();

            evaluator.SetLang(Language.En);

            string expr = "a > (b+5)";
            ParseResult parseResult = evaluator.Parse(expr);

            evaluator.DefineVarInt("a", 2);
            evaluator.DefineVarInt("b", 10);

            ExecResult execResult = evaluator.Exec();
            Assert.IsFalse(execResult.HasError, "The exec of the expression should finish with success");

            // check the final result value
            ExprExecValueBool valueBool = execResult.ExprExec as ExprExecValueBool;
            Assert.IsNotNull(valueBool, "The result value should be a bool");
            Assert.AreEqual(false, valueBool.Value, "The result value should be: false");
        }

    }
}
