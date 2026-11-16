using System;

namespace Pierlam.ExpressionEval
{
    public enum MethodSignatureType
    {
        //======================================================================
        //----return a bool, any parameter.

        // ret bool
        RetBool,

        //==================================================
        //--return a bool, one parameter.

        // ret bool, param1 is a bool
        RetBool_Bool,

        RetBool_Int,

        RetBool_String,

        RetBool_Double,

        //==================================================
        //--return a bool, 2 parameters.

        // ret bool p1: bool, p2: bool.
        RetBool_Bool_Bool,

        RetBool_Bool_Int,

        RetBool_Bool_String,

        RetBool_Bool_Double,

        RetBool_Int_Bool,

        RetBool_Int_Int,

        RetBool_Int_String,

        RetBool_Int_Double,

        RetBool_String_Bool,

        RetBool_String_Int,

        RetBool_String_String,

        RetBool_String_Double,

        RetBool_Double_Bool,

        RetBool_Double_Int,

        RetBool_Double_String,

        RetBool_Double_Double,

        //==================================================
        //--return a bool, 3 parameters.

        RetBool_Bool_Bool_Bool,

        RetBool_Bool_Bool_Int,

        RetBool_Bool_Bool_String,

        RetBool_Bool_Bool_Double,

        RetBool_Bool_Int_Bool,

        RetBool_Bool_Int_Int,

        RetBool_Bool_Int_String,

        RetBool_Bool_Int_Double,

        RetBool_Bool_String_Bool,

        RetBool_Bool_String_Int,

        RetBool_Bool_String_String,

        RetBool_Bool_String_Double,

        RetBool_Bool_Double_Bool,

        RetBool_Bool_Double_Int,

        RetBool_Bool_Double_String,

        RetBool_Bool_Double_Double,

        RetBool_Int_Bool_Bool,

        RetBool_Int_Bool_Int,

        RetBool_Int_Bool_String,

        RetBool_Int_Bool_Double,

        RetBool_Int_Int_Bool,

        RetBool_Int_Int_Int,

        RetBool_Int_Int_String,

        RetBool_Int_Int_Double,

        RetBool_Int_String_Bool,

        RetBool_Int_String_Int,

        RetBool_Int_String_String,

        RetBool_Int_String_Double,

        RetBool_Int_Double_Bool,

        RetBool_Int_Double_Int,

        RetBool_Int_Double_String,

        RetBool_Int_Double_Double,

        RetBool_String_Bool_Bool,

        RetBool_String_Bool_Int,

        RetBool_String_Bool_String,

        RetBool_String_Bool_Double,

        RetBool_String_Int_Bool,

        RetBool_String_Int_Int,

        RetBool_String_Int_String,

        RetBool_String_Int_Double,

        RetBool_String_String_Bool,

        RetBool_String_String_Int,

        RetBool_String_String_String,

        RetBool_String_String_Double,

        RetBool_String_Double_Bool,

        RetBool_String_Double_Int,

        RetBool_String_Double_String,

        RetBool_String_Double_Double,

        RetBool_Double_Bool_Bool,

        RetBool_Double_Bool_Int,

        RetBool_Double_Bool_String,

        RetBool_Double_Bool_Double,

        RetBool_Double_Int_Bool,

        RetBool_Double_Int_Int,

        RetBool_Double_Int_String,

        RetBool_Double_Int_Double,

        RetBool_Double_String_Bool,

        RetBool_Double_String_Int,

        RetBool_Double_String_String,

        RetBool_Double_String_Double,

        RetBool_Double_Double_Bool,

        RetBool_Double_Double_Int,

        RetBool_Double_Double_String,

        RetBool_Double_Double_Double,


        //======================================================================
        //----return an Int

        RetInt,

        //==================================================
        //--return an int, one parameter.

        // ret bool, param1 is an int
        RetInt_Bool,

        RetInt_Int,

        RetInt_String,

        RetInt_Double,

        //==================================================
        //--return a int, 2 parameters.

        // ret bool p1: bool, p2: bool.
        RetInt_Bool_Bool,

        RetInt_Bool_Int,

        RetInt_Bool_String,

        RetInt_Bool_Double,

        RetInt_Int_Bool,

        RetInt_Int_Int,

        RetInt_Int_String,

        RetInt_Int_Double,

        RetInt_String_Bool,

        RetInt_String_Int,

        RetInt_String_String,

        RetInt_String_Double,

        RetInt_Double_Bool,

        RetInt_Double_Int,

        RetInt_Double_String,

        RetInt_Double_Double,

        //==================================================
        //--return an int, 3 parameters.

        RetInt_Bool_Bool_Bool,

        RetInt_Bool_Bool_Int,

        RetInt_Bool_Bool_String,

        RetInt_Bool_Bool_Double,

        RetInt_Bool_Int_Bool,

        RetInt_Bool_Int_Int,

        RetInt_Bool_Int_String,

        RetInt_Bool_Int_Double,

        RetInt_Bool_String_Bool,

        RetInt_Bool_String_Int,

        RetInt_Bool_String_String,

        RetInt_Bool_String_Double,

        RetInt_Bool_Double_Bool,

        RetInt_Bool_Double_Int,

        RetInt_Bool_Double_String,

        RetInt_Bool_Double_Double,

        RetInt_Int_Bool_Bool,

        RetInt_Int_Bool_Int,

        RetInt_Int_Bool_String,

        RetInt_Int_Bool_Double,

        RetInt_Int_Int_Bool,

        RetInt_Int_Int_Int,

        RetInt_Int_Int_String,

        RetInt_Int_Int_Double,

