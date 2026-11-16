using System;
using System.Collections.Generic;

namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// Résultat décodage d'une expression bool.
    /// après le parse,qui extrait la liste des tokens
    /// Vérifie la structure: les parenthèses, les opérateurs et les opérandes.
    /// </summary>
    public class ParseResult
    {
        public ParseResult()
        {
            ListError = new List<ExprError>();
            ListExprToken = new List<ExprToken>();

            ListExprVarUsed = new List<ExprVarUsed>();
            ListExprFunctionCallUsed = new List<ExprFunctionCallUsed>();

            RootExpr = null;
        }

        /// <summary>
        /// L'expression source à parser.
        /// </summary>
        public string Expression { get; set; }
        /// <summary>
        /// Return true is at least one error exists.
        /// </summary>
        public bool HasError
        {
            get
            {
                if (ListError.Count > 0) return true;
                return false;
            }
        }


        /// <summary>
        /// List of errors occurs during the parse of the expression.
        /// Two phases: expression scanner and token parser.
        /// </summary>
        public List<ExprError> ListError { get; private set; }

        /// <summary>
        /// les tokens de l'expression
        /// </summary>
        public List<ExprToken> ListExprToken { get; private set; }

        /// <summary>
        /// List of variables found in the expression.
        /// </summary>
        public List<ExprVarUsed> ListExprVarUsed { get; private set; }

        /// <summary>
        /// List of functions calls found in the expression.
        /// </summary>
        public List<ExprFunctionCallUsed> ListExprFunctionCallUsed { get; private set; }

        /// <summary>
        /// The root parsed/decoded expression.
        /// Its a tree of operands and expressions.
        /// </summary>
        public ExpressionBase RootExpr { get; set; }

        public ExprError AddError(ErrorCode errorCode, ExprToken token)
        {
            var error = new ExprError();
            error.Code = errorCode;
            error.Token = token;

            ListError.Add(error);
            return error;
        }

        //public void AddError(ErrorCode errCode)
        //{
        //    AddError(0, errCode);
        //}

        //public void AddError(int position, ErrorCode errCode)
        //{
        //    ParseError error = new ParseError();
        //    error.TokenPosition = position;
        //    error.Code = errCode;

        //    ListError.Add(error);
        //}

        /// <summary>
        /// save the objectName (variable).
        /// 
        /// ExprVarUsed is an object representing a variable used/defined/found in the expression.
        /// (not an internal object).
        /// </summary>
        /// <param name="objectName"></param>
        public void AddVariable(string objectName)
        {
            ExprVarUsed exprVar = new ExprVarUsed();
            exprVar.Name = objectName;

            // check that the name is not already present in the list
            if (ListExprVarUsed.Find(n => n.Name.Equals(objectName, StringComparison.InvariantCultureIgnoreCase)) != null)
                return;

            // save the var
            ListExprVarUsed.Add(exprVar);
        }

        /// <summary>
        /// save the objectName (variable).
        /// ExprFunctionCallUsed is an object representing a functionCall used/defined/found in the expression.
        /// (not an internal object).
        /// </summary>
        /// <param name="objectName"></param>
        public void AddFunctionCall(string objectName, int paramCount) //List<string> listParams)
        {
            ExprFunctionCallUsed exprFunctionCall = new ExprFunctionCallUsed();
            exprFunctionCall.Name = objectName;
            exprFunctionCall.ParameterCount = paramCount;

            // check that the name is not already present in the list
            if (ListExprFunctionCallUsed.Find(n => n.Name.Equals(objectName, StringComparison.InvariantCultureIgnoreCase)) != null)
                return;

            // save the functionCall
            ListExprFunctionCallUsed.Add(exprFunctionCall);
        }

    }
}
