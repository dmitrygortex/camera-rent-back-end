using Doomsday4.Application.Order.Command;
using Doomsday4.Application.User.Command;
using Doomsday4.Domain.Data;
using MediatR;

namespace Doomsday4.Application.Order.CommandHandlers;

public class AddNewOrderHandler(RentDbContext context) : IRequestHandler<AddNewOrder, Guid>
{
    public async Task<Guid> Handle(AddNewOrder command, CancellationToken cancellationToken)
    {
        var newOrder = await context.Orders.AddAsync(new Domain.Order(command.UserId, command.StartDateTime, command.EndDateTime, command.Сost, command.Status), cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return newOrder.Entity.Id;
    }
}