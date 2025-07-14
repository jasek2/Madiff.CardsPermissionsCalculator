using Madiff.CardsPermissionsCalculator.Domain.Models;

namespace Madiff.CardsPermissionsCalculator.Domain.Rules;

public class Action6Rule : IActionRule
{
    public string ActionName => "ACTION6";

    public bool IsAllowed(CardDetails card)
    {
        return card is { CardStatus: CardStatus.Ordered, IsPinSet: true } or
            { CardStatus: CardStatus.Inactive, IsPinSet: true } or { CardStatus: CardStatus.Active, IsPinSet: true } or
            { CardStatus: CardStatus.Blocked, IsPinSet: true };
    }
}