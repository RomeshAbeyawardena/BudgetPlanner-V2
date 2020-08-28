using BudgetPlannerV2.Domains;
using DNI.Core.Contracts;
using DNI.Core.Contracts.Builders;
using DNI.Core.Services;
using DNI.Core.Services.Extensions;
using DNI.Core.Shared.Enumerations;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerV2.Services
{
    public class ServiceRegistration : IServiceRegistration
    {
        public void RegisterServices(IServiceCollection services)
        {
            services
                .AddSingleton<ApplicationSettings>()
                .RegisterServices(BuildSecurityProfiles, scannerConfiguration: ConfigureScanner)
                .RegisterAutoMapperProviders(definitions => definitions.GetAssembly<ApplicationSettings>())
                .RegisterMediatrProviders(definitions => definitions.GetAssembly<ServiceRegistration>());
        }

        private void ConfigureScanner(ITypeSourceSelector typeSelector)
        {
            typeSelector.FromAssemblyOf<ServiceRegistration>();
        }

        private void BuildSecurityProfiles(IServiceProvider serviceProvider, IEncryptionProfileDictionaryBuilder builder)
        {
            var applicationSettings = serviceProvider.GetRequiredService<ApplicationSettings>();
            builder.Add(EncryptionClassification.Personal, profile =>
            {
                profile.Encoding = Encoding.ASCII;
                profile.InitialVector = Convert.FromBase64String(applicationSettings.InitialVector);
                profile.Key = Convert.FromBase64String(applicationSettings.PersonalKey);
                profile.Salt = Convert.FromBase64String(applicationSettings.Salt);
                profile.HashAlgorithmType = HashAlgorithmType.Sha512;
                profile.SymmetricAlgorithmName = nameof(Aes);

                return profile;
            }).Add(EncryptionClassification.Common, profile => {
                profile.Encoding = Encoding.ASCII;
                profile.InitialVector = Convert.FromBase64String(applicationSettings.InitialVector);
                profile.Key = Convert.FromBase64String(applicationSettings.CommonKey);
                profile.Salt = Convert.FromBase64String(applicationSettings.Salt);
                profile.HashAlgorithmType = HashAlgorithmType.Sha512;
                profile.SymmetricAlgorithmName = nameof(Aes);

                return profile;
            }).Add(EncryptionClassification.Shared, profile => {
                profile.Encoding = Encoding.ASCII;
                profile.InitialVector = Convert.FromBase64String(applicationSettings.InitialVector);
                profile.Key = Convert.FromBase64String(applicationSettings.SharedKey);
                profile.Salt = Convert.FromBase64String(applicationSettings.Salt);
                profile.HashAlgorithmType = HashAlgorithmType.Sha512;
                profile.SymmetricAlgorithmName = nameof(Aes);

                return profile;
            });
        }
    }
}
