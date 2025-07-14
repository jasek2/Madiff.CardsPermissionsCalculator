namespace Madiff.CardsPermissionsCalculator.Domain.Models;

public record CardDetails(string CardNumber, CardType CardType, CardStatus CardStatus, bool IsPinSet);