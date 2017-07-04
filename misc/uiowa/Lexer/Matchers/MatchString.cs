using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexer
{
    public class MatchString : MatcherBase
    {
        public const string QUOTE = "\"";

        public const string TIC = "'";

        private string StringDelim { get; set; }

        public MatchString(string delim)
        {
            StringDelim = delim;
        }

        protected override Token IsMatchImpl(Tokenizer tokenizer)
        {
            StringBuilder str = new StringBuilder();

            if (tokenizer.Current == StringDelim)
            {
                tokenizer.Consume();

                while (!tokenizer.End() && tokenizer.Current != StringDelim)
                {
                    str.Append(tokenizer.Current);
                    tokenizer.Consume();
                }

                if (tokenizer.Current == StringDelim)
                {
                    tokenizer.Consume();
                }
            }

            if (str.Length > 0)
            {
                return new Token(TokenType.Quotedstring, str.ToString());
            }

            return null;
        }
    }
}
