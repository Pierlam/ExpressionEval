namespace Pierlam.ExpressionEval
{
    public class ExprFunctionCallParameterSeparator : ExpressionBase
    {
        public override string ToString()
        {
            return "Sep: " + this.Token.Value;
        }

    }
}
