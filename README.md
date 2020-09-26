# Expression evaluator .NET component

ExpressionEval is an Expression Evaluator back-office component. Expression are provided as raw string. It enables you to evaluate easily: logical (Or, And and Not), comparison (=, <>, <=, <, >, >=) or calculation (+, -, *, /) in an application. Possible to use variable and function call. The component is configurable: double decimal separator, string tag,... This component is a library provided in .NET Standard 2.0 and in .NET Framework 4.5.

The library on nuget: https://www.nuget.org/packages/Pierlam.ExpressionEval/

The component is open-source.


To have code samples, see: https://github.com/Pierlam/ExpressionEvalSamples

This repository contains a solution with several samples of the ExpressionEval library published on nuget.

### Examples of Expressions

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
