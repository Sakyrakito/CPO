using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_5.Business_Layer
{
    public abstract class BusinessBase
    {
        private readonly List<BusinessRule> _rules = new();

        protected void AddRule(string property, string massege)
        {
            _rules.Add(new BusinessRule(property, massege));
        }

        protected void ClearRules() => _rules.Clear();

        public IReadOnlyCollection<BusinessRule> Rules => _rules.AsReadOnly();

        public bool IsValid
        {
            get
            {
                ClearRules();
                Validate();
                return !_rules.Any();
            }
        }

        public abstract void Validate();

        public void ThrowIfInvalid()
        {
            if (!IsValid)
            {
                var message = string.Join("; ", _rules.Select(r => r.ToString()));
                throw new InvalidEntityException(message);
            }
        }
    }
}