        RetInt_Int_String_Bool,

        RetInt_Int_String_Int,

        RetInt_Int_String_String,

        RetInt_Int_String_Double,

        RetInt_Int_Double_Bool,

        RetInt_Int_Double_Int,

        RetInt_Int_Double_String,

        RetInt_Int_Double_Double,

        RetInt_String_Bool_Bool,

        RetInt_String_Bool_Int,

        RetInt_String_Bool_String,

        RetInt_String_Bool_Double,

        RetInt_String_Int_Bool,

        RetInt_String_Int_Int,

        RetInt_String_Int_String,

        RetInt_String_Int_Double,

        RetInt_String_String_Bool,

        RetInt_String_String_Int,

        RetInt_String_String_String,

        RetInt_String_String_Double,

        RetInt_String_Double_Bool,

        RetInt_String_Double_Int,

        RetInt_String_Double_String,

        RetInt_String_Double_Double,

        RetInt_Double_Bool_Bool,

        RetInt_Double_Bool_Int,

        RetInt_Double_Bool_String,

        RetInt_Double_Bool_Double,

        RetInt_Double_Int_Bool,

        RetInt_Double_Int_Int,

        RetInt_Double_Int_String,

        RetInt_Double_Int_Double,

        RetInt_Double_String_Bool,

        RetInt_Double_String_Int,

        RetInt_Double_String_String,

        RetInt_Double_String_Double,

        RetInt_Double_Double_Bool,

        RetInt_Double_Double_Int,

        RetInt_Double_Double_String,

        RetInt_Double_Double_Double,



        //======================================================================
        //----return a string

        RetString,

        //==================================================
        //--return a string, one parameter.

        // ret bool, param1 is an int
        RetString_Bool,

        RetString_Int,

        RetString_String,

        RetString_Double,

        //==================================================
        //--return a string, 2 parameters.

        // ret bool p1: bool, p2: bool.
        RetString_Bool_Bool,

        RetString_Bool_Int,

        RetString_Bool_String,

        RetString_Bool_Double,

        RetString_Int_Bool,

        RetString_Int_Int,

        RetString_Int_String,

        RetString_Int_Double,

        RetString_String_Bool,

        RetString_String_Int,

        RetString_String_String,

        RetString_String_Double,

        RetString_Double_Bool,

        RetString_Double_Int,

        RetString_Double_String,

        RetString_Double_Double,

        //==================================================
        //--return a string, 3 parameters.

        RetString_Bool_Bool_Bool,

        RetString_Bool_Bool_Int,

        RetString_Bool_Bool_String,

        RetString_Bool_Bool_Double,

        RetString_Bool_Int_Bool,

        RetString_Bool_Int_Int,

        RetString_Bool_Int_String,

        RetString_Bool_Int_Double,

        RetString_Bool_String_Bool,

        RetString_Bool_String_Int,

        RetString_Bool_String_String,

        RetString_Bool_String_Double,

        RetString_Bool_Double_Bool,

        RetString_Bool_Double_Int,

        RetString_Bool_Double_String,

        RetString_Bool_Double_Double,

        RetString_Int_Bool_Bool,

        RetString_Int_Bool_Int,

        RetString_Int_Bool_String,

        RetString_Int_Bool_Double,

        RetString_Int_Int_Bool,

        RetString_Int_Int_Int,

        RetString_Int_Int_String,

        RetString_Int_Int_Double,

        RetString_Int_String_Bool,

        RetString_Int_String_Int,

        RetString_Int_String_String,

        RetString_Int_String_Double,

        RetString_Int_Double_Bool,

        RetString_Int_Double_Int,

        RetString_Int_Double_String,

        RetString_Int_Double_Double,

        RetString_String_Bool_Bool,

        RetString_String_Bool_Int,

        RetString_String_Bool_String,

        RetString_String_Bool_Double,

        RetString_String_Int_Bool,

        RetString_String_Int_Int,

        RetString_String_Int_String,

        RetString_String_Int_Double,

        RetString_String_String_Bool,

        RetString_String_String_Int,

        RetString_String_String_String,

        RetString_String_String_Double,

        RetString_String_Double_Bool,

        RetString_String_Double_Int,

        RetString_String_Double_String,

        RetString_String_Double_Double,

        RetString_Double_Bool_Bool,

        RetString_Double_Bool_Int,

        RetString_Double_Bool_String,

        RetString_Double_Bool_Double,

        RetString_Double_Int_Bool,

        RetString_Double_Int_Int,

        RetString_Double_Int_String,

        RetString_Double_Int_Double,

        RetString_Double_String_Bool,

        RetString_Double_String_Int,

        RetString_Double_String_String,

        RetString_Double_String_Double,

        RetString_Double_Double_Bool,

        RetString_Double_Double_Int,

        RetString_Double_Double_String,

        RetString_Double_Double_Double,



        //======================================================================
        //----return a double.

        RetDouble,

        //==================================================
        //--return a double, one parameter.

        // ret bool, param1 is an int
        RetDouble_Bool,

        RetDouble_Int,

        RetDouble_String,

        RetDouble_Double,

        //==================================================
        //--return a double, 2 parameters.

        // ret bool p1: bool, p2: bool.
        RetDouble_Bool_Bool,

        RetDouble_Bool_Int,

        RetDouble_Bool_String,

        RetDouble_Bool_Double,

        RetDouble_Int_Bool,

        RetDouble_Int_Int,

        RetDouble_Int_String,

        RetDouble_Int_Double,

        RetDouble_String_Bool,

        RetDouble_String_Int,

        RetDouble_String_String,

