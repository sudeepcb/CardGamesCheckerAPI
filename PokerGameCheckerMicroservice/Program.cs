using Interfaces;
using Microsoft.OpenApi.Models;
using PokerGameCheckerMicroservice.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

namespace PokerGameCheckerMicroservice
{
    /// <summary>
    /// Entry Point of the application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main Class for Program Class for running applicable services
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            /* -Future
            //Adding DbContext with Azure SQL Database
            //Adding Authentication using Azure AD
            //Adding Application Insights
            */
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddCors();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Poker Game API", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Poker Game API");
                });
            }
            app.UseCors(options =>
            {
                options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}