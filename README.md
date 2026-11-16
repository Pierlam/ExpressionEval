# Expression evaluator .NET component

**ExpressionEval** is an expression evaluation component designed for backend applications.

Expressions are provided as raw strings and can be easily evaluated. The component supports:

- **Logical operators:** `Or`, `And`, `Not`
- **Comparison operators:** `=`, `<>`, `<=`, `<`, `>`, `>=`
- **Arithmetic operators:** `+`, `-`, `*`, `/`
- **Variables and function calls**

The component is configurable, with options such as the decimal separator, string delimiters, and more.

ExpressionEval is available as a .NET library targeting **.NET 8 and .NET 10**.

The source code: https://github.com/Pierlam/ExpressionEval

The library on nuget: https://www.nuget.org/packages/Pierlam.ExpressionEval/

The component is free and open-source.

To have code samples, see: https://github.com/Pierlam/ExpressionEvalSamples

This repository contains a solution with several samples of the ExpressionEval library published on nuget.

# How to use it

Here is a basic sample of how to use this component.

```
//-Init the evaluator engine
ExpressionEval evaluator = new ExpressionEval();

//-The expression to parse and execute, defined as a raw string
string expr = "Not(A)";

//-Parse the expression, decode it
evaluator.Parse(expr);

//-prepare the execution, provide all defined variables: type and value, remove the previous result, a= false
evaluator.DefineVarBool("a", false);

//-Execute the expression, apply values onf each variables, then produce a result
ExecResult execResult = evaluator.Exec();

//-Get the result, its a bool value
Console.WriteLine("Execution Result: " + execResult.ResultBool);  
  -> Execution Result: true
```


# Examples of Expressions

Expressions are provided as a raw string to the library.

Some examples of expressions you can execute:

(a And b)

(a or b) And (c or d)

NOT(a)

Not a

Xor(b)

a=b

(a >= b) and ( c <> d)

(a=12.34)

(count>123E5)

(a="hello")

fct()

fct(a)

fct(12)

fct(a,b)

(a+b)

(a+b)*c)

a+b*c -> Will apply operator priority: first *,/ then +,-

a, b, c, d,... are variables used in expressions.

After the parse (decode) of the expression, you have to define these variables: define the type and provide a value.

Of course, it's possible to get the list of variables found in the expression.

Possibles types are: bool, int, double and string.

Options:

Change the decimal separator of double, is the dot by default but can be set to semicolon (Excel like).

(a=12,35)


# Source code, documentation and nuget

ExpressionEval library is packaged as a nuget ready to use:

https://www.nuget.org/packages/Pierlam.ExpressionEval/


Github source repository:

https://github.com/Pierlam/ExpressionEval


## Contact 

Have any comments or questions? Would you like to request a new feature?

Feel free to send an email at:

pierlam-project@outlook.com