        RetDouble_String_Double,

        RetDouble_Double_Bool,

        RetDouble_Double_Int,

        RetDouble_Double_String,

        RetDouble_Double_Double,

        //==================================================
        //--return a double, 3 parameters.

        RetDouble_Bool_Bool_Bool,

        RetDouble_Bool_Bool_Int,

        RetDouble_Bool_Bool_String,

        RetDouble_Bool_Bool_Double,

        RetDouble_Bool_Int_Bool,

        RetDouble_Bool_Int_Int,

        RetDouble_Bool_Int_String,

        RetDouble_Bool_Int_Double,

        RetDouble_Bool_String_Bool,

        RetDouble_Bool_String_Int,

        RetDouble_Bool_String_String,

        RetDouble_Bool_String_Double,

        RetDouble_Bool_Double_Bool,

        RetDouble_Bool_Double_Int,

        RetDouble_Bool_Double_String,

        RetDouble_Bool_Double_Double,

        RetDouble_Int_Bool_Bool,

        RetDouble_Int_Bool_Int,

        RetDouble_Int_Bool_String,

        RetDouble_Int_Bool_Double,

        RetDouble_Int_Int_Bool,

        RetDouble_Int_Int_Int,

        RetDouble_Int_Int_String,

        RetDouble_Int_Int_Double,

        RetDouble_Int_String_Bool,

        RetDouble_Int_String_Int,

        RetDouble_Int_String_String,

        RetDouble_Int_String_Double,

        RetDouble_Int_Double_Bool,

        RetDouble_Int_Double_Int,

        RetDouble_Int_Double_String,

        RetDouble_Int_Double_Double,

        RetDouble_String_Bool_Bool,

        RetDouble_String_Bool_Int,

        RetDouble_String_Bool_String,

        RetDouble_String_Bool_Double,

        RetDouble_String_Int_Bool,

        RetDouble_String_Int_Int,

        RetDouble_String_Int_String,

        RetDouble_String_Int_Double,

        RetDouble_String_String_Bool,

        RetDouble_String_String_Int,

        RetDouble_String_String_String,

        RetDouble_String_String_Double,

        RetDouble_String_Double_Bool,

        RetDouble_String_Double_Int,

        RetDouble_String_Double_String,

        RetDouble_String_Double_Double,

        RetDouble_Double_Bool_Bool,

        RetDouble_Double_Bool_Int,

        RetDouble_Double_Bool_String,

        RetDouble_Double_Bool_Double,

        RetDouble_Double_Int_Bool,

        RetDouble_Double_Int_Int,

        RetDouble_Double_Int_String,

        RetDouble_Double_Int_Double,

        RetDouble_Double_String_Bool,

        RetDouble_Double_String_Int,

        RetDouble_Double_String_String,

        RetDouble_Double_String_Double,

        RetDouble_Double_Double_Bool,

        RetDouble_Double_Double_Int,

        RetDouble_Double_Double_String,

        RetDouble_Double_Double_Double,


    }

    /// <summary>
    /// To map an external function code to a functionCall.
    /// </summary>
    public class FunctionToCallMapper
    {
        public FunctionToCallMapper()
        {
            Param1Type = DataType.NotDefined;
            Param2Type = DataType.NotDefined;
            Param3Type = DataType.NotDefined;
        }

        public MethodSignatureType MethodSignature { get; set; }

        /// <summary>
        /// the function Call name used in expressions to map to.
        /// </summary>
        public string FunctionCallName { get; set; }

        /// <summary>
        /// The name of the provided function callback.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Return type of the function.
        /// </summary>
        public DataType ReturnType { get; set; }

        /// <summary>
        /// The parameter 1 definiton
        /// </summary>
        public DataType Param1Type { get; set; }

        public DataType Param2Type { get; set; }

        public DataType Param3Type { get; set; }

        //==================================================
        #region function def, Any parameter.

        public Func<bool> FuncBool { get; set; }

        public Func<int> FuncInt { get; set; }

        public Func<double> FuncDouble { get; set; }

        public Func<string> FuncString { get; set; }

        #endregion

        //==================================================
        #region function def, return bool, one parameter.

        public Func<bool, bool> FuncBool_Bool { get; set; }
        public Func<int, bool> FuncBool_Int { get; set; }
        public Func<double, bool> FuncBool_Double { get; set; }
        public Func<string, bool> FuncBool_String { get; set; }

        #endregion

        //==================================================
        #region function def, return int, one parameter.

        //====ret int , one parameter
        public Func<bool, int> FuncInt_Bool { get; set; }
        public Func<int, int> FuncInt_Int { get; set; }
        public Func<double, int> FuncInt_Double { get; set; }
        public Func<string, int> FuncInt_String { get; set; }

        #endregion

        //==================================================
        #region function def, return string, one parameter.

        public Func<bool, string> FuncString_Bool { get; set; }
        public Func<int, string> FuncString_Int { get; set; }
        public Func<double, string> FuncString_Double { get; set; }
        public Func<string, string> FuncString_String { get; set; }

        #endregion

        //==================================================
        #region function def, return double, one parameter.

        public Func<bool, double> FuncDouble_Bool { get; set; }
        public Func<int, double> FuncDouble_Int { get; set; }
        public Func<double, double> FuncDouble_Double { get; set; }
        public Func<string, double> FuncDouble_String { get; set; }

        #endregion

        //==================================================
        #region function def, return bool, 2 parameters.

        /// <summary>
        /// return bool, 
        /// 2 params: bool, bool
        /// </summary>
        public Func<bool, bool, bool> FuncBool_Bool_Bool { get; set; }


