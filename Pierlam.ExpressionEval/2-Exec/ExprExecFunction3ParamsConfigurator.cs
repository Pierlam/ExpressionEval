using System;
using System.Collections.Generic;
using System.Text;

namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// To attach function having 3 parameters.
    /// </summary>
    public class ExprExecFunction3ParamsConfigurator
    {
        ExpressionEvalConfig _exprEvalConfig;

        public bool AttachFunctionRetBool(ExpressionEvalConfig exprEvalConfig, FunctionParamsMapperBase funcParamsMapperBase, FunctionToCallMapper functionToCall, out ExprError error)
        {
            _exprEvalConfig = exprEvalConfig;
            error = null;

            //--ret: bool P1: bool, P2: bool, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Bool_Bool_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<bool, bool, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Bool_Bool_Bool;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncBool_Bool_Bool_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: bool, P2: bool, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Bool_Bool_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<bool, bool, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Bool_Bool_Int;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncBool_Bool_Bool_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: bool, P2: bool, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Bool_Bool_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<bool, bool, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Bool_Bool_String;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncBool_Bool_Bool_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: bool, P2: bool, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Bool_Bool_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<bool, bool, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Bool_Bool_Double;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncBool_Bool_Bool_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: bool, P2: int, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Bool_Int_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<bool, int, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Bool_Int_Bool;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncBool_Bool_Int_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: bool, P2: int, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Bool_Int_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<bool, int, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Bool_Int_Int;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncBool_Bool_Int_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: bool, P2: int, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Bool_Int_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<bool, int, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Bool_Int_String;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncBool_Bool_Int_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: bool, P2: int, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Bool_Int_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<bool, int, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Bool_Int_Double;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncBool_Bool_Int_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: bool, P2: string, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Bool_String_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<bool, string, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Bool_String_Bool;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncBool_Bool_String_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: bool, P2: string, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Bool_String_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<bool, string, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Bool_String_Int;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncBool_Bool_String_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: bool, P2: string, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Bool_String_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<bool, string, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Bool_String_String;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncBool_Bool_String_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: bool, P2: string, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Bool_String_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<bool, string, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Bool_String_Double;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncBool_Bool_String_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: bool, P2: double, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Bool_Double_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<bool, double, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Bool_Double_Bool;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncBool_Bool_Double_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: bool, P2: double, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Bool_Double_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<bool, double, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Bool_Double_Int;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncBool_Bool_Double_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: bool, P2: double, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Bool_Double_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<bool, double, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Bool_Double_String;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncBool_Bool_Double_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: bool, P2: double, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Bool_Double_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<bool, double, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Bool_Double_Double;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncBool_Bool_Double_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: int, P2: bool, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Int_Bool_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<int, bool, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Int_Bool_Bool;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncBool_Int_Bool_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: int, P2: bool, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Int_Bool_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<int, bool, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Int_Bool_Int;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncBool_Int_Bool_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: int, P2: bool, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Int_Bool_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<int, bool, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Int_Bool_String;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncBool_Int_Bool_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: int, P2: bool, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Int_Bool_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<int, bool, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Int_Bool_Double;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncBool_Int_Bool_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: int, P2: int, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Int_Int_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<int, int, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Int_Int_Bool;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncBool_Int_Int_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: int, P2: int, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Int_Int_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<int, int, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Int_Int_Int;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncBool_Int_Int_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: int, P2: int, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Int_Int_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<int, int, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Int_Int_String;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncBool_Int_Int_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: int, P2: int, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Int_Int_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<int, int, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Int_Int_Double;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncBool_Int_Int_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: int, P2: string, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Int_String_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<int, string, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Int_String_Bool;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncBool_Int_String_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: int, P2: string, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Int_String_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<int, string, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Int_String_Int;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncBool_Int_String_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: int, P2: string, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Int_String_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<int, string, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Int_String_String;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncBool_Int_String_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: int, P2: string, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Int_String_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<int, string, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Int_String_Double;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncBool_Int_String_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: int, P2: double, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Int_Double_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<int, double, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Int_Double_Bool;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncBool_Int_Double_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: int, P2: double, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Int_Double_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<int, double, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Int_Double_Int;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncBool_Int_Double_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: int, P2: double, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Int_Double_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<int, double, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Int_Double_String;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncBool_Int_Double_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: int, P2: double, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Int_Double_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<int, double, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Int_Double_Double;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncBool_Int_Double_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: string, P2: bool, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_String_Bool_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<string, bool, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_String_Bool_Bool;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncBool_String_Bool_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: string, P2: bool, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_String_Bool_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<string, bool, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_String_Bool_Int;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncBool_String_Bool_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: string, P2: bool, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_String_Bool_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<string, bool, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_String_Bool_String;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncBool_String_Bool_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: string, P2: bool, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_String_Bool_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<string, bool, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_String_Bool_Double;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncBool_String_Bool_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: string, P2: int, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_String_Int_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<string, int, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_String_Int_Bool;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncBool_String_Int_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: string, P2: int, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_String_Int_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<string, int, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_String_Int_Int;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncBool_String_Int_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: string, P2: int, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_String_Int_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<string, int, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_String_Int_String;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncBool_String_Int_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: string, P2: int, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_String_Int_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<string, int, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_String_Int_Double;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncBool_String_Int_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: string, P2: string, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_String_String_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<string, string, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_String_String_Bool;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncBool_String_String_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: string, P2: string, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_String_String_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<string, string, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_String_String_Int;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncBool_String_String_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: string, P2: string, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_String_String_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<string, string, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_String_String_String;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncBool_String_String_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: string, P2: string, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_String_String_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<string, string, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_String_String_Double;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncBool_String_String_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: string, P2: double, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_String_Double_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<string, double, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_String_Double_Bool;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncBool_String_Double_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: string, P2: double, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_String_Double_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<string, double, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_String_Double_Int;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncBool_String_Double_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: string, P2: double, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_String_Double_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<string, double, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_String_Double_String;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncBool_String_Double_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: string, P2: double, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_String_Double_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<string, double, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_String_Double_Double;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncBool_String_Double_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: double, P2: bool, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Double_Bool_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<double, bool, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Double_Bool_Bool;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncBool_Double_Bool_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: double, P2: bool, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Double_Bool_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<double, bool, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Double_Bool_Int;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncBool_Double_Bool_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: double, P2: bool, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Double_Bool_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<double, bool, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Double_Bool_String;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncBool_Double_Bool_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: double, P2: bool, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Double_Bool_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<double, bool, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Double_Bool_Double;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncBool_Double_Bool_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: double, P2: int, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Double_Int_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<double, int, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Double_Int_Bool;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncBool_Double_Int_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: double, P2: int, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Double_Int_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<double, int, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Double_Int_Int;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncBool_Double_Int_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: double, P2: int, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Double_Int_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<double, int, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Double_Int_String;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncBool_Double_Int_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: double, P2: int, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Double_Int_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<double, int, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Double_Int_Double;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncBool_Double_Int_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: double, P2: string, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Double_String_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<double, string, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Double_String_Bool;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncBool_Double_String_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: double, P2: string, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Double_String_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<double, string, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Double_String_Int;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncBool_Double_String_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: double, P2: string, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Double_String_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<double, string, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Double_String_String;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncBool_Double_String_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: double, P2: string, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Double_String_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<double, string, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Double_String_Double;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncBool_Double_String_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: double, P2: double, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Double_Double_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<double, double, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Double_Double_Bool;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncBool_Double_Double_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: double, P2: double, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Double_Double_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<double, double, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Double_Double_Int;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncBool_Double_Double_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: double, P2: double, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Double_Double_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<double, double, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Double_Double_String;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncBool_Double_Double_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: bool P1: double, P2: double, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetBool_Double_Double_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetBoolMapper<double, double, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetBool_Double_Double_Double;
                functionToCall.ReturnType = DataType.Bool;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncBool_Double_Double_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            // err, not managed or not yet implemented
            error = new ExprError();
            error.Code = ErrorCode.FunctionCall3ParamsNotManaged;
            error.AddParam("RetType", "bool");
            return false;
        }

        public bool AttachFunctionRetInt(ExpressionEvalConfig exprEvalConfig, FunctionParamsMapperBase funcParamsMapperBase, FunctionToCallMapper functionToCall, out ExprError error)
        {
            _exprEvalConfig = exprEvalConfig;
            error = null;

            //--ret: int P1: bool, P2: bool, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Bool_Bool_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<bool, bool, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Bool_Bool_Bool;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncInt_Bool_Bool_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: bool, P2: bool, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Bool_Bool_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<bool, bool, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Bool_Bool_Int;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncInt_Bool_Bool_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: bool, P2: bool, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Bool_Bool_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<bool, bool, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Bool_Bool_String;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncInt_Bool_Bool_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: bool, P2: bool, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Bool_Bool_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<bool, bool, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Bool_Bool_Double;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncInt_Bool_Bool_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: bool, P2: int, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Bool_Int_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<bool, int, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Bool_Int_Bool;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncInt_Bool_Int_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: bool, P2: int, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Bool_Int_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<bool, int, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Bool_Int_Int;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncInt_Bool_Int_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: bool, P2: int, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Bool_Int_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<bool, int, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Bool_Int_String;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncInt_Bool_Int_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: bool, P2: int, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Bool_Int_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<bool, int, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Bool_Int_Double;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncInt_Bool_Int_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: bool, P2: string, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Bool_String_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<bool, string, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Bool_String_Bool;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncInt_Bool_String_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: bool, P2: string, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Bool_String_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<bool, string, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Bool_String_Int;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncInt_Bool_String_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: bool, P2: string, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Bool_String_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<bool, string, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Bool_String_String;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncInt_Bool_String_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: bool, P2: string, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Bool_String_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<bool, string, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Bool_String_Double;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncInt_Bool_String_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: bool, P2: double, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Bool_Double_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<bool, double, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Bool_Double_Bool;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncInt_Bool_Double_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: bool, P2: double, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Bool_Double_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<bool, double, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Bool_Double_Int;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncInt_Bool_Double_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: bool, P2: double, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Bool_Double_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<bool, double, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Bool_Double_String;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncInt_Bool_Double_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: bool, P2: double, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Bool_Double_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<bool, double, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Bool_Double_Double;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncInt_Bool_Double_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: int, P2: bool, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Int_Bool_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<int, bool, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Int_Bool_Bool;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncInt_Int_Bool_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: int, P2: bool, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Int_Bool_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<int, bool, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Int_Bool_Int;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncInt_Int_Bool_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: int, P2: bool, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Int_Bool_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<int, bool, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Int_Bool_String;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncInt_Int_Bool_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: int, P2: bool, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Int_Bool_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<int, bool, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Int_Bool_Double;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncInt_Int_Bool_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: int, P2: int, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Int_Int_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<int, int, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Int_Int_Bool;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncInt_Int_Int_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: int, P2: int, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Int_Int_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<int, int, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Int_Int_Int;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncInt_Int_Int_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: int, P2: int, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Int_Int_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<int, int, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Int_Int_String;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncInt_Int_Int_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: int, P2: int, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Int_Int_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<int, int, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Int_Int_Double;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncInt_Int_Int_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: int, P2: string, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Int_String_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<int, string, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Int_String_Bool;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncInt_Int_String_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: int, P2: string, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Int_String_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<int, string, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Int_String_Int;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncInt_Int_String_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: int, P2: string, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Int_String_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<int, string, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Int_String_String;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncInt_Int_String_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: int, P2: string, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Int_String_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<int, string, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Int_String_Double;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncInt_Int_String_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: int, P2: double, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Int_Double_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<int, double, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Int_Double_Bool;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncInt_Int_Double_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: int, P2: double, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Int_Double_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<int, double, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Int_Double_Int;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncInt_Int_Double_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: int, P2: double, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Int_Double_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<int, double, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Int_Double_String;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncInt_Int_Double_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: int, P2: double, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Int_Double_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<int, double, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Int_Double_Double;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncInt_Int_Double_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: string, P2: bool, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_String_Bool_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<string, bool, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_String_Bool_Bool;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncInt_String_Bool_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: string, P2: bool, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_String_Bool_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<string, bool, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_String_Bool_Int;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncInt_String_Bool_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: string, P2: bool, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_String_Bool_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<string, bool, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_String_Bool_String;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncInt_String_Bool_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: string, P2: bool, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_String_Bool_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<string, bool, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_String_Bool_Double;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncInt_String_Bool_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: string, P2: int, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_String_Int_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<string, int, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_String_Int_Bool;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncInt_String_Int_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: string, P2: int, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_String_Int_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<string, int, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_String_Int_Int;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncInt_String_Int_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: string, P2: int, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_String_Int_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<string, int, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_String_Int_String;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncInt_String_Int_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: string, P2: int, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_String_Int_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<string, int, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_String_Int_Double;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncInt_String_Int_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: string, P2: string, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_String_String_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<string, string, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_String_String_Bool;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncInt_String_String_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: string, P2: string, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_String_String_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<string, string, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_String_String_Int;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncInt_String_String_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: string, P2: string, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_String_String_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<string, string, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_String_String_String;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncInt_String_String_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: string, P2: string, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_String_String_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<string, string, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_String_String_Double;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncInt_String_String_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: string, P2: double, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_String_Double_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<string, double, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_String_Double_Bool;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncInt_String_Double_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: string, P2: double, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_String_Double_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<string, double, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_String_Double_Int;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncInt_String_Double_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: string, P2: double, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_String_Double_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<string, double, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_String_Double_String;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncInt_String_Double_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: string, P2: double, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_String_Double_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<string, double, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_String_Double_Double;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncInt_String_Double_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: double, P2: bool, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Double_Bool_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<double, bool, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Double_Bool_Bool;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncInt_Double_Bool_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: double, P2: bool, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Double_Bool_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<double, bool, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Double_Bool_Int;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncInt_Double_Bool_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: double, P2: bool, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Double_Bool_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<double, bool, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Double_Bool_String;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncInt_Double_Bool_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: double, P2: bool, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Double_Bool_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<double, bool, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Double_Bool_Double;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncInt_Double_Bool_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: double, P2: int, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Double_Int_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<double, int, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Double_Int_Bool;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncInt_Double_Int_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: double, P2: int, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Double_Int_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<double, int, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Double_Int_Int;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncInt_Double_Int_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: double, P2: int, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Double_Int_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<double, int, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Double_Int_String;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncInt_Double_Int_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: double, P2: int, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Double_Int_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<double, int, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Double_Int_Double;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncInt_Double_Int_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: double, P2: string, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Double_String_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<double, string, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Double_String_Bool;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncInt_Double_String_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: double, P2: string, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Double_String_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<double, string, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Double_String_Int;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncInt_Double_String_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: double, P2: string, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Double_String_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<double, string, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Double_String_String;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncInt_Double_String_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: double, P2: string, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Double_String_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<double, string, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Double_String_Double;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncInt_Double_String_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: double, P2: double, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Double_Double_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<double, double, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Double_Double_Bool;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncInt_Double_Double_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: double, P2: double, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Double_Double_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<double, double, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Double_Double_Int;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncInt_Double_Double_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: double, P2: double, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Double_Double_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<double, double, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Double_Double_String;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncInt_Double_Double_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: int P1: double, P2: double, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetInt_Double_Double_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetIntMapper<double, double, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetInt_Double_Double_Double;
                functionToCall.ReturnType = DataType.Int;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncInt_Double_Double_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }


            // err, not managed or not yet implemented
            error = new ExprError();
            error.Code = ErrorCode.FunctionCall3ParamsNotManaged;
            error.AddParam("RetType", "int");
            return false;
        }

        public bool AttachFunctionRetString(ExpressionEvalConfig exprEvalConfig, FunctionParamsMapperBase funcParamsMapperBase, FunctionToCallMapper functionToCall, out ExprError error)
        {
            _exprEvalConfig = exprEvalConfig;
            error = null;

            //--ret: string P1: bool, P2: bool, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Bool_Bool_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<bool, bool, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Bool_Bool_Bool;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncString_Bool_Bool_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: bool, P2: bool, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Bool_Bool_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<bool, bool, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Bool_Bool_Int;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncString_Bool_Bool_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: bool, P2: bool, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Bool_Bool_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<bool, bool, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Bool_Bool_String;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncString_Bool_Bool_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: bool, P2: bool, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Bool_Bool_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<bool, bool, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Bool_Bool_Double;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncString_Bool_Bool_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: bool, P2: int, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Bool_Int_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<bool, int, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Bool_Int_Bool;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncString_Bool_Int_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: bool, P2: int, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Bool_Int_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<bool, int, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Bool_Int_Int;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncString_Bool_Int_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: bool, P2: int, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Bool_Int_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<bool, int, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Bool_Int_String;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncString_Bool_Int_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: bool, P2: int, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Bool_Int_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<bool, int, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Bool_Int_Double;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncString_Bool_Int_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: bool, P2: string, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Bool_String_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<bool, string, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Bool_String_Bool;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncString_Bool_String_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: bool, P2: string, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Bool_String_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<bool, string, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Bool_String_Int;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncString_Bool_String_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: bool, P2: string, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Bool_String_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<bool, string, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Bool_String_String;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncString_Bool_String_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: bool, P2: string, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Bool_String_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<bool, string, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Bool_String_Double;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncString_Bool_String_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: bool, P2: double, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Bool_Double_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<bool, double, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Bool_Double_Bool;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncString_Bool_Double_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: bool, P2: double, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Bool_Double_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<bool, double, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Bool_Double_Int;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncString_Bool_Double_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: bool, P2: double, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Bool_Double_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<bool, double, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Bool_Double_String;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncString_Bool_Double_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: bool, P2: double, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Bool_Double_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<bool, double, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Bool_Double_Double;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncString_Bool_Double_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: int, P2: bool, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Int_Bool_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<int, bool, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Int_Bool_Bool;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncString_Int_Bool_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: int, P2: bool, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Int_Bool_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<int, bool, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Int_Bool_Int;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncString_Int_Bool_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: int, P2: bool, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Int_Bool_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<int, bool, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Int_Bool_String;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncString_Int_Bool_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: int, P2: bool, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Int_Bool_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<int, bool, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Int_Bool_Double;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncString_Int_Bool_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: int, P2: int, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Int_Int_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<int, int, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Int_Int_Bool;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncString_Int_Int_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: int, P2: int, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Int_Int_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<int, int, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Int_Int_Int;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncString_Int_Int_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: int, P2: int, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Int_Int_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<int, int, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Int_Int_String;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncString_Int_Int_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: int, P2: int, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Int_Int_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<int, int, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Int_Int_Double;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncString_Int_Int_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: int, P2: string, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Int_String_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<int, string, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Int_String_Bool;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncString_Int_String_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: int, P2: string, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Int_String_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<int, string, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Int_String_Int;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncString_Int_String_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: int, P2: string, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Int_String_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<int, string, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Int_String_String;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncString_Int_String_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: int, P2: string, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Int_String_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<int, string, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Int_String_Double;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncString_Int_String_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: int, P2: double, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Int_Double_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<int, double, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Int_Double_Bool;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncString_Int_Double_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: int, P2: double, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Int_Double_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<int, double, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Int_Double_Int;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncString_Int_Double_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: int, P2: double, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Int_Double_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<int, double, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Int_Double_String;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncString_Int_Double_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: int, P2: double, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Int_Double_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<int, double, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Int_Double_Double;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncString_Int_Double_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: string, P2: bool, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_String_Bool_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<string, bool, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_String_Bool_Bool;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncString_String_Bool_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: string, P2: bool, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_String_Bool_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<string, bool, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_String_Bool_Int;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncString_String_Bool_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: string, P2: bool, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_String_Bool_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<string, bool, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_String_Bool_String;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncString_String_Bool_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: string, P2: bool, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_String_Bool_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<string, bool, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_String_Bool_Double;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncString_String_Bool_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: string, P2: int, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_String_Int_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<string, int, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_String_Int_Bool;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncString_String_Int_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: string, P2: int, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_String_Int_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<string, int, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_String_Int_Int;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncString_String_Int_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: string, P2: int, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_String_Int_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<string, int, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_String_Int_String;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncString_String_Int_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: string, P2: int, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_String_Int_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<string, int, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_String_Int_Double;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncString_String_Int_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: string, P2: string, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_String_String_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<string, string, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_String_String_Bool;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncString_String_String_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: string, P2: string, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_String_String_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<string, string, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_String_String_Int;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncString_String_String_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: string, P2: string, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_String_String_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<string, string, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_String_String_String;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncString_String_String_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: string, P2: string, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_String_String_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<string, string, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_String_String_Double;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncString_String_String_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: string, P2: double, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_String_Double_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<string, double, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_String_Double_Bool;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncString_String_Double_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: string, P2: double, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_String_Double_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<string, double, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_String_Double_Int;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncString_String_Double_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: string, P2: double, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_String_Double_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<string, double, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_String_Double_String;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncString_String_Double_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: string, P2: double, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_String_Double_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<string, double, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_String_Double_Double;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncString_String_Double_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: double, P2: bool, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Double_Bool_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<double, bool, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Double_Bool_Bool;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncString_Double_Bool_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: double, P2: bool, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Double_Bool_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<double, bool, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Double_Bool_Int;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncString_Double_Bool_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: double, P2: bool, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Double_Bool_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<double, bool, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Double_Bool_String;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncString_Double_Bool_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: double, P2: bool, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Double_Bool_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<double, bool, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Double_Bool_Double;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncString_Double_Bool_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: double, P2: int, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Double_Int_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<double, int, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Double_Int_Bool;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncString_Double_Int_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: double, P2: int, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Double_Int_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<double, int, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Double_Int_Int;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncString_Double_Int_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: double, P2: int, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Double_Int_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<double, int, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Double_Int_String;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncString_Double_Int_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: double, P2: int, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Double_Int_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<double, int, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Double_Int_Double;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncString_Double_Int_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: double, P2: string, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Double_String_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<double, string, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Double_String_Bool;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncString_Double_String_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: double, P2: string, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Double_String_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<double, string, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Double_String_Int;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncString_Double_String_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: double, P2: string, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Double_String_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<double, string, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Double_String_String;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncString_Double_String_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: double, P2: string, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Double_String_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<double, string, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Double_String_Double;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncString_Double_String_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: double, P2: double, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Double_Double_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<double, double, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Double_Double_Bool;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncString_Double_Double_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: double, P2: double, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Double_Double_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<double, double, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Double_Double_Int;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncString_Double_Double_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: double, P2: double, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Double_Double_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<double, double, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Double_Double_String;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncString_Double_Double_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: string P1: double, P2: double, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetString_Double_Double_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetStringMapper<double, double, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetString_Double_Double_Double;
                functionToCall.ReturnType = DataType.String;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncString_Double_Double_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }


            // err, not managed or not yet implemented
            error = new ExprError();
            error.Code = ErrorCode.FunctionCall3ParamsNotManaged;
            error.AddParam("RetType", "string");
            return false;
        }

        public bool AttachFunctionRetDouble(ExpressionEvalConfig exprEvalConfig, FunctionParamsMapperBase funcParamsMapperBase, FunctionToCallMapper functionToCall, out ExprError error)
        {
            _exprEvalConfig = exprEvalConfig;
            error = null;

            //--ret: double P1: bool, P2: bool, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Bool_Bool_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<bool, bool, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Bool_Bool_Bool;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncDouble_Bool_Bool_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: bool, P2: bool, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Bool_Bool_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<bool, bool, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Bool_Bool_Int;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncDouble_Bool_Bool_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: bool, P2: bool, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Bool_Bool_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<bool, bool, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Bool_Bool_String;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncDouble_Bool_Bool_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: bool, P2: bool, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Bool_Bool_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<bool, bool, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Bool_Bool_Double;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncDouble_Bool_Bool_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: bool, P2: int, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Bool_Int_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<bool, int, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Bool_Int_Bool;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncDouble_Bool_Int_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: bool, P2: int, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Bool_Int_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<bool, int, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Bool_Int_Int;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncDouble_Bool_Int_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: bool, P2: int, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Bool_Int_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<bool, int, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Bool_Int_String;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncDouble_Bool_Int_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: bool, P2: int, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Bool_Int_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<bool, int, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Bool_Int_Double;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncDouble_Bool_Int_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: bool, P2: string, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Bool_String_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<bool, string, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Bool_String_Bool;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncDouble_Bool_String_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: bool, P2: string, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Bool_String_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<bool, string, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Bool_String_Int;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncDouble_Bool_String_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: bool, P2: string, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Bool_String_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<bool, string, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Bool_String_String;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncDouble_Bool_String_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: bool, P2: string, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Bool_String_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<bool, string, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Bool_String_Double;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncDouble_Bool_String_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: bool, P2: double, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Bool_Double_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<bool, double, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Bool_Double_Bool;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncDouble_Bool_Double_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: bool, P2: double, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Bool_Double_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<bool, double, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Bool_Double_Int;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncDouble_Bool_Double_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: bool, P2: double, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Bool_Double_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<bool, double, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Bool_Double_String;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncDouble_Bool_Double_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: bool, P2: double, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Bool_Double_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<bool, double, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Bool_Double_Double;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Bool;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncDouble_Bool_Double_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: int, P2: bool, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Int_Bool_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<int, bool, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Int_Bool_Bool;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncDouble_Int_Bool_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: int, P2: bool, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Int_Bool_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<int, bool, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Int_Bool_Int;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncDouble_Int_Bool_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: int, P2: bool, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Int_Bool_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<int, bool, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Int_Bool_String;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncDouble_Int_Bool_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: int, P2: bool, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Int_Bool_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<int, bool, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Int_Bool_Double;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncDouble_Int_Bool_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: int, P2: int, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Int_Int_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<int, int, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Int_Int_Bool;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncDouble_Int_Int_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: int, P2: int, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Int_Int_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<int, int, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Int_Int_Int;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncDouble_Int_Int_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: int, P2: int, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Int_Int_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<int, int, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Int_Int_String;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncDouble_Int_Int_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: int, P2: int, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Int_Int_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<int, int, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Int_Int_Double;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncDouble_Int_Int_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: int, P2: string, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Int_String_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<int, string, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Int_String_Bool;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncDouble_Int_String_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: int, P2: string, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Int_String_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<int, string, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Int_String_Int;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncDouble_Int_String_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: int, P2: string, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Int_String_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<int, string, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Int_String_String;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncDouble_Int_String_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: int, P2: string, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Int_String_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<int, string, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Int_String_Double;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncDouble_Int_String_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: int, P2: double, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Int_Double_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<int, double, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Int_Double_Bool;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncDouble_Int_Double_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: int, P2: double, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Int_Double_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<int, double, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Int_Double_Int;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncDouble_Int_Double_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: int, P2: double, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Int_Double_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<int, double, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Int_Double_String;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncDouble_Int_Double_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: int, P2: double, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Int_Double_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<int, double, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Int_Double_Double;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Int;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncDouble_Int_Double_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: string, P2: bool, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_String_Bool_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<string, bool, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_String_Bool_Bool;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncDouble_String_Bool_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: string, P2: bool, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_String_Bool_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<string, bool, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_String_Bool_Int;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncDouble_String_Bool_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: string, P2: bool, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_String_Bool_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<string, bool, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_String_Bool_String;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncDouble_String_Bool_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: string, P2: bool, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_String_Bool_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<string, bool, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_String_Bool_Double;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncDouble_String_Bool_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: string, P2: int, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_String_Int_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<string, int, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_String_Int_Bool;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncDouble_String_Int_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: string, P2: int, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_String_Int_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<string, int, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_String_Int_Int;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncDouble_String_Int_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: string, P2: int, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_String_Int_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<string, int, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_String_Int_String;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncDouble_String_Int_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: string, P2: int, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_String_Int_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<string, int, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_String_Int_Double;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncDouble_String_Int_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: string, P2: string, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_String_String_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<string, string, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_String_String_Bool;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncDouble_String_String_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: string, P2: string, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_String_String_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<string, string, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_String_String_Int;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncDouble_String_String_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: string, P2: string, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_String_String_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<string, string, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_String_String_String;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncDouble_String_String_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: string, P2: string, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_String_String_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<string, string, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_String_String_Double;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncDouble_String_String_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: string, P2: double, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_String_Double_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<string, double, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_String_Double_Bool;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncDouble_String_Double_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: string, P2: double, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_String_Double_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<string, double, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_String_Double_Int;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncDouble_String_Double_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: string, P2: double, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_String_Double_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<string, double, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_String_Double_String;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncDouble_String_Double_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: string, P2: double, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_String_Double_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<string, double, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_String_Double_Double;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.String;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncDouble_String_Double_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: double, P2: bool, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Double_Bool_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<double, bool, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Double_Bool_Bool;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncDouble_Double_Bool_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: double, P2: bool, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Double_Bool_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<double, bool, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Double_Bool_Int;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncDouble_Double_Bool_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: double, P2: bool, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Double_Bool_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<double, bool, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Double_Bool_String;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncDouble_Double_Bool_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: double, P2: bool, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Double_Bool_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<double, bool, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Double_Bool_Double;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Bool;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncDouble_Double_Bool_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: double, P2: int, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Double_Int_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<double, int, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Double_Int_Bool;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncDouble_Double_Int_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: double, P2: int, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Double_Int_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<double, int, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Double_Int_Int;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncDouble_Double_Int_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: double, P2: int, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Double_Int_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<double, int, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Double_Int_String;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncDouble_Double_Int_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: double, P2: int, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Double_Int_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<double, int, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Double_Int_Double;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Int;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncDouble_Double_Int_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: double, P2: string, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Double_String_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<double, string, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Double_String_Bool;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncDouble_Double_String_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: double, P2: string, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Double_String_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<double, string, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Double_String_Int;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncDouble_Double_String_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: double, P2: string, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Double_String_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<double, string, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Double_String_String;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncDouble_Double_String_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: double, P2: string, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Double_String_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<double, string, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Double_String_Double;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.String;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncDouble_Double_String_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: double, P2: double, P3: bool
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Double_Double_Bool)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<double, double, bool>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Double_Double_Bool;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Bool;

                // set the function to call
                functionToCall.FuncDouble_Double_Double_Bool = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: double, P2: double, P3: int
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Double_Double_Int)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<double, double, int>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Double_Double_Int;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Int;

                // set the function to call
                functionToCall.FuncDouble_Double_Double_Int = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: double, P2: double, P3: string
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Double_Double_String)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<double, double, string>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Double_Double_String;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.String;

                // set the function to call
                functionToCall.FuncDouble_Double_Double_String = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }

            //--ret: double P1: double, P2: double, P3: double
            if (funcParamsMapperBase.MethodSignature == MethodSignatureType.RetDouble_Double_Double_Double)
            {
                var function3ParamsMapper = funcParamsMapperBase as Func3ParamsRetDoubleMapper<double, double, double>;

                functionToCall.Name = function3ParamsMapper.Function.Method.Name;
                // set the signature
                functionToCall.MethodSignature = MethodSignatureType.RetDouble_Double_Double_Double;
                functionToCall.ReturnType = DataType.Double;
                functionToCall.Param1Type = DataType.Double;
                functionToCall.Param2Type = DataType.Double;
                functionToCall.Param3Type = DataType.Double;

                // set the function to call
                functionToCall.FuncDouble_Double_Double_Double = function3ParamsMapper.Function;

                // if an attachment exists, replace it
                return AttachFunctionToCall(functionToCall);
            }


            // err, not managed or not yet implemented
            error = new ExprError();
            error.Code = ErrorCode.FunctionCall3ParamsNotManaged;
            error.AddParam("RetType", "double");
            return false;
        }


        /// <summary>
        /// Add a function to call linked to a functionCall used in the expression.
        /// The link is done by the functionCall name.
        /// If already exists, replace it with the function code.
        /// </summary>
        /// <param name="functionToCall"></param>
        /// <returns></returns>
        private bool AttachFunctionToCall(FunctionToCallMapper functionToCall)
        {
            // check if the linked functionCall has not already a function to call mapped
            FunctionToCallMapper functionToCallAttached = _exprEvalConfig.ListFunctionToCallMapper.Find(ftm => ftm.FunctionCallName.Equals(functionToCall.FunctionCallName, StringComparison.InvariantCultureIgnoreCase));
            // a function is already linked to the functionCall
            if (functionToCallAttached != null)
                // remove it( to replace it)
                _exprEvalConfig.ListFunctionToCallMapper.Remove(functionToCallAttached);

            _exprEvalConfig.ListFunctionToCallMapper.Add(functionToCall);
            return true;
        }

    }
}
