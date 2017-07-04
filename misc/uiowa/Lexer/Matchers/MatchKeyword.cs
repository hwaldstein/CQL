using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexer.Matchers
{
    public class MatchKeyword : MatcherBase
    {
        public string Match { get; private set; }

        private TokenType TokenType { get; set; }


        /// <summary>
        /// If true then matching on { in a string like "{test" will match the first cahracter
        /// because it is not space delimited. If false it must be space or special character delimited
        /// </summary>
        public bool AllowAsSubString { get; set; }

        public List<MatchKeyword> SpecialCharacters { get; set; }

        public MatchKeyword(TokenType type, string match)
        {
            Match = match;
            TokenType = type;
            AllowAsSubString = true;
        }

        protected override Token IsMatchImpl(Tokenizer tokenizer)
        {
            foreach (char character in Match)
            {
                if (tokenizer.Current == character.ToString(CultureInfo.InvariantCulture))
                {
                    tokenizer.Consume();
                }
                else
                {
                    return null;
                }
            }

            bool found;

            if (!AllowAsSubString)
            {
                string next = tokenizer.Current;

                found = string.IsNullOrWhiteSpace(next) || SpecialCharacters.Any(character => character.Match == next);
            }
            else
            {
                found = true;
            }

            if (found)
            {
                return new Token(TokenType, Match);
            }

            return null;
        }
    }
}
