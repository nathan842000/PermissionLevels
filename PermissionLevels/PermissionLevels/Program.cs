using PermissionLevels.DTOs;
using PermissionLevels.Repositories;
using PermissionLevels.Repositories.Interfaces;
using static Dapper.SqlMapper;

namespace PermissionLevels
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Build a config object, using env vars and JSON providers.
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            // Get values from the config given their key and their target type.
            Configuration configuration = config.GetRequiredSection("ConnectionStrings").Get<Configuration>();

            builder.Services.AddSingleton(configuration);
            
            builder.Services.AddScoped<IGroupRepository, GroupRepository>();
            builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
            builder.Services.AddScoped<IPermissionTypeRepository, PermissionTypeRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IModuleRepository, ModuleRepository>();
            builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
            builder.Services.AddScoped<IApplicationPermissionTypeRepository, ApplicationPermissionTypeRepository>();            
            builder.Services.AddScoped<IApplicationPermissionTypeDetailRepository, ApplicationPermissionTypeDetailRepository>();

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