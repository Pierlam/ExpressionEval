namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// Execution of a function returning a double value.
    /// </summary>
    public class ExprExecFunctionCallDouble : ExprExecValueDouble
    {
        // the functionCall 
        public ExprFunctionCall ExprFunctionCall { get; set; }

        // the functionToCall mapper 
        public FunctionToCallMapper FunctionToCallMapper { get; set; }

    }
}
