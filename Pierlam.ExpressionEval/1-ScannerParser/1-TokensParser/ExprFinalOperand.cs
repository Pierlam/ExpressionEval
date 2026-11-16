namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// A final operand value.
    /// can be a variable, a string, a number.
    /// </summary>
    public class ExprFinalOperand : ExpressionBase
    {
        /// <summary>
        /// Operand value.
        /// can be a number, a string.
        /// </summary>
        public string Operand { get; set; }

        /// <summary>
        /// Typ: number, string object name.
        /// </summary>
        public OperandType ContentType { get; set; }

        public int ValueInt { get; set; }

        public double ValueDouble { get; set; }

        public bool ValueBool { get; set; }

        public override string ToString()
        {
            return "Operand: " + this.Token.Value;
        }
    }
}
