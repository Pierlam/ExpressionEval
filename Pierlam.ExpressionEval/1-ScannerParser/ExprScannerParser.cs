using System.Collections.Generic;

namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// scan, parse, generate a syntax tree.
    /// </summary>
    public class ExprScannerParser
    {
        /// <summary>
        /// General configuration:
        ///  -operators definition: logical, comparison, calculation.
        ///  -Function Code attached to functionCall name.
        /// </summary>
        ExpressionEvalConfig _exprEvalConfig;

        /// <summary>
        /// Build operators used in expression.
        /// binary/logical (and, or,..) comparison (=, >, <,...) calculation (+, -,...).
        /// (hard coded)
        /// </summary>
        ExprOperatorBuilder _operatorsBuilder;

        /// <summary>
        /// Scan the string bool expression, extract tokens.
        /// </summary>
        ExprScanner _scanner;

        /// <summary>
        /// Parse tokens, generate a syntax tree.
        /// </summary>
        ExprTokensParser _exprTokensParser;

        /// <summary>
        /// Expression Syntax tree analyzer.
        /// Extract the list of used variables.
        /// Do some checks: check the consistency of the expression, data, type,...
        /// Define the result data type: bool, stirng or a number (in or double).
        /// After the parse process.
        /// </summary>
        ExprSyntaxTreeAnalyzer _exprSyntaxTreeAnalyzer;

        ExpressionData _expressionData;

        public ExprScannerParser(ExpressionEvalConfig exprEvalConfig)
        {
            _exprEvalConfig = exprEvalConfig;
            _operatorsBuilder = new ExprOperatorBuilder();

            _scanner = new ExprScanner();
            _exprTokensParser = new ExprTokensParser();
            _exprSyntaxTreeAnalyzer = new ExprSyntaxTreeAnalyzer();
        }

        /// <summary>
        /// Scan and Parse the string expression, return a syntax tree.
        /// </summary>
        /// <returns></returns>
        public ExpressionData Parse(string expr)
        {
            _expressionData = new ExpressionData();
            _expressionData.Expression = expr;

            // ExprDecoder -> ExprParser
            // build the configuration data (operators...) depending on the definition
            _operatorsBuilder.BuildOperators(_exprEvalConfig);

            // the parser need them to compact/group tokens after the first raw parse/split of tokens
            _scanner.SetConfiguration(_exprEvalConfig);

            _exprTokensParser.SetConfiguration(_exprEvalConfig);

            // split the raw string expression into list of tokens
            List<ExprToken> list = _scanner.SplitExpr(expr);

            // group/compact tokens if necessary, like operators comparators (having 2 char length)
            List<ExprToken> listCompacted = _scanner.GroupTokens(expr, list);

            // parse the tokens found by the scanner in the string expression
            _expressionData.ExprParseResult = _exprTokensParser.Parse(expr, listCompacted);

            // analyze the tree of expressions result: get variables, functionCall, define the result data type of the expression
            _exprSyntaxTreeAnalyzer.Analyze(_expressionData.ExprParseResult);

            return _expressionData;
        }

    }
}
