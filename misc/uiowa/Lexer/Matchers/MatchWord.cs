using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lexer.Exceptions;

namespace Lexer.Matchers
{
    public class MatchWord : MatcherBase
    {
        private List<MatchKeyword> SpecialCharacters { get; set; }
        public MatchWord(IEnumerable<IMatcher> keywordMatchers)
        {
            SpecialCharacters = keywordMatchers.Select(i => i as MatchKeyword).Where(i => i != null).ToList();
        }

        protected override Token IsMatchImpl(Tokenizer tokenizer)
        {
            string current = null;

            while (!tokenizer.End() && !string.IsNullOrWhiteSpace(tokenizer.Current) && SpecialCharacters.All(m => m.Match != tokenizer.Current))
            {
                current += tokenizer.Current;
                tokenizer.Consume();
            }

            if (current == null)
            {
                return null;
            }

            // can't start a word with a special character
            if (SpecialCharacters.Any(c => current.StartsWith(c.Match)))
            {
                throw new InvalidSyntaxException($"Cannot start a word with a special character {current}");
            }

            return new Token(TokenType.Word, current);
        }
    }
}
