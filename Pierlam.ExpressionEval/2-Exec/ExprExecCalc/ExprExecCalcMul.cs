using System;
using System.Collections.Generic;
using System.Text;

namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// List of multiplication and division of final numbers.
    /// exp:
    /// 2*4/5*3
    /// </summary>
    public class ExprExecCalcMul : ExprExecCalcBase
    {
        public ExprExecCalcMul()
        {
            ListExprExecCalcValue = new List<ExprExecCalcValue>();
            ListOperator = new List<ExprOperatorCalculation>();
        }

        public List<ExprExecCalcValue> ListExprExecCalcValue { get; set; }

        /// <summary>
        /// Only multiplication and division.
        /// </summary>
        public List<ExprOperatorCalculation> ListOperator { get; set; }

        /// <summary>
        /// Add a number operand: int or double.
        /// </summary>
        /// <param name="exprExecBase"></param>
        /// <returns></returns>
        public bool AddOperandNumber(ExpressionExecBase exprExecBase)
        {
            ExprExecCalcValue calcValue = new ExprExecCalcValue();

            // save the value
            calcValue.ExprExecValue = exprExecBase;
            ListExprExecCalcValue.Add(calcValue);
            return true;
        }

    }
}
