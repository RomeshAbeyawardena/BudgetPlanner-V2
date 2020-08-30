using BudgetPlannerV2.Domains.Data;
using DNI.Core.Contracts;
using DNI.Core.Contracts.Managers;
using DNI.Core.Contracts.Services;
using DNI.Core.Shared.Enumerations;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerV2.Services
{
    public class PasswordHasher : IPasswordHasher<User>
    {
        public PasswordHasher(IEncryptionService encryptionService,
            IEncryptionProfileManager encryptionProfileManager)
        {
            this.encryptionService = encryptionService;
            this.encryptionProfileManager = encryptionProfileManager;
        }
        public string HashPassword(User user, string password)
        {
            return encryptionService.Hash(password, GetEncryptionProfile(EncryptionClassification.Personal));
        }

        public PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword)
        {
            var hashedProvidedPassword = HashPassword(user, providedPassword);

            if (hashedPassword == hashedProvidedPassword)
            {
                return PasswordVerificationResult.Success;
            }

            return PasswordVerificationResult.Failed;
        }

        private IEncryptionProfile GetEncryptionProfile(EncryptionClassification encryptionClassification)
        {
            if(encryptionProfileManager.TryGetValue(encryptionClassification, out var encryptionProfile))
            {
                return encryptionProfile;
            }

            throw new NotSupportedException();
        }

        private readonly IEncryptionService encryptionService;
        private readonly IEncryptionProfileManager encryptionProfileManager;
    }
}
