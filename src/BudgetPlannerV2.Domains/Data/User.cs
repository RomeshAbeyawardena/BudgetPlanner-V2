using DNI.Core.Shared.Attributes;
using DNI.Core.Shared.Enumerations;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerV2.Domains.Data
{
    public class User : IdentityUser<int>
    {
        [Encrypt(EncryptionMethod.TwoWay, EncryptionClassification.Personal)]
        public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }
        public override string UserName { get => base.Email; set => base.UserName = value; }
        public override string NormalizedUserName { get => UserName.ToUpper(); set => base.NormalizedUserName = value; }
        [Encrypt(EncryptionMethod.TwoWay, EncryptionClassification.Personal)]
        public override string Email { get => base.Email; set => base.Email = value; }
        public override string NormalizedEmail { get => base.Email.ToUpper(); set => base.NormalizedEmail = value; }

        [Encrypt(EncryptionMethod.TwoWay, EncryptionClassification.Common)]
        public string FirstName { get; set; }

        [Encrypt(EncryptionMethod.TwoWay, EncryptionClassification.Common)]
        public string MiddleName { get; set; }

        [Encrypt(EncryptionMethod.TwoWay, EncryptionClassification.Common)]
        public string LastName { get; set; }

        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Modified { get; set; }
    }
}
