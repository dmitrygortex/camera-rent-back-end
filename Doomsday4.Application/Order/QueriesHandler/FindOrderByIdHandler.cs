using Doomsday4.Application.Equipment;
using Doomsday4.Application.Equipment.Models;
using Doomsday4.Application.Order.Queries;
using Doomsday4.Domain.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Doomsday4.Application.Order.QueriesHandler;

public class FindOrderByIdHandler(RentDbContext context) : IRequestHandler<FindOrderById, OrderDto.OrderDto>
{
    public async Task<OrderDto.OrderDto?> Handle(FindOrderById command, CancellationToken cancellationToken)
    {
        var order = await context.Orders.FirstOrDefaultAsync(u => u.Id == command.Id, cancellationToken: cancellationToken);
        if (order is null)
        {
            return null;
        }
        else
        {
            return new OrderDto.OrderDto(order.Id, order.UserId, order.StartDateTime, order.EndDateTime, order.Сost,
                order.Status);
        }
    }
}