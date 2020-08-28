using BudgetPlannerV2.Data;
using DNI.Core.Services.Abstractions;

namespace BudgetPlannerV2.Broker
{
    public class DefaultServiceBroker : ServiceBroker
    {
        public DefaultServiceBroker() : base(definitions => definitions
            .GetAssembly<Services.ServiceRegistration>()
            .GetAssembly<BudgetPlannerDbContext>()
        )
        {

        }
    }
}
