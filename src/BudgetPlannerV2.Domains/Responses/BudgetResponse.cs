using BudgetPlannerV2.Domains.Data;
using DNI.Core.Services.Abstractions;
using System;

namespace BudgetPlannerV2.Domains.Responses
{
    public class BudgetResponse : ResponseBase<Budget>
    {
        public BudgetResponse(Budget budget)
            : base(budget)
        {

        }

        public BudgetResponse(Exception ex)
            : base(ex)
        {

        }
    }
}
