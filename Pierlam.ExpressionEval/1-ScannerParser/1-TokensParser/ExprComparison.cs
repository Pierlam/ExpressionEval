namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// Comparison expression.
    /// 2 operands, one operator.
    /// </summary>
    public class ExprComparison : ExpressionBase
    {
        public ExpressionBase ExprLeft { get; set; }
        public ExpressionBase ExprRight { get; set; }

        /// <summary>
        /// Comparison operator: equals, different, greater than, lesser than, greater equals than, lesser equals than.
        /// TODO: better to have an object like: ExpressionOperatorComparison, to have also the position! needed for error trace.
        /// </summary>
        public OperatorComparisonCode Operator { get; set; }

    }
}
