using Madiff.CardsPermissionsCalculator.Domain.Models;

namespace Madiff.CardsPermissionsCalculator.Domain.Rules;

public class Action10Rule : IActionRule
{
    public string ActionName => "ACTION10";

    public bool IsAllowed(CardDetails card)
    {
        return card.CardStatus == CardStatus.Ordered ||
               card.CardStatus == CardStatus.Inactive ||
               card.CardStatus == CardStatus.Active
            ;
    }
}