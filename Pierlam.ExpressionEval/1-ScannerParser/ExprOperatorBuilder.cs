namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// Build operators: logical (And, OR,..), comparison and calculation.
    /// </summary>
    public class ExprOperatorBuilder
    {
        /// <summary>
        /// Build the list of operators depending on the language/culture.
        /// boolean and comparison operators.
        /// Build also the list of special large operators (2 char large).
        /// </summary>
        /// <param name="lang"></param>
        /// <param name="dictOperators"></param>
        /// <param name="listSpecial2CharOperators"></param>
        public bool BuildOperators(ExpressionEvalConfig exprEvalConfig)
        {
            if (exprEvalConfig == null)
                return false;

            exprEvalConfig.DictComparisonOperators.Clear();

            //----build list of comparison operators
            exprEvalConfig.DictComparisonOperators.Add("=", OperatorComparisonCode.Equals);
            exprEvalConfig.DictComparisonOperators.Add("<>", OperatorComparisonCode.Different);

            exprEvalConfig.DictComparisonOperators.Add(">", OperatorComparisonCode.Greater);
            exprEvalConfig.DictComparisonOperators.Add(">=", OperatorComparisonCode.GreaterEquals);

            exprEvalConfig.DictComparisonOperators.Add("<", OperatorComparisonCode.Less);
            exprEvalConfig.DictComparisonOperators.Add("<=", OperatorComparisonCode.LessEquals);

            //----build list of calculation operators
            exprEvalConfig.DictCalculationOperators.Add("+", OperatorCalculationCode.Plus);
            exprEvalConfig.DictCalculationOperators.Add("-", OperatorCalculationCode.Minus);
            exprEvalConfig.DictCalculationOperators.Add("*", OperatorCalculationCode.Multiplication);
            exprEvalConfig.DictCalculationOperators.Add("/", OperatorCalculationCode.Division);

            //---build list of special 2 char operators (needed for grouping/compacting tokens)
            exprEvalConfig.ListSpecial2CharOperators.Add("<>");
            exprEvalConfig.ListSpecial2CharOperators.Add(">=");
            exprEvalConfig.ListSpecial2CharOperators.Add("<=");

            //----build binary operators
            if (exprEvalConfig.Lang == Language.Fr)
            {
                exprEvalConfig.DictLogicalOperators.Add("et", OperatorLogicalCode.And);
                exprEvalConfig.DictLogicalOperators.Add("ou", OperatorLogicalCode.Or);
                exprEvalConfig.DictLogicalOperators.Add("oux", OperatorLogicalCode.Xor);
                exprEvalConfig.DictLogicalOperators.Add("non", OperatorLogicalCode.Not);

                // define true and false boolean const value
                exprEvalConfig.SetBoolConstValue(true, "vrai");
                exprEvalConfig.SetBoolConstValue(false, "faux");
                return true;
            }

            // par défaut, en anglais
            exprEvalConfig.DictLogicalOperators.Add("and", OperatorLogicalCode.And);
            exprEvalConfig.DictLogicalOperators.Add("or", OperatorLogicalCode.Or);
            exprEvalConfig.DictLogicalOperators.Add("xor", OperatorLogicalCode.Xor);
            exprEvalConfig.DictLogicalOperators.Add("not", OperatorLogicalCode.Not);

            // define true and false boolean const value
            exprEvalConfig.SetBoolConstValue(true, "true");
            exprEvalConfig.SetBoolConstValue(false, "false");
            return true;
        }

    }
}
