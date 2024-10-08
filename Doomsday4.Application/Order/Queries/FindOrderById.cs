using MediatR;

namespace Doomsday4.Application.Order.Queries;

public class FindOrderById : IRequest<OrderDto.OrderDto>
{
    public FindOrderById(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }
}