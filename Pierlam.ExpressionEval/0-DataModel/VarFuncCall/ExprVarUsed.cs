namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// a variable name used in a expression.
    /// Can be present one time or more in a expression.
    /// ExprVarUsed
    /// 
    /// Found in the tokens parse process.
    /// 
    /// todo: pb nommage!!
    /// </summary>
    public class ExprVarUsed : ExprObjectUsedBase
    {
        public ExprVarUsed()
        {
            ExprObjectType = ExprObjectType.Variable;
        }
    }
}
