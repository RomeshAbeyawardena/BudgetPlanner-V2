using DNI.Core.Shared.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DNI.Core.Shared.Enumerations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerV2.Domains.ViewModels
{
    public class RegisterViewModel
    {
        [Required, Encrypt(EncryptionMethod.TwoWay, EncryptionClassification.Personal)]
        public string EmailAddress { get; set; }
        
        [Required, Encrypt(EncryptionMethod.TwoWay, EncryptionClassification.Personal)]
        public string PhoneNumber { get; set; }
        
        [Required, Encrypt(EncryptionMethod.TwoWay, EncryptionClassification.Common)]
        public string FirstName { get; set; }
        
        [Encrypt(EncryptionMethod.TwoWay, EncryptionClassification.Common)]
        public string MiddleName { get; set; }
        
        [Required, Encrypt(EncryptionMethod.TwoWay, EncryptionClassification.Common)]
        public string LastName { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required, Compare(nameof(Password), ErrorMessage = "Must match the password field")]
        public string ConfirmPassword { get; set; }
    }
}
