using Doomsday4.Application.Order.Queries;
using Doomsday4.Domain.Data;
using MediatR;

namespace Doomsday4.Application.Order.QueriesHandler;

public class FindAllOrdersHandler(RentDbContext context) : IRequestHandler<FindAllOrders, List<OrderDto.OrderDto>>
{
    
    
    
    public async Task<List<OrderDto.OrderDto>> Handle(FindAllOrders request, CancellationToken cancellationToken)
    {
        // return await context.Orders.
        return null;
    }
    
}