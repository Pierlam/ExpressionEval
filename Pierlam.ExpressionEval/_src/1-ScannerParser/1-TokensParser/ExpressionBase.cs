namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// Noeud expression booléenne binaire
    /// opérande droite, opérateur, opérande  gauche
    /// ou opérande final.
    /// operator, functionCall, ...
    /// </summary>
    public abstract class ExpressionBase
    {
        public ExpressionBase()
        {
            //HasOpeningParenthesisBefore = false;
            //HasClosingParenthesisAfter = false;
            StartsWithOpeningParenthesis = false;
        }

        /// <summary>
        /// Le token parsé concerné.
        /// </summary>
        public ExprToken Token { get; set; }

        /// <summary>
        /// Used when the expression is a parameter of a functionCall.
        /// exp: fct(a=b)   fct(a>12), ...
        /// </summary>
        public bool StartsWithOpeningParenthesis { get; set; }
        //public bool HasOpeningParenthesisBefore { get; set; }
        //public bool HasClosingParenthesisAfter { get; set; }

        // todo: gestion séparateur paramètre fonction
    }
}
