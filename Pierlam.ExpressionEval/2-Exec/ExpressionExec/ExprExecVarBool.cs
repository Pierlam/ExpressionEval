namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// Expression Execution variable type bool.
    /// Its an instance.
    /// result of an execution.
    /// </summary>
    public class ExprExecVarBool : ExprExecValueBool
    {
        /// <summary>
        /// The implemented type.
        /// </summary>
        public ExprVariableBool ExprVariableBool { get; set; }

        //public bool Value { get; set; }
    }
}
