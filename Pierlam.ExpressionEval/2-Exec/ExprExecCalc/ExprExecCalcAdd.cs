using System;
using System.Collections.Generic;
using System.Text;

namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// list of addition and soustraction.
    /// 
    /// exp: 
    ///   a+b-c
    ///   (a*b) + c
    /// </summary>
    public class ExprExecCalcAdd
    {
        public ExprExecCalcAdd()
        {
            ListExprExecCalc = new List<ExprExecCalcBase>();
            ListOperator = new List<ExprOperatorCalculation>();
        }

        /// <summary>
        /// lis of operands.
        /// Number (int or double) or list of multiplication/division.
        /// </summary>
        public List<ExprExecCalcBase> ListExprExecCalc { get; set; }

        /// <summary>
        /// Only addition and minus.
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
            ListExprExecCalc.Add(calcValue);
            return true;
        }
        
    }
}
