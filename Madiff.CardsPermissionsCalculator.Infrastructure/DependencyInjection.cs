using Madiff.CardsPermissionsCalculator.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Madiff.CardsPermissionsCalculator.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ICardService, CardService>();

        return services;
    }
}