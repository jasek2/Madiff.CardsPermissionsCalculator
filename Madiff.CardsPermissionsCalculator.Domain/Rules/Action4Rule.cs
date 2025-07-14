using Madiff.CardsPermissionsCalculator.Domain.Models;

namespace Madiff.CardsPermissionsCalculator.Domain.Rules;

public class Action4Rule : IActionRule
{
    public string ActionName => "ACTION4";

    public bool IsAllowed(CardDetails card)
    {
        return true;
    }
}