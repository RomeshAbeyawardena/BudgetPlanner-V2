using BudgetPlannerV2.Data;
using BudgetPlannerV2.Services;
using DNI.Core.Contracts;
using DNI.Core.Services.Abstractions;
using System;

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
