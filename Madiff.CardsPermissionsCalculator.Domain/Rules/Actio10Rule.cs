using Madiff.CardsPermissionsCalculator.Domain.Models;

namespace Madiff.CardsPermissionsCalculator.Domain.Rules;

public class Action10Rule : IActionRule
{
    public string ActionName => "ACTION10";

    public bool IsAllowed(CardDetails card)
    {
        return card.CardStatus is CardStatus.Ordered or CardStatus.Inactive or CardStatus.Active;
    }
}