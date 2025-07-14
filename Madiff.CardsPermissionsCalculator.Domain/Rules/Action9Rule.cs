using Madiff.CardsPermissionsCalculator.Domain.Models;

namespace Madiff.CardsPermissionsCalculator.Domain.Rules;

public class Action9Rule : IActionRule
{
    public string ActionName => "ACTION9";

    public bool IsAllowed(CardDetails card)
    {
        return true;
    }
}