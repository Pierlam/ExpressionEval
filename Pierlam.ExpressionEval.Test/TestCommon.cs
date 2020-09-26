using Pierlam.ExpressionEval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pierlam.ExpressionEval.Test
{

    public class TestCommon
    {

        public static List<ExprToken> AddTokens(string tok, string tok2, string tok3, string tok4, string tok5, string tok6)
        {
            List<ExprToken> listTokens = new List<ExprToken>();
            AddTokens(listTokens, tok);
            AddTokens(listTokens, tok2);
            AddTokens(listTokens, tok3);
            AddTokens(listTokens, tok4);
            AddTokens(listTokens, tok5);
            AddTokens(listTokens, tok6);
            return listTokens;
        }

        public static List<ExprToken> AddTokens(string tok, string tok2, string tok3, string tok4,string tok5)
        {
            List<ExprToken> listTokens = new List<ExprToken>();
            AddTokens(listTokens, tok);
            AddTokens(listTokens, tok2);
            AddTokens(listTokens, tok3);
            AddTokens(listTokens, tok4);
            AddTokens(listTokens, tok5);
            return listTokens;
        }

        public static List<ExprToken> AddTokens(string tok, string tok2, string tok3, string tok4)
        {
            List<ExprToken> listTokens = new List<ExprToken>();
            AddTokens(listTokens, tok);
            AddTokens(listTokens, tok2);
            AddTokens(listTokens, tok3);
            AddTokens(listTokens, tok4);
            return listTokens;
        }

        public static List<ExprToken> AddTokens(string tok, string tok2, string tok3)
        {
            List<ExprToken> listTokens = new List<ExprToken>();
            AddTokens(listTokens, tok);
            AddTokens(listTokens, tok2);
            AddTokens(listTokens, tok3);
            return listTokens;
        }

        public static List<ExprToken> AddTokens(string tok, string tok2)
        {
            List<ExprToken> listTokens = new List<ExprToken>();
            AddTokens(listTokens, tok);
            AddTokens(listTokens, tok2);
            return listTokens;
        }

        public static List<ExprToken> AddTokens(string tok)
        {
            List<ExprToken> listTokens = new List<ExprToken>();
            AddTokens(listTokens, tok);
            return listTokens;
        }

        public static void AddTokens(List<ExprToken> listTokens, string tok, string tok2, string tok3)
        {
            AddTokens(listTokens, tok);
            AddTokens(listTokens, tok2);
            AddTokens(listTokens, tok3);
        }

        public static void AddTokens(List<ExprToken> listTokens, string tok, string tok2)
        {
            AddTokens(listTokens, tok);
            AddTokens(listTokens, tok2);
        }

        public static void AddTokens(List<ExprToken> listTokens, string tok)
        {
            var exprToken = new ExprToken();
            exprToken.Value = tok;
            exprToken.Position = 0;
            listTokens.Add(exprToken);
        }

        public static ExpressionEvalConfig BuildDefaultConfig()
        {
            // build and set operators
            ExprOperatorBuilder operatorsBuilder = new ExprOperatorBuilder();

            ExpressionEvalConfig exprEvalConfig = new ExpressionEvalConfig();
            exprEvalConfig.SetLang(Language.En);
            exprEvalConfig.SetDecimalAndFunctionSeparators(DecimalAndFunctionSeparators.Standard);
            operatorsBuilder.BuildOperators(exprEvalConfig);
            return exprEvalConfig;
        }

        public static ExpressionEvalConfig BuildConfig(DecimalAndFunctionSeparators doubleDecimalSeparator)
        {
            // build and set operators
            ExprOperatorBuilder operatorsBuilder = new ExprOperatorBuilder();

            ExpressionEvalConfig exprEvalConfig = new ExpressionEvalConfig();
            exprEvalConfig.SetLang(Language.En);
            exprEvalConfig.SetDecimalAndFunctionSeparators(doubleDecimalSeparator);
            operatorsBuilder.BuildOperators(exprEvalConfig);
            return exprEvalConfig;
        }

        public static void BuildDefaultConfig(ExprScanner scanner)
        {
            // configure
            ExpressionEvalConfig exprEvalConfig = new ExpressionEvalConfig();
            exprEvalConfig.SetLang(Language.En);
            exprEvalConfig.SetStringTagCode(StringTagCode.DoubleQuote);

            ExprOperatorBuilder operatorsBuilder = new ExprOperatorBuilder();
            operatorsBuilder.BuildOperators(exprEvalConfig);

            //ExpressionEvalConfig evalConfig = new ExpressionEvalConfig();
            //scanner.SetListSpecial2CharOperators(exprEvalConfig.ListSpecial2CharOperators);
            scanner.SetConfiguration(exprEvalConfig);
        }
    }
}
