using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// function mapper, return int, with 3 parameters.
    /// Type of parameters are generic but only some predefined types are managed.
    /// </summary>
    /// <typeparam name="TP1"></typeparam>
    /// <typeparam name="TP2"></typeparam>
    /// <typeparam name="TP3"></typeparam>
    public class Func3ParamsRetIntMapper<TP1, TP2, TP3> : FunctionParamsMapperBase
    {
        public Func3ParamsRetIntMapper()
        {
            base.ReturnType = DataType.Int;
            base.ParamsCount = 3;
        }

        /// <summary>
        /// The function code attached to the functionCall.
        /// return an int.
        /// </summary>
        public Func<TP1, TP2, TP3, int> Function { get; private set; }

        // type P1
        //TP1 _param1;
        public DataType Param1Type { get; private set; }

        public DataType Param2Type { get; private set; }
        public DataType Param3Type { get; private set; }

        /// <summary>
        /// Attach a function to a functionCall.
        /// Check parameters.
        /// 
        /// Get return and parameter infos:
        /// bool Boolean
        /// int  Int32.
        /// </summary>
        /// <param name="func"></param>
        public bool SetFunction(Func<TP1, TP2, TP3, int> func)
        {
            Function = func;

            if (func == null)
                return false;

            // get the type of the parameter 1
            ParameterInfo[] parameterInfos = func.Method.GetParameters();

            // find param1 type
            DataType dataType;
            if (!SetDataType(parameterInfos[0].ParameterType.Name, out dataType))
                return false;
            Param1Type = dataType;

            // find param2 type
            if (!SetDataType(parameterInfos[1].ParameterType.Name, out dataType))
                return false;
            Param2Type = dataType;

            // find param13 type
            if (!SetDataType(parameterInfos[2].ParameterType.Name, out dataType))
                return false;
            Param3Type = dataType;

            return SetMethodSignature(Param1Type, Param2Type, Param3Type);
        }

        /// <summary>
        /// Set the method signature.
        /// return an int.
        /// </summary>
        /// <param name="param1Type"></param>
        /// <param name="param2Type"></param>
        /// <param name="param3Type"></param>
        /// <returns></returns>
        private bool SetMethodSignature(DataType param1Type, DataType param2Type, DataType param3Type)
        {
            if (param1Type == DataType.Bool && param2Type == DataType.Bool && param3Type == DataType.Bool)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Bool_Bool_Bool;
                return true;
            }

            if (param1Type == DataType.Bool && param2Type == DataType.Bool && param3Type == DataType.Int)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Bool_Bool_Int;
                return true;
            }

            if (param1Type == DataType.Bool && param2Type == DataType.Bool && param3Type == DataType.String)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Bool_Bool_String;
                return true;
            }

            if (param1Type == DataType.Bool && param2Type == DataType.Bool && param3Type == DataType.Double)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Bool_Bool_Double;
                return true;
            }

            if (param1Type == DataType.Bool && param2Type == DataType.Int && param3Type == DataType.Bool)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Bool_Int_Bool;
                return true;
            }

            if (param1Type == DataType.Bool && param2Type == DataType.Int && param3Type == DataType.Int)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Bool_Int_Int;
                return true;
            }

            if (param1Type == DataType.Bool && param2Type == DataType.Int && param3Type == DataType.String)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Bool_Int_String;
                return true;
            }

            if (param1Type == DataType.Bool && param2Type == DataType.Int && param3Type == DataType.Double)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Bool_Int_Double;
                return true;
            }

            if (param1Type == DataType.Bool && param2Type == DataType.String && param3Type == DataType.Bool)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Bool_String_Bool;
                return true;
            }

            if (param1Type == DataType.Bool && param2Type == DataType.String && param3Type == DataType.Int)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Bool_String_Int;
                return true;
            }

            if (param1Type == DataType.Bool && param2Type == DataType.String && param3Type == DataType.String)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Bool_String_String;
                return true;
            }

            if (param1Type == DataType.Bool && param2Type == DataType.String && param3Type == DataType.Double)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Bool_String_Double;
                return true;
            }

            if (param1Type == DataType.Bool && param2Type == DataType.Double && param3Type == DataType.Bool)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Bool_Double_Bool;
                return true;
            }

            if (param1Type == DataType.Bool && param2Type == DataType.Double && param3Type == DataType.Int)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Bool_Double_Int;
                return true;
            }

            if (param1Type == DataType.Bool && param2Type == DataType.Double && param3Type == DataType.String)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Bool_Double_String;
                return true;
            }

            if (param1Type == DataType.Bool && param2Type == DataType.Double && param3Type == DataType.Double)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Bool_Double_Double;
                return true;
            }

            if (param1Type == DataType.Int && param2Type == DataType.Bool && param3Type == DataType.Bool)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Int_Bool_Bool;
                return true;
            }

            if (param1Type == DataType.Int && param2Type == DataType.Bool && param3Type == DataType.Int)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Int_Bool_Int;
                return true;
            }

            if (param1Type == DataType.Int && param2Type == DataType.Bool && param3Type == DataType.String)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Int_Bool_String;
                return true;
            }

            if (param1Type == DataType.Int && param2Type == DataType.Bool && param3Type == DataType.Double)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Int_Bool_Double;
                return true;
            }

            if (param1Type == DataType.Int && param2Type == DataType.Int && param3Type == DataType.Bool)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Int_Int_Bool;
                return true;
            }

            if (param1Type == DataType.Int && param2Type == DataType.Int && param3Type == DataType.Int)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Int_Int_Int;
                return true;
            }

            if (param1Type == DataType.Int && param2Type == DataType.Int && param3Type == DataType.String)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Int_Int_String;
                return true;
            }

            if (param1Type == DataType.Int && param2Type == DataType.Int && param3Type == DataType.Double)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Int_Int_Double;
                return true;
            }

            if (param1Type == DataType.Int && param2Type == DataType.String && param3Type == DataType.Bool)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Int_String_Bool;
                return true;
            }

            if (param1Type == DataType.Int && param2Type == DataType.String && param3Type == DataType.Int)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Int_String_Int;
                return true;
            }

            if (param1Type == DataType.Int && param2Type == DataType.String && param3Type == DataType.String)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Int_String_String;
                return true;
            }

            if (param1Type == DataType.Int && param2Type == DataType.String && param3Type == DataType.Double)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Int_String_Double;
                return true;
            }

            if (param1Type == DataType.Int && param2Type == DataType.Double && param3Type == DataType.Bool)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Int_Double_Bool;
                return true;
            }

            if (param1Type == DataType.Int && param2Type == DataType.Double && param3Type == DataType.Int)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Int_Double_Int;
                return true;
            }

            if (param1Type == DataType.Int && param2Type == DataType.Double && param3Type == DataType.String)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Int_Double_String;
                return true;
            }

            if (param1Type == DataType.Int && param2Type == DataType.Double && param3Type == DataType.Double)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Int_Double_Double;
                return true;
            }

            if (param1Type == DataType.String && param2Type == DataType.Bool && param3Type == DataType.Bool)
            {
                this.MethodSignature = MethodSignatureType.RetInt_String_Bool_Bool;
                return true;
            }

            if (param1Type == DataType.String && param2Type == DataType.Bool && param3Type == DataType.Int)
            {
                this.MethodSignature = MethodSignatureType.RetInt_String_Bool_Int;
                return true;
            }

            if (param1Type == DataType.String && param2Type == DataType.Bool && param3Type == DataType.String)
            {
                this.MethodSignature = MethodSignatureType.RetInt_String_Bool_String;
                return true;
            }

            if (param1Type == DataType.String && param2Type == DataType.Bool && param3Type == DataType.Double)
            {
                this.MethodSignature = MethodSignatureType.RetInt_String_Bool_Double;
                return true;
            }

            if (param1Type == DataType.String && param2Type == DataType.Int && param3Type == DataType.Bool)
            {
                this.MethodSignature = MethodSignatureType.RetInt_String_Int_Bool;
                return true;
            }

            if (param1Type == DataType.String && param2Type == DataType.Int && param3Type == DataType.Int)
            {
                this.MethodSignature = MethodSignatureType.RetInt_String_Int_Int;
                return true;
            }

            if (param1Type == DataType.String && param2Type == DataType.Int && param3Type == DataType.String)
            {
                this.MethodSignature = MethodSignatureType.RetInt_String_Int_String;
                return true;
            }

            if (param1Type == DataType.String && param2Type == DataType.Int && param3Type == DataType.Double)
            {
                this.MethodSignature = MethodSignatureType.RetInt_String_Int_Double;
                return true;
            }

            if (param1Type == DataType.String && param2Type == DataType.String && param3Type == DataType.Bool)
            {
                this.MethodSignature = MethodSignatureType.RetInt_String_String_Bool;
                return true;
            }

            if (param1Type == DataType.String && param2Type == DataType.String && param3Type == DataType.Int)
            {
                this.MethodSignature = MethodSignatureType.RetInt_String_String_Int;
                return true;
            }

            if (param1Type == DataType.String && param2Type == DataType.String && param3Type == DataType.String)
            {
                this.MethodSignature = MethodSignatureType.RetInt_String_String_String;
                return true;
            }

            if (param1Type == DataType.String && param2Type == DataType.String && param3Type == DataType.Double)
            {
                this.MethodSignature = MethodSignatureType.RetInt_String_String_Double;
                return true;
            }

            if (param1Type == DataType.String && param2Type == DataType.Double && param3Type == DataType.Bool)
            {
                this.MethodSignature = MethodSignatureType.RetInt_String_Double_Bool;
                return true;
            }

            if (param1Type == DataType.String && param2Type == DataType.Double && param3Type == DataType.Int)
            {
                this.MethodSignature = MethodSignatureType.RetInt_String_Double_Int;
                return true;
            }

            if (param1Type == DataType.String && param2Type == DataType.Double && param3Type == DataType.String)
            {
                this.MethodSignature = MethodSignatureType.RetInt_String_Double_String;
                return true;
            }

            if (param1Type == DataType.String && param2Type == DataType.Double && param3Type == DataType.Double)
            {
                this.MethodSignature = MethodSignatureType.RetInt_String_Double_Double;
                return true;
            }

            if (param1Type == DataType.Double && param2Type == DataType.Bool && param3Type == DataType.Bool)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Double_Bool_Bool;
                return true;
            }

            if (param1Type == DataType.Double && param2Type == DataType.Bool && param3Type == DataType.Int)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Double_Bool_Int;
                return true;
            }

            if (param1Type == DataType.Double && param2Type == DataType.Bool && param3Type == DataType.String)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Double_Bool_String;
                return true;
            }

            if (param1Type == DataType.Double && param2Type == DataType.Bool && param3Type == DataType.Double)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Double_Bool_Double;
                return true;
            }

            if (param1Type == DataType.Double && param2Type == DataType.Int && param3Type == DataType.Bool)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Double_Int_Bool;
                return true;
            }

            if (param1Type == DataType.Double && param2Type == DataType.Int && param3Type == DataType.Int)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Double_Int_Int;
                return true;
            }

            if (param1Type == DataType.Double && param2Type == DataType.Int && param3Type == DataType.String)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Double_Int_String;
                return true;
            }

            if (param1Type == DataType.Double && param2Type == DataType.Int && param3Type == DataType.Double)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Double_Int_Double;
                return true;
            }

            if (param1Type == DataType.Double && param2Type == DataType.String && param3Type == DataType.Bool)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Double_String_Bool;
                return true;
            }

            if (param1Type == DataType.Double && param2Type == DataType.String && param3Type == DataType.Int)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Double_String_Int;
                return true;
            }

            if (param1Type == DataType.Double && param2Type == DataType.String && param3Type == DataType.String)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Double_String_String;
                return true;
            }

            if (param1Type == DataType.Double && param2Type == DataType.String && param3Type == DataType.Double)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Double_String_Double;
                return true;
            }

            if (param1Type == DataType.Double && param2Type == DataType.Double && param3Type == DataType.Bool)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Double_Double_Bool;
                return true;
            }

            if (param1Type == DataType.Double && param2Type == DataType.Double && param3Type == DataType.Int)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Double_Double_Int;
                return true;
            }

            if (param1Type == DataType.Double && param2Type == DataType.Double && param3Type == DataType.String)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Double_Double_String;
                return true;
            }

            if (param1Type == DataType.Double && param2Type == DataType.Double && param3Type == DataType.Double)
            {
                this.MethodSignature = MethodSignatureType.RetInt_Double_Double_Double;
                return true;
            }


            return false;
        }
    }
}
