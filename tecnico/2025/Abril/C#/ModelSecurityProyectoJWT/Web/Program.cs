
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

            builder.Services.AddDataAccessFactory("SQLServer", builder.Configuration);

            builder.Services.AddScoped<FormBusiness>();
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


            builder.Services.AddScoped<FormData>();
            builder.Services.AddScoped<FormBusiness>();

            builder.Services.AddScoped<ModuleData>();
            builder.Services.AddScoped<ModuleBusiness>();


            builder.Services.AddAutoMapper(typeof(Helpers.MappingProfile));



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
