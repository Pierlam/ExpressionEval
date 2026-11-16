namespace Pierlam.ExpressionEval
{
    public class ExprOperatorComparison : ExprOperatorBase
    {
        /// <summary>
        /// >, <, >=, <=, <>, !=
        /// </summary>
        public OperatorComparisonCode Operator { get; set; }
    }
}