        public Func<bool, int, bool> FuncBool_Bool_Int { get; set; }


        public Func<bool, string, bool> FuncBool_Bool_String { get; set; }


        public Func<bool, double, bool> FuncBool_Bool_Double { get; set; }


        public Func<int, bool, bool> FuncBool_Int_Bool { get; set; }


        public Func<int, int, bool> FuncBool_Int_Int { get; set; }


        public Func<int, string, bool> FuncBool_Int_String { get; set; }


        public Func<int, double, bool> FuncBool_Int_Double { get; set; }


        public Func<string, bool, bool> FuncBool_String_Bool { get; set; }


        public Func<string, int, bool> FuncBool_String_Int { get; set; }


        public Func<string, string, bool> FuncBool_String_String { get; set; }


        public Func<string, double, bool> FuncBool_String_Double { get; set; }


        public Func<double, bool, bool> FuncBool_Double_Bool { get; set; }


        public Func<double, int, bool> FuncBool_Double_Int { get; set; }


        public Func<double, string, bool> FuncBool_Double_String { get; set; }


        public Func<double, double, bool> FuncBool_Double_Double { get; set; }

        #endregion

        //==================================================
        #region function def, return int, 2 parameters.

        public Func<bool, bool, int> FuncInt_Bool_Bool { get; set; }


        public Func<bool, int, int> FuncInt_Bool_Int { get; set; }


        public Func<bool, string, int> FuncInt_Bool_String { get; set; }


        public Func<bool, double, int> FuncInt_Bool_Double { get; set; }


        public Func<int, bool, int> FuncInt_Int_Bool { get; set; }


        public Func<int, int, int> FuncInt_Int_Int { get; set; }


        public Func<int, string, int> FuncInt_Int_String { get; set; }


        public Func<int, double, int> FuncInt_Int_Double { get; set; }


        public Func<string, bool, int> FuncInt_String_Bool { get; set; }


        public Func<string, int, int> FuncInt_String_Int { get; set; }


        public Func<string, string, int> FuncInt_String_String { get; set; }


        public Func<string, double, int> FuncInt_String_Double { get; set; }


        public Func<double, bool, int> FuncInt_Double_Bool { get; set; }


        public Func<double, int, int> FuncInt_Double_Int { get; set; }


        public Func<double, string, int> FuncInt_Double_String { get; set; }


        public Func<double, double, int> FuncInt_Double_Double { get; set; }


        #endregion

        //==================================================
        #region function def, return string, 2 parameters.

        public Func<bool, bool, string> FuncString_Bool_Bool { get; set; }


        public Func<bool, int, string> FuncString_Bool_Int { get; set; }


        public Func<bool, string, string> FuncString_Bool_String { get; set; }


        public Func<bool, double, string> FuncString_Bool_Double { get; set; }


        public Func<int, bool, string> FuncString_Int_Bool { get; set; }


        public Func<int, int, string> FuncString_Int_Int { get; set; }


        public Func<int, string, string> FuncString_Int_String { get; set; }


        public Func<int, double, string> FuncString_Int_Double { get; set; }


        public Func<string, bool, string> FuncString_String_Bool { get; set; }


        public Func<string, int, string> FuncString_String_Int { get; set; }


        public Func<string, string, string> FuncString_String_String { get; set; }

        public Func<string, double, string> FuncString_String_Double { get; set; }

        public Func<double, bool, string> FuncString_Double_Bool { get; set; }


        public Func<double, int, string> FuncString_Double_Int { get; set; }


        public Func<double, string, string> FuncString_Double_String { get; set; }


        public Func<double, double, string> FuncString_Double_Double { get; set; }


        #endregion

        //==================================================
        #region function def, return double, 2 parameters.

        public Func<bool, bool, double> FuncDouble_Bool_Bool { get; set; }


        public Func<bool, int, double> FuncDouble_Bool_Int { get; set; }


        public Func<bool, string, double> FuncDouble_Bool_String { get; set; }


        public Func<bool, double, double> FuncDouble_Bool_Double { get; set; }


        public Func<int, bool, double> FuncDouble_Int_Bool { get; set; }


        public Func<int, int, double> FuncDouble_Int_Int { get; set; }


        public Func<int, string, double> FuncDouble_Int_String { get; set; }


        public Func<int, double, double> FuncDouble_Int_Double { get; set; }


        public Func<string, bool, double> FuncDouble_String_Bool { get; set; }


        public Func<string, int, double> FuncDouble_String_Int { get; set; }


        public Func<string, string, double> FuncDouble_String_String { get; set; }


        public Func<string, double, double> FuncDouble_String_Double { get; set; }


        public Func<double, bool, double> FuncDouble_Double_Bool { get; set; }


        public Func<double, int, double> FuncDouble_Double_Int { get; set; }


        public Func<double, string, double> FuncDouble_Double_String { get; set; }


        public Func<double, double, double> FuncDouble_Double_Double { get; set; }

        #endregion

        //==================================================
        #region function def, return bool, 3 parameters.

        /// <summary>
        /// return bool, 
        /// 2 params: bool, bool
        /// </summary>
        public Func<bool, bool, bool, bool> FuncBool_Bool_Bool_Bool { get; set; }


        public Func<bool, bool, int, bool> FuncBool_Bool_Bool_Int { get; set; }


        public Func<bool, bool, string, bool> FuncBool_Bool_Bool_String { get; set; }


        public Func<bool, bool, double, bool> FuncBool_Bool_Bool_Double { get; set; }


        public Func<bool, int, bool, bool> FuncBool_Bool_Int_Bool { get; set; }


