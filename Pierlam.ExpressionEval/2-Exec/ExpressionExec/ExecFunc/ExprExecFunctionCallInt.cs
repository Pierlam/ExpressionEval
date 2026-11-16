namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// Execution of a function returning an int value.
    /// </summary>
    public class ExprExecFunctionCallInt : ExprExecValueInt
    {
        // the functionCall 
        public ExprFunctionCall ExprFunctionCall { get; set; }

        // the functionToCall mapper 
        public FunctionToCallMapper FunctionToCallMapper { get; set; }

    }
}
