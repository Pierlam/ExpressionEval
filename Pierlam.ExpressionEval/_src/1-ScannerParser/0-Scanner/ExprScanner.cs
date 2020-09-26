using System.Collections.Generic;
using System.Linq;

namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// Scan the string expression, extract tokens.
    /// 
    /// BoolExprScanner
    /// BoolExprTokenizer
    /// </summary>
    public class ExprScanner
    {
        /// <summary>
        /// list of "pure" separator. space, tabulation, line feed.
        /// </summary>
        private string _listSeparatorPure = " \t\r\n";

        /// <summary>
        /// Specials operators using none standard char like: =, >= ...
        /// todo: que les operateurs spéciaux "long" (2 char) car sont traités dans la phase 2: le compactage.
        /// </summary>
        List<string> _listSpecial2CharOperators;

        /// <summary>
        /// Configuration: list of special two char operators.
        /// </summary>
        ExpressionEvalConfig _exprEvalConfig;

        public ExprScanner()
        {
        }

        public void SetConfiguration(ExpressionEvalConfig exprEvalConfig)
        {
            _exprEvalConfig = exprEvalConfig;
            _listSpecial2CharOperators = _exprEvalConfig.ListSpecial2CharOperators;
        }

        /// <summary>
        /// Split the expression string, generate tokens.
        /// </summary>
        /// <returns></returns>
        public List<ExprToken> SplitExpr(string expr)
        {
            List<ExprToken> listExprToken = new List<ExprToken>();

            if (_listSpecial2CharOperators == null)
                return listExprToken;

            if (string.IsNullOrWhiteSpace(expr))
                return listExprToken;

            // scan the string expression, char by char
            int currPos = 0;
            char currChar;
            ExprToken token = null;
            while (true)
            {
                // plus de char à traiter?
                if (currPos >= expr.Length)
                // finalise token encours, s'il y a
                {
                    // termine le token précédent s'il y a
                    FinalizeToken(listExprToken, token);
                    token = null;
                    break;
                }

                // recup car en cours
                currChar = expr[currPos];

                //----Est-ce un car séparteur pur (espace, tab,...)? (ne pas garder)
                if (_listSeparatorPure.Contains(currChar))
                {
                    // termine le token précédent s'il y a
                    FinalizeToken(listExprToken, token);
                    token = null;

                    // passe au char suivant
                    currPos++;
                    continue;
                }

                //----Est-ce un car séparateur spécial? (à garder)
                if (_exprEvalConfig.ListSeparatorSpecial.Contains(currChar))
                {
                    // termine le token précédent s'il y a
                    FinalizeToken(listExprToken, token);

                    // est un nouveau token
                    BuildToken(listExprToken, currPos, currChar.ToString());
                    token = null;

                    // passe au char suivant
                    currPos++;
                    continue;

                }

                //----Is it a string start tag? 
                if (_exprEvalConfig.StringTagValue == currChar.ToString())
                {
                    // termine le token précédent s'il y a
                    FinalizeToken(listExprToken, token);

                    // save start position of the string
                    int posStartString = currPos;
                    char tagStartString = currChar;

                    // find the string end tag (must find)
                    int posEndString;
                    if (!FindStringEndTag(expr, posStartString, tagStartString, out posEndString))
                    {
                        // create a new token
                        token = BuildToken(listExprToken, currPos, expr.Substring(currPos, posEndString + 1 - currPos));
                        token = null;

                        // stop, no end tag found, so get all the end of the expr string
                        return listExprToken;
                    }

                    // create a new token
                    token = BuildToken(listExprToken, currPos, expr.Substring(currPos, posEndString + 1 - currPos));
                    token = null;

                    currPos = posEndString;

                    // passe au char suivant
                    currPos++;
                    continue;
                }

                //----Is it a comment start tag? 
                // todo:

                //----le car courant est un car std de token
                // pas de token précédent?
                if (token == null)
                {
                    // create a new token
                    token = BuildToken(null, currPos, currChar.ToString());

                    // passe au char suivant
                    currPos++;
                    continue;
                }

                // car de token, ajoute le char au token
                token.Value += currChar.ToString();
                // passe au char suivant
                currPos++;
            }

            // return the list of token found in the string
            return listExprToken;

        }


        /// <summary>
        /// group tokens if necessary, like operators comparators (having 2 char length)
        /// Depends on specials char.
        /// group also negative number, exp: -, 12  becomes -12
        /// 
        /// exp:  '>', '='  becomes '>='
        /// 
        /// </summary>
        /// <param name="expr"></param>
        /// <param name="listTokens"></param>
        /// <returns></returns>
        public List<ExprToken> GroupTokens(string expr, List<ExprToken> listTokens)
        {
            List<ExprToken> listTokensOut = new List<ExprToken>();

            // expr is null or mepty, contains no token, so the returned list is empty
            if (listTokens.Count == 0)
                return listTokensOut;

            if (_listSpecial2CharOperators == null)
                return listTokensOut;

            // scan all tokens
            int i = 0;
            ExprToken prevToken;
            ExprToken token;
            ExprToken nextToken;

            while (true)
            {
                // no more token to process
                if (i >= listTokens.Count)
                    break;

                if (i > 0)
                    prevToken = listTokens[i - 1];
                else
                    prevToken = null; 

                // get the current token
                token = listTokens[i];

                // get the next one if exists
                nextToken = GetToken(listTokens, i + 1);

                // both current token and the next can be grouped/compacted 
                // need the previous to manage the minus case
                if (CanGroupTokens(prevToken, token, nextToken))
                {
                    // build a new token based on two: current and next
                    ExprToken groupToken = new ExprToken();
                    groupToken.Position = token.Position;
                    groupToken.Value = token.Value + nextToken.Value;

                    // save it
                    listTokensOut.Add(groupToken);

                    // move to next token (first step)
                    i++;
                }
                else
                {
                    listTokensOut.Add(token);
                }
                i++;
            }

            return listTokensOut;
        }

        /// <summary>
        /// find the string end tag.
        /// return the end position
        /// todo: si pas de end tag???
        /// </summary>
        /// <param name="expr"></param>
        /// <param name="posStartString"></param>
        /// <param name="tagStartString"></param>
        /// <returns></returns>
        private bool FindStringEndTag(string expr, int posStartString, char tagStartString, out int posEndString)
        {
            posEndString = posStartString;

            // scan the string expression, char by char
            int currPos = posStartString + 1;
            char currChar;
            while (true)
            {
                // plus de char à traiter?
                if (currPos >= expr.Length)
                {
                    // error
                    posEndString = currPos - 1;
                    return false;
                }

                currChar = expr[currPos];

                // string end tag is found?
                if (currChar == tagStartString)
                {
                    // yes!
                    posEndString = currPos;
                    return true;
                }

                currPos++;
            }

        }

        /// <summary>
        /// Get the token from the list, if it exists.
        /// 
        /// </summary>
        /// <param name="listTokens"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        private ExprToken GetToken(List<ExprToken> listTokens, int pos)
        {
            if (pos >= listTokens.Count)
                return null;
            return listTokens[pos];
        }

        /// <summary>
        /// Can Group these 2 tokens ?
        /// (because both represents a special token).
        /// Manage these cases: negative numbers like:  3toks: -, -, 12 ---> 2toks: -, -12
        /// a, -, -, 12  -> group it a, -, -12
        /// a, -, 3      -> don't group -3 !!
        /// a, =, -, 3   -> group it   a, =, -3 
        /// a and - 3    - group it, 
        /// </summary>
        /// <returns></returns>
        private bool CanGroupTokens(ExprToken prevToken, ExprToken token, ExprToken nextToken)
        {
            // DEBUG:
            //ExprToken prevToken = null;

            if (nextToken == null)
                // no more next token, so can't group
                return false;

            // manage negative number
            if (token.Value == "-")
            {
                // the next one is again a minus sign?
                if (nextToken.Value == "-")
                    // its a special case (exp: --12)
                    return false;

                // need to check the previous token: can group only if its a calculation token: +,-, *,/, modulo
                // exp: a-3  don't group -3!!
                // ok can group, its a negative number (have to check that the next token is a number)
                if(prevToken==null)
                    // can group, exp -3 ...
                    return true;

                // if the previous token is an operator: logical, comparison or calculation -> group it , its a negative number.
                // todo: manque cas spécial du modulo!!  exp: 12 modulo -3 -> il faut grouper!!
                if (_exprEvalConfig.IsOperator(prevToken.Value))
                    // ok, can group, exp: + - 3  --> + -3
                    return true;

                // can't group, exp: a - 3
                return false;
            }

            // the current token is the start of a special token having more than one char, exp: >=
            string specialToken;
            if (IsStartSpecialOperator(token.Value, out specialToken))
            {
                // the next token should be the end of the special large operator
                if (IsEndSpecialOperator(specialToken, nextToken.Value))
                {
                    // ok, can group these two tokens
                    return true;
                }
            }

            // can't group these two tokens
            return false;
        }

        /// <summary>
        /// Is the token value a special large operator (more than one char).
        /// </summary>
        /// <param name="tok"></param>
        /// <returns></returns>
        private bool IsStartSpecialOperator(string tok, out string specialToken)
        {
            specialToken = "";

            // todo: parcourir la liste des special large operator
            specialToken = _listSpecial2CharOperators.Where(s => s.StartsWith(tok)).FirstOrDefault();
            if (specialToken == null)
                return false;

            return true;
        }

        /// <summary>
        /// Check if the token match the end of the special token.
        /// (if here, the previous token match the start of the special token).
        /// </summary>
        /// <param name="specialToken"></param>
        /// <param name="tok"></param>
        /// <returns></returns>
        private bool IsEndSpecialOperator(string specialToken, string tok)
        {
            if (specialToken.EndsWith(tok))
                return true;

            return false;
        }

        private void FinalizeToken(List<ExprToken> listExprToken, ExprToken token)
        {
            // termine le token précédent s'il y a
            if (token == null)
                return;

            listExprToken.Add(token);
        }

        /// <summary>
        /// Build a new token, add it to the list (if exists).
        /// </summary>
        /// <param name="listExprToken"></param>
        /// <param name="currPos"></param>
        /// <param name="strToken"></param>
        /// <returns></returns>
        private ExprToken BuildToken(List<ExprToken> listExprToken, int currPos, string strToken)
        {
            var token = new ExprToken();
            token.Position = currPos;
            token.Value = strToken;

            if (listExprToken != null)
                listExprToken.Add(token);

            return token;
        }

    }
}
