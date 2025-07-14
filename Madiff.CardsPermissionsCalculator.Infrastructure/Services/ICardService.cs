using Madiff.CardsPermissionsCalculator.Domain.Models;

namespace Madiff.CardsPermissionsCalculator.Infrastructure.Services;

public interface ICardService
{
    Task<CardDetails?> GetCardDetails(string userId, string cardNumber);
}