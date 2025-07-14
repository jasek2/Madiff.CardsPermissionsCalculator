using Madiff.CardsPermissionsCalculator.Domain.Models;

namespace Madiff.CardsPermissionsCalculator.Domain.Rules;

public class Action6Rule : IActionRule
{
    public string ActionName => "ACTION6";

    public bool IsAllowed(CardDetails card)
    {
        return card is { CardStatus: CardStatus.Ordered, IsPinSet: true } ||
               card is { CardStatus: CardStatus.Inactive, IsPinSet: true } ||
               card is { CardStatus: CardStatus.Active, IsPinSet: true } ||
               card is { CardStatus: CardStatus.Blocked, IsPinSet: true };
    }
}