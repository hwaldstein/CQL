using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Lexer;

namespace CourseScheduler_cli
{
    // ReSharper disable once ClassNeverInstantiated.Global
    // ReSharper disable once ArrangeTypeModifiers
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Contains("--query") && args.Length == 2)
            {
                string test = @"(company = acme AND itemtype=""cookie"") OR packagequantity >= 3.0";

                List<Token> tokens = new Lexer.Lexer(test).Lex().ToList();

                foreach (Token token in tokens)
                {
                    Console.WriteLine(token.TokenType + ": " + token.TokenValue);
                }
            }
            else
            {
                PrintHelp();
            }
            Console.ReadLine();
        }

        private static void PrintHelp()
        {
            // TODO fill help text
            Console.WriteLine("Help Text");
        }
    }
}
