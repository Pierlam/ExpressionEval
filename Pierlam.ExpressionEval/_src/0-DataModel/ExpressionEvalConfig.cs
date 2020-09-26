using System.Collections.Generic;

namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// General configuration.
    /// parse and exec configuration.
    /// Operators defined/used in the expression evaluator.
    /// logical, comparison, calculation
    /// </summary>
    public class ExpressionEvalConfig
    {
        /// <summary>
        /// special separator character: logical, comparison, calculation and others!
        /// Used to split string to extract tokens.
        /// 
        /// dot and comma is by default not in the list, 
        /// is used as double decimal separator depending of the configuration: Standard or ExcelLike.
        /// 
        /// DO NOT put the double decimal separator in this list! dot or comma, depending on the choice.
        /// function parameters  : ()
        /// Comparison operators : ><= 
        /// calculation operators: +-*/
        /// </summary>
        private string _listSeparatorSpecialBase = "()><=+-*/";

        public ExpressionEvalConfig()
        {
            Lang = Language.En;

            StringTagCode = StringTagCode.DoubleQuote;
            StringTagValue = "\"";

            ListBoolConst = new List<BoolConst>();
            DictComparisonOperators = new Dictionary<string, OperatorComparisonCode>();
            DictLogicalOperators = new Dictionary<string, OperatorLogicalCode>();
            DictCalculationOperators = new Dictionary<string, OperatorCalculationCode>();
            ListSpecial2CharOperators = new List<string>();

            ListFunctionToCallMapper = new List<FunctionToCallMapper>();
            ListExprVariable = new List<ExprVariableBase>();

            // double decimal separator is the doit, exp: 12.34 and function param sep is: semicolon, exp: fct(a,b)
            SetDecimalAndFunctionSeparators(DecimalAndFunctionSeparators.Standard);
        }

        #region Parameters section
        /// <summary>
        /// The language used for keyword: en or fr (for now).
        /// or, and, not  -> ou, et, non
        /// true, false -> vrai, faux
        /// </summary>
        public Language Lang { get; private set; }

        public DecimalAndFunctionSeparators DecimalAndFunctionSeparators { get; private set; }

        /// <summary>
        /// List of string start and end tags.
        /// "xx" et 'xx'
        /// </summary>
        public StringTagCode StringTagCode { get; private set; }

        public string StringTagValue { get; private set; }

        /// <summary>
        /// special separator character: logical, comparison, calculation and others!
        /// Used to split string to extract tokens.
        /// 
        /// dot and comma is by default not in the list, 
        /// is used as double decimal separator depending of the configuration: Standard or ExcelLike.
        /// </summary>
        public string ListSeparatorSpecial { get; private set; }

        /// <summary>
        /// List of bool string value: true/false, vrai/faux,..
        /// </summary>
        public List<BoolConst> ListBoolConst { get; private set; }

        /// <summary>
        /// Comparison operator (>, <, >...) in a language.
        /// Used to find the code of the operator.
        /// </summary>
        public Dictionary<string, OperatorComparisonCode> DictComparisonOperators { get; private set; }

        /// <summary>
        /// logical operators: and, or, ...
        /// Used to find the code of the operator.
        /// </summary>
        public Dictionary<string, OperatorLogicalCode> DictLogicalOperators { get; private set; }

        /// <summary>
        /// Calculation operators: +, - *, /.
        /// Used to find the code of the operator.
        /// </summary>
        public Dictionary<string, OperatorCalculationCode> DictCalculationOperators { get; private set; }

        /// <summary>
        /// Special (2 char long) operators, exp: <=,>=, <>
        /// needed for grouping tokens.
        /// </summary>
        public List<string> ListSpecial2CharOperators { get; private set; }

        /// <summary>
        /// List of variables defined by the user.
        /// </summary>
        public List<ExprVariableBase> ListExprVariable { get; private set; }

        /// <summary>
        /// Functions to call.
        /// Available for all execution of the expression.
        /// variables definition ara available only for the current execution.
        /// </summary>
        public List<FunctionToCallMapper> ListFunctionToCallMapper { get; private set; }

        #endregion

        #region Public methods.
        public void SetLang(Language lang)
        {
            Lang = lang;
        }

        /// <summary>
        /// Simple or double quote string start/end tag.
        /// exp: "string"  or 'string'
        /// </summary>
        /// <param name="stringTag"></param>
        public void SetStringTagCode(StringTagCode stringTagCode)
        {
            if (stringTagCode == StringTagCode.DoubleQuote)
                StringTagValue = "\"";
            else
                StringTagValue = "'";
        }

        public void SetDecimalAndFunctionSeparators(DecimalAndFunctionSeparators doubleDecimalSeparator)
        {
            DecimalAndFunctionSeparators = doubleDecimalSeparator;

            ListSeparatorSpecial = _listSeparatorSpecialBase;

            // adds the function call parameter separator
            if (DecimalAndFunctionSeparators == DecimalAndFunctionSeparators.Standard)
                // exp: fct(a,b)
                // dot is the double decimal separator, exp 12.34 -> not placed in this list!
                ListSeparatorSpecial += ",";
            else
                // exp: fct(a;b)
                ListSeparatorSpecial += ";";

        }

        /// <summary>
        ///  set a boolean value, in a language.
        ///  exp: true -> "true"  in english or "true -> "vrai"  in french.
        ///  
        /// </summary>
        /// <param name="boolValue"></param>
        /// <param name="constStringValue"></param>
        public void SetBoolConstValue(bool boolValue, string constStringValue)
        {
            BoolConst boolConst = new BoolConst();
            boolConst.BoolValue = boolValue;
            boolConst.BoolStringValue = constStringValue;

            ListBoolConst.Add(boolConst);
        }

        /// <summary>
        /// Is the token an operator: comparison, logical or calculation?
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public bool IsOperator(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return false;

            if (DictComparisonOperators.ContainsKey(token))
                return true;

            if (DictLogicalOperators.ContainsKey(token))
                return true;

            if (DictCalculationOperators.ContainsKey(token))
                return true;

            // not an operator
            return false;
        }

        #endregion
    }
}