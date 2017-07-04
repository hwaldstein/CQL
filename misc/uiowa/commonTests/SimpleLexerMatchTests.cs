using System.Collections.Generic;
using System.Linq;
using Lexer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace commonTests
{
    [TestClass()]
    public class SimpleLexerMatchTests
    {

        [TestMethod()]
        public void EmptyStringLexesToNothings()
        {
            List<Token> tokens = new Lexer.Lexer("").Lex().ToList();
            Assert.AreEqual(0, tokens.Count);
        }

        [TestMethod()]
        public void OrLexesToOr()
        {
            List<Token> tokens = new Lexer.Lexer("OR").Lex().ToList();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(TokenType.Or, tokens.First().TokenType);
        }

        [TestMethod()]
        public void AndLexesToAnd()
        {
            List<Token> tokens = new Lexer.Lexer("AND").Lex().ToList();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(TokenType.And, tokens.First().TokenType);
        }

        [TestMethod()]
        public void NotLexesToNot()
        {
            List<Token> tokens = new Lexer.Lexer("NOT").Lex().ToList();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(TokenType.Not, tokens.First().TokenType);
        }

        [TestMethod()]
        public void BangLexesToBang()
        {
            List<Token> tokens = new Lexer.Lexer("!").Lex().ToList();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(TokenType.Bang, tokens.First().TokenType);
        }

        [TestMethod()]
        public void LParenLexesToLParen()
        {
            List<Token> tokens = new Lexer.Lexer("(").Lex().ToList();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(TokenType.LParen, tokens.First().TokenType);
        }

        [TestMethod()]
        public void RParenLexesToRParen()
        {
            List<Token> tokens = new Lexer.Lexer(")").Lex().ToList();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(TokenType.RParen, tokens.First().TokenType);
        }

        [TestMethod()]
        public void EqualsLexesToEquals()
        {
            List<Token> tokens = new Lexer.Lexer("=").Lex().ToList();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(TokenType.Equals, tokens.First().TokenType);
        }

        [TestMethod()]
        public void NotEqualsLexesToNotEquals()
        {
            List<Token> tokens = new Lexer.Lexer("!=").Lex().ToList();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(TokenType.NotEquals, tokens.First().TokenType);
        }

        [TestMethod()]
        public void LikeLexesToLike()
        {
            List<Token> tokens = new Lexer.Lexer("~").Lex().ToList();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(TokenType.Like, tokens.First().TokenType);
        }

        [TestMethod()]
        public void NotLikeLexesToNotLike()
        {
            List<Token> tokens = new Lexer.Lexer("!~").Lex().ToList();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(TokenType.NotLike, tokens.First().TokenType);
        }

        [TestMethod()]
        public void LTLexesToLT()
        {
            List<Token> tokens = new Lexer.Lexer("<").Lex().ToList();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(TokenType.LT, tokens.First().TokenType);
        }

        [TestMethod()]
        public void GTLexesToGT()
        {
            List<Token> tokens = new Lexer.Lexer(">").Lex().ToList();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(TokenType.GT, tokens.First().TokenType);
        }

        [TestMethod()]
        public void LTEQLexesToLTEQ()
        {
            List<Token> tokens = new Lexer.Lexer("<=").Lex().ToList();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(TokenType.LTEQ, tokens.First().TokenType);
        }

        [TestMethod()]
        public void GTEQLexesToGTEQ()
        {
            List<Token> tokens = new Lexer.Lexer(">=").Lex().ToList();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(TokenType.GTEQ, tokens.First().TokenType);
        }

        [TestMethod()]
        public void InLexesToIn()
        {
            List<Token> tokens = new Lexer.Lexer("IN").Lex().ToList();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(TokenType.In, tokens.First().TokenType);
        }

        [TestMethod()]
        public void IsLexesToIs()
        {
            List<Token> tokens = new Lexer.Lexer("IS").Lex().ToList();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(TokenType.Is, tokens.First().TokenType);
        }

        [TestMethod()]
        public void LBracketLexesToLBracket()
        {
            List<Token> tokens = new Lexer.Lexer("[").Lex().ToList();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(TokenType.LBracket, tokens.First().TokenType);
        }

        [TestMethod()]
        public void ZeroThroughNineLexesToInt()
        {
            List<int> ints = new List<int> {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            foreach (int i in ints)
            {
                List<Token> tokens = new Lexer.Lexer(i.ToString()).Lex().ToList();
                Assert.AreEqual(1, tokens.Count);
                Assert.AreEqual(TokenType.Int, tokens.First().TokenType);
            }
        }

        [TestMethod()]
        public void ZeroFloatThroughNineFloatLexesToInt()
        {
            List<string> strings = new List<string> { "0.0", "1.0", "2.0", "3.0", "4.0", "5.0", "6.0", "7.0", "8.0", "9.0" };
            foreach (string s in strings) 
            {
                List<Token> tokens = new Lexer.Lexer(s).Lex().ToList();
                Assert.AreEqual(1, tokens.Count);
                Assert.AreEqual(TokenType.Float, tokens.First().TokenType);
            }
        }

        [TestMethod()]
        public void RBracketLexesToRBracket()
        {
            List<Token> tokens = new Lexer.Lexer("]").Lex().ToList();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(TokenType.RBracket, tokens.First().TokenType);
        }

        [TestMethod()]
        public void EmptyLexesToEmpty()
        {
            List<Token> tokens = new Lexer.Lexer("EMPTY").Lex().ToList();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(TokenType.Empty, tokens.First().TokenType);
        }

        [TestMethod()]
        public void WordsLexToWord()
        {
            List<string> words = new List<string> { "Quisque", "gravida", "egestas", "velit", "vel" };
            foreach (string word in words)
            {
                List<Token> tokens = new Lexer.Lexer(word).Lex().ToList();
                Assert.AreEqual(1, tokens.Count);
                Assert.AreEqual(TokenType.Word, tokens.First().TokenType);
            }
        }

        [TestMethod()]
        public void DoubleQuotesLexToQuotedString()
        {
            List<string> words = new List<string> { "\"Quisque\"", "\"gravida\"", "\"egestas\"", "\"velit\"", "\"vel\"" };
            foreach (string word in words)
            {
                List<Token> tokens = new Lexer.Lexer(word).Lex().ToList();
                Assert.AreEqual(1, tokens.Count);
                Assert.AreEqual(TokenType.Quotedstring, tokens.First().TokenType);
            }
        }

        [TestMethod()]
        public void SingleQuotesLexToQuotedString()
        {
            List<string> words = new List<string> { "'Quisqu'", "'gravid'", "'egesta'", "'veli'", "'vel'" };
            foreach (string word in words)
            {
                List<Token> tokens = new Lexer.Lexer(word).Lex().ToList();
                Assert.AreEqual(1, tokens.Count);
                Assert.AreEqual(TokenType.Quotedstring, tokens.First().TokenType);
            }
        }

        [TestMethod()]
        public void CommaLexesToComma()
        {
            List<Token> tokens = new Lexer.Lexer(",").Lex().ToList();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(TokenType.Comma, tokens.First().TokenType);
        }

        [TestMethod()]
        public void OrderLexesToOrder()
        {
            List<Token> tokens = new Lexer.Lexer("ORDER").Lex().ToList();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(TokenType.Order, tokens.First().TokenType);
        }

        [TestMethod()]
        public void ByLexesToBy()
        {
            List<Token> tokens = new Lexer.Lexer("BY").Lex().ToList();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(TokenType.By, tokens.First().TokenType);
        }

        [TestMethod()]
        public void DescLexesToDesc()
        {
            List<Token> tokens = new Lexer.Lexer("DESC").Lex().ToList();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(TokenType.Desc, tokens.First().TokenType);
        }

        [TestMethod()]
        public void AscLexesToAsc()
        {
            List<Token> tokens = new Lexer.Lexer("ASC").Lex().ToList();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(TokenType.Asc, tokens.First().TokenType);
        }

        [TestMethod()]
        public void MinusLexesToMinus()
        {
            List<Token> tokens = new Lexer.Lexer("-").Lex().ToList();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(TokenType.Minus, tokens.First().TokenType);
        }

        [TestMethod()]
        public void PlusLexesToPlus()
        {
            List<Token> tokens = new Lexer.Lexer("+").Lex().ToList();
            Assert.AreEqual(1, tokens.Count);
            Assert.AreEqual(TokenType.Plus, tokens.First().TokenType);
        }

        [TestMethod()]
        public void WhiteSpaceLexesToNothing()
        {
            List<string> strings = new List<string> {" ", "\t", "\n"};
            foreach (string s in strings)
            {
                List<Token> tokens = new Lexer.Lexer(s).Lex().ToList();
                Assert.AreEqual(0, tokens.Count);
            }
        }
    }
}