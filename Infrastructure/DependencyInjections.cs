using Application.Abstractions;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<ChallengeDbContext>();

            services.AddScoped<IChallengeDbContext>(provider => provider.GetService<ChallengeDbContext>());

            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
