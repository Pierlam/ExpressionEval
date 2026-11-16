using System.Collections.Generic;

namespace Pierlam.ExpressionEval
{
    public class ExprFunctionCall : ExpressionBase
    {
        public ExprFunctionCall()
        {
            ListExprParameters = new List<ExpressionBase>();
        }

        /// <summary>
        /// Operand value.
        /// can be a number, a string.
        /// </summary>
        public string FunctionName { get; set; }

        // list of parameters
        public List<ExpressionBase> ListExprParameters { get; private set; }

        // return type of the function
        // todo:

        public void AddFirstParameter(ExpressionBase exprParameter)
        {
            ListExprParameters.Insert(0, exprParameter);
        }

        public override string ToString()
        {
            return "FuncCall: " + this.Token.Value;
        }

    }
}
