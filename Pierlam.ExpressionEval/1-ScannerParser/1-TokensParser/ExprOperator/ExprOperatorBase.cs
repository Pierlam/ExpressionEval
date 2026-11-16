namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// Base of all operators: logical, comparison, calculation or setValue.
    /// Used to decode token (saved in a stack).
    /// </summary>
    public abstract class ExprOperatorBase : ExpressionBase
    {
        /// <summary>
        /// Opérateur booléen: and, or, not xor.
        /// </summary>
        //public OperatorComparisonCode Operator {get;set;}
    }
}
