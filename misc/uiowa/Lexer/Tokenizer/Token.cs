﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexer
{
    public class Token
    {
        public TokenType TokenType { get; private set; }

        public string TokenValue { get; private set; }

        public Token(TokenType tokenType, string token)
        {
            TokenType = tokenType;
            TokenValue = token;
        }

        public Token(TokenType tokenType)
        {
            TokenValue = null;
            TokenType = tokenType;
        }

        public override string ToString()
        {
            return TokenType + ": " + TokenValue;
        }
    }
}
