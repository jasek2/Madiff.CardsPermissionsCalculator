using Madiff.CardsPermissionsCalculator.Domain.Models;

namespace Madiff.CardsPermissionsCalculator.Domain.Rules;

public class Action3Rule : IActionRule
{
    public string ActionName => "ACTION3";

    public bool IsAllowed(CardDetails card)
    {
        return true;
    }
}