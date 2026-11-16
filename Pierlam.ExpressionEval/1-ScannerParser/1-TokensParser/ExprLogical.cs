namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// logical expression: and, or, xor, ..
    /// 
    /// the NOT expression has its own class: ExprLogicalNot.
    /// </summary>
    public class ExprLogical : ExpressionBase
    {
        public ExpressionBase ExprLeft { get; set; }
        public ExpressionBase ExprRight { get; set; }

        public OperatorLogicalCode Operator { get; set; }

        public override string ToString()
        {
            return "ExprLogical: " + this.Token.Value;
        }

    }
}
