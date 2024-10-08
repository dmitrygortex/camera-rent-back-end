using Doomsday4.Application.User.Command;
using Doomsday4.Application.User.Queries;
using Doomsday4.Domain;
using Doomsday4.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Doomsday4.Api.Endpoints;

public static class UserEndpoints
{
    public static WebApplication AddUserEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("/user");

        endpoints.MapPost("/add-new-user", async (IMediator mediator, [FromBody] User user) =>
        {
            var result = await mediator.Send(new AddNewUser(user.PhoneNumber, user.Password, user.Email,
                user.LastName, user.FirstName, user.UserRole));
            return Results.Ok(result);
        });
        endpoints.MapGet("/find-by-id/{id}", async (IMediator mediator, [FromBody] FindUserById user) =>
        {
            var result = await mediator.Send(new FindUserById(user.Id));
                
            return Results.Ok(result);
        });
        return app;
    }
}