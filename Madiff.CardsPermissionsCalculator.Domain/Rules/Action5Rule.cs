using Madiff.CardsPermissionsCalculator.Domain.Models;

namespace Madiff.CardsPermissionsCalculator.Domain.Rules;

public class Action5Rule : IActionRule
{
    public string ActionName => "ACTION5";

    public bool IsAllowed(CardDetails card)
    {
        return card.CardType == CardType.Credit;
    }
}