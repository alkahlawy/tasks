using Demo.BLL.MappingProfiles;
using Demo.BLL.Services.AttachmentService;
using Demo.BLL.Services.Departments;
using Demo.BLL.Services.Employees;
using Demo.DAL.Data.Contexts;
using Demo.DAL.Models.IdentityModels;
using Demo.DAL.Repositories.Shared.Classes;
using Demo.DAL.Repositories.Shared.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region Configure Services : Add Services to DI Container
            builder.Services.AddControllersWithViews(
                // apply Anti Forgery Token to all Http Methods that can change data (POST, PUT, DELETE)
                options => options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute())
            );
            // Give CLR the ability to create Instance from ApplicaionDbContext Class
            //builder.Services.AddScoped<ApplicaionDbContext>(); // Register Services 
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString).UseLazyLoadingProxies();
            });
            // No need to register GenericRepository as it is being used internally in UnitOfWork
            //builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            //builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IAttachmentService, AttachmentService>();
            builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            // Auto Mapper Registration
            builder.Services.AddAutoMapper(M => M.AddProfile(profile: new MappingProfile()));
            builder.Services.AddIdentity<ApplicationUser,IdentityRole>(options =>
            {
                // To make customize settings
                //options.Password.RequireDigit = true;
                //options.Password.RequireLowercase = true;
                //options.Password.RequireUppercase = true;
                //options.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
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
                pattern: "{controller=Account}/{action=Register}/{id?}");

            app.Run();
        }
    }
}
