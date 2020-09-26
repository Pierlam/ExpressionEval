using System;
using System.Collections.Generic;
using System.Text;

namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// calculation expression.
    /// 2 operands, one operator.
    /// </summary>
    public class ExprCalculation : ExpressionBase
    {
        public ExprCalculation()
        {
            ListExprOperand = new List<ExpressionBase>();
            ListOperator = new List<ExprOperatorCalculation>();
        }

        /// <summary>
        /// todo: a supprimer après implementation expr calcul multi-operandes.
        /// </summary>
        //public ExpressionBase ExprLeft { get; set; }

        /// <summary>
        /// todo: a supprimer après implementation expr calcul multi-operandes.
        /// </summary>
        //public ExpressionBase ExprRight { get; set; }

        /// <summary>
        /// Calculation operator: +, -, * / and modulo.
        /// TODO: better to have an object like: ExprOperatorCalculation, to have also the position! needed for error trace.
        /// 
        /// todo: a supprimer après implementation expr calcul multi-operandes.
        /// </summary>
        //public OperatorCalculationCode Operator { get; set; }

        /// <summary>
        /// list of operands.
        /// Should contains two operands at least.
        /// </summary>
        public List<ExpressionBase> ListExprOperand { get; private set; }

        /// <summary>
        /// list of operators. between operands.
        /// One operator at least.
        /// </summary>
        public List<ExprOperatorCalculation> ListOperator { get; private set; }

    }
}
