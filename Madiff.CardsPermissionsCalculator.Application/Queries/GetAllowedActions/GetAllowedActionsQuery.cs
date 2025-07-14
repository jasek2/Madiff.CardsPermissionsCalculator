using MediatR;

namespace Madiff.CardsPermissionsCalculator.Application.Queries.GetAllowedActions;

public record GetAllowedActionsQuery(string UserId, string CardNumber) : IRequest<List<string>>;