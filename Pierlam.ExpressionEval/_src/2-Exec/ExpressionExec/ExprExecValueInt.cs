namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// An int const value.
    /// </summary>
    public class ExprExecValueInt : ExpressionExecBase
    {
        public int Value { get; set; }
        public override string ToString()
        {
            return Value.ToString();
        }

    }
}
