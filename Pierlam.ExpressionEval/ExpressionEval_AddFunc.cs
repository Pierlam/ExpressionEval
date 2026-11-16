using System;

namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// Partial class concerning attaching function code to functionCall.
    /// </summary>
    public partial class ExpressionEval
    {
        /// <summary>
        /// Remove all attached function code.
        /// </summary>
        public void RemoveAllFunctionAttachment()
        {
            _exprExecConfigurator.RemoveAllFunctionAttachment();
        }

        //======================================================================
        #region Public function attachment return bool, 0 and 1 parameters

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// 
        /// Can define attachment even if functionCall is not yet defined.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool> funcBool)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcBool, out error);

            // ListExecConfigError?  
        }
        public bool AttachFunction(string functionCallName, Func<bool, bool> funcRetBool_Bool)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcRetBool_Bool, out error);
        }

        public bool AttachFunction(string functionCallName, Func<int, bool> funcRetBool_Int)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcRetBool_Int, out error);
        }

        public bool AttachFunction(string functionCallName, Func<string, bool> funcRetBool_String)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcRetBool_String, out error);
        }

        public bool AttachFunction(string functionCallName, Func<double, bool> funcRetBool_Double)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcRetBool_Double, out error);
        }
        #endregion

        //======================================================================
        #region Public function attachment return int, 0 and 1 parameters

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// 
        /// Can define attachment even if functionCall is not yet defined.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int> funcRetInt)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcRetInt, out error);

            // ListExecConfigError?  
        }
        public bool AttachFunction(string functionCallName, Func<bool, int> funcRetInt_Bool)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcRetInt_Bool, out error);
        }

        public bool AttachFunction(string functionCallName, Func<int, int> funcRetInt_Int)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcRetInt_Int, out error);
        }

        public bool AttachFunction(string functionCallName, Func<string, int> funcRetInt_String)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcRetInt_String, out error);
        }

        public bool AttachFunction(string functionCallName, Func<double, int> funcRetInt_Double)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcRetInt_Double, out error);
        }

        #endregion

        //======================================================================
        #region Public function attachment return string, 0 and 1 parameters

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// 
        /// Can define attachment even if functionCall is not yet defined.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string> funcRetString)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcRetString, out error);

            // ListExecConfigError?  
        }
        public bool AttachFunction(string functionCallName, Func<bool, string> funcRetString_Bool)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcRetString_Bool, out error);
        }

        public bool AttachFunction(string functionCallName, Func<int, string> funcRetString_Int)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcRetString_Int, out error);
        }

        public bool AttachFunction(string functionCallName, Func<string, string> funcRetString_String)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcRetString_String, out error);
        }

        public bool AttachFunction(string functionCallName, Func<double, string> funcRetString_Double)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcRetString_Double, out error);
        }

        #endregion

        //======================================================================
        #region Public function attachment return double, 0 and 1 parameters

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// 
        /// Can define attachment even if functionCall is not yet defined.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double> funcRetDouble)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcRetDouble, out error);

            // ListExecConfigError?  
        }
        public bool AttachFunction(string functionCallName, Func<bool, double> funcRetDouble_Bool)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcRetDouble_Bool, out error);
        }

        public bool AttachFunction(string functionCallName, Func<int, double> funcRetDouble_Int)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcRetDouble_Int, out error);
        }

        public bool AttachFunction(string functionCallName, Func<string, double> funcRetDouble_String)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcRetDouble_String, out error);
        }

        public bool AttachFunction(string functionCallName, Func<double, double> funcRetString_Double)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcRetString_Double, out error);
        }

        #endregion


        //======================================================================
        #region Public function attachment return Bool, 2 parameters.

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: bool.
        /// P1 type: bool, P2 type: bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, bool, bool> funcbool_bool_bool)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcbool_bool_bool, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: bool.
        /// P1 type: bool, P2 type: int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, int, bool> funcbool_bool_int)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcbool_bool_int, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: bool.
        /// P1 type: bool, P2 type: string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, string, bool> funcbool_bool_string)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcbool_bool_string, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: bool.
        /// P1 type: bool, P2 type: double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, double, bool> funcbool_bool_double)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcbool_bool_double, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: bool.
        /// P1 type: int, P2 type: bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, bool, bool> funcbool_int_bool)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcbool_int_bool, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: bool.
        /// P1 type: int, P2 type: int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, int, bool> funcbool_int_int)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcbool_int_int, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: bool.
        /// P1 type: int, P2 type: string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, string, bool> funcbool_int_string)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcbool_int_string, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: bool.
        /// P1 type: int, P2 type: double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, double, bool> funcbool_int_double)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcbool_int_double, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: bool.
        /// P1 type: string, P2 type: bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, bool, bool> funcbool_string_bool)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcbool_string_bool, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: bool.
        /// P1 type: string, P2 type: int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, int, bool> funcbool_string_int)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcbool_string_int, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: bool.
        /// P1 type: string, P2 type: string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, string, bool> funcbool_string_string)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcbool_string_string, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: bool.
        /// P1 type: string, P2 type: double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, double, bool> funcbool_string_double)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcbool_string_double, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: bool.
        /// P1 type: double, P2 type: bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, bool, bool> funcbool_double_bool)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcbool_double_bool, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: bool.
        /// P1 type: double, P2 type: int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, int, bool> funcbool_double_int)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcbool_double_int, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: bool.
        /// P1 type: double, P2 type: string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, string, bool> funcbool_double_string)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcbool_double_string, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: bool.
        /// P1 type: double, P2 type: double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, double, bool> funcbool_double_double)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcbool_double_double, out error);
        }

        #endregion

        //======================================================================
        #region Public function attachment return Int, 2 parameters.
        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: int.
        /// P1 type: bool, P2 type: bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, bool, int> funcint_bool_bool)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcint_bool_bool, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: int.
        /// P1 type: bool, P2 type: int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, int, int> funcint_bool_int)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcint_bool_int, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: int.
        /// P1 type: bool, P2 type: string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, string, int> funcint_bool_string)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcint_bool_string, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: int.
        /// P1 type: bool, P2 type: double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, double, int> funcint_bool_double)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcint_bool_double, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: int.
        /// P1 type: int, P2 type: bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, bool, int> funcint_int_bool)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcint_int_bool, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: int.
        /// P1 type: int, P2 type: int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, int, int> funcint_int_int)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcint_int_int, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: int.
        /// P1 type: int, P2 type: string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, string, int> funcint_int_string)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcint_int_string, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: int.
        /// P1 type: int, P2 type: double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, double, int> funcint_int_double)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcint_int_double, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: int.
        /// P1 type: string, P2 type: bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, bool, int> funcint_string_bool)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcint_string_bool, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: int.
        /// P1 type: string, P2 type: int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, int, int> funcint_string_int)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcint_string_int, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: int.
        /// P1 type: string, P2 type: string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, string, int> funcint_string_string)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcint_string_string, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: int.
        /// P1 type: string, P2 type: double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, double, int> funcint_string_double)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcint_string_double, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: int.
        /// P1 type: double, P2 type: bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, bool, int> funcint_double_bool)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcint_double_bool, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: int.
        /// P1 type: double, P2 type: int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, int, int> funcint_double_int)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcint_double_int, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: int.
        /// P1 type: double, P2 type: string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, string, int> funcint_double_string)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcint_double_string, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: int.
        /// P1 type: double, P2 type: double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, double, int> funcint_double_double)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcint_double_double, out error);
        }


        #endregion


        //======================================================================
        #region Public function attachment return String, 2 parameters.


        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: string.
        /// P1 type: bool, P2 type: bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, bool, string> funcstring_bool_bool)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcstring_bool_bool, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: string.
        /// P1 type: bool, P2 type: int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, int, string> funcstring_bool_int)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcstring_bool_int, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: string.
        /// P1 type: bool, P2 type: string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, string, string> funcstring_bool_string)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcstring_bool_string, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: string.
        /// P1 type: bool, P2 type: double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, double, string> funcstring_bool_double)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcstring_bool_double, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: string.
        /// P1 type: int, P2 type: bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, bool, string> funcstring_int_bool)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcstring_int_bool, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: string.
        /// P1 type: int, P2 type: int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, int, string> funcstring_int_int)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcstring_int_int, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: string.
        /// P1 type: int, P2 type: string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, string, string> funcstring_int_string)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcstring_int_string, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: string.
        /// P1 type: int, P2 type: double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, double, string> funcstring_int_double)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcstring_int_double, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: string.
        /// P1 type: string, P2 type: bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, bool, string> funcstring_string_bool)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcstring_string_bool, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: string.
        /// P1 type: string, P2 type: int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, int, string> funcstring_string_int)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcstring_string_int, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: string.
        /// P1 type: string, P2 type: string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, string, string> funcstring_string_string)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcstring_string_string, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: string.
        /// P1 type: string, P2 type: double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, double, string> funcstring_string_double)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcstring_string_double, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: string.
        /// P1 type: double, P2 type: bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, bool, string> funcstring_double_bool)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcstring_double_bool, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: string.
        /// P1 type: double, P2 type: int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, int, string> funcstring_double_int)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcstring_double_int, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: string.
        /// P1 type: double, P2 type: string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, string, string> funcstring_double_string)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcstring_double_string, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: string.
        /// P1 type: double, P2 type: double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, double, string> funcstring_double_double)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcstring_double_double, out error);
        }

        #endregion

        //======================================================================
        #region Public function attachment return Double, 2 parameters.

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: double.
        /// P1 type: bool, P2 type: bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, bool, double> funcdouble_bool_bool)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcdouble_bool_bool, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: double.
        /// P1 type: bool, P2 type: int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, int, double> funcdouble_bool_int)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcdouble_bool_int, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: double.
        /// P1 type: bool, P2 type: string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, string, double> funcdouble_bool_string)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcdouble_bool_string, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: double.
        /// P1 type: bool, P2 type: double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<bool, double, double> funcdouble_bool_double)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcdouble_bool_double, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: double.
        /// P1 type: int, P2 type: bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, bool, double> funcdouble_int_bool)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcdouble_int_bool, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: double.
        /// P1 type: int, P2 type: int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, int, double> funcdouble_int_int)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcdouble_int_int, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: double.
        /// P1 type: int, P2 type: string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, string, double> funcdouble_int_string)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcdouble_int_string, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: double.
        /// P1 type: int, P2 type: double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<int, double, double> funcdouble_int_double)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcdouble_int_double, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: double.
        /// P1 type: string, P2 type: bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, bool, double> funcdouble_string_bool)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcdouble_string_bool, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: double.
        /// P1 type: string, P2 type: int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, int, double> funcdouble_string_int)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcdouble_string_int, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: double.
        /// P1 type: string, P2 type: string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, string, double> funcdouble_string_string)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcdouble_string_string, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: double.
        /// P1 type: string, P2 type: double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<string, double, double> funcdouble_string_double)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcdouble_string_double, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: double.
        /// P1 type: double, P2 type: bool.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, bool, double> funcdouble_double_bool)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcdouble_double_bool, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: double.
        /// P1 type: double, P2 type: int.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, int, double> funcdouble_double_int)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcdouble_double_int, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: double.
        /// P1 type: double, P2 type: string.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, string, double> funcdouble_double_string)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcdouble_double_string, out error);
        }

        /// <summary>
        /// Add a function code , attach it to a functionCall.
        /// When a functionCall is found in the expression, execute the attached/linked function code.
        /// Can define attachment even if functionCall is not yet defined.
        ///
        /// Return type: double.
        /// P1 type: double, P2 type: double.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcBool"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, Func<double, double, double> funcdouble_double_double)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcdouble_double_double, out error);
        }

        #endregion

        //======================================================================
        #region Essais.

        /// <summary>
        /// ESSAI avec des methodes generiques.
        /// </summary>
        /// <param name="functionCallName"></param>
        /// <param name="funcParamsMapper"></param>
        /// <returns></returns>
        public bool AttachFunction(string functionCallName, FunctionParamsMapperBase funcParamsMapper)
        {
            // toto: gestion erreur, dans une liste?
            ExprError error;
            return _exprExecConfigurator.AttachFunction(functionCallName, funcParamsMapper, out error);
        }

        #endregion

    }
}
