using BudgetPlannerV2.Domains.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerV2.Services.Validators
{
    public class PasswordValidator : IPasswordValidator<User>
    {
        public PasswordValidator(IPasswordHasher<User> passwordHasher)
        {
            this.passwordHasher = passwordHasher;
        }

        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user, string password)
        {
            if (passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password) == PasswordVerificationResult.Success)
            {
                return Task.FromResult(IdentityResult.Success);
            }

            return Task.FromResult(IdentityResult.Failed(new IdentityError { Code = "InvalidPassword", Description = "Invalid password has been entered" }));
        }

        private readonly IPasswordHasher<User> passwordHasher;
    }
}
