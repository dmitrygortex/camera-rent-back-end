using Doomsday4.Application.Equipment.Command;
using Doomsday4.Domain.Data;
using Doomsday4.Domain.Models;
using MediatR;

namespace Doomsday4.Application.Equipment.CommandHandlers;

public class ChangeStatusOfEquipmentHandler(RentDbContext context) : IRequestHandler<ChangeStatusOfEquipment, Guid>
{
    public async Task<Guid> Handle(ChangeStatusOfEquipment command, CancellationToken cancellationToken)
    {
        var equipment = await context.Equipments.FindAsync(new object[] { command.Equipment.Id });
        if (equipment != null)
        {
            equipment.ChangeStatus(command.EquipmentStatus);
            await context.SaveChangesAsync(cancellationToken);
            return equipment.Id;
        }
        
        throw new ApplicationException($"Equipment {Guid.Empty} does not exist");
    }
}