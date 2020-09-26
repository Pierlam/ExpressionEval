namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// An expression data/context.
    /// The string initial expression.
    /// Th parse result.
    /// The last execution result.
    /// </summary>
    public class ExpressionData
    {
        public string Expression { get; set; }

        /// <summary>
        /// Result of the parse of the expression.
        /// An expression is parsed a single time.
        /// </summary>
        public ParseResult ExprParseResult { get; set; }

        /// <summary>
        /// Result of the last execution of the expression.
        /// An expression can be executed many times.
        /// 
        /// Contains the tree of tokens of the expression to execute.
        /// and the variables definitions (type and value).
        /// </summary>
        public ExecResult ExprExecResult { get; private set; }

        /// <summary>
        /// The previous execution.
        /// </summary>
        public ExecResult ExprExecResultPrevious { get; private set; }

        public ExecResult CreateExprExecResult()
        {
            ExprExecResultPrevious = ExprExecResult;
            ExprExecResult = new ExecResult();
            return ExprExecResult;
        }
    }
}
