using Madiff.CardsPermissionsCalculator.Domain.Models;

namespace Madiff.CardsPermissionsCalculator.Domain.Rules;

public class Action13Rule : IActionRule
{
    public string ActionName => "ACTION13";

    public bool IsAllowed(CardDetails card)
    {
        return card.CardStatus is CardStatus.Ordered or CardStatus.Inactive or CardStatus.Active;
    }
}