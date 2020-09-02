using AutoMapper;
using BudgetPlannerV2.Cms.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;

namespace BudgetPlannerV2.Cms.Models
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<SectionItem, Section>()
                .ForMember(member => member.Forms,
                    configure => configure.MapFrom(member => (member.Form as FormGroup).FormItems))
                .ForMember(member => member.UsefulLinks, 
                    configure => configure.MapFrom(member => (member.Section as ViewModels.PageSection).Urls))
                .ForMember(member => member.Summary,
                    configure => configure.MapFrom(member => (member.Section as ViewModels.PageSection).Summary));
            CreateMap<ViewModels.Page, Page>();
            
            CreateMap<ViewModels.LinkItem, Link>()
                .ForMember(member => member.Url,
                    configure => configure.MapFrom(member => (member.LinkItemUrl as ViewModels.Link).Url))
                .ForMember(member => member.Title,
                    configure => configure.MapFrom(member => (member.LinkItemUrl as ViewModels.Link).Title));
            CreateMap<ViewModels.FormItem, Form>();
        }

    }
}
