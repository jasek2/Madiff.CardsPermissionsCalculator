using Madiff.CardsPermissionsCalculator.Domain.Models;

namespace Madiff.CardsPermissionsCalculator.Domain.Rules;

public class Action1Rule : IActionRule
{
    public string ActionName => "ACTION1";

    public bool IsAllowed(CardDetails card)
    {
        return card.CardStatus == CardStatus.Active;
    }
}