using Business.Classes;
using Business.Services.Auth;
using Business.Services.JWT;
using Data.Classes.Specifics;
using Data.Interfases;
using Entity.Audit;
using Entity.Models;

namespace Web.Extensions
{
    public static class ServiceExtensionsBussinesData
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            //User 
            services.AddScoped<UserData>();
            services.AddScoped<ICrudBase<User>, UserData>();
            services.AddScoped<UserBusiness>();

            //Person 
            services.AddScoped<ICrudBase<Person>, PersonData>();
            services.AddScoped<PersonBusiness>();

            //Rol 
            services.AddScoped<ICrudBase<Rol>, RolData>();
            services.AddScoped<RolBusiness>();

            //Form 
            services.AddScoped<ICrudBase<Form>, FormData>();
            services.AddScoped<FormBusiness>();

            //Module
            services.AddScoped<ICrudBase<Module>, ModuleData>();
            services.AddScoped<ModuleBusiness>();

            //ModuleForm 
            services.AddScoped<ICrudBase<ModuleForm>, ModuleFormData>();
            services.AddScoped<ModuleFormBusiness>();

            //Permission 
            services.AddScoped<ICrudBase<Permission>, PermissionData>();
            services.AddScoped<PermissionBusiness>();

            //RolFormPermission 
            services.AddScoped<ICrudBase<RolFormPermission>, RolFormPermissionData>();
            services.AddScoped<RolFormPermissionBusiness>();

            //UserRol 
            services.AddScoped<UserRolData>();
            services.AddScoped<ICrudBase<UserRol>, UserRolData>();
            services.AddScoped<UserBusiness>();
            services.AddScoped<UserRolBusiness>();


            //Auth 
            services.AddScoped<AuthService>();
            services.AddScoped<JwtService>();

            //Auth 
            services.AddScoped<AuditManager>();
            services.AddScoped<AuditService>();

            return services;
        }
    }
}

