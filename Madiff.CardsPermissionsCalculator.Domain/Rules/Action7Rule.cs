using Madiff.CardsPermissionsCalculator.Domain.Models;

namespace Madiff.CardsPermissionsCalculator.Domain.Rules;

public class Action7Rule : IActionRule
{
    public string ActionName => "ACTION7";

    public bool IsAllowed(CardDetails card)
    {
        return card is { CardStatus: CardStatus.Ordered, IsPinSet: false } or
            { CardStatus: CardStatus.Inactive, IsPinSet: false } or
            { CardStatus: CardStatus.Active, IsPinSet: false } or { CardStatus: CardStatus.Blocked, IsPinSet: true };
    }
}