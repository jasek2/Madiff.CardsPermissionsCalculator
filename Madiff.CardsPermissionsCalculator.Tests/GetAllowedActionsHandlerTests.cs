using Madiff.CardsPermissionsCalculator.Application.Exceptions;
using Madiff.CardsPermissionsCalculator.Application.Queries.GetAllowedActions;
using Madiff.CardsPermissionsCalculator.Domain.Models;
using Madiff.CardsPermissionsCalculator.Domain.Rules;
using Madiff.CardsPermissionsCalculator.Infrastructure.Services;
using Moq;

namespace Madiff.CardsPermissionsCalculator.Tests;

public class GetAllowedActionsHandlerTests
{
    private readonly Mock<ICardService> _cardServiceMock;
    private readonly List<IActionRule> _rules;

    public GetAllowedActionsHandlerTests()
    {
        _cardServiceMock = new Mock<ICardService>();

        _rules = new List<IActionRule>
        {
            new DummyRule("ACTION1", c => c.CardType == CardType.Prepaid),
            new DummyRule("ACTION2", c => c.IsPinSet)
        };
    }

    [Fact]
    public async Task Returns_Expected_Actions_For_Valid_Card()
    {
        // Arrange
        var card = new CardDetails("Card123", CardType.Prepaid, CardStatus.Active, true);
        _cardServiceMock.Setup(x => x.GetCardDetails("user1", "Card123"))
            .ReturnsAsync(card);

        var handler = new GetAllowedActionsHandler(_cardServiceMock.Object, _rules);
        var query = new GetAllowedActionsQuery("user1", "Card123");

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Contains("ACTION1", result);
        Assert.Contains("ACTION2", result);
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task Throws_NotFoundException_When_Card_Not_Found()
    {
        // Arrange
        _cardServiceMock.Setup(x => x.GetCardDetails("user1", "invalid"))
            .ReturnsAsync((CardDetails)null!);

        var handler = new GetAllowedActionsHandler(_cardServiceMock.Object, _rules);
        var query = new GetAllowedActionsQuery("user1", "invalid");

        // Act & Assert
        await Assert.ThrowsAsync<NotFoundException>(() =>
            handler.Handle(query, CancellationToken.None));
    }

    private class DummyRule : IActionRule
    {
        private readonly Func<CardDetails, bool> _predicate;

        public DummyRule(string actionName, Func<CardDetails, bool> predicate)
        {
            ActionName = actionName;
            _predicate = predicate;
        }

        public string ActionName { get; }

        public bool IsAllowed(CardDetails card)
        {
            return _predicate(card);
        }
    }
}