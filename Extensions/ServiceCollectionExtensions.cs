using Microsoft.Extensions.DependencyInjection;
using RockPaperScissorsGame.Interfaces;
using RockPaperScissorsGame.Services;

namespace RockPaperScissorsGame.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IGameService, GameService>();
            return services;
        }
    }

}