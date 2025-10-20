namespace ServiceLifeTime
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region DI Container
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            #region Service Life Time
            // Service Life Time
            // Transient : a new instance of the service is created each time it is requested.
            builder.Services.AddTransient<Services.ITransientService, Services.TransientService>();
            // Scoped : a new instance of the service is created once per client request (connection).
            // Scoped is often used for services that need to maintain state within
            // a single request but should not share state across different requests. (Best Practice)
            builder.Services.AddScoped<Services.IScopedService, Services.ScopedService>();
            // Singleton : a single instance of the service is created and shared throughout the application's lifetime.
            builder.Services.AddSingleton<Services.ISingletonService, Services.SingletonService>();
            #endregion
            #endregion
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
