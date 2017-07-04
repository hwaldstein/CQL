﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexer
{
    public class Tokenizer : TokenizableStreamBase<string>
    {
        public Tokenizer(string source) : base(() => source.ToCharArray().Select(i => i.ToString(CultureInfo.InvariantCulture)).ToList())
        {
        }
    }
}
