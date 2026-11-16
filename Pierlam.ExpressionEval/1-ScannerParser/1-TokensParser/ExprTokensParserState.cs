using System.Collections.Generic;

namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// State machine, used to decode sub expression
    /// when a closing parenthesis is found-> decode/parse tokens until found an opening parenthesis
    /// continue, until all tokens of the expression are analyzed.
    /// use a stack to help decode.
    /// </summary>
    public class ExprTokensParserState
    {
        public ExprTokensParserState()
        {
            Code = ExprTokensParserStateCode.Init;
            Option = ExprTokensParserStateOption.NotSet;

            ListFunctionCallParam = new List<ExpressionBase>();
        }

        public ExprTokensParserStateCode Code { get; set; }

        // todo: ExprTokensParserStateCode.OperatorLogicalWithInnerRightExprLogicalNot
        // BuildExprLogicalWithInnerRightExprLogicalNot
        // OperatorLogicalWithInnerRightExprLogicalNot
        // OperatorLogical -> RightExprLogicalNot
        // OperatorLogical -> RightFunctionCall
        public ExprTokensParserStateOption Option { get; set; }

        /// <summary>
        /// set if a function call is under construction.
        /// </summary>
        //public ExprFunctionCall ExprFunctionCall { get; set; }

        public List<ExpressionBase> ListFunctionCallParam { get; private set; }

        /// <summary>
        /// Set code.
        /// Keep the option if set.
        /// </summary>
        /// <param name="code"></param>
        public void Set(ExprTokensParserStateCode code)
        {
            Code = code;
            //Option = ExprTokensParserStateOption.NotSet;
        }


        public void Set(ExprTokensParserStateCode code, ExprTokensParserStateOption option)
        {
            Code = code;
            Option = option;
        }


    }
}
