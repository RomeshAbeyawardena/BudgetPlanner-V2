using BudgetPlannerV2.Domains.Data;
using BudgetPlannerV2.Domains.Requests;
using BudgetPlannerV2.Domains.Responses;
using DNI.Core.Contracts.Providers;
using DNI.Core.Services.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BudgetPlannerV2.Services.Handlers.Requests
{
    public class BudgetRequestHandler : ResponseRequestHandler<Budget, BudgetRequest, BudgetResponse>
    {
        public BudgetRequestHandler(IMapperProvider mapperProvider) : base(mapperProvider)
        {
        }

        public override Task<BudgetResponse> Handle(BudgetRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
