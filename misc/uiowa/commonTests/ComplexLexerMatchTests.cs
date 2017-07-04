using System.Collections.Generic;
using System.Linq;
using Lexer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace commonTests
{
    [TestClass()]
    public class ComplexLexerMatchTests
    {

        [TestMethod()]
        public void EmptyStringLexesToNothings()
        {
            List<Token> tokens = new Lexer.Lexer("project = \"TEST\"").Lex().ToList();
            Assert.AreEqual(3, tokens.Count);
        }
    }
}