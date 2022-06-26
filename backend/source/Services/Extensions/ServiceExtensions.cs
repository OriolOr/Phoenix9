
using Microsoft.Extensions.DependencyInjection;
using OriolOr.Maneko.Services.Interfaces;

namespace OriolOr.Maneko.Services.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>()
                    .AddScoped<IUserCredentialsService, UserCredentialsService>();

            return services;
        }
    }
}
