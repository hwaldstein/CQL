using System.Collections.Generic;
using System.Linq;
using Lexer.Matchers;

namespace Lexer
{
    public class Lexer
    {
        public Lexer(string source)
        {
            Tokenizer = new Tokenizer(source);
        }

        private Tokenizer Tokenizer { get; }

        private List<IMatcher> Matchers { get; set; }

        public IEnumerable<Token> Lex()
        {
            Matchers = InitializeMatchList();

            Token current = Next();

            while ((current != null) && (current.TokenType != TokenType.EOF))
            {
                // skip whitespace
                if (current.TokenType != TokenType.WhiteSpace)
                    yield return current;

                current = Next();
            }
        }

        private List<IMatcher> InitializeMatchList()
        {
            // the order here matters because it defines token precedence

            List<IMatcher> matchers = new List<IMatcher>();

            List<IMatcher> keywordmatchers = new List<IMatcher>
            {
                new MatchKeyword(TokenType.Or, "OR"),
                new MatchKeyword(TokenType.And, "AND"),
                new MatchKeyword(TokenType.Not, "NOT"),
                new MatchKeyword(TokenType.In, "IN"),
                new MatchKeyword(TokenType.Is, "IS"),
                new MatchKeyword(TokenType.Empty, "EMPTY"),
                new MatchKeyword(TokenType.Order, "ORDER"),
                new MatchKeyword(TokenType.By, "BY"),
                new MatchKeyword(TokenType.Desc, "DESC"),
                new MatchKeyword(TokenType.Asc, "ASC")
            };


            List<IMatcher> specialCharacters = new List<IMatcher>
            {
                
                new MatchKeyword(TokenType.LParen, "("),
                new MatchKeyword(TokenType.RParen, ")"),
                new MatchKeyword(TokenType.Equals, "="),
                new MatchKeyword(TokenType.NotEquals, "!="),
                new MatchKeyword(TokenType.Like, "~"),
                new MatchKeyword(TokenType.NotLike, "!~"),
                new MatchKeyword(TokenType.Bang, "!"),
                new MatchKeyword(TokenType.LTEQ, "<="),
                new MatchKeyword(TokenType.GTEQ, ">="),
                new MatchKeyword(TokenType.LT, "<"),
                new MatchKeyword(TokenType.GT, ">"),
                new MatchKeyword(TokenType.LBracket, "["),
                new MatchKeyword(TokenType.RBracket, "]"),
                new MatchKeyword(TokenType.Comma, ","),
                new MatchKeyword(TokenType.Minus, "-"),
                new MatchKeyword(TokenType.Plus, "+")
            };

            // give each keyword the list of possible delimiters and not allow them to be 
            // substrings of other words, i.e. token fun should not be found in string "function"
            keywordmatchers.ForEach(keyword =>
            {
                MatchKeyword current = keyword as MatchKeyword;
                current.AllowAsSubString = false;
                current.SpecialCharacters = specialCharacters.Select(i => i as MatchKeyword).ToList();
            });

            matchers.Add(new MatchString(MatchString.QUOTE));
            matchers.Add(new MatchString(MatchString.TIC));
            matchers.AddRange(specialCharacters);
            matchers.AddRange(keywordmatchers);
            matchers.AddRange(new List<IMatcher>
            {
                new MatchWhiteSpace(),
                new MatchNumber(),
                new MatchWord(specialCharacters)
            });

            return matchers;
        }

        private Token Next()
        {
            if (Tokenizer.End())
                return new Token(TokenType.EOF);

            return
            (from match in Matchers
                let token = match.IsMatch(Tokenizer)
                where token != null
                select token).FirstOrDefault();
        }
    }
}