        public Func<bool, int, int, bool> FuncBool_Bool_Int_Int { get; set; }


        public Func<bool, int, string, bool> FuncBool_Bool_Int_String { get; set; }


        public Func<bool, int, double, bool> FuncBool_Bool_Int_Double { get; set; }


        public Func<bool, string, bool, bool> FuncBool_Bool_String_Bool { get; set; }


        public Func<bool, string, int, bool> FuncBool_Bool_String_Int { get; set; }


        public Func<bool, string, string, bool> FuncBool_Bool_String_String { get; set; }


        public Func<bool, string, double, bool> FuncBool_Bool_String_Double { get; set; }


        public Func<bool, double, bool, bool> FuncBool_Bool_Double_Bool { get; set; }


        public Func<bool, double, int, bool> FuncBool_Bool_Double_Int { get; set; }


        public Func<bool, double, string, bool> FuncBool_Bool_Double_String { get; set; }


        public Func<bool, double, double, bool> FuncBool_Bool_Double_Double { get; set; }


        public Func<int, bool, bool, bool> FuncBool_Int_Bool_Bool { get; set; }


        public Func<int, bool, int, bool> FuncBool_Int_Bool_Int { get; set; }


        public Func<int, bool, string, bool> FuncBool_Int_Bool_String { get; set; }


        public Func<int, bool, double, bool> FuncBool_Int_Bool_Double { get; set; }


        public Func<int, int, bool, bool> FuncBool_Int_Int_Bool { get; set; }


        public Func<int, int, int, bool> FuncBool_Int_Int_Int { get; set; }


        public Func<int, int, string, bool> FuncBool_Int_Int_String { get; set; }


        public Func<int, int, double, bool> FuncBool_Int_Int_Double { get; set; }


        public Func<int, string, bool, bool> FuncBool_Int_String_Bool { get; set; }


        public Func<int, string, int, bool> FuncBool_Int_String_Int { get; set; }


        public Func<int, string, string, bool> FuncBool_Int_String_String { get; set; }


        public Func<int, string, double, bool> FuncBool_Int_String_Double { get; set; }


        public Func<int, double, bool, bool> FuncBool_Int_Double_Bool { get; set; }


        public Func<int, double, int, bool> FuncBool_Int_Double_Int { get; set; }


        public Func<int, double, string, bool> FuncBool_Int_Double_String { get; set; }


        public Func<int, double, double, bool> FuncBool_Int_Double_Double { get; set; }


        public Func<string, bool, bool, bool> FuncBool_String_Bool_Bool { get; set; }


        public Func<string, bool, int, bool> FuncBool_String_Bool_Int { get; set; }


        public Func<string, bool, string, bool> FuncBool_String_Bool_String { get; set; }


        public Func<string, bool, double, bool> FuncBool_String_Bool_Double { get; set; }


        public Func<string, int, bool, bool> FuncBool_String_Int_Bool { get; set; }


        public Func<string, int, int, bool> FuncBool_String_Int_Int { get; set; }


        public Func<string, int, string, bool> FuncBool_String_Int_String { get; set; }


        public Func<string, int, double, bool> FuncBool_String_Int_Double { get; set; }


        public Func<string, string, bool, bool> FuncBool_String_String_Bool { get; set; }


        public Func<string, string, int, bool> FuncBool_String_String_Int { get; set; }


        public Func<string, string, string, bool> FuncBool_String_String_String { get; set; }


        public Func<string, string, double, bool> FuncBool_String_String_Double { get; set; }


        public Func<string, double, bool, bool> FuncBool_String_Double_Bool { get; set; }


        public Func<string, double, int, bool> FuncBool_String_Double_Int { get; set; }


        public Func<string, double, string, bool> FuncBool_String_Double_String { get; set; }


        public Func<string, double, double, bool> FuncBool_String_Double_Double { get; set; }


        public Func<double, bool, bool, bool> FuncBool_Double_Bool_Bool { get; set; }


        public Func<double, bool, int, bool> FuncBool_Double_Bool_Int { get; set; }


        public Func<double, bool, string, bool> FuncBool_Double_Bool_String { get; set; }


        public Func<double, bool, double, bool> FuncBool_Double_Bool_Double { get; set; }


        public Func<double, int, bool, bool> FuncBool_Double_Int_Bool { get; set; }


        public Func<double, int, int, bool> FuncBool_Double_Int_Int { get; set; }


        public Func<double, int, string, bool> FuncBool_Double_Int_String { get; set; }


        public Func<double, int, double, bool> FuncBool_Double_Int_Double { get; set; }


        public Func<double, string, bool, bool> FuncBool_Double_String_Bool { get; set; }


        public Func<double, string, int, bool> FuncBool_Double_String_Int { get; set; }


        public Func<double, string, string, bool> FuncBool_Double_String_String { get; set; }


        public Func<double, string, double, bool> FuncBool_Double_String_Double { get; set; }


        public Func<double, double, bool, bool> FuncBool_Double_Double_Bool { get; set; }


        public Func<double, double, int, bool> FuncBool_Double_Double_Int { get; set; }


        public Func<double, double, string, bool> FuncBool_Double_Double_String { get; set; }


        public Func<double, double, double, bool> FuncBool_Double_Double_Double { get; set; }



        #endregion

        //==================================================
        #region function def, return int, 3 parameters.

        public Func<bool, bool, bool, int> FuncInt_Bool_Bool_Bool { get; set; }


        public Func<bool, bool, int, int> FuncInt_Bool_Bool_Int { get; set; }


