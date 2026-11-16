namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// Execution of a function returning a string value.
    /// </summary>
    public class ExprExecFunctionCallString : ExprExecValueString
    {
        // the functionCall 
        public ExprFunctionCall ExprFunctionCall { get; set; }

        // the functionToCall mapper 
        public FunctionToCallMapper FunctionToCallMapper { get; set; }

    }
}
