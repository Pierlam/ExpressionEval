using System;
using System.Collections.Generic;
using System.Text;

namespace Pierlam.ExpressionEval
{
    /// <summary>
    /// Base of function x parameters. (which are generic).
    /// </summary>
    public abstract class FunctionParamsMapperBase
    {
        public DataType ReturnType { get; set; }
        public int ParamsCount { get; set; }
        public MethodSignatureType MethodSignature { get; set; }

        public bool SetDataType(string typeCS, out DataType dataType)
        {
            if (typeCS.Equals("Boolean", StringComparison.InvariantCultureIgnoreCase))
            {
                dataType = DataType.Bool;
                return true;
            }

            if (typeCS.Equals("Int32", StringComparison.InvariantCultureIgnoreCase))
            {
                dataType = DataType.Int;
                return true;
            }

            // todo: vérifier!!
            if (typeCS.Equals("String", StringComparison.InvariantCultureIgnoreCase))
            {
                dataType = DataType.String;
                return true;
            }

            // todo: vérifier!!
            if (typeCS.Equals("Double", StringComparison.InvariantCultureIgnoreCase))
            {
                dataType = DataType.Double;
                return true;
            }

            // err, unmanaged cs type
            dataType = DataType.NotDefined;
            return false;
        }

    }
}
