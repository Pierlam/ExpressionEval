using System;
using System.Collections.Generic;

namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// Decode a sub expression of tokens.
    /// when a closed bracket is found, decode the sub expression, until reach an open bracket.
    /// Tokens are saved in a stack.
    /// exp: (A=B)
    /// 
    /// Use a current state to decode the sub expresssion, the first one is Init.
    /// </summary>
    public class SubExprDecoder
    {
        /// <summary>
        /// The current state of decoding the sub expression.
        /// the first one is Init.
        /// ExprTokensParserState
        /// </summary>
        ExprTokensParserState _currState;

        ExpressionBase _exprOperandRight;
        ExpressionBase _exprOperandLeft;

        /// <summary>
        /// list of operands. Used to decode a calculation expression.
        /// Can have at least two operands or more.
        /// </summary>
        List<ExpressionBase> _currListOperand;

        ExprOperatorComparison _currOperatorComparison;
        ExprOperatorLogical _currOperatorLogical;
        ExprOperatorLogicalNot _currOperatorLogicalNot;

        /// <summary>
        /// todo: remove!!
        /// </summary>
        ExprOperatorCalculation _currOperatorCalculation;

        List<ExprOperatorCalculation> _currListOperatorCalculation;

        // todo: current operator setValue to a var

        public SubExprDecoder()
        {
        }

        /// <summary>
        /// Closed bracket found, so pop tokens from the stack and analyse that.
        /// pop (and decode) content until found an open bracket.
        /// 
        /// The expression can be:
        /// 
        ///  -Comparison: A
        ///   (OperandLeft Compare OperandRight)
        /// 
        ///  -Logical: B
        ///   (OperandLeft AND/OR  OperandRight)
        ///   (OperandLeft AND/OR ExprRight)
        ///   (ExprLeft AND/OR OperandRight)
        ///   (ExprLeft AND/OR ExprRight)
        ///   
        ///   (NOT Operand)
        ///   (NOT Expr)
        ///   (ExprLeft AND/OR NOT ExprRight)
        ///  NOT NOT ??  non, pas géré, renvoie une erreur.
        ///   
        ///  -Calculation: C
        ///    (OperandLeft + OperandRight)
        ///    
        ///  -function:  D
        ///     fct()
        ///     fct(a)
        ///     fct(a,b)
        ///     ... todo: nested call function.
        ///   
        /// -SetValue: E
        ///     (a := Operand)
        ///     with calculation:
        ///     (a := operandLeft + OperandRight)
        /// 
        /// </summary>
        /// <param name="stack"></param>
        /// <param name=""></param>
        public bool DecodeExpr(Stack<ExpressionBase> stack, ExprToken token, ParseResult result)
        {
            bool loopAgain = true;

            // create the curent state (first state is Init)
            _currState = new ExprTokensParserState();

            // loop until there are tokens to analyze
            do
            {
                // get the next token (the top of the stack), should be the opening parenthesis or a bool operator (or, and,...)
                ExpressionBase currentExpr;
                if (!GetNextStackItem(stack, result, ErrorCode.WrongExpression, out currentExpr))
                {
                    // get the occured error
                    //var error = result.ListError[result.ListError.Count - 1];

                    // no more token in the stack!
                    return false;
                }

                // decode the toke, move to the next state
                if (!DecodeTokens(_currState, stack, currentExpr, result))
                    return false;

                if (_currState.Code == ExprTokensParserStateCode.IsFinished)
                    return true;

                if (_currState.Code == ExprTokensParserStateCode.OperandRight ||
                    _currState.Code == ExprTokensParserStateCode.OpenedAndClosedBrackets)
                    // get and decode the next token
                    continue;

                // build expression: operand left, operator, operand right
                if (_currState.Code == ExprTokensParserStateCode.PushExprComparison)
                {
                    PushExprComparison(stack);
                    return true;
                }

                // build expression: operand left, operator, operand right
                if (_currState.Code == ExprTokensParserStateCode.PushExprLogical)
                {
                    PushExprLogical(stack);
                    return true;
                }

                // build expression: operand left, operator, operand right
                if (_currState.Code == ExprTokensParserStateCode.PushExprLogicalNot)
                {
                    PushExprLogicalNot(stack);
                    return true;
                }


                // build expression: operand left, operator, operand right
                if (_currState.Code == ExprTokensParserStateCode.PushExprCalculation)
                {
                    PushExprCalculation(stack);
                    return true;
                }

                // build expression: operand left, operator, operand right, exp: (12)
                // can be a single parameter of a function call, exp: fct(a)
                if (_currState.Code == ExprTokensParserStateCode.PushExprSingleOperand)
                {
                    PushExprSingleOperand(stack);
                    return true;
                }

                if (_currState.Code == ExprTokensParserStateCode.PushExprFunctionCall)
                {
                    PushExprFunctionCall(stack);
                    return true;
                }

                // build others expressions
                // todo:

            } while (loopAgain);

            return true;
        }
        #region Decode tokens
        /// <summary>
        /// Decode tokens to build a sub expression.
        /// between an open brack to a closed brack in the general case.
        /// In fact, the process starts from a closed bracket and stops until an open bracket is found 
        /// (or no more token in the stack).
        /// exp: (a AND b)
        /// </summary>
        /// <param name="stack"></param>
        /// <param name=""></param>
        private bool DecodeTokens(ExprTokensParserState state, Stack<ExpressionBase> stack, ExpressionBase exprToDecode, ParseResult result)
        {
            //----init state, many cases possibles 
            if (state.Code == ExprTokensParserStateCode.Init)
                return ProcessStateInit(state, stack, exprToDecode, result);

            //----is the previous token a OperandRight?
            if (state.Code == ExprTokensParserStateCode.OperandRight)
                return ProcessStateOperandRight(state, stack, exprToDecode, result);

            //----is the previous token a operator?
            if (state.Code == ExprTokensParserStateCode.OperatorComparison)
                return ProcessStateOperatorComparison(state, stack, exprToDecode, result);

            //----is the previous token a logical operator?
            if (state.Code == ExprTokensParserStateCode.OperatorLogical)
                return ProcessStateOperatorLogical(state, stack, exprToDecode, result);

            //----is the previous token a logical NOT operator?
            if (state.Code == ExprTokensParserStateCode.OperatorLogicalNot)
                return ProcessStateOperatorLogicalNot(state, stack, exprToDecode, result);

            //----is the previous token a calculation operator?
            if (state.Code == ExprTokensParserStateCode.OperatorCalculation)
                return ProcessStateOperatorCalculation(state, stack, exprToDecode, result);

            //----is the previous token a operand left?
            if (state.Code == ExprTokensParserStateCode.OperandLeftComparison)
                return ProcessStateOperandLeftComparison(state, stack, exprToDecode, result);

            if (state.Code == ExprTokensParserStateCode.OperandLeftLogical)
                return ProcessStateOperandLeftLogical(state, stack, exprToDecode, result);

            if (state.Code == ExprTokensParserStateCode.OperandLeftCalculation)
                return ProcessStateOperandLeftCalculation(state, stack, exprToDecode, result);

            if (state.Code == ExprTokensParserStateCode.FunctionCallParamSeparator)
                return ProcessStateFunctionCallParamSeparator(state, stack, exprToDecode, result);

            if (state.Code == ExprTokensParserStateCode.FunctionCallParameter)
                return ProcessStateFunctionCallParameter(state, stack, exprToDecode, result);

            if (state.Code == ExprTokensParserStateCode.OperandFunctionCall)
                return ProcessStateOperandFunctionCall(state, stack, exprToDecode, result);

            if (state.Code == ExprTokensParserStateCode.FunctionCallParamsGetFinished)
                return ProcessStateFunctionCallParamsGetFinished(state, stack, exprToDecode, result);

            // fct()
            if (state.Code == ExprTokensParserStateCode.OpenedAndClosedBrackets)
                return ProcessStateOpenedAndClosedBrackets(state, stack, exprToDecode, result);

            // if here, its an error
            return false;
        }

        /// <summary>
        /// A closed parenthesis has been found, so decode the previous token, placed in the stack.
        /// Many possibles cases:
        ///   1/ ... operandRight )
        ///   2/ ( )
        ///   2/ ... fctCall ( )
        /// </summary>
        /// <param name="stack"></param>
        /// <param name="token"></param>
        /// <param name="exprToDecode"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool ProcessStateInit(ExprTokensParserState state, Stack<ExpressionBase> stack, ExpressionBase exprToDecode, ParseResult result)
        {
            ExprError error;

            // the stack is empty, the current is an close braket, exp: Expr)
            if (stack.Count == 0)
            {
                // error!, its like: a not not b
                error = new ExprError();
                error.Code = ErrorCode.BadExpressionBracketOpenCloseMismatch;
                error.Token = exprToDecode.Token;
                result.ListError.Add(error);
                return false;
            }

            //-1---Is the  expression to decode a final operand or an expression (logical, LogicalNOT, comparison,...)?
            ExpressionBase exprOperand;
            if (IsOperandOrExpr(exprToDecode, out exprOperand))
            {
                state.Set(ExprTokensParserStateCode.OperandRight);

                _exprOperandRight = exprOperand;
                // set the flag on the (first) right operand: has a closing parenthesis after it
                //_exprOperandRight.HasClosingParenthesisAfter = true;
                return true;
            }

            //-2---is the current token an open bracket?
            // todo: its a call function!! without any parameter, exp: fct()
            ExprBracketOpen exprBracketOpen;
            if (IsOpenBracket(exprToDecode, out exprBracketOpen))
            {
                // the previous token is empty or must be a functionCall, push nothng on the stack
                state.Set(ExprTokensParserStateCode.OpenedAndClosedBrackets);
                return true;
            }

            // error, unexpected token
            error = new ExprError();
            error.Code = ErrorCode.UnexpectedToken;
            error.Token = exprToDecode.Token;
            result.ListError.Add(error);
            return false;
        }

        /// <summary>
        /// Process the current state is: OperandRight
        /// A right operand was found on the previous step.
        /// so analyze the token placed before this right operand.
        /// 
        /// cases:
        ///    1/ .. ComparisonOperator  OperandRight )
        ///    2/ .. LogicalOperator  OperandRight )
        ///    3/ Not OperandRight )
        ///    4/ CalculationOperator OperandRight )
        ///    5/ ( OperandRight )   
        ///    6/ , OperandRight )
        ///    7/ fct OperandRight

        /// todo: flush the stack content into the error.
        /// </summary>
        /// <param name="stack"></param>
        /// <param name="exprToDecode"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool ProcessStateOperandRight(ExprTokensParserState state, Stack<ExpressionBase> stack, ExpressionBase exprToDecode, ParseResult result)
        {
            //-1---Is it a comparison operator? exp: (A=B)
            ExprOperatorComparison operatorComparison;
            if (IsOperatorComparison(exprToDecode, out operatorComparison))
            {
                // ok, the current token is really an operator, exp: (A =B), the next token should be an operand (left one)
                state.Set(ExprTokensParserStateCode.OperatorComparison);
                _currOperatorComparison = operatorComparison;
                return true;
            }

            //-2---Is it a logical operator? exp: (a and b)
            ExprOperatorLogical operatorLogical;
            if (IsOperatorLogical(exprToDecode, out operatorLogical))
            {
                // ok, the current token is really an operator, exp: (A and B), the next token should be an operand (left one)
                state.Set(ExprTokensParserStateCode.OperatorLogical);
                _currOperatorLogical = operatorLogical;
                return true;
            }

            //-3---Is it a Not logical operator? exp: (Not a)
            ExprOperatorLogicalNot operatorLogicalNot;
            if (IsOperatorLogicalNot(exprToDecode, out operatorLogicalNot))
            {
                // ok, the current token is really an operator, exp: (A and B), the next token should be an operand (left one)
                state.Set(ExprTokensParserStateCode.OperatorLogicalNot);
                _currOperatorLogicalNot = operatorLogicalNot;
                return true;
            }

            //-4---Is it a calculation operator? exp: "... + OperandRight)" 
            ExprOperatorCalculation exprOperatorCalculation;
            if (IsOperatorCalculation(exprToDecode, out exprOperatorCalculation))
            {
                // ok, the current token is really an operator, exp: A+B, the next token should be an operand (left one)
                state.Set(ExprTokensParserStateCode.OperatorCalculation);

                // XXXX-TODO: remove 
                _currOperatorCalculation = exprOperatorCalculation;
                // XXXXX

                // save the last calculation operator
                _currListOperatorCalculation = new List<ExprOperatorCalculation>();
                _currListOperatorCalculation.Add(exprOperatorCalculation);

                // save the last operand of the calculation expression
                _currListOperand = new List<ExpressionBase>();
                _currListOperand.Add(_exprOperandRight);
                return true;
            }

            //-5---Is it a opening parenthesis? exp: (operandRight), can be an expression with one operand, exp: (A) 
            // or a function call with one parameter, exp: fct(A)
            // or a not with one operand, exp: not(a)
            ExprBracketOpen exprBracketOpen = exprToDecode as ExprBracketOpen;
            if (exprBracketOpen != null)
            {
                // special cases: (), (a): no more token previous this one! the stack is empty
                if (stack.Count == 0)
                {
                    // push the right operand in the stack
                    stack.Push(_exprOperandRight);

                    // todo: 
                    state.Set(ExprTokensParserStateCode.IsFinished);
                    return true;
                }

                // then the expression is : (operand), exp: (A), so build it
                state.Set(ExprTokensParserStateCode.OpenedAndClosedBrackets, ExprTokensParserStateOption.HasOperand);
                _exprOperandRight.StartsWithOpeningParenthesis = true;

                return true;
            }

            //-6----is it a function separator? exp: , OperandRight )
            ExprFunctionCallParameterSeparator functParamSep = exprToDecode as ExprFunctionCallParameterSeparator;
            if (functParamSep != null)
            {
                // the OperandRight is the last param of a function call, save it
                state.ListFunctionCallParam.Add(_exprOperandRight);

                // now the current state
                state.Set(ExprTokensParserStateCode.FunctionCallParamSeparator);
                return true;
            }

            //-7----is it a function call? exp: fct OperandRight
            // tood: vérifier que le OperandRight commence bien par une parenthèse ouvrante!! pour avoir fct( operandRight...
            ExprFinalOperand finalOperand = exprToDecode as ExprFinalOperand;
            if (finalOperand != null)
            {
                // is it an objectName (var or funcCall)?
                if (finalOperand.ContentType == OperandType.ObjectName)
                {
                    //the expression placed after(OperandRight) has an opening parenthesis?
                    if (_exprOperandRight.StartsWithOpeningParenthesis)
                    {
                        // so this operand is a function call
                        state.Set(ExprTokensParserStateCode.OperandFunctionCall);

                        var exprFunctionCall = new ExprFunctionCall();
                        exprFunctionCall.FunctionName = finalOperand.Operand;
                        exprFunctionCall.AddFirstParameter(_exprOperandRight);

                        _exprOperandRight = exprFunctionCall;
                        return true;
                    }
                }
            }

            // error, unexpected token, exp: a= 12,45
            var error = result.AddError(ErrorCode.UnexpectedToken, exprToDecode.Token);
            //var error = new ExprError();
            //error.Code = ErrorCode.UnexpectedToken;
            //error.Token = exprToDecode.Token;

            // adds the stack content to the error, to help debugging
            // todo:

            // before the right operand
            error.AddParam("Where", "TokenBeforeOperandRight");
            //result.ListError.Add(error);
            return false;
        }


        private bool ProcessStateOperatorComparison(ExprTokensParserState state, Stack<ExpressionBase> stack, ExpressionBase exprToDecode, ParseResult result)
        {
            // the token should be the left operand (final or expr), exp: (A=B)
            ExpressionBase exprOperand;
            if (IsOperandOrExpr(exprToDecode, out exprOperand))
            {
                state.Set(ExprTokensParserStateCode.OperandLeftComparison);
                _exprOperandLeft = exprOperand;
                return true;
            }

            // todo: others cases
            var error = result.AddError(ErrorCode.UnexpectedToken, exprToDecode.Token);
            //var error = new ExprError();
            //error.Code = ErrorCode.UnexpectedToken;
            //error.Token = exprToDecode.Token;

            // adds the stack content to the error, to help debugging
            // todo:
            error.AddParam("Where", "TokenBeforeOperatorComparison");
            result.ListError.Add(error);
            return false;
        }


        /// <summary>
        /// Process operator logical.
        /// 
        /// exprLeft operator exprRight
        /// </summary>
        /// <param name="state"></param>
        /// <param name="stack"></param>
        /// <param name="exprToDecode"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool ProcessStateOperatorLogical(ExprTokensParserState state, Stack<ExpressionBase> stack, ExpressionBase exprToDecode, ParseResult result)
        {
            // the token should be the left operand (final or expr), exp: (A=B)
            ExpressionBase exprOperand;
            if (IsOperandOrExpr(exprToDecode, out exprOperand))
            {
                state.Set(ExprTokensParserStateCode.OperandLeftLogical);
                _exprOperandLeft = exprOperand;
                return true;
            }

            // is the current token an open bracket?
            ExprBracketOpen exprBracketOpen = exprToDecode as ExprBracketOpen;
            if (exprBracketOpen != null)
            {
                // the next token is the not operator, exp: (not a)
                if (_currOperatorLogicalNot != null)
                {
                    // ok, build the expr: logical not operand.
                    state.Set(ExprTokensParserStateCode.PushExprLogicalNot);
                    return true;
                }
            }

            // todo: others cases
            var error = result.AddError(ErrorCode.UnexpectedToken, exprToDecode.Token);
            //var error = new ExprError();
            //error.Code = ErrorCode.UnexpectedToken;
            //error.Token = exprToDecode.Token;

            // adds the stack content to the error, to help debugging
            // todo:
            error.AddParam("Where", "TokenBeforeOperatorLogical");
            result.ListError.Add(error);
            return false;
        }

        /// <summary>
        /// .. (Not Expr 
        /// .. and Not Expr
        /// 
        /// The expr is saved in OperandRight.
        /// </summary>
        /// <param name="stack"></param>
        /// <param name="exprToDecode"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool ProcessStateOperatorLogicalNot(ExprTokensParserState state, Stack<ExpressionBase> stack, ExpressionBase exprToDecode, ParseResult result)
        {
            ExprError error;

            // is the token an open bracket? exp (not a)
            ExprBracketOpen exprBracketOpen = exprToDecode as ExprBracketOpen;
            if (exprBracketOpen != null)
            {
                ExprLogicalNot exprLogicalNotNew = new ExprLogicalNot();
                exprLogicalNotNew.ExprBase = _exprOperandRight;
                _exprOperandRight = exprLogicalNotNew;
                _exprOperandRight.StartsWithOpeningParenthesis = true;

                // ok build the expression and push it on the stack
                state.Set(ExprTokensParserStateCode.PushExprLogicalNot);
                return true;
            }

            // is the token a logical operator? (but not the NOT operator), exp : a OR NOT b
            ExprOperatorLogical exprOperatorLogical = exprToDecode as ExprOperatorLogical;
            if (exprOperatorLogical != null)
            {
                // attention, 2 expr à créer: ExprLogical, left=operand, right: logicalNot

                // ok, build the expr: logical not operand.
                _currOperatorLogical = exprOperatorLogical;
                state.Set(ExprTokensParserStateCode.OperatorLogical); //, ExprTokensParserStateOption.RightExprLogicalNot); 

                ExprLogicalNot exprLogicalNotRight = new ExprLogicalNot();
                exprLogicalNotRight.ExprBase = _exprOperandRight;
                // becomes the new right operand
                _exprOperandRight = exprLogicalNotRight;
                return true;
            }

            // the current token is a logical operator? (but not the NOT operator)
            ExprOperatorLogicalNot exprLogicalNot = exprToDecode as ExprOperatorLogicalNot;
            if (exprLogicalNot != null)
            {
                // error!, its like: a not not b
                error = new ExprError();
                error.Code = ErrorCode.ExprNotBeforeNotIsUnanthorized;
                error.Token = exprToDecode.Token;
                result.ListError.Add(error);
                return false;
            }


            // if here, the expression is wrong
            // error case, exp, a = not b
            // no more token in the stack!
            error = result.AddError(ErrorCode.UnexpectedTokenBeforeNot, exprToDecode.Token);
            //error = new ExprError();
            //error.Code = ErrorCode.UnexpectedTokenBeforeNot;
            //error.Token = exprToDecode.Token;
            //result.ListError.Add(error);
            return false;
        }

        /// <summary>
        /// Process operator calculation.
        /// 
        /// 
        /// exprLeft operator exprRight)
        /// 
        /// WF of events:
        /// OperandRight  -> OperatorCalculation  -> OperandLeftCalculation  -1-> PushExprCalculation
        ///               ^                         2|              
        ///               |__________________________|
        ///
        /// </summary>
        /// <param name="state"></param>
        /// <param name="stack"></param>
        /// <param name="exprToDecode"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool ProcessStateOperatorCalculation(ExprTokensParserState state, Stack<ExpressionBase> stack, ExpressionBase exprToDecode, ParseResult result)
        {
            // the token should be the left operand (final or expr), exp: A+B
            ExpressionBase exprOperand;
            if (IsOperandOrExpr(exprToDecode, out exprOperand))
            {
                state.Set(ExprTokensParserStateCode.OperandLeftCalculation);

                // save the operand
                _currListOperand.Insert(0,exprOperand);

                // todo: remove
                _exprOperandLeft = exprOperand;
                return true;
            }

            var error = result.AddError(ErrorCode.UnexpectedToken, exprToDecode.Token);

            // adds the stack content to the error, to help debugging
            string stackContent = StackToString(stack);

            error.AddParam("Where", "TokenBeforeOperatorCalculation");
            error.AddParam("Stack", stackContent);
            return false;
        }

        /// <summary>
        /// The state: is operand left of a comparison:
        /// 
        /// so the current token can be:
        /// 1/ opening parenthesis:   ...(OperandLeft CompOper OperandRight)
        ///     so the comparison expression full, next step: build it.
        ///     
        /// 2/ ??? todo: pb si expr: fct(a) > b
        /// </summary>
        /// <param name="state"></param>
        /// <param name="stack"></param>
        /// <param name="exprToDecode"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool ProcessStateOperandLeftComparison(ExprTokensParserState state, Stack<ExpressionBase> stack, ExpressionBase exprToDecode, ParseResult result)
        {
            //-1---the token should an open bracket, exp: (A=B)
            ExprBracketOpen openBracket;
            if (IsOpenBracket(exprToDecode, out openBracket))
            {
                // so the next step is to build the expresssion (OperandLeft operator OperandRight)
                state.Set(ExprTokensParserStateCode.PushExprComparison);

                ExprComparison exprComparison = new ExprComparison();
                exprComparison.Operator = _currOperatorComparison.Operator;
                exprComparison.ExprLeft = _exprOperandLeft;
                exprComparison.ExprRight = _exprOperandRight;
                // needed the expr is a functionCall parameter, exp: fct(a=b)
                exprComparison.StartsWithOpeningParenthesis = true;

                // the expression starts at the opening parenthesis
                exprComparison.Token = openBracket.Token;

                // the compo expr becomes the new right operand
                _exprOperandRight = exprComparison;
                return true;
            }

            // if here, the expression is wrong
            var error = result.AddError(ErrorCode.UnexpectedToken, exprToDecode.Token);

            // adds the stack content to the error, to help debugging
            // todo:
            error.AddParam("Where", "TokenBeforeOperatorCalculation");

            //result.ListError.Add(error);
            return false;
        }


        /// <summary>
        /// Operand left logical is the previous decoded token.
        /// ( OperandLeft LogicalOperator OperandRight
        /// 
        /// </summary>
        /// <param name="stack"></param>
        /// <param name="exprToDecode"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool ProcessStateOperandLeftLogical(ExprTokensParserState state, Stack<ExpressionBase> stack, ExpressionBase exprToDecode, ParseResult result)
        {
            // the token should an open bracket, exp: (A=B)
            ExprBracketOpen openBracket;
            if (IsOpenBracket(exprToDecode, out openBracket))
            {
                // so the next step is to build an expresssion (OperandLeft operator OperandRight)
                state.Set(ExprTokensParserStateCode.PushExprLogical);

                ExprLogical exprLogical = new ExprLogical();
                //expr.Token = token;
                exprLogical.Operator = _currOperatorLogical.Operator;
                exprLogical.ExprLeft = _exprOperandLeft;
                // can be: operand, exprLog, exprLogNOT, exprComp, functionCall
                exprLogical.ExprRight = _exprOperandRight;

                // needed the expr is a functionCall parameter, exp: fct(a=b)
                exprLogical.StartsWithOpeningParenthesis = true;

                // the expression starts at the opening parenthesis
                exprLogical.Token = openBracket.Token;

                // the compo expr becomes the new right operand
                _exprOperandRight = exprLogical;

                return true;
            }

            // if here, the expression is wrong
            var error = result.AddError(ErrorCode.UnexpectedToken, exprToDecode.Token);

            // adds the stack content to the error, to help debugging
            // todo:
            error.AddParam("Where", "TokenBeforeOperatorCalculation");

            //result.ListError.Add(error);
            return false;
        }

        /// <summary>
        /// The state: is operand left of a calculation:
        /// 
        /// so the current token can be:
        /// 1/ opening parenthesis:   ...(OperandLeft calcOper OperandRight)
        ///     so the calculation expression is full, next step: build it.
        ///     
        /// 2/ is the token a calculation operator? 
        ///    to manage calc expr with more than one operator/two operands.
        ///   exp: A+B-C
        ///
        /// WF of events:
        /// OperandRight  -> OperatorCalculation  -> OperandLeftCalculation  -1-> PushExprCalculation
        ///               ^                         2|              
        ///               |__________________________|
        /// </summary>
        /// <param name="state"></param>
        /// <param name="stack"></param>
        /// <param name="exprToDecode"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool ProcessStateOperandLeftCalculation(ExprTokensParserState state, Stack<ExpressionBase> stack, ExpressionBase exprToDecode, ParseResult result)
        {
            //-1---is the token an open bracket? exp: (A=B)
            ExprBracketOpen openBracket;
            if (IsOpenBracket(exprToDecode, out openBracket))
            {
                // so the next step is to build the expresssion (OperandLeft operator OperandRight)
                state.Set(ExprTokensParserStateCode.PushExprCalculation);

                ExprCalculation exprCalculation = new ExprCalculation();

                // push the operands and the operator into the calculation expression
                exprCalculation.ListOperator.AddRange(_currListOperatorCalculation);
                exprCalculation.ListExprOperand.AddRange(_currListOperand);

                // XXXXX-TODO: supprimer les 3 lignes ci-dessous après implementation du multi-calculs
                //exprCalculation.Operator = _currOperatorCalculation.Operator;
                //exprCalculation.ExprLeft = _exprOperandLeft;
                //exprCalculation.ExprRight = _exprOperandRight;
                // XXXXXXXXXXX

                // needed the expr is a functionCall parameter, exp: fct(a=b)
                exprCalculation.StartsWithOpeningParenthesis = true;

                // the expression starts at the opening parenthesis
                exprCalculation.Token = openBracket.Token;

                // the compo expr becomes the new right operand
                _exprOperandRight = exprCalculation;
                return true;
            }

            //-2---is the token a calculation operator? exp: (A+B-C)
            ExprOperatorCalculation operatorCalculation;
            if (IsOperatorCalculation(exprToDecode, out operatorCalculation))
            {
                // so the next step is an, exp: "operand  Operand... operator Operand operator Operand)"
                state.Set(ExprTokensParserStateCode.OperatorCalculation);

                _currListOperatorCalculation.Insert(0, operatorCalculation);
                return true;
            }

            // if here, the expression is wrong
            var error = result.AddError(ErrorCode.UnexpectedToken, exprToDecode.Token);

            // adds the stack content to the error, to help debugging
            string stackContent = StackToString(stack);
            error.AddParam("Where", "TokenBeforeOperatorCalculation");
            error.AddParam("Stack", "stackContent");

            return false;
        }

        /// <summary>
        /// A functionCall parameter separator is found.
        /// exp: , param )
        /// 
        /// The current token should be:
        /// -An expression (another parameter of the functionCall).
        /// </summary>
        /// <param name="state"></param>
        /// <param name="stack"></param>
        /// <param name="exprToDecode"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool ProcessStateFunctionCallParamSeparator(ExprTokensParserState state, Stack<ExpressionBase> stack, ExpressionBase exprToDecode, ParseResult result)
        {
            // the token should be the left operand (final or expr), exp: (A=B)
            ExpressionBase exprOperand;
            if (IsOperandOrExpr(exprToDecode, out exprOperand))
            {
                // save this new functionCall parameter
                state.ListFunctionCallParam.Add(exprToDecode);

                // the next token should be: a separator or an opening parenthesis
                //state.Set(ExprTokensParserStateCode.OperandLeftLogical);
                state.Set(ExprTokensParserStateCode.FunctionCallParameter);
                return true;
            }


            // if here, the expression is wrong
            var error = result.AddError(ErrorCode.UnexpectedToken, exprToDecode.Token);
            //var error = new ExprError();
            //error.Code = ErrorCode.UnexpectedToken;
            //error.Token = exprToDecode.Token;
            //result.ListError.Add(error);
            return false;

        }
        /// <summary>
        /// The current state is: FunctionCall parameter.
        /// so the next token should be: a separator or an opening parenthesis
        /// 
        /// cases:
        /// 1/ ... ( param
        /// 2/ ... , param
        /// </summary>
        /// <param name="state"></param>
        /// <param name="stack"></param>
        /// <param name="exprToDecode"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool ProcessStateFunctionCallParameter(ExprTokensParserState state, Stack<ExpressionBase> stack, ExpressionBase exprToDecode, ParseResult result)
        {
            // the token should an opening parenthesis 
            ExprBracketOpen openBracket;
            if (IsOpenBracket(exprToDecode, out openBracket))
            {
                // so the next step is to get the functionCall Name
                state.Set(ExprTokensParserStateCode.FunctionCallParamsGetFinished);
                return true;
            }

            // the token should a functionCall parameter separator 
            ExprFunctionCallParameterSeparator paramSeparator;
            if (IsFunctionCallParameterSeparator(exprToDecode, out paramSeparator))
            {
                state.Set(ExprTokensParserStateCode.FunctionCallParamSeparator);
                return true;
            }

            // if here, the expression is wrong
            var error = result.AddError(ErrorCode.UnexpectedToken, exprToDecode.Token);
            //var error = new ExprError();
            //error.Code = ErrorCode.UnexpectedToken;
            //error.Token = exprToDecode.Token;
            //result.ListError.Add(error);
            return false;
        }

        /// <summary>
        /// The current decoded tokens is an operand function call.
        /// cases:
        ///  1/  ( fct(a
        ///  2/  (a > fct(b
        ///  
        /// </summary>
        /// <param name="stack"></param>
        /// <param name="exprToDecode"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool ProcessStateOperandFunctionCall(ExprTokensParserState state, Stack<ExpressionBase> stack, ExpressionBase exprToDecode, ParseResult result)
        {
            // 1/ the token is an openning parenthesis, exp: (fct(a))
            ExprBracketOpen openBracket;
            if (IsOpenBracket(exprToDecode, out openBracket))
            {
                // so the next step is to build an expresssion (OperandLeft operator OperandRight)
                state.Set(ExprTokensParserStateCode.PushExprFunctionCall);
                _exprOperandRight.StartsWithOpeningParenthesis = true;
                return true;
            }

            // 2/ the token is a comparison operator?
            ExprOperatorComparison exprOperatorComparison = exprToDecode as ExprOperatorComparison;
            if (exprOperatorComparison != null)
            {
                // attention, 2 expr à créer: ExprLogical, left=operand, right: functionCall

                _currOperatorComparison = exprOperatorComparison;
                state.Set(ExprTokensParserStateCode.OperatorComparison);
                return true;
            }

            // is the token a logical operator? (but not the NOT operator), exp : a And fct()
            ExprOperatorLogical exprOperatorLogical = exprToDecode as ExprOperatorLogical;
            if (exprOperatorLogical != null)
            {
                // attention, 2 expr à créer: ExprLogical, left=operand, right: functionCall

                // ok, build the expr
                _currOperatorLogical = exprOperatorLogical;

                // todo: pas sur que ce soit géré derriere!
                state.Set(ExprTokensParserStateCode.OperatorLogical);
                return true;
            }


            // if here, the expression is wrong
            var error = result.AddError(ErrorCode.UnexpectedToken, exprToDecode.Token);
            //var error = new ExprError();
            //error.Code = ErrorCode.UnexpectedToken;
            //error.Token = exprToDecode.Token;
            //result.ListError.Add(error);
            return false;
        }


        /// <summary>
        /// All params of a functionCall are found. and also the opening parenthesis.
        /// Now the functionCall name is expected.
        /// 
        /// exp: fct Params
        /// </summary>
        /// <param name="state"></param>
        /// <param name="stack"></param>
        /// <param name="exprToDecode"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool ProcessStateFunctionCallParamsGetFinished(ExprTokensParserState state, Stack<ExpressionBase> stack, ExpressionBase exprToDecode, ParseResult result)
        {
            ExprFinalOperand exprFinalOperand = exprToDecode as ExprFinalOperand;
            if (exprFinalOperand != null)
            {
                // the final should be an objectName
                if (exprFinalOperand.ContentType == OperandType.ObjectName)
                {
                    // ok its a function call and the name is found
                    ExprFunctionCall exprFunctionCall = new ExprFunctionCall();
                    exprFunctionCall.FunctionName = exprFinalOperand.Operand;

                    // add parameters, in the right order
                    foreach (ExpressionBase exprParam in state.ListFunctionCallParam)
                        exprFunctionCall.AddFirstParameter(exprParam);

                    _exprOperandRight = exprFunctionCall;
                    state.Set(ExprTokensParserStateCode.PushExprFunctionCall);
                    return true;
                }
            }

            // if here, the expression is wrong
            var error = result.AddError(ErrorCode.UnexpectedToken, exprToDecode.Token);
            //var error = new ExprError();
            //error.Code = ErrorCode.UnexpectedToken;
            //error.Token = exprToDecode.Token;
            //result.ListError.Add(error);
            return false;
        }

        /// <summary>
        /// current state is: () or (Expr)  Opening and closing parenthesis.
        /// cases:
        /// 1/ functioncall, exp fct() or fct(Expr)
        /// 2/ Not(Expr)
        /// 
        /// </summary>
        /// <param name="stack"></param>
        /// <param name="exprToDecode"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool ProcessStateOpenedAndClosedBrackets(ExprTokensParserState state, Stack<ExpressionBase> stack, ExpressionBase exprToDecode, ParseResult result)
        {
            ExprError error;

            //-1---is it a final operand ?
            ExprFinalOperand operand = exprToDecode as ExprFinalOperand;
            if (operand != null)
            {
                if (operand.ContentType == OperandType.ObjectName)
                {
                    // so the next step is to build the function call expresssion: fct()
                    var exprFunctionCall = new ExprFunctionCall();
                    exprFunctionCall.FunctionName = operand.Operand;

                    // an operand is present? exp: (expr)
                    if (state.Option == ExprTokensParserStateOption.HasOperand)
                    {
                        exprFunctionCall.AddFirstParameter(_exprOperandRight);
                    }

                    // now becomes the new right operand
                    _exprOperandRight = exprFunctionCall;

                    state.Set(ExprTokensParserStateCode.PushExprFunctionCall);
                    return true;
                }

                // if here, the expression is wrong
                error = result.AddError(ErrorCode.UnexpectedToken, exprToDecode.Token);
                //error = new ExprError();
                //error.Code = ErrorCode.UnexpectedToken;
                //error.Token = exprToDecode.Token;
                //result.ListError.Add(error);
                return false;
            }

            //-2---Is it the logicalNot operator?
            ExprOperatorLogicalNot exprOperatorLogicalNot = exprToDecode as ExprOperatorLogicalNot;
            if (exprOperatorLogicalNot != null)
            {
                // build the expression
                ExprLogicalNot exprNot = new ExprLogicalNot();
                //expr.Token = token;
                exprNot.ExprBase = _exprOperandRight;
                _exprOperandRight = exprNot;
                state.Set(ExprTokensParserStateCode.PushExprLogicalNot);

                return true;
            }

            // if here, the expression is wrong
            error = result.AddError(ErrorCode.UnexpectedToken, exprToDecode.Token);
            //error = new ExprError();
            //error.Code = ErrorCode.UnexpectedToken;
            //error.Token = exprToDecode.Token;
            //result.ListError.Add(error);
            return false;
        }

        /// <summary>
        /// décode l'expression ou l'opérande, partie droite ou gauche.
        /// renvoie true si ok ou erreur, renvoie false si erreur fatale.
        /// </summary>
        /// <param name="stack"></param>
        /// <param name="token"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool IsOperandOrExpr(ExpressionBase exprToDecode, out ExpressionBase exprOrFinal)
        {
            exprOrFinal = null;

            // is it a comparison expr?
            ExprComparison exprComp = exprToDecode as ExprComparison;
            if (exprComp != null)
            {
                exprOrFinal = exprComp;
                return true;
            }

            // is it a logical expr?
            ExprLogical exprLogical = exprToDecode as ExprLogical;
            if (exprLogical != null)
            {
                exprOrFinal = exprLogical;
                return true;
            }

            // is the expression to decode, a not logical expression (already decoded in fact)?
            // exp: ( ( not a ) ) -> ( ExprNot )
            ExprLogicalNot exprLogicalNot = exprToDecode as ExprLogicalNot;
            if (exprLogicalNot != null)
            {
                exprOrFinal = exprLogicalNot;
                return true;
            }

            // is it a calculation expr?
            ExprCalculation exprCalc = exprToDecode as ExprCalculation;
            if (exprCalc != null)
            {
                exprOrFinal = exprCalc;
                return true;
            }

            // is it a functionCall expr?
            ExprFunctionCall exprFunctionCall = exprToDecode as ExprFunctionCall;
            if (exprFunctionCall != null)
            {
                exprOrFinal = exprFunctionCall;
                return true;
            }

            // is it a final operand ?
            ExprFinalOperand operand = exprToDecode as ExprFinalOperand;
            if (operand != null)
            {
                exprOrFinal = operand;
                return true;
            }

            // not an operand
            return false;
        }


        private bool IsOperatorComparison(ExpressionBase exprBase, out ExprOperatorComparison opertorFound)
        {
            opertorFound = exprBase as ExprOperatorComparison;
            if (opertorFound != null)
                return true;

            return false;
        }

        private bool IsOperatorLogical(ExpressionBase exprBase, out ExprOperatorLogical opertorFound)
        {
            opertorFound = exprBase as ExprOperatorLogical;
            if (opertorFound != null)
                return true;

            return false;
        }

        private bool IsOperatorLogicalNot(ExpressionBase exprBase, out ExprOperatorLogicalNot opertorFound)
        {
            opertorFound = exprBase as ExprOperatorLogicalNot;
            if (opertorFound != null)
                return true;

            return false;
        }

        private bool IsOperatorCalculation(ExpressionBase exprBase, out ExprOperatorCalculation opertorFound)
        {
            opertorFound = exprBase as ExprOperatorCalculation;
            if (opertorFound != null)
                return true;

            return false;
        }

        /// <summary>
        /// Is the toekn an open bracket?
        /// </summary>
        /// <param name="token"></param>
        /// <param name="exprBase"></param>
        /// <param name="openBracketFound"></param>
        /// <returns></returns>
        private bool IsOpenBracket(ExpressionBase exprBase, out ExprBracketOpen openBracketFound)
        {
            // est-ce un operateur ?
            openBracketFound = exprBase as ExprBracketOpen;
            if (openBracketFound != null)
                return true;

            return false;
        }

        private bool IsFunctionCallParameterSeparator(ExpressionBase exprBase, out ExprFunctionCallParameterSeparator paramSeparatorFound)
        {
            // est-ce un operateur ?
            paramSeparatorFound = exprBase as ExprFunctionCallParameterSeparator;
            if (paramSeparatorFound != null)
                return true;

            return false;
        }

        /// <summary>
        /// Get/extract the next token from the stack.
        /// </summary>
        /// <param name="stack"></param>
        /// <param name="token"></param>
        /// <param name="result"></param>
        /// <param name="errCode"></param>
        /// <param name="exprBase"></param>
        /// <returns></returns>
        private bool GetNextStackItem(Stack<ExpressionBase> stack, ParseResult result, ErrorCode errCode, out ExpressionBase exprBase)
        {
            exprBase = null;
            ExprError error;

            // the stack should contains one token at least
            if (stack.Count == 0)
            {
                // no more token in the stack!
                error = new ExprError();
                error.Code = errCode;
                //error.Token = token;
                result.ListError.Add(error);

                return false;
            }

            // get the top of the stack
            exprBase = stack.Pop();
            return true;
        }
        #endregion

        //##############################################################
        #region Push expression on the stack.


        /// <summary>
        /// Push the built expression.
        /// </summary>
        /// <param name="stack"></param>
        /// <returns></returns>
        private bool PushExprComparison(Stack<ExpressionBase> stack)
        {
            stack.Push(_exprOperandRight);
            return true;
        }

        /// <summary>
        /// Push the built expression.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="stack"></param>
        /// <returns></returns>
        private bool PushExprLogical(Stack<ExpressionBase> stack)
        {
            stack.Push(_exprOperandRight);
            return true;
        }

        /// <summary>
        /// Push the built expression.
        /// exp: (not a)
        /// </summary>
        /// <param name="stack"></param>
        /// <returns></returns>
        private bool PushExprLogicalNot(Stack<ExpressionBase> stack)
        {
            stack.Push(_exprOperandRight);
            return true;
        }

        /// <summary>
        /// Push the built expression.
        /// </summary>
        /// <param name="stack"></param>
        /// <returns></returns>
        private bool PushExprCalculation(Stack<ExpressionBase> stack)
        {
            stack.Push(_exprOperandRight);
            return true;
        }

        private bool PushExprSingleOperand(Stack<ExpressionBase> stack)
        {
            // just push the operand in the stack
            stack.Push(_exprOperandRight);
            return true;
        }

        /// <summary>
        /// The functionCall expression is created before coming here.
        /// Contains (or not) parameters.
        /// </summary>
        /// <param name="state"></param>
        /// <param name="stack"></param>
        /// <returns></returns>
        private bool PushExprFunctionCall(Stack<ExpressionBase> stack)
        {
            stack.Push(_exprOperandRight);
            return true;
        }


        #endregion


        /// <summary>
        /// Print the stack content into a string
        /// </summary>
        /// <param name="stack"></param>
        /// <returns></returns>
        private string StackToString(Stack<ExpressionBase> stack)
        {
            string stackContent = "";
            string tokenValue = "";

            foreach(ExpressionBase exprBase in stack)
            {
                if (exprBase.Token == null)
                    tokenValue = "(null)";
                else
                    tokenValue = exprBase.Token.Value;

                stackContent += " tokPos: " + exprBase.Token.Position + ", Tok: " + tokenValue;

                // todo: add more detail of the expression!! 

            }

            return stackContent;
        }

    }
}
