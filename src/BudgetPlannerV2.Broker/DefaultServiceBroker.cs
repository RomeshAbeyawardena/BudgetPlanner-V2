using BudgetPlannerV2.Data;
using DNI.Core.Services.Abstractions;
using DNI.Core.Services.Extensions;

namespace BudgetPlannerV2.Broker
{
    public class DefaultServiceBroker : ServiceBroker
    {
        public DefaultServiceBroker() : base(definitions => definitions
            .DescribeAssembly<Services.ServiceRegistration>()
            .DescribeAssembly<BudgetPlannerDbContext>()
        )
        {

        }
    }
}
