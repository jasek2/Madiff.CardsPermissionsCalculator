using Madiff.CardsPermissionsCalculator.Application.Exceptions;
using Madiff.CardsPermissionsCalculator.Domain.Rules;
using Madiff.CardsPermissionsCalculator.Infrastructure.Services;
using MediatR;

namespace Madiff.CardsPermissionsCalculator.Application.Queries.GetAllowedActions;

public class GetAllowedActionsHandler : IRequestHandler<GetAllowedActionsQuery, List<string>>
{
    private readonly ICardService cardService;
    private readonly IEnumerable<IActionRule> rules;

    public GetAllowedActionsHandler(ICardService cardService, IEnumerable<IActionRule> rules)
    {
        this.cardService = cardService;
        this.rules = rules;
    }

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