        public Func<bool, bool, string, int> FuncInt_Bool_Bool_String { get; set; }


        public Func<bool, bool, double, int> FuncInt_Bool_Bool_Double { get; set; }


        public Func<bool, int, bool, int> FuncInt_Bool_Int_Bool { get; set; }


        public Func<bool, int, int, int> FuncInt_Bool_Int_Int { get; set; }


        public Func<bool, int, string, int> FuncInt_Bool_Int_String { get; set; }


        public Func<bool, int, double, int> FuncInt_Bool_Int_Double { get; set; }


        public Func<bool, string, bool, int> FuncInt_Bool_String_Bool { get; set; }


        public Func<bool, string, int, int> FuncInt_Bool_String_Int { get; set; }


        public Func<bool, string, string, int> FuncInt_Bool_String_String { get; set; }


        public Func<bool, string, double, int> FuncInt_Bool_String_Double { get; set; }


        public Func<bool, double, bool, int> FuncInt_Bool_Double_Bool { get; set; }


        public Func<bool, double, int, int> FuncInt_Bool_Double_Int { get; set; }


        public Func<bool, double, string, int> FuncInt_Bool_Double_String { get; set; }


        public Func<bool, double, double, int> FuncInt_Bool_Double_Double { get; set; }


        public Func<int, bool, bool, int> FuncInt_Int_Bool_Bool { get; set; }


        public Func<int, bool, int, int> FuncInt_Int_Bool_Int { get; set; }


        public Func<int, bool, string, int> FuncInt_Int_Bool_String { get; set; }


        public Func<int, bool, double, int> FuncInt_Int_Bool_Double { get; set; }


        public Func<int, int, bool, int> FuncInt_Int_Int_Bool { get; set; }


        public Func<int, int, int, int> FuncInt_Int_Int_Int { get; set; }


        public Func<int, int, string, int> FuncInt_Int_Int_String { get; set; }


        public Func<int, int, double, int> FuncInt_Int_Int_Double { get; set; }


        public Func<int, string, bool, int> FuncInt_Int_String_Bool { get; set; }


        public Func<int, string, int, int> FuncInt_Int_String_Int { get; set; }


        public Func<int, string, string, int> FuncInt_Int_String_String { get; set; }


        public Func<int, string, double, int> FuncInt_Int_String_Double { get; set; }


        public Func<int, double, bool, int> FuncInt_Int_Double_Bool { get; set; }


        public Func<int, double, int, int> FuncInt_Int_Double_Int { get; set; }


        public Func<int, double, string, int> FuncInt_Int_Double_String { get; set; }


        public Func<int, double, double, int> FuncInt_Int_Double_Double { get; set; }


        public Func<string, bool, bool, int> FuncInt_String_Bool_Bool { get; set; }


        public Func<string, bool, int, int> FuncInt_String_Bool_Int { get; set; }


        public Func<string, bool, string, int> FuncInt_String_Bool_String { get; set; }


        public Func<string, bool, double, int> FuncInt_String_Bool_Double { get; set; }


        public Func<string, int, bool, int> FuncInt_String_Int_Bool { get; set; }


        public Func<string, int, int, int> FuncInt_String_Int_Int { get; set; }


        public Func<string, int, string, int> FuncInt_String_Int_String { get; set; }


        public Func<string, int, double, int> FuncInt_String_Int_Double { get; set; }


        public Func<string, string, bool, int> FuncInt_String_String_Bool { get; set; }


        public Func<string, string, int, int> FuncInt_String_String_Int { get; set; }


        public Func<string, string, string, int> FuncInt_String_String_String { get; set; }


        public Func<string, string, double, int> FuncInt_String_String_Double { get; set; }


        public Func<string, double, bool, int> FuncInt_String_Double_Bool { get; set; }


        public Func<string, double, int, int> FuncInt_String_Double_Int { get; set; }


        public Func<string, double, string, int> FuncInt_String_Double_String { get; set; }


        public Func<string, double, double, int> FuncInt_String_Double_Double { get; set; }


        public Func<double, bool, bool, int> FuncInt_Double_Bool_Bool { get; set; }


        public Func<double, bool, int, int> FuncInt_Double_Bool_Int { get; set; }


        public Func<double, bool, string, int> FuncInt_Double_Bool_String { get; set; }


        public Func<double, bool, double, int> FuncInt_Double_Bool_Double { get; set; }


        public Func<double, int, bool, int> FuncInt_Double_Int_Bool { get; set; }


        public Func<double, int, int, int> FuncInt_Double_Int_Int { get; set; }


        public Func<double, int, string, int> FuncInt_Double_Int_String { get; set; }


        public Func<double, int, double, int> FuncInt_Double_Int_Double { get; set; }


        public Func<double, string, bool, int> FuncInt_Double_String_Bool { get; set; }


        public Func<double, string, int, int> FuncInt_Double_String_Int { get; set; }


        public Func<double, string, string, int> FuncInt_Double_String_String { get; set; }


        public Func<double, string, double, int> FuncInt_Double_String_Double { get; set; }


        public Func<double, double, bool, int> FuncInt_Double_Double_Bool { get; set; }


        public Func<double, double, int, int> FuncInt_Double_Double_Int { get; set; }


        public Func<double, double, string, int> FuncInt_Double_Double_String { get; set; }


        public Func<double, double, double, int> FuncInt_Double_Double_Double { get; set; }



        #endregion

        //==================================================
        #region function def, return string, 3 parameters.
        public Func<bool, bool, bool, string> FuncString_Bool_Bool_Bool { get; set; }


