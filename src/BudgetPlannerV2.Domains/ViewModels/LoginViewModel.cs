﻿using DNI.Core.Shared.Attributes;
using DNI.Core.Shared.Enumerations;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerV2.Domains.ViewModels
{
    public class LoginViewModel
    {
        [Required, EmailAddress, Encrypt(EncryptionMethod.TwoWay, EncryptionClassification.Personal)]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }
        public AuthenticationProperties PersistUserSecurity { get; set; }
    }
}
