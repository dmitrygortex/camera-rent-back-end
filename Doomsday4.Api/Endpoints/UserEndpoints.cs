using Doomsday4.Application.User.Command;
using Doomsday4.Domain;
using MediatR;

namespace Doomsday4.Api.Endpoints;

public static class UserEndpoints
{
    public static WebApplication AddUserEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("/user");

        endpoints.MapPost("/add-new-user", async (IMediator mediator, User user) =>
        {
            var result = await mediator.Send(new AddNewUser(user.PhoneNumber, user.Password, user.Email,
                user.LastName, user.FirstName, user.UserRole));
            return Results.Ok(result);
        });
        return app;
    }
}