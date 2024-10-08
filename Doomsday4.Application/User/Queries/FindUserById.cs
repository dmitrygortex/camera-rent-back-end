using MediatR;

namespace Doomsday4.Application.User.Queries;

public class FindUserById : IRequest<UserDto.UserDto>
{
    public FindUserById(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }
}
