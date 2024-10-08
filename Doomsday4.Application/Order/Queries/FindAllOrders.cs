using MediatR;

namespace Doomsday4.Application.Order.Queries;
public class FindAllOrders : IRequest<List<OrderDto.OrderDto>>;