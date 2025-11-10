using DomainLayer.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersistenceLayer;
using PersistenceLayer.Data;
using PersistenceLayer.Repositories;
using ServiceAbstractionLayer;
using ServiceLayer;
using ServiceLayer.MappingProfiles;
using Shared.ErrorModels;
using TalabatDemo.CustomMiddleware;
using TalabatDemo.Extentions;
using TalabatDemo.Factories;

namespace TalabatDemo
{
    public class Program
    {
        public static async Task Main(string[] args)
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

            #region Add Services to DI Container
            // Add services to the container.
            builder.Services.AddControllers();

            // Swagger registration
            builder.Services.AddSwaggerRegisteration();

            #region Register User-Defined Services
            // Infrastructure layer registration
            builder.Services.AddInfrastructureServices(builder.Configuration);

            // Service layer registration
            builder.Services.AddApplicationServices();

            builder.Services.AddScoped<IProductService, ProductService>();

            // Web Application registration
            builder.Services.AddWebApplicationService(); 
            #endregion

            #endregion

            var app = builder.Build();
            await app.SeedDatabaseAsync();

            #region Configure the HTTP request pipeline

            app.UseCustomExceptionsMiddleware();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerMiddlewares();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseStaticFiles();
            app.MapControllers();

            app.Run(); 
            #endregion
        }
    }
}
