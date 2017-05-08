using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using CQL;
using CQL.Interfaces;
using CQL.Models;
using CQL.Visitors;
using Data.Interfaces;

namespace CLI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new Program().Run(args);
        }

        private void Run(string[] args)
        {
            string input = "Department=MATH AND GenEd=QFR";
            //string input = args[0];
            Root root = Parse(input);
            
            foreach (ICourse course in root.Evaluate())
            {
                Console.WriteLine(course.ToString());
            }
            Console.Write("Hit enter to exit.");
            Console.ReadLine();
        }

        private Root Parse(string input)
        {
            AntlrInputStream inputStream = new AntlrInputStream(input);
            CQLLexer cqlLexer = new CQLLexer(inputStream);
            CommonTokenStream commonTokenStream = new CommonTokenStream(cqlLexer);
            CQLParser cqlParser = new CQLParser(commonTokenStream);

            RootVisitor rootVisitor = new RootVisitor();
            Root traversalResult = rootVisitor.Visit(cqlParser.root());
            return traversalResult;
        }
    }
}
