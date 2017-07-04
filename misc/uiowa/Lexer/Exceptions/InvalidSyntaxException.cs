using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexer.Exceptions
{
    public class InvalidSyntaxException : Exception
    {
        public InvalidSyntaxException(string format) : base(format)
        {
        }
    }
}
