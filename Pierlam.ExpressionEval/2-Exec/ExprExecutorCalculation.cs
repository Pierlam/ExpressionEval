using System;
using System.Collections.Generic;
using System.Text;

namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// Execute calculation, after the parse.
    /// Each Expression are executed/evaluated.
    /// 
    /// The function return a single main addition/subtraction.
    /// 
    /// exp: 
    /// a+b        -> a+b
    /// a*b        -> ??   cas particulier
    /// 
    /// a+b*c      -> a+(b*c)
    /// a*b+c*d    -> (a*b)+(c*d)
    /// a*b/c+d-e  -> (a*b/c)+d-e
    /// 
    /// </summary>
    public class ExprExecutorCalculation
    {
        /// <summary>
        /// calculation operator type workflow.
        /// To decode raw expression and build a main addition expression.
        /// </summary>
        enum CalcOperatorTypeWF
        {
            Nothing, Plus, Mul
        }

        enum CalcIntOrDouble
        {
            NotDefined,
            IsInt,
            IsDouble,
        }

        /// <summary>
        /// Process the calculation expression.
        /// The expression can have two operands (one operator) at least and more.
        /// 
        /// exp: a+b,  a+b*c
        /// 
        /// Manage the operator priority: multiplication and division first, then addition and substraction.
        /// a+b*c  -> a+(b*c)
        /// 
        /// </summary>
        /// <param name="execResult"></param>
        /// <param name="exprCalculation"></param>
        /// <param name="listExprExecBase"></param>
        /// <param name="exprExecCalcResult"></param>
        /// <returns></returns>
        public bool Process(ExecResult execResult, ExprCalculation exprCalculation, List<ExpressionExecBase> listExprExecBase, out ExpressionExecBase exprExecCalcResult)
        {
            exprExecCalcResult = null;

            //----organize calculation depending on operators priority: plus and mul
            ExprExecCalcAdd mainCalcAdd;

            // build expression with priority: first calculate mult and div, and then add and minus.
            if (!BuildCalculationExpressionWithPriority(execResult, exprCalculation, listExprExecBase, out mainCalcAdd))
                return false;

            //----do the calculation of all sub expression multiplications
            if (!DoCalculationSubExprMul(execResult, exprCalculation, mainCalcAdd))
                return false;

            //----do the calculation main expression additions
            return DoCalculationMainExprAdditions(execResult, exprCalculation, mainCalcAdd, out exprExecCalcResult);
        }

        /// <summary>
        /// a+b      -> a+b
        /// a*b      -> ?? cas particulier
        /// a+b*c    -> a+(b*c)
        /// a*b+c*d  -> (a*b)+(c*d)
        /// </summary>
        /// <param name="execResult"></param>
        /// <param name="exprCalculation"></param>
        /// <param name="listExprExecBase"></param>
        /// <param name="listCalcAdd"></param>
        /// <returns></returns>
        private bool BuildCalculationExpressionWithPriority(ExecResult execResult, ExprCalculation exprCalculation, List<ExpressionExecBase> listExprExecBase, out ExprExecCalcAdd mainCalcAdd)
        {
            // init the main additions/sub
            mainCalcAdd = new ExprExecCalcAdd();

            //bool currOperatorIsAdd = true;

            CalcOperatorTypeWF calcOperatorTypeWF = CalcOperatorTypeWF.Nothing;

            ExprExecCalcMul exprExecCalcMul=null;

            int pos = 0;

            // scan operators
            while(true)
            {
                // no more operator or operand
                if (pos >= exprCalculation.ListOperator.Count)
                {
                    // the current calc operation is an add?
                    if(calcOperatorTypeWF== CalcOperatorTypeWF.Plus)
                    {
                        // the current calc operation is an add/sub; add the last operand
                        mainCalcAdd.AddOperandNumber(listExprExecBase[pos]);

                        return true;
                    }
                    else
                    {
                        // the current calc operation is an mul/div
                        exprExecCalcMul.AddOperandNumber(listExprExecBase[pos]);
                        return true;
                    }
                }

                // todo: sur?? il y a un operande de plus que les opérateurs
                if (pos >= listExprExecBase.Count)
                    break;

                // analyze the current operator: its an add/sous or a mul/div
                CalcOperatorTypeWF calcOperatorTypeWFOut;
                ExprExecCalcMul exprExecCalcMulOut;
                if (!BuildCalcExprProcessOperator(execResult, exprCalculation, listExprExecBase, mainCalcAdd, pos, calcOperatorTypeWF, exprExecCalcMul, out calcOperatorTypeWFOut, out exprExecCalcMulOut))
                    return false;

                // the workflow is updated by the function
                calcOperatorTypeWF = calcOperatorTypeWFOut;
                exprExecCalcMul = exprExecCalcMulOut;

                // goto next operator/operand
                pos++;
            }
            return true;
        }

        /// <summary>
        /// analyze the current operator: its an add/sous or a mul/div.
        /// 
        /// </summary>
        /// <param name="execResult"></param>
        /// <param name="exprCalculation"></param>
        /// <returns></returns>
        private bool BuildCalcExprProcessOperator(ExecResult execResult, ExprCalculation exprCalculation, List<ExpressionExecBase> listExprExecBase, ExprExecCalcAdd mainCalcAdd, int pos, CalcOperatorTypeWF calcOperatorTypeWFIn, ExprExecCalcMul exprExecCalcMulIn, out CalcOperatorTypeWF calcOperatorTypeWFOut, out ExprExecCalcMul exprExecCalcMulOut)
        {
            exprExecCalcMulOut = null;

            if (exprCalculation.ListOperator[pos].Operator == OperatorCalculationCode.Plus ||
                exprCalculation.ListOperator[pos].Operator == OperatorCalculationCode.Minus)
            {
                // manage the previous case, exp: 2*3+4  -> (2*3)+4 finish the 2*3 mul expr and continue the addition
                if (calcOperatorTypeWFIn == CalcOperatorTypeWF.Mul)
                {
                    // add the last operand to the mul expr
                    exprExecCalcMulIn.AddOperandNumber(listExprExecBase[pos]);
                    exprExecCalcMulOut = exprExecCalcMulIn;

                    // now its an addition expression
                    calcOperatorTypeWFOut = CalcOperatorTypeWF.Plus;
                    //mainCalcAdd.AddOperandNumber(listExprExecBase[pos]);
                    mainCalcAdd.ListOperator.Add(exprCalculation.ListOperator[pos]);
                    return true;
                }

                // the operator is a + (addition)
                calcOperatorTypeWFOut = CalcOperatorTypeWF.Plus;

                // save the current operand value and the current operator
                mainCalcAdd.AddOperandNumber(listExprExecBase[pos]);
                mainCalcAdd.ListOperator.Add(exprCalculation.ListOperator[pos]);
                return true;
            }

            // its the first operator of the expression or the previous operator was: +/plus
            if (calcOperatorTypeWFIn == CalcOperatorTypeWF.Nothing ||
                calcOperatorTypeWFIn == CalcOperatorTypeWF.Plus)
            {
                // start a new calc expression
                exprExecCalcMulOut = new ExprExecCalcMul();
                exprExecCalcMulOut.AddOperandNumber(listExprExecBase[pos]);
                exprExecCalcMulOut.ListOperator.Add(exprCalculation.ListOperator[pos]);
                calcOperatorTypeWFOut = CalcOperatorTypeWF.Mul;

                // save it in the main addition expression
                mainCalcAdd.ListExprExecCalc.Add(exprExecCalcMulOut);
                return true;
            }

            // the previous operator is a mul
            exprExecCalcMulIn.AddOperandNumber(listExprExecBase[pos]);
            exprExecCalcMulIn.ListOperator.Add(exprCalculation.ListOperator[pos]);
            calcOperatorTypeWFOut = CalcOperatorTypeWF.Mul;
            exprExecCalcMulOut = exprExecCalcMulIn;
            return true;
        }

        /// <summary>
        /// Do calculation of all multiplication sub expression.
        /// replace it by the result value.
        /// </summary>
        /// <param name="execResult"></param>
        /// <param name="exprCalculation"></param>
        /// <param name="mainCalcAdd"></param>
        /// <returns></returns>
        private bool DoCalculationSubExprMul(ExecResult execResult, ExprCalculation exprCalculation, ExprExecCalcAdd mainCalcAdd)
        {
            int pos = -1;

            List<ExprExecCalcBase> listListExprExecCalcResult = new List<ExprExecCalcBase>();

            foreach (ExprExecCalcBase execCalcBase in mainCalcAdd.ListExprExecCalc)
            {
                pos++;

                // the item should be a number (int or double) or a mul expr
                ExprExecCalcMul execCalcMul = execCalcBase as ExprExecCalcMul;
                // not a calc multiplication, next
                if (execCalcMul == null)
                {
                    listListExprExecCalcResult.Add(execCalcBase);
                    continue;
                }

                // do the calculation of the mul expr, and replace it by the result value
                ExprExecCalcValue execCalcValueResult;
                DoCalculationExprMul(execResult, exprCalculation, execCalcMul, out execCalcValueResult);
                // save the new value (in place of the mul expr)
                listListExprExecCalcResult.Add(execCalcValueResult);
            }

            // replace the result list 
            mainCalcAdd.ListExprExecCalc = listListExprExecCalcResult;

            return true;
        }

        /// <summary>
        /// Do the calculation of the multiplication/division expr comme l'add mais le rs va remplacer l'objet Mul dans le main add)
        /// 
        /// </summary>
        /// <param name="execResult"></param>
        /// <param name="exprCalculation"></param>
        /// <param name="mainCalcAdd"></param>
        /// <param name="exprExecCalcResult"></param>
        /// <returns></returns>
        private bool DoCalculationExprMul(ExecResult execResult, ExprCalculation exprCalculation, ExprExecCalcMul execCalcMul, out ExprExecCalcValue execCalcValueResult)
        {
            // the temporary result, to start the addition calculation
            ExprExecValueInt resInt = new ExprExecValueInt();

            // the integer neutral value, the first calculation is 1*operand[0]
            resInt.Value = 1;
            ExpressionExecBase exprExecCalcResult = resInt;

            ExpressionExecBase exprExecTmpResult = null;
            int pos = 0;

            // scan addition expressions, two by two operands
            foreach (ExprExecCalcValue execCalcValue in execCalcMul.ListExprExecCalcValue)
            {
                // the item should be a number: an int or a double

                // get the operator
                ExprOperatorCalculation operatorCalc;

                // the first calc is special: res := 0 + firstOperand
                if (pos == 0)
                {
                    // put the default neutral operator: +
                    operatorCalc = new ExprOperatorCalculation();
                    operatorCalc.Operator = OperatorCalculationCode.Multiplication;
                    //operatorCalc.Token = mainCalcAdd.ListOperator[0].Token;
                }
                else
                    // there one operator less than operand
                    operatorCalc = execCalcMul.ListOperator[pos - 1];

                // Do the calculation:   tmpRes := res +/- currentValue
                DoCalculationTwoOperands(execResult, exprCalculation, exprExecCalcResult, execCalcValue.ExprExecValue, operatorCalc, out exprExecTmpResult);

                // the current temporary result
                exprExecCalcResult = exprExecTmpResult;

                pos++;
            }

            // then replace the calc mul expr by the result
            execCalcValueResult = new ExprExecCalcValue();
            execCalcValueResult.ExprExecValue = exprExecTmpResult;
            //mainCalcAdd.ListExprExecCalc[posMulInMainAdd] = execCalcValueResult;

            return true;
        }

        /// <summary>
        /// Execute/evaluate the addition main expression.
        /// </summary>
        /// <param name="execResult"></param>
        /// <param name="exprCalculation"></param>
        /// <param name="listCalcAdd"></param>
        /// <returns></returns>
        private bool DoCalculationMainExprAdditions(ExecResult execResult, ExprCalculation exprCalculation, ExprExecCalcAdd mainCalcAdd, out ExpressionExecBase exprExecCalcResult)
        {
            // the temporary result, to start the addition calculation
            ExprExecValueInt resInt = new ExprExecValueInt();

            // the integer neutral value, the first calculation is 0+operand[0]
            resInt.Value = 0;
            exprExecCalcResult = resInt;

            ExpressionExecBase exprExecTmpResult;
            int pos = 0;

            // scan addition expressions, two by two operands
            foreach (ExprExecCalcBase execCalcBase in mainCalcAdd.ListExprExecCalc)
            {
                // the item should be a number: an int or a double
                ExprExecCalcValue execCalcValue = execCalcBase as ExprExecCalcValue;

                // get the operator
                ExprOperatorCalculation operatorCalc;

                // the first calc is special: res := 0 + firstOperand
                if (pos == 0)
                {
                    // put the default neutral operator: +
                    operatorCalc = new ExprOperatorCalculation();
                    operatorCalc.Operator = OperatorCalculationCode.Plus;
                    if(mainCalcAdd.ListOperator.Count>0)
                        operatorCalc.Token = mainCalcAdd.ListOperator[0].Token;
                }
                else
                    // there one operator less than operand
                    operatorCalc = mainCalcAdd.ListOperator[pos-1];

                // Do the calculation:   tmpRes := res +/- currentValue
                DoCalculationTwoOperands(execResult, exprCalculation, exprExecCalcResult, execCalcValue.ExprExecValue, operatorCalc, out exprExecTmpResult);

                // the current temporary result
                exprExecCalcResult = exprExecTmpResult;

                pos++;
            }

            return true;

        }

        /// <summary>
        /// Do the calculation: res := operandLeft operator operandRight.
        /// Both operand must be number, int or double.
        /// the operator can be: +, -, *, /.
        /// </summary>
        /// <param name="execResult"></param>
        /// <param name="exprExecBase"></param>
        /// <returns></returns>
        private bool DoCalculationTwoOperands(ExecResult execResult, ExprCalculation exprCalculation, ExpressionExecBase exprExecBaseLeft, ExpressionExecBase exprExecBaseRight, ExprOperatorCalculation operatorCalc, out ExpressionExecBase exprExecCalcResult)
        {
            exprExecCalcResult = null;

            CalcIntOrDouble calcIntOrDoubleLeft = CalcIntOrDouble.NotDefined;
            CalcIntOrDouble calcIntOrDoubleRight = CalcIntOrDouble.NotDefined;

            int valLeftInt = 0;
            int valRightInt = 0;
            double valLeftDouble = 0;
            double valRightDouble = 0;

            //---parse the left operand
            ExprExecValueInt exprExecValueLeftInt = exprExecBaseLeft as ExprExecValueInt;
            if (exprExecValueLeftInt != null)
            {
                valLeftInt = exprExecValueLeftInt.Value;
                calcIntOrDoubleLeft = CalcIntOrDouble.IsInt;
            }
            else
            {
                ExprExecValueDouble exprExecValueLeftDouble = exprExecBaseLeft as ExprExecValueDouble;
                if (exprExecValueLeftDouble != null)
                {
                    valLeftDouble = exprExecValueLeftDouble.Value;
                    calcIntOrDoubleLeft = CalcIntOrDouble.IsDouble;
                }
            }

            //---parse the right operand
            ExprExecValueInt exprExecValueRightInt = exprExecBaseRight as ExprExecValueInt;
            if (exprExecValueRightInt != null)
            {
                valRightInt = exprExecValueRightInt.Value;
                calcIntOrDoubleRight = CalcIntOrDouble.IsInt;
            }
            else
            {
                ExprExecValueDouble exprExecValueRightDouble = exprExecBaseRight as ExprExecValueDouble;
                if (exprExecValueRightDouble != null)
                {
                    valRightDouble = exprExecValueRightDouble.Value;
                    calcIntOrDoubleRight = CalcIntOrDouble.IsDouble;
                }
            }

            //----wrong type
            if (calcIntOrDoubleLeft == CalcIntOrDouble.NotDefined)
            {
                // other operators are not allowed on the boolean type (only bool)
                execResult.AddErrorExec(ErrorCode.ExprCalculationOperandTypeUnExcepted, "Position", exprExecBaseLeft.Expr.Token.Position.ToString(), "Operand", exprExecBaseLeft.Expr.Token.Value);

                return false;
            }
            if (calcIntOrDoubleRight == CalcIntOrDouble.NotDefined)
            {
                // other operators are not allowed on the boolean type (only bool)
                execResult.AddErrorExec(ErrorCode.ExprCalculationOperandTypeUnExcepted, "Position", exprExecBaseRight.Expr.Token.Position.ToString(), "Operand", exprExecBaseRight.Expr.Token.Value);

                return false;
            }

            // if one of both operand is an double, convert the other to a double
            if (calcIntOrDoubleLeft == CalcIntOrDouble.IsDouble || calcIntOrDoubleRight == CalcIntOrDouble.IsDouble)
            {
                if (calcIntOrDoubleLeft == CalcIntOrDouble.IsInt)
                    valLeftDouble = (double)valLeftInt;

                if (calcIntOrDoubleRight == CalcIntOrDouble.IsInt)
                    valRightDouble = (double)valRightInt;

                // used to define the calculation type
                calcIntOrDoubleLeft = CalcIntOrDouble.IsDouble;
            }

            //----calculate, depending on the operator: Plus
            if (operatorCalc.Operator == OperatorCalculationCode.Plus)
            {
                if (calcIntOrDoubleLeft == CalcIntOrDouble.IsDouble)
                {
                    ExprExecValueDouble resDouble = new ExprExecValueDouble();
                    resDouble.Value = valLeftDouble + valRightDouble;
                    exprExecCalcResult = resDouble;
                    return true;
                }

                ExprExecValueInt resInt = new ExprExecValueInt();
                resInt.Value = valLeftInt + valRightInt;
                exprExecCalcResult = resInt;
                return true;
            }

            //----calculate, depending on the operator: Minus
            if (operatorCalc.Operator == OperatorCalculationCode.Minus)
            {
                if (calcIntOrDoubleLeft == CalcIntOrDouble.IsDouble)
                {
                    ExprExecValueDouble resDouble = new ExprExecValueDouble();
                    resDouble.Value = valLeftDouble - valRightDouble;
                    exprExecCalcResult = resDouble;
                    return true;
                }

                ExprExecValueInt resInt = new ExprExecValueInt();
                resInt.Value = valLeftInt - valRightInt;
                exprExecCalcResult = resInt;
                return true;
            }

            //----calculate, depending on the operator: Multiplication
            if (operatorCalc.Operator == OperatorCalculationCode.Multiplication)
            {
                if (calcIntOrDoubleLeft == CalcIntOrDouble.IsDouble)
                {
                    ExprExecValueDouble resDouble = new ExprExecValueDouble();
                    resDouble.Value = valLeftDouble * valRightDouble;
                    exprExecCalcResult = resDouble;
                    return true;
                }

                ExprExecValueInt resInt = new ExprExecValueInt();
                resInt.Value = valLeftInt * valRightInt;
                exprExecCalcResult = resInt;
                return true;
            }

            //----calculate, depending on the operator: Division
            if (operatorCalc.Operator == OperatorCalculationCode.Division)
            {
                if (calcIntOrDoubleLeft == CalcIntOrDouble.IsDouble)
                {
                    ExprExecValueDouble resDouble = new ExprExecValueDouble();
                    resDouble.Value = valLeftDouble / valRightDouble;
                    exprExecCalcResult = resDouble;
                    return true;
                }

                // the result can be a double!
                double res = (double)valLeftInt / (double)valRightInt;
                double res2 = res - Math.Truncate(res);

                if (res2 == 0)
                {
                    ExprExecValueInt resInt = new ExprExecValueInt();
                    resInt.Value = valLeftInt / valRightInt;
                    exprExecCalcResult = resInt;
                    return true;
                }
                else
                {
                    ExprExecValueDouble resDouble = new ExprExecValueDouble();
                    resDouble.Value = res; // valLeftInt / valRightInt;
                    exprExecCalcResult = resDouble;
                    return true;
                }
                return true;
            }

            // operator not yet implemented
            execResult.AddErrorExec(ErrorCode.ExprCalculationOperatorNotYetImplemented, "Position", exprExecBaseLeft.Expr.Token.Position.ToString(), "Operand", exprExecBaseLeft.Expr.Token.Value);
            return false;
        }
    }
}
