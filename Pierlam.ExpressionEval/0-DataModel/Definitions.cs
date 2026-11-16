namespace Pierlam.ExpressionEval
{
    public class Definitions
    {
        public static readonly int ExprCalculationMaxOperandsCount = 64;
    }

    /// <summary>
    /// Language used for keywords:
    /// logical operator: and, or Not
    /// boolean value: true/false.
    /// </summary>
    public enum Language
    {
        /// <summary>
        /// French
        /// </summary>
        Fr,

        /// <summary>
        /// English
        /// </summary>
        En
    }

    /// <summary>
    /// Concerns both object: 
    /// double decimal separator 
    /// function call parameters separator
    /// function separator (not yet implemented).
    /// 
    /// 2 cases:
    ///  -Standard: décimal separtor is dot and parameters separator is comma.
    ///     exp: 12.45     fct(a,b)
    ///  
    ///  -ExcelLike: décimal separtor is comma and parameters separator is double-comma.
    ///     exp: 12,45     fct(a;b)
    ///
    /// </summary>
    public enum DecimalAndFunctionSeparators
    {
        /// <summary>
        /// The double decimal separator is the dot
        /// exp: 12.34 
        /// The function call parameter separator is the semicolon. 
        /// ex: fct(a,b)
        /// </summary>
        Standard,

        /// <summary>
        /// The double decimal separator is the semicolon
        /// exp: 12,34 
        /// The function call parameter separator is the xx. 
        /// ex: fct(a;b)
        /// 
        /// it's exactly like Excel runs.
        /// </summary>
        ExcelLike
    }

    /// <summary>
    /// Operator code/Id.
    /// </summary>
    public enum OperatorComparisonCode
    {
        // comparison operator
        Equals,
        Different,
        Greater,
        Less,

        // >=
        GreaterEquals,
        LessEquals,
    }

    /// <summary>
    /// operator logical code.
    /// Not is different.
    /// </summary>
    public enum OperatorLogicalCode
    {
        And,
        Or,
        Xor,
        Not,
    }

    public enum OperatorCalculationCode
    {
        Plus,
        Minus,
        Multiplication,

        // real division: /
        Division,

        // whole division % modulo
        //Modulo
    }

    /// <summary>
    /// Final operand type.
    /// </summary>
    public enum OperandType
    {
        ValueInt,
        ValueDouble,
        ValueBool,
        ValueNumberBadFormed,

        ValueString,
        ValueStringBadFormed,

        /// <summary>
        /// Object name : variable or function call.
        /// When detected during the prasing process, can't say if it's a variable or a function call.
        /// </summary>
        ObjectName,
    }

    /// <summary>
    /// string tag start and end code.
    /// </summary>
    public enum StringTagCode
    {
        // 'string'
        Quote,

        // "string"
        DoubleQuote,
    }

    /// <summary>
    /// Error occurs during the parse of the string expression.
    /// Two stages: string scanner and tokens parser.
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// The expression is wrong.
        /// Unable to be more precise.
        /// </summary>
        WrongExpression,

        ExprIsNullOrEmpty,


        /// <summary>
        /// A token is not expected.
        /// </summary>
        UnexpectedToken,

        OperatorExpected,
        OpenBracketExpected,
        BooleanOperatorExpected,

        BadExpressionBracketOpenCloseMismatch,

        AnyOperatorDefined,

        /// <summary>
        /// The token before the not logical operator is unexpected/wrong.
        /// UnexpectedTokenBeforeNot
        /// </summary>
        UnexpectedTokenBeforeNot,

        /// <summary>
        /// A logical NOT operator is not authorized before a NOT logical operator.
        /// UnexpectedNotTokenBeforeNot
        /// </summary>
        ExprNotBeforeNotIsUnanthorized,

        BooleanOperatorExpectedBeforeNot,
        OpenBracketOrBooleanOperatorExpectedBeforeNot,

        RightOperandTypeUnexpected,
        LeftOperandTypeUnexpected,

        NoMoreTokenOperatorExpected,
        NoMoreTokenRightOperandExpected,
        NoMoreTokenLeftOperandExpected,
        NoMoreTokenOpenBracketExpected,
        NoMoreTokenOpenBracketOrBoolOperatorExpected,

        ValueStringBadFormed,
        ValueNumberBadFormed,

        ObjectNameSyntaxWrong,

        //============execution error code:

        /// <summary>
        /// Exec() called but parse() was never called before.
        /// </summary>
        ParsedExpressionMissing,

        /// <summary>
        /// The variable is used in the expression but not defined, so the execution is impossible.
        /// </summary>
        VariableNotDefined,

        VarNameSyntaxWrong,

        FunctionCallNameSyntaxWrong,

        // expression type (comparison, logicial, function call,...)
        ExpressionTypeNotYetImplemented,

        ExprComparisonOperandsTypeMismatchBoolExpected,
        ExprComparisonOperandsTypeMismatchIntExpected,
        ExprComparisonOperandsTypeMismatchDoubleExpected,
        ExprComparisonOperandsTypeMismatchStringExpected,

        /// <summary>
        /// For boolean type, in the expression comparison, only equals and different operator are allowed.
        /// </summary>
        ExprComparisonOperatorNotAllowedForBoolType,
        ExprComparisonOperatorNotAllowedForStringType,

        ExprComparisonOperatorNotYetImplementedForIntType,
        ExprComparisonOperatorNotYetImplementedForDoubleType,

        ExprComparisonOperandTypeNotYetImplemented,

        //----expr logical errors
        ExprLogicalOperandsTypeMismatchBoolExpected,
        ExprLogicalOperandTypeNotAllowed,
        ExprLogicalOperatorNotAllowed,

        /// <summary>
        /// bool type expected for the operand inner the not logical expression, but the operand has another type.
        /// </summary>
        ExprLogicalNotOperator_InnerOperandBoolTypeExpected,

        //ExprLogicalOperandTypeNotYetImplemented,
        //ExprLogicalNotOperandTypeNotYetImplemented,

        ExprCalculationTooManyOperands,
        ExprCalculationOperandTypeUnExcepted,
        ExprCalculationOperatorNotYetImplemented,

        /// <summary>
        /// function call hasn't any function code linked
        /// </summary>
        FunctionCallNotLinked,

        /// <summary>
        /// The execution of the function failed, an exception occurs
        /// maybe pb with parameters: count and type.
        /// </summary>
        FunctionCallExecException,

        /// <summary>
        /// Params count of the function code mismatch the functionCall params.
        /// </summary>
        FunctionCallParamCountWrong,

        /// <summary>
        /// A parameter type is not expected.
        /// </summary>
        FunctionCallParamTypeWrong,

        /// <summary>
        /// Errors occurs when configuring the execution.
        /// Define variable, attach function,...
        /// </summary>
        FunctionCall3ParamsNotManaged,
    }
}
