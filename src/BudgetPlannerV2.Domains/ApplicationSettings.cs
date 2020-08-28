using Microsoft.Extensions.Configuration;

namespace BudgetPlannerV2.Domains
{
    public class ApplicationSettings
    {
        public ApplicationSettings(IConfiguration configuration)
        {
            configuration.Bind(this);
        }

        public string DefaultConnectionString { get; set; }
        public string InitialVector { get; set; }
        public string PersonalKey { get; set; }
        public string Salt { get; set; }
        public string CommonKey { get; set; }
        public string SharedKey { get; set; }
    }
}
