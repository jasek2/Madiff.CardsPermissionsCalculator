using Madiff.CardsPermissionsCalculator.Application.Queries.GetAllowedActions;
using Madiff.CardsPermissionsCalculator.Domain.Rules;
using Microsoft.Extensions.DependencyInjection;

namespace Madiff.CardsPermissionsCalculator.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(GetAllowedActionsQuery).Assembly));

        services.AddSingleton<IActionRule, Action1Rule>();
        services.AddSingleton<IActionRule, Action2Rule>();
        services.AddSingleton<IActionRule, Action3Rule>();
        services.AddSingleton<IActionRule, Action4Rule>();
        services.AddSingleton<IActionRule, Action5Rule>();
        services.AddSingleton<IActionRule, Action6Rule>();
        services.AddSingleton<IActionRule, Action7Rule>();
        services.AddSingleton<IActionRule, Action8Rule>();
        services.AddSingleton<IActionRule, Action9Rule>();
        services.AddSingleton<IActionRule, Action10Rule>();
        services.AddSingleton<IActionRule, Action11Rule>();
        services.AddSingleton<IActionRule, Action12Rule>();
        services.AddSingleton<IActionRule, Action13Rule>();

        return services;
    }
}