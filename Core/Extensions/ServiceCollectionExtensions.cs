using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependecyResolvers(this IServiceCollection serviceCollection, ICoreModule[] coreModels)
        {
            foreach (var coreModel in coreModels)
            {
                coreModel.Load(serviceCollection);
            }
            return ServiceTool.Create(serviceCollection);
        }
    }
}
