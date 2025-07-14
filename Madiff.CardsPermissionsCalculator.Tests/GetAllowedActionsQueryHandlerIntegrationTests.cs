using Madiff.CardsPermissionsCalculator.Application.Queries.GetAllowedActions;
using Madiff.CardsPermissionsCalculator.Domain.Rules;
using Madiff.CardsPermissionsCalculator.Infrastructure.Services;

namespace Madiff.CardsPermissionsCalculator.Tests;

public class GetAllowedActionsQueryHandlerIntegrationTests
{
    private readonly ICardService _cardService;
    private readonly List<IActionRule> _rules;

    public GetAllowedActionsQueryHandlerIntegrationTests()
    {
        _cardService = new CardService();
        _rules = typeof(IActionRule)
            .Assembly
            .GetTypes()
            .Where(t => !t.IsAbstract && typeof(IActionRule).IsAssignableFrom(t))
            .Select(t => (IActionRule)Activator.CreateInstance(t)!)
            .ToList();
    }

    [Fact]
    public async Task Prepaid_Closed_Returns_Action3_4_9()
    {
        var query = new GetAllowedActionsQuery("User1", "Card17");
        var handler = new GetAllowedActionsHandler(_cardService, _rules);

        var result = await handler.Handle(query, CancellationToken.None);

        var expected = new[] { "ACTION3", "ACTION4", "ACTION9" };
        Assert.Equal(expected.OrderBy(x => x), result.OrderBy(x => x));
    }

    [Fact]
    public async Task Credit_Blocked_WithPin_Returns_Action3_4_5_6_7_8_9()
    {
        var query = new GetAllowedActionsQuery("User1", "Card119");
        var handler = new GetAllowedActionsHandler(_cardService, _rules);

        var result = await handler.Handle(query, CancellationToken.None);

        var expected = new[]
        {
            "ACTION3", "ACTION4", "ACTION5", "ACTION8", "ACTION9"
        };
        Assert.Equal(expected.OrderBy(x => x), result.OrderBy(x => x));
    }
}