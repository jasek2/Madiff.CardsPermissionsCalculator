using Madiff.CardsPermissionsCalculator.API.Middleware;
using Madiff.CardsPermissionsCalculator.Application;
using Madiff.CardsPermissionsCalculator.Application.Queries.GetAllowedActions;
using Madiff.CardsPermissionsCalculator.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure();
builder.Services.AddApplication();
builder.Services.AddSingleton<ExceptionHandlingMiddleware>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionHandlingMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/cards/{userId}/{cardNumber}/actions", async (
        string userId,
        string cardNumber,
        [FromServices] IMediator mediator) =>
    {
        var query = new GetAllowedActionsQuery(userId, cardNumber);
        var actions = await mediator.Send(query);
        return Results.Ok(actions);
    })
    .WithName("GetAllowedActions")
    .WithOpenApi();

app.Run();