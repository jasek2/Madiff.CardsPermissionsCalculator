using Madiff.CardsPermissionsCalculator.Domain.Models;

namespace Madiff.CardsPermissionsCalculator.Domain.Rules;

public class Action2Rule : IActionRule
{
    public string ActionName => "ACTION2";

    public bool IsAllowed(CardDetails card)
    {
        return card.CardStatus == CardStatus.Inactive;
    }
}