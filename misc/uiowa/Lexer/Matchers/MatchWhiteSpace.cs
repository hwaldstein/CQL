using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexer
{
    class MatchWhiteSpace : MatcherBase
    {
        protected override Token IsMatchImpl(Tokenizer tokenizer)
        {
            bool foundWhiteSpace = false;

            while (!tokenizer.End() && string.IsNullOrWhiteSpace(tokenizer.Current))
            {
                foundWhiteSpace = true;

                tokenizer.Consume();
            }

            if (foundWhiteSpace)
            {
                return new Token(TokenType.WhiteSpace);
            }

            return null;
        }
    }
}
