using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_5.Business_Layer
{
    public class InvalidEntityException : Exception
    {
        public InvalidEntityException(string message) : base(message) { }
    }
}
