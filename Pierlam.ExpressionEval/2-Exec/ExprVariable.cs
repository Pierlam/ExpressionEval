namespace Pierlam.ExpressionEval
{
    public enum VarType
    {
        Bool,
        String,
        Int,
        Double
    }

    /// <summary>
    /// A defined variable, found in the expression.
    /// has a type and a value.
    /// </summary>
    public abstract class ExprVariableBase
    {
        public VarType VarType { get; set; }
        public string Name { get; set; }
    }

    public class ExprVariableBool : ExprVariableBase
    {
        public ExprVariableBool()
        {
            VarType = VarType.Bool;
        }

        public bool Value { get; set; }
    }

    public class ExprVariableString : ExprVariableBase
    {
        public ExprVariableString()
        {
            VarType = VarType.String;
        }

        public string Value { get; set; }
    }

    public class ExprVariableInt : ExprVariableBase
    {
        public ExprVariableInt()
        {
            VarType = VarType.Int;
        }

        public int Value { get; set; }
    }

    public class ExprVariableDouble : ExprVariableBase
    {
        public ExprVariableDouble()
        {
            VarType = VarType.Double;
        }

        public double Value { get; set; }
    }

}
