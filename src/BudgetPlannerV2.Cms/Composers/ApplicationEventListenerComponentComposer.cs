using AutoMapper;
using BudgetPlannerV2.Cms.Components;
using BudgetPlannerV2.Cms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace BudgetPlannerV2.Cms.Composers
{
    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class ApplicationEventListenerComponentComposer : ComponentComposer<ApplicationEventListenerComponent>
    {
        public override void Compose(Composition composition)
        {
            composition.Register((factory) => { 
                var configuration = new MapperConfiguration(ConfigureMapper); 
                return configuration.CreateMapper(); }, Lifetime.Singleton);
            base.Compose(composition);
        }

        private void ConfigureMapper(IMapperConfigurationExpression configure)
        {
            configure.AddProfile(new DomainProfile());
        }
    }
}
