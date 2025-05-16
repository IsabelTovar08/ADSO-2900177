
using Business;
using Data;
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


            builder.Services.AddScoped<FormBusiness>();
            builder.Services.AddScoped<FormData>();

            builder.Services.AddDbContext<ApplicationDbContext>(opciones => opciones
.UseSqlServer("name=DefaultConnection"));

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
