namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// Binary Logical operator.
    /// and, or, xor, nor, nand.
    /// Not is unary operator and has its own class: ExprOperatorLogicalNot
    /// ExprOperatorBinLogical
    /// </summary>
    public class ExprOperatorLogical : ExprOperatorBase
    {
        /// <summary>
        /// The code operator.
        /// </summary>
        public OperatorLogicalCode Operator { get; set; }
    }
}
