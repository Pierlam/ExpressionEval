using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pierlam.ExpressionEval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pierlam.ExpressionEval.Test.TokParser
{
    [TestClass]
    public class TokParser_Analyzer_Variable
    {
        /// <summary>
        /// The expression: a=b
        /// contains 2 variables.
        /// </summary>
        [TestMethod]
        public void a_Eq_b()
        {
            string expr = "a=b";
            List<ExprToken> listTokens = TestCommon.AddTokens("a", "=", "b");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);
            ExprSyntaxTreeAnalyzer analyzer = new ExprSyntaxTreeAnalyzer();
            analyzer.Analyze(result);

            // finished with no error
            Assert.AreEqual(0, result.ListError.Count, "The tokens should be decoded with success");

            // check the list of variables present in the expression
            Assert.AreEqual(2, result.ListExprVarUsed.Count, "The expression should have 2 variables");

            ExprObjectUsedBase obj1 = result.ListExprVarUsed.Find(o => o.Name.Equals("a"));
            Assert.IsNotNull(obj1, "The var a should exists");
            Assert.AreEqual(ExprObjectType.Variable, obj1.ExprObjectType, "The obj a should be a variable");

            ExprObjectUsedBase obj2 = result.ListExprVarUsed.Find(o => o.Name.Equals("b"));
            Assert.IsNotNull(obj2, "The var b should exists");
            Assert.AreEqual(ExprObjectType.Variable, obj1.ExprObjectType, "The obj b should be a variable");

        }

        /// <summary>
        /// The expression: a=a
        /// contains 1 variable.
        /// </summary>
        [TestMethod]
        public void a_Eq_a()
        {
            string expr = "a=a";
            List<ExprToken> listTokens = TestCommon.AddTokens("a", "=", "a");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);
            ExprSyntaxTreeAnalyzer analyzer = new ExprSyntaxTreeAnalyzer();
            analyzer.Analyze(result);

            // finished with no error
            Assert.AreEqual(0, result.ListError.Count, "The tokens should be decoded with success");

            // check the list of variables present in the expression
            Assert.AreEqual(1, result.ListExprVarUsed.Count, "The expression should have 1 variable");

            ExprObjectUsedBase obj1 = result.ListExprVarUsed.Find(o => o.Name.Equals("a"));
            Assert.IsNotNull(obj1, "The var a should exists");
            Assert.AreEqual(ExprObjectType.Variable, obj1.ExprObjectType, "The obj a should be a variable");

        }

        /// <summary>
        /// The expression: a=A
        /// contains 1 variable.
        /// </summary>
        [TestMethod]
        public void a_Eq_A()
        {
            string expr = "a=A";
            List<ExprToken> listTokens = TestCommon.AddTokens("a", "=", "A");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);
            ExprSyntaxTreeAnalyzer analyzer = new ExprSyntaxTreeAnalyzer();
            analyzer.Analyze(result);

            // finished with no error
            Assert.AreEqual(0, result.ListError.Count, "The tokens should be decoded with success");

            // check the list of variables present in the expression
            Assert.AreEqual(1, result.ListExprVarUsed.Count, "The expression should have 1 variable");

            ExprObjectUsedBase obj1 = result.ListExprVarUsed.Find(o => o.Name.Equals("a"));
            Assert.IsNotNull(obj1, "The var a should exists");
            Assert.AreEqual(ExprObjectType.Variable, obj1.ExprObjectType, "The obj a should be a variable");

        }

        [TestMethod]
        public void a_Eq_12_checkVarSyntax_0var_err()
        {
            string expr = "0var";
            List<ExprToken> listTokens = TestCommon.AddTokens("0var");

            // decoder, renvoie un arbre de node
            ExprTokensParser parser = new ExprTokensParser();

            // the default list: =, <, >, >=, <=, <>
            var dictOperators = TestCommon.BuildDefaultConfig();
            parser.SetConfiguration(dictOperators);

            // decode the list of tokens
            ParseResult result = parser.Parse(expr, listTokens);
            ExprSyntaxTreeAnalyzer analyzer = new ExprSyntaxTreeAnalyzer();
            analyzer.Analyze(result);

            // finished with an error
            Assert.AreEqual(1, result.ListError.Count, "The tokens should be decoded with an error");

            // check the list of variables present in the expression
            Assert.AreEqual(0, result.ListExprVarUsed.Count, "The expression should have any variable");

            // todo: check error code
            Assert.AreEqual(ErrorCode.ValueNumberBadFormed, result.ListError[0].Code, "The error code should be: ValueNumberBadFormed");
        }


        // todo: checker la syntaxe d'une var
        // nom de var non autorisé: opérateur logique (lang!!), opérateur bool (lang!!) et???

        // tester case sensitive
        // ...
    }
}
