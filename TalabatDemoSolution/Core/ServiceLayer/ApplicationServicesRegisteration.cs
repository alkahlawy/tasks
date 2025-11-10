using Microsoft.Extensions.DependencyInjection;
using ServiceAbstractionLayer;
using ServiceLayer.MappingProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public static class ApplicationServicesRegisteration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection Services)
        {
            //builder.Services.AddAutoMapper(p => p.AddProfile<ProductProfile>());
            Services.AddAutoMapper((x) => { }, typeof(ProductProfile).Assembly); // Registering all profiles in the assembly where ProductProfile is located
            Services.AddScoped<IServiceManager, ServiceManager>();
            return Services;
        }
    }
}
