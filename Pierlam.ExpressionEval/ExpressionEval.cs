using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// Evaluate an expression provided as a string.
    /// exp: 
    /// a and b, a+12, a>b,...
    /// 
    /// Parse the expression, set variables values, and then execute/evaluate the expression.
    /// Return a result, a boolean, an integer,... depending on the expression content.
    /// </summary>
    public partial class ExpressionEval
    {
        /// <summary>
        /// General configuration:
        ///  -operators definition: logical, comparison, calculation.
        ///  -Function Code attached to functionCall name.
        /// </summary>
        ExpressionEvalConfig _exprEvalConfig;

        /// <summary>
        /// scan and parse a string expression: generate a syntax tree ready to execution.
        /// </summary>
        ExprScannerParser _exprScannerParser;

        /// <summary>
        /// Execution configurator.
        /// To define variable, attach function code to functionCall
        /// Called before the executor.
        /// </summary>
        ExprExecConfigurator _exprExecConfigurator;

        /// <summary>
        /// To execute a parsed expression.
        /// </summary>
        ExprExecutor _exprExecutor;

        /// <summary>
        /// The current expression data/context.
        /// </summary>
        ExpressionData _expressionData;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ExpressionEval()
        {
            _exprEvalConfig = new ExpressionEvalConfig();

            _exprScannerParser = new ExprScannerParser(_exprEvalConfig);

            _exprExecConfigurator = new ExprExecConfigurator();
            _exprExecutor = new ExprExecutor();

            // todo: passer directement dans le constructeur comme pour le scannerParser?
            _exprExecConfigurator.SetConfiguration(_exprEvalConfig);
            _exprExecutor.SetConfiguration(_exprEvalConfig);

            // default language is en/english
            SetLang(Language.En);

            // default double decimal separator
            _exprEvalConfig.SetDecimalAndFunctionSeparators(DecimalAndFunctionSeparators.Standard);

            _expressionData = null;
        }

        /// <summary>
        /// Set the language of keywords.
        /// boolean operators: and, or not, in english.
        /// boolean values: true/false,  in english.
        /// </summary>
        /// <param name="lang"></param>
        public void SetLang(Language lang)
        {
            _exprEvalConfig.SetLang(lang);
        }

        /// <summary>
        /// Simple or double quote string start/end tag.
        /// exp: "string"  or 'string'
        /// </summary>
        /// <param name="stringTag"></param>
        public void SetStringTagCode(StringTagCode stringTagCode)
        {
            _exprEvalConfig.SetStringTagCode(stringTagCode);
        }

        /// <summary>
        /// Concerns both objects: double decimal separator 
        /// and function call parameters separator
        /// 2 cases:
        ///  -Standard: décimal separator is dot and parameters separator is comma.
        ///     exp: 12.45     fct(a,b)
        ///  
        ///  -ExcelLike: décimal separator is comma and parameters separator is double-comma.
        ///     exp: 12,45     fct(a;b)
        ///     
        /// </summary>
        public void SetDecimalAndFunctionSeparators(DecimalAndFunctionSeparators doubleDecimalSeparator)
        {
            _exprEvalConfig.SetDecimalAndFunctionSeparators(doubleDecimalSeparator);
        }

        /// <summary>
        /// Scan and Parse the string expression, return a syntax tree.
        /// </summary>
        /// <returns></returns>
        public ParseResult Parse(string expr)
        {
            // clear the config errors (define var, attach func)
            _exprExecConfigurator.ClearAllErrorExprConfig();

            // parse/decode the expression
            _expressionData = _exprScannerParser.Parse(expr);

            // provide the expression data to the execution managers
            _exprExecConfigurator.SetExpressionData(_expressionData);
            _exprExecutor.SetExpressionData(_expressionData);

            return _expressionData.ExprParseResult;
        }


        /// <summary>
        /// Start the execution of the last parsed expression.
        /// Evaluate the expression, generate a result value.
        /// 
        /// Should have any error before (parse stage) to execute it.
        /// </summary>
        /// <returns></returns>
        public ExecResult Exec()
        {
            _expressionData = _exprExecutor.Exec(_expressionData);
            return _expressionData.ExprExecResult;
        }


        #region Public Define Variable

        /// <summary>
        /// remove all variable definitions.
        /// </summary>
        public void ClearAllVarDefinition()
        {
            _exprExecConfigurator.ClearAllVarDefinition();
        }

        /// <summary>
        /// Returns the list of configuration errors:
        /// wrong var definitions, wring function attachments.
        /// </summary>
        /// <returns></returns>
        public List<ExprError> GetListErrorExprConfig()
        {
            return _exprExecConfigurator.GetListErrorExprConfig();
        }

        /// <summary>
        /// Create/define an int variable and set a value.
        /// Variable definition scope is global to the component.
        /// So it's available for all expressions the component evaluate.
        /// If already exists, replace it with the new value (and the new type if its different!!).
        /// </summary>
        /// <param name="varName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool DefineVarBool(string varName, bool value)
        {
            ExprError error;
            return _exprExecConfigurator.DefineVarBool(varName, value, out error);
        }

        public bool DefineVarInt(string varName, int value)
        {
            ExprError error;
            return _exprExecConfigurator.DefineVarInt(varName, value, out error);
        }

        public bool DefineVarDouble(string varName, double value)
        {
            ExprError error;
            return _exprExecConfigurator.DefineVarDouble(varName, value, out error);
        }

        public bool DefineVarString(string varName, string value)
        {
            ExprError error;
            return _exprExecConfigurator.DefineVarString(varName, value, out error);
        }
        #endregion

    }
}
