using Infrastructure;
using Core.Interfaces;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using Core.Models;
//using Microsoft.Extensions.DependencyInjection;

namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CORSPolicy",
                    builder =>
                    {
                        builder
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowAnyOrigin();
                    });
            });


            builder.Services.Configure<EmailValidationConfig>(builder.Configuration.GetSection("EmailValidation"));
            builder.Services.Configure<EmailingServiceConfig>(builder.Configuration.GetSection("EmailingService"));

            var conStr = builder.Configuration.GetConnectionString("SQLiteDb");
            builder.Services.AddDbContext<SubscriberDbContext>(o => o.UseSqlite(conStr));

            builder.Services.AddTransient<ISubscriberRepository, SubscriberRepository>();
            builder.Services.AddTransient<IEmailValidationRepository, EmailValidationRepository>();
            builder.Services.AddTransient<SubscriberService>();
            builder.Services.AddTransient<IEmailingService, EmailingService>();

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //app.UseAuthorization();


            app.MapControllers();
            app.UseCors("CORSPolicy");
            app.Run();
        }
    }
}