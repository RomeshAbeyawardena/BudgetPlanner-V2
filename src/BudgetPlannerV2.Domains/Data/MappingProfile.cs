using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerV2.Domains.Data
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<ViewModels.RegisterViewModel, User>()
                .ForMember(member => member.Email, config => config.MapFrom(member => member.EmailAddress))
                .ForMember(member => member.UserName, config => config.MapFrom(member => member.EmailAddress));
        }
    }
}
