using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevApp
{
    /// <summary>
    /// Dev and test functionCall.
    /// </summary>
    public class TestDevFunctionCall
    {
        /// <summary>
        /// Test ajout fonction.
        /// </summary>
        public void Run()
        {
            FunctionToCallMapper<int, bool> functionToCallMapper = new FunctionToCallMapper<int, bool>();

            // Function3ParamsMapper
            // attache une fonction
            functionToCallMapper.AddFunction(FctRetBool_Int);
        }
        public void Run2()
        {
            ExprEvalTest exprEvalTest = new ExprEvalTest();

            // Add a function that return a bool without any param.
            exprEvalTest.AddFunction(Fct);
            exprEvalTest.AddFunction(Inc);


            exprEvalTest.ExecFunc("Fct");

            int ret =exprEvalTest.ExecFunc("Inc", 12);

        }

        public bool Fct()
        {
            return true;
        }

        public int FctInt()
        {
            return 1;
        }

        public int Inc(int a)
        {
            return a+1;
        }

        public bool FctRetBool_Int(int a)
        {
            if (a > 9) return true;
            return false;
        }
    }
}
