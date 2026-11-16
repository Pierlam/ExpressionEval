namespace Pierlam.ExpressionEval
{
    public class ExprLogicalNot : ExpressionBase
    {
        /// <summary>
        /// L'expression sur laquelle appliquer le not:
        /// une expression ou un opérande.
        /// </summary>
        public ExpressionBase ExprBase { get; set; }

        public override string ToString()
        {
            return "ExprLogicalNot: " + this.Token.Value;
        }

    }
}
