using Microsoft.AspNetCore.Mvc;
using TalabatDemo.Factories;

namespace TalabatDemo.Extentions
{
    public static class ServicesRegisteration
    {
        public static IServiceCollection AddSwaggerRegisteration(this IServiceCollection Services)
        {
            Services.AddEndpointsApiExplorer();
            Services.AddSwaggerGen();
            return Services;
        }

        public static IServiceCollection AddWebApplicationService(this IServiceCollection Services)
        {
            Services.Configure<ApiBehaviorOptions>((options) =>
            {
                options.InvalidModelStateResponseFactory = ApiResponseFactory.GenerateApiValidationErrorResponse;
            });
            return Services;
        }
    }
}
