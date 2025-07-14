using Madiff.CardsPermissionsCalculator.Domain.Models;

namespace Madiff.CardsPermissionsCalculator.Domain.Rules;

public interface IActionRule
{
    string ActionName { get; }
    bool IsAllowed(CardDetails card);
}