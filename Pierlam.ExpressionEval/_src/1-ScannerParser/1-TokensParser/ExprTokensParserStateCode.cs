namespace Pierlam.ExpressionEval
{
    public enum ExprTokensParserStateCode
    {
        /// <summary>
        /// closed bracked found, start to pop the stack content and analyze
        /// ... a)
        /// ... expr )
        /// ... ()      -> fct call  
        /// </summary>
        Init,


        IsFinished,

        //====Operand found

        /// <summary>
        /// Its generally the first token decoded.
        ///   ... a)
        ///   Its the first token before the closing parenthesis in the expression,
        ///   (the token is on the top of the stack). 
        ///   
        /// At this time, the others tokens are not yet decoded.
        /// </summary>
        OperandRight,


        /// <summary>
        /// Operand right and a comparison operator are found previously.
        /// </summary>
        OperandLeftComparison,

        OperandLeftLogical,

        OperandLeftCalculation,

        /// <summary>
        /// Operand function call is found.
        /// The next token can be an opening parenthesis or an operator (logical, comparison).
        /// </summary>
        OperandFunctionCall,

        /// <summary>
        /// single operand found, 2 cases:
        ///  -1/ just a single operand, a final one or an expression (logical/Not, comparison,...)
        ///      exp: a, (a),  (Expr)
        ///  -2/ fct call
        ///     exp: fct(a)
        /// </summary>
        //OperandSingle,
        //SingleOperandInBrackets,

        /// <summary>
        /// seems to be a function call without parameter
        /// fct()
        /// 
        /// or just that: ()
        /// 
        /// </summary>
        OpenedAndClosedBrackets,

        /// <summary>
        /// (a)
        /// fct(a)
        /// a and (b)
        /// </summary>
        //SingleOperandInBrackets,

        //====Operator

        /// <summary>
        /// Unique
        /// </summary>
        OperatorComparison,


        /// <summary>
        /// logical operator: and, or, ...
        /// </summary>
        OperatorLogical,

        /// <summary>
        /// The special NOT logical operator.
        /// </summary>
        OperatorLogicalNot,

        /// <summary>
        /// todo: can be one or more!!
        /// exp: A+12-B
        /// </summary>
        OperatorCalculation,

        //====Function

        /// <summary>
        /// A functionCall parameter separator was found.
        /// </summary>
        FunctionCallParamSeparator,

        /// <summary>
        /// A functionCall parameter was found.
        /// The next step can be: opening parenthesis or param separator.
        /// </summary>
        FunctionCallParameter,

        /// <summary>
        /// all functionCall parameter are get, an opening parenthesis was found.
        /// The next step is to get the functionCallName.
        /// </summary>
        FunctionCallParamsGetFinished,


        //====Push

        /// <summary>
        /// Bukld the comparison expression..
        /// Operand left, operator, operand right are found so now build the expression
        /// 
        /// </summary>
        PushExprComparison,

        PushExprLogical,

        PushExprLogicalNot,

        PushExprCalculation,

        /// <summary>
        /// A single operand in bracket is found, exp: (A).
        /// it's not a function call with one parameter.
        /// </summary>
        PushExprSingleOperand,

        /// <summary>
        /// Build a function call expression.
        /// having any, one or more parameter.
        /// </summary>
        PushExprFunctionCall,
    }

    /// <summary>
    /// Used for some state code, has an option.
    /// exp: LogicalExpr -> Option: HasInnerExprLogicalNot, HasInnerFunctionCall,..
    /// </summary>
    public enum ExprTokensParserStateOption
    {
        NotSet,

        HasOperand,

        /// <summary>
        /// exp: a OR NOT b
        ///  a logical operator is present befor a NOT logical operator.
        ///  OperatorLogicalWithInnerRightExprLogicalNot
        /// </summary>
        //RightExprLogicalNot,

        //OperandLeftLogicalWithInnerRightexprLogicalNot
        //RightexprLogicalNot,

        /// <summary>
        /// ExprLogical operator FunctionCall
        /// </summary>
        //RightFunctionCall,
    }
}
