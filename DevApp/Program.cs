using Pierlam.ExpressionEval;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace DevApp
{
    class Program
    {
        static ParseResult ParseExpr(ExpressionEval evaluator, string expr)
        {
            // definir langue: fr ou en, sert pour les opérateurs: ET/AND, OU/OR, NON/NOT.
            evaluator.SetLang(Language.En);

            // configurer le format des opérandes
            // todo:  constante, var..
            // todo: configurer les valeurs spéciales: true et false (vrai et faux)

            Console.WriteLine("eval expr: " + expr);

            //====1/décode l'expression booléenne
            ParseResult parseResult = evaluator.Parse(expr);

            if (parseResult.HasError)
            {
                Console.WriteLine("ERR, Une ou plusieurs erreurs ont été générées lors du parsing de l'expression " + expr + ", nb erreur(s): " + parseResult.ListError.Count);

                // affiche les erreurs
                int i = 0;
                foreach (ExprError error in parseResult.ListError)
                    Console.WriteLine("erreur N°" + i + ": " + error.Code.ToString());
                return null;
            }

            // displays all variables present in the expression
            int j = 0;
            foreach (ExprVarUsed exprVar in parseResult.ListExprVarUsed)
            {
                j++;
                Console.WriteLine("Var #" + j + "Name=" + exprVar.Name);
            }

            // display all the tokens found in the expression
            foreach (ExprToken token in parseResult.ListExprToken)
            {
                Console.WriteLine(token.Position + ", " + token.Value);
            }
            Console.WriteLine("Decode expr: OK, pas d'erreur.");


            //====2/prepare the execution, provide all used variables: type and value
            //return evaluator.InitExec(parseResult);

            return parseResult;
        }

        static void Execute(ExpressionEval evaluator, string expr) //, ExprExecResult execResult)
        {
            //====2/prepare the execution, provide all used variables: type and value

            //====3/execute l'expression booléenne
            var execResult= evaluator.Exec();

            // displays errors and result
            if (execResult.HasError)
            {
                Console.WriteLine("ERR, Une ou plusieurs erreurs ont été générées lors de l'exécution de l'expression " + expr + ", nb erreur(s): " + execResult.ListError.Count);

                // affiche les erreurs
                int i = 0;
                foreach (ExprError error in execResult.ListError)
                {
                    i++;
                    Console.WriteLine("erreur N°" + i + ": " + error.Code.ToString() + ", " + error.ListErrorParam[0].Key + ": " + error.ListErrorParam[0].Value);
                }
                return;
            }

            //====4/display the result of the execution of the expression
            string typeRes = "NA";
            string valueRes = "NA";
            ExprExecValueBool valueBool = execResult.ExprExec as ExprExecValueBool;
            if (valueBool != null)
            {
                typeRes = "bool";
                valueRes = valueBool.Value.ToString();
            }

            // others types: todo:

            Console.WriteLine("Execution Result of the expression, type: " + typeRes + ", value: " + valueRes);
            Console.WriteLine("Execution Result: " + valueBool.Value.ToString());
        }

        static void TestEpressionEval()
        {
            //string expr = "not A";
            string expr = "A and B";


            ExpressionEval evaluator = new ExpressionEval();

            ParseResult parseResult = ParseExpr(evaluator, expr);

            //====2/prepare the execution, provide all used variables: type and value, remove the previous result
            evaluator.DefineVarInt("a", 12);
            evaluator.DefineVarBool("b", false);
            //evaluator.SetVariableValueInt("b", 12);

            Execute(evaluator, expr); 

        }

        static void TestErrorDefinitionVarFunc()
        {
            //string expr = "not A";
            string expr = "A and B";


            ExpressionEval evaluator = new ExpressionEval();

            ParseResult parseResult = ParseExpr(evaluator, expr);

            //====2/prepare the execution, provide all used variables: type and value, remove the previous result
            evaluator.DefineVarInt("a", 12);
            evaluator.DefineVarBool("b", false);
            //evaluator.SetVariableValueInt("b", 12);

            // check definition (var/func) errors
            List<ExprError> listError = evaluator.GetListErrorExprConfig();

            Execute(evaluator, expr);

        }

        static void TestSomeExpression()
        {
            //--------------------ESSAIS
            //int a = -12;
            //var res = (a< - 10);

            // erreur
            //var res = (a =< 10);
            // ok
            //var res = (a <= 10);
            //--------------------

            string s1 = "bonjour";

            string s2 = "bonjour";
            //string s2 = "salut";

            // ok
            //bool ress = (s1 == s2);

            // error!
            //bool ress = (s1 > s2);


            //bool ress = (s1 < s2);

            //====================
            bool a = true;
            bool b = true;
            bool res = (a && b);

            int ia = 12;
            int ib = 12;
            bool resi = (a && b);
            bool resii = (a || b);
        }

        /// <summary>
        /// A dev!!
        /// </summary>
        static void TestExprLogicalSeveralOperands()
        {
            string expr = "(A and B or C)";

            ExpressionEval evaluator = new ExpressionEval();

            //====1/décode l'expression booléenne
            ParseResult parseResult = evaluator.Parse(expr);

            //====2/prepare the execution, provide all used variables: type and value, remove the previous result
            //ExprExecResult execResult = evaluator.InitExec();

            evaluator.DefineVarBool("a", true);
            evaluator.DefineVarBool("b", true);
            evaluator.DefineVarBool("c", false);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();

            //====4/get the result
            if (execResult.HasError)
            {
                Console.WriteLine("Execution Result: error!");
            }

            if (execResult.IsResultBool)
            {
                Console.WriteLine("Execution Result: " + execResult.ResultBool);
            }

        }

        static void OP_A_Eq_B_CP_Exec2Times()
        {
            string expr = "(A = B)";

            ExpressionEval evaluator = new ExpressionEval();

            //====1/décode l'expression booléenne
            ParseResult parseResult = evaluator.Parse(expr);

            //====2/prepare the execution, provide all used variables: type and value, remove the previous result
            //ExprExecResult execResult = evaluator.InitExec();

            evaluator.DefineVarInt("a", 15);
            evaluator.DefineVarInt("b", 15);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();

            //====4/get the result, its a bool value
            ExprExecValueBool valueBool = execResult.ExprExec as ExprExecValueBool;

            Console.WriteLine("Execution Result: " + valueBool.Value.ToString());

            //======================================================
            //====2/prepare the execution, provide all used variables: type and value, remove the previous result
            //execResult = evaluator.InitExec();

            evaluator.DefineVarBool("a", false);
            evaluator.DefineVarBool("b", false);

            //====3/execute l'expression booléenne
            execResult = evaluator.Exec();

            //====4/get the result, its a bool value
            valueBool = execResult.ExprExec as ExprExecValueBool;

            Console.WriteLine("Execution Result: " + valueBool.Value.ToString());

        }

        static void OP_A_Eq_B_CP()
        {
            string expr = "(A = B)";

            ExpressionEval evaluator = new ExpressionEval();

            //====1/décode l'expression booléenne
            ParseResult parseResult = evaluator.Parse(expr);

            // displays variables used/found in the expression
            foreach (ExprVarUsed exprVarUsed in parseResult.ListExprVarUsed)
            {
                Console.WriteLine("Var, Name=" + exprVarUsed.Name);
                // ExprVariableInt
            }

            //====2/prepare the execution, provide all used variables: type and value, remove the previous result
            //ExprExecResult execResult = evaluator.InitExec();

            evaluator.DefineVarInt("a", 15);
            evaluator.DefineVarInt("b", 15);

            //====3/execute l'expression booléenne
            ExecResult execResult = evaluator.Exec();

            //====4/get the result
            if (execResult.HasError)
            {
                Console.WriteLine("Execution Result: error!");
            }

            if (execResult.IsResultBool)
            {
                Console.WriteLine("Execution Result: " + execResult.ResultBool);
            }

            // replace:
            //ExprExecValueBool valueBool = execResult.ExprExec as ExprExecValueBool;
            //Console.WriteLine("Execution Result: " + valueBool.Value.ToString());

        }


        /// <summary>
        /// séparateur de millier: virgule + séparateur décimal: point
        ///  124,567.34  ok 
        ///  124 567.34  echec 
        ///  124,34E2    ok
        /// 
        /// Separateur décimal: virgule
        ///  124567,34   ok
        ///  124 567,34  echec  (meme is AllowThousands est activé).
        ///  124,34E2    ok
        ///  
        /// dépend du style: NumberStyles.AllowDecimalPoint pour gérer le séparateur décimal.
        /// (indépendamment de la culture).
        /// 
        /// Les styles:
        /// NumberStyles.AllowExponent: à mettre toujours 
        /// et jouer avec: NumberStyles.AllowDecimalPoint pour le séparateur décimal: point ou virgule.
        /// </summary>
        static void TestDecodeOperandDouble()
        {

            string sd = "567,34E2";
            double d;

            // the decimal separator is a point, exp: 123.45
            System.IFormatProvider cultureUS = new System.Globalization.CultureInfo("en-US");

            // the decimal separator is a comma, exp: 123,45
            System.Globalization.CultureInfo cultureFr = new System.Globalization.CultureInfo("fr-fr");

            //bool res = double.TryParse(sd, out d);

            // code pour traiter le séparateur point
            //bool res=double.TryParse(sd, NumberStyles.AllowDecimalPoint, NumberFormatInfo.InvariantInfo, out d);

            NumberStyles styles = NumberStyles.AllowExponent | NumberStyles.AllowThousands| NumberStyles.AllowDecimalPoint;
            //NumberStyles styles = NumberStyles.AllowExponent | NumberStyles.AllowThousands;
            //NumberStyles styles = NumberStyles.AllowExponent;


            bool res = double.TryParse(sd, styles, cultureFr, out d);

            //NumberFormatInfo nfi = new NumberFormatInfo();
            //nfi.NumberDecimalSeparator = ".";
            //value.ToString(nfi);

            if (!res)
            {
                Console.WriteLine("!Error");
                return;
            }
            Console.WriteLine("d= " + d.ToString());
        }


        static void TestMathTrigo()
        {
            double a = Math.Sin(12);
            //Math.
        }

        static void Main(string[] args)
        {
            Console.WriteLine("=======ExpressionEval dev:");

            DateTime dt = new DateTime(2020, 08, 22);
            dt = dt.AddDays(100);

            //BasicTest();
            //OP_A_Eq_B_CP();

            //TestDevExpressionEval test = new TestDevExpressionEval();
            //test.Exec();
            //TestSomeExpression();

            //TestEpressionEval();
            TestErrorDefinitionVarFunc();

            //TestDecodeOperandDouble();

            //TestDevFunctionCall testDevFunctionCall = new TestDevFunctionCall();
            //testDevFunctionCall.Run();

            TestMathTrigo();

            Console.WriteLine("Fin.");
            Console.ReadKey();
        }
    }
}
