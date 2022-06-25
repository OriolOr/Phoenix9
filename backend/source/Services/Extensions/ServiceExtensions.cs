
using Microsoft.Extensions.DependencyInjection;
using OriolOr.Maneko.Services.Interfaces;

namespace OriolOr.Maneko.Services.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IAccountService, AccountService>()
                    .AddSingleton<IUserCredentialsService, UserCredentialsService>();

            return services;
        }
    }
}
