using Entity.Context;
using Entity.Models.Notifications;
using Microsoft.EntityFrameworkCore;
using Web.Extensions;

namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHttpContextAccessor();

            // servicios y data
            builder.Services.AddProjectServices();
            //Cors
            builder.Services.AddCorsConfiguration(configuration);

            //Automapper
            builder.Services.AddAutoMapper(typeof(Helper.MappingProfile));

            // JWT
            builder.Services.AddJwtAuthentication(configuration);

            builder.Services.AddDbContext<AuditDbContext>(options =>
               options.UseNpgsql(configuration.GetConnectionString("AuditLog")));

            //Conexión 
            builder.Services.AddDatabaseConfiguration(configuration);


            //Mail 
            builder.Services.Configure<EmailSettings>(
            builder.Configuration.GetSection("EmailSettings"));

            builder.Services.Configure<TwilioSettings>(
                builder.Configuration.GetSection("Twilio"));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseHttpsRedirection();
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
