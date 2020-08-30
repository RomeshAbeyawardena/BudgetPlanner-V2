using BudgetPlannerV2.Domains.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerV2.Domains.Exceptions
{
    [Serializable]
    public class UserLoginException : Exception
    {
        public UserLoginException() { }
        public UserLoginException(User user, string message) : this(user, message, null) {  }
        public UserLoginException(User user, string message, Exception inner) : base(message, inner) { User = user; }

        public User User { get; set; }
        protected UserLoginException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }   
}
