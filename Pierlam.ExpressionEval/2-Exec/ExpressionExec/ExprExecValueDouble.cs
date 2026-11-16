namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// A double const value.
    /// </summary>
    public class ExprExecValueDouble : ExpressionExecBase
    {
        public double Value { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
