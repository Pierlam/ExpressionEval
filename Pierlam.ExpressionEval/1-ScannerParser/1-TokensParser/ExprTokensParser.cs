using System;
using System.Collections.Generic;
using System.Globalization;

namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// Parse input tokens, generate a syntax tree.
    /// Use a stack to decode the expression splitted in tokens.
    /// Add tokens in the stack, when a closed bracket is found, pop and decode the sub-expression unitl reach an open bracket.
    /// </summary>
    public class ExprTokensParser
    {
        /// <summary>
        /// operators needed: logical, comparison, calculation.
        /// </summary>
        ExpressionEvalConfig _exprEvalConfig;

        /// <summary>
        /// List of string start and end tags.
        /// "xx" et 'xx'
        /// </summary>
        //private string _listStringTag = "\"";


        public ExprTokensParser()
        {

        }

        public void SetConfiguration(ExpressionEvalConfig exprOperators)
        {
            _exprEvalConfig = exprOperators;
        }

        /// <summary>
        /// decode les tokens de l'expression.
        /// construit une structure d'objets arborescente binaire basée sur la classe BoolBinExprBase.
        /// 
        /// Compact the tokens before decoding it.
        /// </summary>
        /// <param name="expr"></param>
        /// <param name="listTokens"></param>
        /// <returns></returns>
        public ParseResult Parse(string expr, List<ExprToken> listTokens)
        {
            ParseResult result = new ParseResult();
            result.Expression = expr;
            result.ListExprToken.AddRange(listTokens);

            // err, any operator (bool and comp) is defined
            if (_exprEvalConfig == null)
            {
                ExprError error = new ExprError();
                // its an internal error!
                error.Code = ErrorCode.AnyOperatorDefined;
                result.ListError.Add(error);
                return result;
            }

            // err, the expression is null or empty
            if (listTokens.Count == 0)
            {
                // erreur! plus de token, token attendu: opérande gauche.
                ExprError error = new ExprError();
                error.Code = ErrorCode.ExprIsNullOrEmpty;
                result.ListError.Add(error);
                return result;
            }

            // adds open and close bracket to the tokens, exp A=B  -> (A=B)
            AddBrackets(listTokens);

            // init stack pour gérer les parenthèse
            Stack<ExpressionBase> stack = new Stack<ExpressionBase>();

            // parcours les tokens un à un
            foreach (ExprToken token in listTokens)
            {
                //----parenthèse ouvrante?  empile le token
                if (token.Value == "(")
                {
                    ExprBracketOpen bracketOpen = new ExprBracketOpen();
                    bracketOpen.Token = token;
                    stack.Push(bracketOpen);
                    continue;
                }

                //----closed bracket found? pop tokens from the stack until find the open bracket, build a sub-expression.                
                if (token.Value == ")")
                {
                    SubExprDecoder subExprDecoder = new SubExprDecoder();
                    if (!subExprDecoder.DecodeExpr(stack, token, result))
                        break;
                    continue;
                }

                //----opérateur?  empile le token
                // selon langue, recupere la liste des opérateurs et compare.
                if (DecodeTokenOperator(stack, token))
                {
                    continue;
                }

                //----is it function Call parameter separator?  
                if (DecodeTokenFunctionCallParameterSeparator(stack, token))
                    continue;


                //----opérande?  empile le token
                // n'est ni une parenthèse ouvrante, fermante, ni un opérateur.
                ExprFinalOperand exprFinalOperand = BuildOperand(token, result);
                stack.Push(exprFinalOperand);
            }

            // decoder le résultat du traitement: la pile ne doit contenir qu'une seule expr
            AnalyzeStackContent(stack, result);
            return result;
        }

        /// <summary>
        /// adds open and close bracket to the tokens, exp A=B  -> (A=B)
        /// 
        /// Only if there is no brackets, open and close.
        /// 
        /// Because the process is made for expressions having always opne and close bracket.
        /// </summary>
        /// <param name="listTokens"></param>
        private void AddBrackets(List<ExprToken> listTokens)
        {
            // get the first token
            ExprToken firstToken = listTokens[0];
            ExprToken lastToken = listTokens[listTokens.Count - 1];

            //if (firstToken.Value == "(" && lastToken.Value == ")")
            // the expression has an opened and a closed bracket, so nothing to do
            //    return;


            // there is no open and close bracket,  so add it
            ExprToken tokenOpenBracket = new ExprToken();
            tokenOpenBracket.Position = 0;
            tokenOpenBracket.Value = "(";
            listTokens.Insert(0, tokenOpenBracket);

            ExprToken tokenCloseBracket = new ExprToken();
            tokenCloseBracket.Position = 0;
            tokenCloseBracket.Value = ")";
            listTokens.Add(tokenCloseBracket);
        }

        /// <summary>
        /// Decode the token, is it an operator??
        /// Depending of the language, get the right operator.
        /// can be:
        ///     Logical, comparison, calculation or a setValue.
        /// </summary>
        /// <param name="token"></param>
        private bool DecodeTokenOperator(Stack<ExpressionBase> stack, ExprToken token)
        {
            //----is it a comparison operator?
            if (_exprEvalConfig.DictComparisonOperators.ContainsKey(token.Value.ToLower()))
            {
                OperatorComparisonCode operComp = _exprEvalConfig.DictComparisonOperators[token.Value.ToLower()];

                // empile le token opérateur
                ExprOperatorComparison exprOperatorComparison = new ExprOperatorComparison();
                exprOperatorComparison.Operator = operComp;
                exprOperatorComparison.Token = token;
                stack.Push(exprOperatorComparison);
                return true;
            }

            // is it a logical operator?
            if (_exprEvalConfig.DictLogicalOperators.ContainsKey(token.Value.ToLower()))
            {
                OperatorLogicalCode operLogical = _exprEvalConfig.DictLogicalOperators[token.Value.ToLower()];

                // is it the NOT operator?
                if (operLogical == OperatorLogicalCode.Not)
                {
                    // empile le token opérateur
                    ExprOperatorLogicalNot exprOperatorLogicalNot = new ExprOperatorLogicalNot();
                    exprOperatorLogicalNot.Token = token;
                    stack.Push(exprOperatorLogicalNot);
                    return true;

                }

                // empile le token opérateur
                ExprOperatorLogical exprOperatorLogical = new ExprOperatorLogical();
                exprOperatorLogical.Operator = operLogical;
                exprOperatorLogical.Token = token;
                stack.Push(exprOperatorLogical);
                return true;
            }

            // is it a calculation operator?
            if (_exprEvalConfig.DictCalculationOperators.ContainsKey(token.Value.ToLower()))
            {
                OperatorCalculationCode operCalc = _exprEvalConfig.DictCalculationOperators[token.Value.ToLower()];

                // empile le token opérateur
                ExprOperatorCalculation exprOperatorCalc = new ExprOperatorCalculation();
                exprOperatorCalc.Operator = operCalc;
                exprOperatorCalc.Token = token;
                stack.Push(exprOperatorCalc);
                return true;
            }

            // the token is not an operator 
            return false;
        }

        /// <summary>
        /// Is the token a function call paramater separator?
        /// a comma or a dot-comma, depending on the configuration.
        /// </summary>
        /// <param name="stack"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        private bool DecodeTokenFunctionCallParameterSeparator(Stack<ExpressionBase> stack, ExprToken token)
        {
            // is it a function call parameter separator?
            if (_exprEvalConfig.DecimalAndFunctionSeparators == DecimalAndFunctionSeparators.Standard)
            {
                // is it the comma?  exp: fct(a,b)
                if (token.Value == ",")
                {
                    // yes!
                    ExprFunctionCallParameterSeparator exprSeparator = new ExprFunctionCallParameterSeparator();
                    exprSeparator.Token = token;
                    stack.Push(exprSeparator);
                    return true;
                }

                // no
                return false;
            }

            // is it a function call parameter separator?
            if (_exprEvalConfig.DecimalAndFunctionSeparators == DecimalAndFunctionSeparators.ExcelLike)
            {
                // is it the dot-comma?  exp: fct(a;b)
                if (token.Value == ";")
                {
                    // yes!
                    ExprFunctionCallParameterSeparator exprSeparator = new ExprFunctionCallParameterSeparator();
                    exprSeparator.Token = token;
                    stack.Push(exprSeparator);
                    return true;
                }

                // no
                return false;
            }

            // not the function call parameter separator
            return false;
        }

        /// <summary>
        /// Build the final operand: not a separator.
        /// can be a number (positive or negative), an object name (var, fct,...) or a string.
        /// 
        /// The string can be well-formed or bad-formed: the end tag is missing.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private ExprFinalOperand BuildOperand(ExprToken token, ParseResult result)
        {
            ExprFinalOperand exprFinalOperand = new ExprFinalOperand();
            exprFinalOperand.Operand = token.Value;
            exprFinalOperand.Token = token;

            //----is the value a string? starts with a string tag (quote or double-quote)
            if (_exprEvalConfig.StringTagValue == token.Value[0].ToString())
            {
                // is the last char a string tag?
                //if (_exprEvalConfig.ListStringTag.Contains(token.Value[token.Value.Length-1]) && token.Value.Length>1)
                if (_exprEvalConfig.StringTagValue == token.Value[token.Value.Length - 1].ToString() && token.Value.Length > 1)
                {
                    exprFinalOperand.ContentType = OperandType.ValueString;
                    return exprFinalOperand;
                }
                exprFinalOperand.ContentType = OperandType.ValueStringBadFormed;
                ExprError error = new ExprError();
                error.Token = token;
                error.Code = ErrorCode.ValueStringBadFormed;
                result.ListError.Add(error);

                return exprFinalOperand;
            }

            //----is the value an integer?
            int numberInt;
            if (int.TryParse(token.Value, out numberInt))
            {
                exprFinalOperand.ContentType = OperandType.ValueInt;
                exprFinalOperand.ValueInt = numberInt;
                return exprFinalOperand;
            }

            //----is the value a double?
            if (IsOperandDouble(token, result, exprFinalOperand))
                return exprFinalOperand;

            // is it a bad-formed number? (seems to be number: start with minus or a digit)
            if (token.Value[0] == '-' || char.IsDigit(token.Value[0]))
            {
                exprFinalOperand.ContentType = OperandType.ValueNumberBadFormed;
                ExprError error = new ExprError();
                error.Token = token;
                error.Code = ErrorCode.ValueNumberBadFormed;
                result.ListError.Add(error);
                return exprFinalOperand;
            }

            //-----is it a bool value?
            // todo: get values from the configurator: true/false, vrai/faux
            BoolConst boolConst = _exprEvalConfig.ListBoolConst.Find(bc => bc.BoolStringValue.Equals(token.Value, StringComparison.InvariantCultureIgnoreCase));
            if (boolConst != null)
            {
                exprFinalOperand.ContentType = OperandType.ValueBool;
                exprFinalOperand.ValueBool = boolConst.BoolValue;
                return exprFinalOperand;
            }

            // it's an object name, (sure?) check the syntax
            CheckObjectNameSyntax(token, result, exprFinalOperand);

            return exprFinalOperand;
        }

        /// <summary>
        /// Decode the token, is it an operand type double number?
        /// </summary>
        /// <param name="token"></param>
        /// <param name="result"></param>
        /// <param name="exprFinalOperand"></param>
        /// <returns></returns>
        private bool IsOperandDouble(ExprToken token, ParseResult result, ExprFinalOperand exprFinalOperand)
        {
            global::System.IFormatProvider culture = null;

            if (_exprEvalConfig.DecimalAndFunctionSeparators == DecimalAndFunctionSeparators.Standard)
            {
                // the decimal separator is a point, exp: 123.45
                culture = new global::System.Globalization.CultureInfo("en-US");
            }
            else
            {
                // the decimal separator is a comma, exp: 123,45
                culture = new global::System.Globalization.CultureInfo("fr-fr");
            }

            //NumberStyles styles = NumberStyles.AllowExponent | NumberStyles.AllowThousands | NumberStyles.AllowDecimalPoint;
            NumberStyles styles = NumberStyles.AllowExponent | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign;

            double numberDouble;
            if (double.TryParse(token.Value, styles, culture, out numberDouble))
            {
                exprFinalOperand.ContentType = OperandType.ValueDouble;
                exprFinalOperand.ValueDouble = numberDouble;
                return true;
            }

            // its not a double operand value
            return false;
        }

        private bool CheckObjectNameSyntax(ExprToken token, ParseResult result, ExprFinalOperand exprFinalOperand)
        {
            exprFinalOperand.ContentType = OperandType.ObjectName;

            // the first char mut be: a letter or an underscore
            if (!char.IsLetter(token.Value[0]) && token.Value[0] != '_')
            {
                // erreur! plus de token, token attendu: opérande gauche.
                ExprError error = new ExprError();
                error.Code = ErrorCode.ObjectNameSyntaxWrong;
                result.ListError.Add(error);
                return false;
            }

            // check others char of the objectName
            // ici();

            exprFinalOperand.ContentType = OperandType.ObjectName;
            return true;
        }

        /// <summary>
        /// Decoder le résultat du traitement: la pile ne doit contenir qu'une seule expr.
        /// </summary>
        /// <param name="stack"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool AnalyzeStackContent(Stack<ExpressionBase> stack, ParseResult result)
        {
            // an error occurs
            if (result.HasError)
                return false;

            // ok, la pile contient une et une seule expr
            if (stack.Count == 1)
            {
                result.RootExpr = stack.Pop();
                return true;
            }

            // cas spécial, normalement traité avant ici
            if (stack.Count == 0)
                return false;

            // expression malformée, pb parenthèses
            ExprError error = new ExprError();
            // todo: compter les bracket open et les end pour préciser l'erreur?
            error.Code = ErrorCode.BadExpressionBracketOpenCloseMismatch;

            error.Token = result.ListExprToken[result.ListExprToken.Count - 1];
            //error.TokenPosition = error.Token.Position;
            result.ListError.Add(error);

            // sort du traitement
            return false;

        }

    }
}
