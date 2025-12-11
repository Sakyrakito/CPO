using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_5.Business_Layer
{
    public class BusinessRule
    {
        public string PropertyName { get; }
        public string Message { get; }

        public BusinessRule(string propertyName, string message)
        {
            PropertyName = propertyName;
            Message = message;
        }

        public override string ToString() => $"{PropertyName}: {Message}";
    }
}