        public Func<bool, bool, int, string> FuncString_Bool_Bool_Int { get; set; }


        public Func<bool, bool, string, string> FuncString_Bool_Bool_String { get; set; }


        public Func<bool, bool, double, string> FuncString_Bool_Bool_Double { get; set; }


        public Func<bool, int, bool, string> FuncString_Bool_Int_Bool { get; set; }


        public Func<bool, int, int, string> FuncString_Bool_Int_Int { get; set; }


        public Func<bool, int, string, string> FuncString_Bool_Int_String { get; set; }


        public Func<bool, int, double, string> FuncString_Bool_Int_Double { get; set; }


        public Func<bool, string, bool, string> FuncString_Bool_String_Bool { get; set; }


        public Func<bool, string, int, string> FuncString_Bool_String_Int { get; set; }


        public Func<bool, string, string, string> FuncString_Bool_String_String { get; set; }


        public Func<bool, string, double, string> FuncString_Bool_String_Double { get; set; }


        public Func<bool, double, bool, string> FuncString_Bool_Double_Bool { get; set; }


        public Func<bool, double, int, string> FuncString_Bool_Double_Int { get; set; }


        public Func<bool, double, string, string> FuncString_Bool_Double_String { get; set; }


        public Func<bool, double, double, string> FuncString_Bool_Double_Double { get; set; }


        public Func<int, bool, bool, string> FuncString_Int_Bool_Bool { get; set; }


        public Func<int, bool, int, string> FuncString_Int_Bool_Int { get; set; }


        public Func<int, bool, string, string> FuncString_Int_Bool_String { get; set; }


        public Func<int, bool, double, string> FuncString_Int_Bool_Double { get; set; }


        public Func<int, int, bool, string> FuncString_Int_Int_Bool { get; set; }


        public Func<int, int, int, string> FuncString_Int_Int_Int { get; set; }


        public Func<int, int, string, string> FuncString_Int_Int_String { get; set; }


        public Func<int, int, double, string> FuncString_Int_Int_Double { get; set; }


        public Func<int, string, bool, string> FuncString_Int_String_Bool { get; set; }


        public Func<int, string, int, string> FuncString_Int_String_Int { get; set; }


        public Func<int, string, string, string> FuncString_Int_String_String { get; set; }


        public Func<int, string, double, string> FuncString_Int_String_Double { get; set; }


        public Func<int, double, bool, string> FuncString_Int_Double_Bool { get; set; }


        public Func<int, double, int, string> FuncString_Int_Double_Int { get; set; }


        public Func<int, double, string, string> FuncString_Int_Double_String { get; set; }


        public Func<int, double, double, string> FuncString_Int_Double_Double { get; set; }


        public Func<string, bool, bool, string> FuncString_String_Bool_Bool { get; set; }


        public Func<string, bool, int, string> FuncString_String_Bool_Int { get; set; }


        public Func<string, bool, string, string> FuncString_String_Bool_String { get; set; }


        public Func<string, bool, double, string> FuncString_String_Bool_Double { get; set; }


        public Func<string, int, bool, string> FuncString_String_Int_Bool { get; set; }


        public Func<string, int, int, string> FuncString_String_Int_Int { get; set; }


        public Func<string, int, string, string> FuncString_String_Int_String { get; set; }


        public Func<string, int, double, string> FuncString_String_Int_Double { get; set; }


        public Func<string, string, bool, string> FuncString_String_String_Bool { get; set; }


        public Func<string, string, int, string> FuncString_String_String_Int { get; set; }


        public Func<string, string, string, string> FuncString_String_String_String { get; set; }


        public Func<string, string, double, string> FuncString_String_String_Double { get; set; }


        public Func<string, double, bool, string> FuncString_String_Double_Bool { get; set; }


        public Func<string, double, int, string> FuncString_String_Double_Int { get; set; }


        public Func<string, double, string, string> FuncString_String_Double_String { get; set; }


        public Func<string, double, double, string> FuncString_String_Double_Double { get; set; }


        public Func<double, bool, bool, string> FuncString_Double_Bool_Bool { get; set; }


        public Func<double, bool, int, string> FuncString_Double_Bool_Int { get; set; }


        public Func<double, bool, string, string> FuncString_Double_Bool_String { get; set; }


        public Func<double, bool, double, string> FuncString_Double_Bool_Double { get; set; }


        public Func<double, int, bool, string> FuncString_Double_Int_Bool { get; set; }


        public Func<double, int, int, string> FuncString_Double_Int_Int { get; set; }


        public Func<double, int, string, string> FuncString_Double_Int_String { get; set; }


        public Func<double, int, double, string> FuncString_Double_Int_Double { get; set; }


        public Func<double, string, bool, string> FuncString_Double_String_Bool { get; set; }


        public Func<double, string, int, string> FuncString_Double_String_Int { get; set; }


        public Func<double, string, string, string> FuncString_Double_String_String { get; set; }


        public Func<double, string, double, string> FuncString_Double_String_Double { get; set; }


        public Func<double, double, bool, string> FuncString_Double_Double_Bool { get; set; }


        public Func<double, double, int, string> FuncString_Double_Double_Int { get; set; }


        public Func<double, double, string, string> FuncString_Double_Double_String { get; set; }


        public Func<double, double, double, string> FuncString_Double_Double_Double { get; set; }



        #endregion

        //==================================================
        #region function def, return double, 3 parameters.
        public Func<bool, bool, bool, double> FuncDouble_Bool_Bool_Bool { get; set; }


        public Func<bool, bool, int, double> FuncDouble_Bool_Bool_Int { get; set; }


