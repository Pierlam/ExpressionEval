namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// A calculation operator.
    /// </summary>
    public class ExprOperatorCalculation : ExprOperatorBase
    {
        /// <summary>
        /// +, - /,...
        /// </summary>
        public OperatorCalculationCode Operator { get; set; }

        // todo: add token object (position and value), helpfull for error log/trace

        public override string ToString()
        {
            return Operator.ToString();
        }
    }
}
