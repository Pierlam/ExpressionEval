namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// A function call used in a expression.
    /// 
    /// todo: pb nommage!!
    /// </summary>
    public class ExprFunctionCallUsed : ExprObjectUsedBase
    {
        public ExprFunctionCallUsed()
        {
            ExprObjectType = ExprObjectType.FunctionCall;
            ParameterCount = 0;
        }

        public int ParameterCount { get; set; }
    }
}
