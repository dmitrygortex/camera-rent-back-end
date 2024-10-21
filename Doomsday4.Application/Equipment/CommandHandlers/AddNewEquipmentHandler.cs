using Doomsday4.Application.Equipment.Command;
using Doomsday4.Domain.Data;
using MediatR;

namespace Doomsday4.Application.Equipment.CommandHandlers;

public class AddNewEquipmentHandler(RentDbContext context) : IRequestHandler<AddNewEquipment, Guid>
{
    public async Task<Guid> Handle(AddNewEquipment command, CancellationToken cancellationToken)
    {
        var newEquipment = await context.Equipments.AddAsync(new Domain.Models.Equipment(command.Name, command.Description, command.Price, command.Category, command.Status), cancellationToken);

        
        await context.SaveChangesAsync(cancellationToken);
        return newEquipment.Entity.Id;
    }
}