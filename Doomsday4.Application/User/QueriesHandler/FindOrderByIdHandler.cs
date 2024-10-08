using Doomsday4.Application.Order.OrderDto;
using Doomsday4.Application.Order.Queries;
using Doomsday4.Application.User.Queries;
using Doomsday4.Domain.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Doomsday4.Application.User.QueriesHandler;

public class FindUserByIdHandler(RentDbContext context) : IRequestHandler<FindUserById, UserDto.UserDto>
{
    public async Task<UserDto.UserDto> Handle(FindUserById command, CancellationToken cancellationToken)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == command.Id, cancellationToken: cancellationToken);
        if (user is null)
        {
            return null;
        }
        else
        {
            return new UserDto.UserDto(user.Id, user.PhoneNumber, user.Password, user.Email, user.LastName,
                user.FirstName, user.UserRole);
        }
    }
}