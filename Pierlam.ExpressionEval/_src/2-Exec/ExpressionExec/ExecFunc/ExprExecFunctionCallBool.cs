namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// Execution of a function returning a bool value.
    /// </summary>
    public class ExprExecFunctionCallBool : ExprExecValueBool
    {
        // the functionCall 
        public ExprFunctionCall ExprFunctionCall { get; set; }

        // the functionToCall mapper 
        public FunctionToCallMapper FunctionToCallMapper { get; set; }

    }
}
