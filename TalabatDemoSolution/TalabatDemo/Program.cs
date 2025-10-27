
using DomainLayer.Contracts;
using Microsoft.EntityFrameworkCore;
using PersistenceLayer;
using PersistenceLayer.Data;

namespace TalabatDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region Notes
            // API types:
            // - RESTful APIs: it's the most common type of API, using HTTP requests to GET, POST, PUT, DELETE data.
            //                 it returns data in JSON format.
            // - GraphQL APIs: allows clients to request only the data they need, reducing over-fetching.
            // - SOAP APIs: a protocol for exchanging structured information in web services and offers high level security.

            // Onion Architecture Layers:
            // - Domain [Core] Layer:
            //      - contains Models & Exceptions.
            //      - contains interfaces for repositories and services.
            // - Service Layer:
            //      - Services implementations.
            //      - Service Abstraction [Not dealing with domain directly].
            // - Persistence Layer:
            //      - Database Contexts.
            //      - Core of project implementations [Repositories implementations].
            //      - Cashing 
            // - Persentation API Controllers
            // - Web Application Layer
            #endregion

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IDataSeeding, DataSeeding>();


            var app = builder.Build();

            // Manual Injection to Seed Data
            using var dataSeedingScope = app.Services.CreateScope();
            var dataSeeding = dataSeedingScope.ServiceProvider.GetRequiredService<IDataSeeding>();
            dataSeeding.SeedData();



            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
