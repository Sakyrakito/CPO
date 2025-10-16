using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_3
{
    [Serializable]
    public class Punctuation : Token
    {
        public Punctuation() { }

        public Punctuation(string value) : base(value) { }
    }
}
