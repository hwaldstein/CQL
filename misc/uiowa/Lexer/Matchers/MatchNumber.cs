using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lexer.Matchers
{
    public class MatchNumber : MatcherBase
    {
        protected override Token IsMatchImpl(Tokenizer tokenizer)
        {

            string leftOperand = GetIntegers(tokenizer);

            if (leftOperand != null)
            {
                if (tokenizer.Current == ".")
                {
                    tokenizer.Consume();

                    string rightOperand = GetIntegers(tokenizer);

                    // found a float
                    if (rightOperand != null)
                    {
                        return new Token(TokenType.Float, leftOperand + "." + rightOperand);
                    }
                }

                return new Token(TokenType.Int, leftOperand);
            }

            return null;
        }

        private string GetIntegers(Tokenizer tokenizer)
        {
            Regex regex = new Regex("[0-9]");

            string num = null;

            while (tokenizer.Current != null && regex.IsMatch(tokenizer.Current))
            {
                num += tokenizer.Current;
                tokenizer.Consume();
            }

            return num;
        }
    }
}
