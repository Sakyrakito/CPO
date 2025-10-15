using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_3
{
    public abstract class Token
    {
        public string Value { get; protected set; }
        public Token(string value) => Value = value;
        public override string ToString() => Value;
    }
}
