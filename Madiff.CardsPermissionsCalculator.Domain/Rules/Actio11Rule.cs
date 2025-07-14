using Madiff.CardsPermissionsCalculator.Domain.Models;

namespace Madiff.CardsPermissionsCalculator.Domain.Rules;

public class Action11Rule : IActionRule
{
    public string ActionName => "ACTION11";

    public bool IsAllowed(CardDetails card)
    {
        return card.CardStatus == CardStatus.Inactive ||
               card.CardStatus == CardStatus.Active;
    }
}