using DomainLayer.Contracts;
using TalabatDemo.CustomMiddleware;

namespace TalabatDemo.Extentions
{
    public static class WebApplicationRegisteration
    {
        public static async Task SeedDatabaseAsync(this WebApplication app)
        {
            // Manual Injection to Seed Data
            using var dataSeedingScope = app.Services.CreateScope();
            var dataSeeding = dataSeedingScope.ServiceProvider.GetRequiredService<IDataSeeding>();
            await dataSeeding.SeedDataAsync();
        }

        public static IApplicationBuilder UseCustomExceptionsMiddleware(this IApplicationBuilder app)
        {
            #region Using Custom Middleware
            app.UseMiddleware<CustomExceptionHandlerMiddleware>();
            #endregion
            return app;
        }

        public static IApplicationBuilder UseSwaggerMiddlewares(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            return app;
        }
    }
}
