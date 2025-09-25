namespace DemoSession02MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            #region Register Services In DI Container
            builder.Services.AddControllersWithViews();
            #endregion

            #region MapGet
            //app.MapGet("/", () => "Hello World!"); // Default
            //// app.MapGet("/", () => "Hello World!"); ambiguous routing error
            //app.MapGet("/kahlawy", () => "Hello Kahlawy!"); // Static Segment
            //app.MapGet("{name}",async (context) =>
            //{
            //    var name = context.Request.RouteValues["name"];
            //    await context.Response.WriteAsync($"Hello {name}");
            //}); // Dynamic Segment
            //app.MapGet("mr{name}", async (context) =>
            //{
            //    var name = context.Request.RouteValues["name"];
            //    await context.Response.WriteAsync($"Hello Mr {name}");
            //}); // Mix Segment
            #endregion

            app.MapControllerRoute(
                name: "Default",
                pattern: "{controller}/{action=Index}"
                );

            app.Run();
        }
    }
}
