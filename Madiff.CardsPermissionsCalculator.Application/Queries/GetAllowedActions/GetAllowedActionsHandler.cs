using Madiff.CardsPermissionsCalculator.Application.Exceptions;
using Madiff.CardsPermissionsCalculator.Domain.Rules;
using Madiff.CardsPermissionsCalculator.Infrastructure.Services;
using MediatR;

namespace Madiff.CardsPermissionsCalculator.Application.Queries.GetAllowedActions;

public class GetAllowedActionsHandler
    (ICardService cardService, IEnumerable<IActionRule> rules) : IRequestHandler<GetAllowedActionsQuery, List<string>>
{
    public async Task<List<string>> Handle(GetAllowedActionsQuery request, CancellationToken cancellationToken)
    {
        var card = await cardService.GetCardDetails(request.UserId, request.CardNumber);
        if (card is null)
            throw new NotFoundException("Card not found.");

        return rules
            .Where(r => r.IsAllowed(card))
            .Select(r => r.ActionName)
            .ToList();
    }
}