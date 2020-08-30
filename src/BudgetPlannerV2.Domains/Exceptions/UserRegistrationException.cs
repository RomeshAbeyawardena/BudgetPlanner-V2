using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerV2.Domains.Exceptions
{
    [Serializable]
    public class UserRegistrationException : Exception
    {
        public UserRegistrationException() { }
        public UserRegistrationException(string message) : base(message) { }
        public UserRegistrationException(IEnumerable<IdentityError> errors, string message) : base(message)
        {
            Errors = errors;
        }

        public UserRegistrationException(string message, Exception inner) : base(message, inner) { }
        protected UserRegistrationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public IEnumerable<IdentityError> Errors { get; }
    }
}
