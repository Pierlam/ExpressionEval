using System;
using System.Collections.Generic;
using System.Text;

namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// A value, used in calculation expression.
    /// can be an integer or a double.
    /// </summary>
    public class ExprExecCalcValue : ExprExecCalcBase
    {
        //public bool IsInt { get; set; }
        //public ExprExecValueInt ValueInt { get; set; }

        //public ExprExecValueDouble ValueDouble { get; set; }


        /// <summary>
        /// The value, its an integer or a double value.
        /// </summary>
        public ExpressionExecBase ExprExecValue { get; set; }
    }
}
