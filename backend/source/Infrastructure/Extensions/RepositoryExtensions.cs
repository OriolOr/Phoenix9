using Microsoft.Extensions.DependencyInjection;
using OriolOr.Maneko.Infrastructure.Interfaces;

namespace OriolOr.Maneko.Infrastructure.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositoryServices(IServiceCollection services)
        {
            services.AddSingleton<IAccountDataRepository, AccountDataRepository>()
                    .AddSingleton<IUserDataRepository, UserDataRepository>();
            return services;
        }
    }
}