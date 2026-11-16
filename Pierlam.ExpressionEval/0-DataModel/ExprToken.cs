namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// A token in a raw (a string) expression.
    /// </summary>
    public class ExprToken
    {
        public ExprToken()
        {
            Value = "";
        }

        /// <summary>
        /// Position of the token in the initial string containing the expression.
        /// It's the position of the first char of the token in the raw expression.
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// The value (the content/payload) of the token.
        /// </summary>
        public string Value { get; set; }

        public override string ToString()
        {
            return Position.ToString() + ": " + Value;
        }
    }
}
