using System;
using System.Collections.Generic;

namespace Pierlam.ExpressionEval
{
    public enum ErrorType
    {
        Parse,
        Exec,
        DefineVar,
        AttachFunc,
        License
    }

    /// <summary>
    /// Error occurs in the component.
    /// Can be: 
    /// License, parse, exec, defineVar or AttachFunc.
    /// </summary>
    public class ExprError 
    {
        public ExprError()
        {
            ListErrorParam = new List<ErrorParam>();

            ErrorType = ErrorType.Parse;
            DateTimeCreation = DateTime.Now;
        }

        /// <summary>
        /// When the error was created.
        /// </summary>
        public DateTime DateTimeCreation { get; private set; }

        /// <summary>
        /// Position of the token in the initial string containing the expression.
        /// It's the position of the first char of the token in the raw expression.
        /// </summary>
        public int TokenPosition {
            get
            {
                if (Token == null) return 0;
                return Token.Position;
            }
        }

        /// <summary>
        /// Content/value of a token.
        /// </summary>
        public string TokenValue
        {
            get
            {
                if (Token == null) return "";
                return Token.Value;
            }
        }

        /// <summary>
        /// Type of the error: License, parse, Exec or config.
        /// </summary>
        public ErrorType ErrorType { get; set; }

        /// <summary>
        /// The code of the error.
        /// </summary>
        public ErrorCode Code { get; set; }

        /// <summary>
        /// The expression token concerned by the error.
        /// </summary>
        public ExprToken Token { get; set; }

        public List<ErrorParam> ListErrorParam { get; private set; }

        public static ExprError CreateError(ErrorCode errCode, string paramKey, string paramValue)
        {
            ExprError error = new ExprError();
            error.Code = errCode;


            if (string.IsNullOrEmpty(paramKey))
                paramKey = "Param1";
            if (string.IsNullOrEmpty(paramValue))
                paramKey = "(null)";

            ErrorParam errorParam = new ErrorParam();
            errorParam.Key = paramKey;
            errorParam.Value = paramValue;
            //error.Param = param;

            error.ListErrorParam.Add(errorParam);
            return error;
        }

        public void AddParam(string key, string value)
        {
            ErrorParam errorParam = new ErrorParam();
            errorParam.Key = key;
            errorParam.Value = value;

            ListErrorParam.Add(errorParam);
        }

    }
}