        public Func<bool, bool, string, double> FuncDouble_Bool_Bool_String { get; set; }


        public Func<bool, bool, double, double> FuncDouble_Bool_Bool_Double { get; set; }


        public Func<bool, int, bool, double> FuncDouble_Bool_Int_Bool { get; set; }


        public Func<bool, int, int, double> FuncDouble_Bool_Int_Int { get; set; }


        public Func<bool, int, string, double> FuncDouble_Bool_Int_String { get; set; }


        public Func<bool, int, double, double> FuncDouble_Bool_Int_Double { get; set; }


        public Func<bool, string, bool, double> FuncDouble_Bool_String_Bool { get; set; }


        public Func<bool, string, int, double> FuncDouble_Bool_String_Int { get; set; }


        public Func<bool, string, string, double> FuncDouble_Bool_String_String { get; set; }


        public Func<bool, string, double, double> FuncDouble_Bool_String_Double { get; set; }


        public Func<bool, double, bool, double> FuncDouble_Bool_Double_Bool { get; set; }


        public Func<bool, double, int, double> FuncDouble_Bool_Double_Int { get; set; }


        public Func<bool, double, string, double> FuncDouble_Bool_Double_String { get; set; }


        public Func<bool, double, double, double> FuncDouble_Bool_Double_Double { get; set; }


        public Func<int, bool, bool, double> FuncDouble_Int_Bool_Bool { get; set; }


        public Func<int, bool, int, double> FuncDouble_Int_Bool_Int { get; set; }


        public Func<int, bool, string, double> FuncDouble_Int_Bool_String { get; set; }


        public Func<int, bool, double, double> FuncDouble_Int_Bool_Double { get; set; }


        public Func<int, int, bool, double> FuncDouble_Int_Int_Bool { get; set; }


        public Func<int, int, int, double> FuncDouble_Int_Int_Int { get; set; }


        public Func<int, int, string, double> FuncDouble_Int_Int_String { get; set; }


        public Func<int, int, double, double> FuncDouble_Int_Int_Double { get; set; }


        public Func<int, string, bool, double> FuncDouble_Int_String_Bool { get; set; }


        public Func<int, string, int, double> FuncDouble_Int_String_Int { get; set; }


        public Func<int, string, string, double> FuncDouble_Int_String_String { get; set; }


        public Func<int, string, double, double> FuncDouble_Int_String_Double { get; set; }


        public Func<int, double, bool, double> FuncDouble_Int_Double_Bool { get; set; }


        public Func<int, double, int, double> FuncDouble_Int_Double_Int { get; set; }


        public Func<int, double, string, double> FuncDouble_Int_Double_String { get; set; }


        public Func<int, double, double, double> FuncDouble_Int_Double_Double { get; set; }


        public Func<string, bool, bool, double> FuncDouble_String_Bool_Bool { get; set; }


        public Func<string, bool, int, double> FuncDouble_String_Bool_Int { get; set; }


        public Func<string, bool, string, double> FuncDouble_String_Bool_String { get; set; }


        public Func<string, bool, double, double> FuncDouble_String_Bool_Double { get; set; }


        public Func<string, int, bool, double> FuncDouble_String_Int_Bool { get; set; }


        public Func<string, int, int, double> FuncDouble_String_Int_Int { get; set; }


        public Func<string, int, string, double> FuncDouble_String_Int_String { get; set; }


        public Func<string, int, double, double> FuncDouble_String_Int_Double { get; set; }


        public Func<string, string, bool, double> FuncDouble_String_String_Bool { get; set; }


        public Func<string, string, int, double> FuncDouble_String_String_Int { get; set; }


        public Func<string, string, string, double> FuncDouble_String_String_String { get; set; }


        public Func<string, string, double, double> FuncDouble_String_String_Double { get; set; }


        public Func<string, double, bool, double> FuncDouble_String_Double_Bool { get; set; }


        public Func<string, double, int, double> FuncDouble_String_Double_Int { get; set; }


        public Func<string, double, string, double> FuncDouble_String_Double_String { get; set; }


        public Func<string, double, double, double> FuncDouble_String_Double_Double { get; set; }


        public Func<double, bool, bool, double> FuncDouble_Double_Bool_Bool { get; set; }


        public Func<double, bool, int, double> FuncDouble_Double_Bool_Int { get; set; }


        public Func<double, bool, string, double> FuncDouble_Double_Bool_String { get; set; }


        public Func<double, bool, double, double> FuncDouble_Double_Bool_Double { get; set; }


        public Func<double, int, bool, double> FuncDouble_Double_Int_Bool { get; set; }


        public Func<double, int, int, double> FuncDouble_Double_Int_Int { get; set; }


        public Func<double, int, string, double> FuncDouble_Double_Int_String { get; set; }


        public Func<double, int, double, double> FuncDouble_Double_Int_Double { get; set; }


        public Func<double, string, bool, double> FuncDouble_Double_String_Bool { get; set; }


        public Func<double, string, int, double> FuncDouble_Double_String_Int { get; set; }


        public Func<double, string, string, double> FuncDouble_Double_String_String { get; set; }


        public Func<double, string, double, double> FuncDouble_Double_String_Double { get; set; }


        public Func<double, double, bool, double> FuncDouble_Double_Double_Bool { get; set; }


        public Func<double, double, int, double> FuncDouble_Double_Double_Int { get; set; }


        public Func<double, double, string, double> FuncDouble_Double_Double_String { get; set; }


        public Func<double, double, double, double> FuncDouble_Double_Double_Double { get; set; }



        #endregion

        //====4 parameters and more


        // todo:

    }
}
