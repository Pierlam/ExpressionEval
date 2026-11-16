namespace Pierlam.ExpressionEval
{
    public enum ExprObjectType
    {
        Variable,
        FunctionCall
    }

    /// <summary>
    /// represents an object name (variable and functions?) used in the expression.
    /// todo: pb nommage!!
    /// </summary>
    public abstract class ExprObjectUsedBase
    {
        public ExprObjectUsedBase()
        {
            ExprObjectType = ExprObjectType.Variable;
        }

        /// <summary>
        /// Type of the object name: Variable or function call.
        /// </summary>
        public ExprObjectType ExprObjectType { get; set; }

        public string Name { get; set; }
    }
}
