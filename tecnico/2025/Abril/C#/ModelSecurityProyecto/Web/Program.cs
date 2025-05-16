
using Business;
using Data;
using Data.Clases;
using Entity.Context;
using Microsoft.EntityFrameworkCore;

namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(politica =>
                politica.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()
                );
            });


            builder.Services.AddScoped<FormBusiness2>();
            builder.Services.AddScoped<FormData>();

            builder.Services.AddScoped<ModuleBusiness>();
            builder.Services.AddScoped<ModuleData>();

            builder.Services.AddScoped<RolBusiness>();
            builder.Services.AddScoped<RolData>();


            builder.Services.AddScoped<PermissionBusiness>();
            builder.Services.AddScoped<PermissionData>();


            builder.Services.AddScoped<UserBusiness>();
            builder.Services.AddScoped<UserData>();


            builder.Services.AddScoped<PersonBusiness>();
            builder.Services.AddScoped<PersonData>();

            builder.Services.AddScoped<UserRoleBusiness>();
            builder.Services.AddScoped<UserRoleData>();

            builder.Services.AddScoped<FormModuleBusiness>();
            builder.Services.AddScoped<FormModuleData>();

            builder.Services.AddScoped<RoleFormPermissionBusiness>();
            builder.Services.AddScoped<RoleFormPermissionData>();


            builder.Services.AddScoped<FormData2>();
            builder.Services.AddScoped<FormBusiness>();

            builder.Services.AddScoped<ModuleData2>();
            builder.Services.AddScoped<ModuleBusiness2>();


            var connectionString = builder.Configuration.GetConnectionString("SQLServer");
            var databaseProvider = builder.Configuration["DatabaseProvider"];

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                switch (databaseProvider.ToLower())
                {
                    case "postgresql":
                        options.UseNpgsql(connectionString);
                        break;
                    case "mysql":
                        var serverVersion = new MySqlServerVersion(new Version(8, 0, 41)); // Ejemplo de versión 8.0.21, ajusta según tu versión de MySQL
                        options.UseMySql(connectionString, serverVersion);
                        break;
                    case "sqlserver":
                    default:
                        options.UseSqlServer(connectionString);
                        break;
                }
            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors();


            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
