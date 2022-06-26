using OriolOr.Maneko.Infrastructure;
using OriolOr.Maneko.Infrastructure.Interfaces;
using OriolOr.Maneko.Services;
using OriolOr.Maneko.Services.Interfaces;
using OriolOr.Maneko.Services.Extensions;
using OriolOr.Maneko.Infrastructure.Extensions;

namespace OriolOr.Maneko.API
{
    class Program
    {
        static void Main(string[] args)
        {
            // Add services to the container.
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Extensions 
            builder.Services.AddServices()
                            .AddRepositoryServices();

            var app = builder.Build();

            MongoDbConfigurator.InitializeDataBase();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}


