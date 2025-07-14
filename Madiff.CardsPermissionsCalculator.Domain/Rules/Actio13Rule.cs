using Madiff.CardsPermissionsCalculator.Domain.Models;

namespace Madiff.CardsPermissionsCalculator.Domain.Rules;

public class Action13Rule : IActionRule
{
    public string ActionName => "ACTION13";

    public bool IsAllowed(CardDetails card)
    {
        return card.CardStatus == CardStatus.Ordered ||
               card.CardStatus == CardStatus.Inactive ||
               card.CardStatus == CardStatus.Active;
    }
}