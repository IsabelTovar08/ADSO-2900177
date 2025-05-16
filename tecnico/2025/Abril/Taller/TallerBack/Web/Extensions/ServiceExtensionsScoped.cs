using Business.Classes;
using Business.Classes.PublicApi;
using Business.Services.Auth;
using Business.Services.JWT;
using Data.Classes.PublicApi;
using Data.Classes.Specifics;
using Data.Interfases;
using Entity.Audit;
using Entity.Models;
using Entity.Models.Notifications;
using Entity.Models.PublicApi;
using Infrastructure.Notifications.Implementations;
using Infrastructure.Notifications.Interfases;

namespace Web.Extensions
{
    public static class ServiceExtensionsScoped
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            //User 
            services.AddScoped<UserData>();
            services.AddScoped<ICrudBase<User>, UserData>();
            services.AddScoped<UserBusiness>();

            //Person 
            services.AddScoped<PersonData>();

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
            services.AddScoped<UserService>();
            services.AddScoped<GoogleAuthService>();

            services.AddScoped<AuthService>();
            services.AddScoped<JwtService>();

            //Audit 
            services.AddScoped<AuditManager>();
            services.AddScoped<AuditService>();


            //Notificatios 
            services.AddScoped<IMessageSender, EmailMessageSender>();
            services.AddScoped<IMessageSender, WhatsAppMessageSender>();

            services.AddScoped<INotify, Notifier>();
            services.AddScoped<IMessageSender, TelegramMessageSender>();


            //Public Api 
            //Users
            services.AddScoped<ICrudBase<UserPublic>, UserPublicData>();
            services.AddScoped<UserPublicBusiness>();
            services.AddScoped<UserPublic>();


            //Albums
            services.AddScoped<ICrudBase<AlbumsPublic>, AlbumsPublicData>();
            services.AddScoped<AlbumsPublicBusiness>();
            return services;
        }
    }
}

