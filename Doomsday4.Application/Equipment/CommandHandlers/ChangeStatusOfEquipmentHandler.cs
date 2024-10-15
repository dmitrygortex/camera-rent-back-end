using Doomsday4.Application.Equipment.Command;
using Doomsday4.Domain.Data;
using Doomsday4.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Doomsday4.Application.Equipment.CommandHandlers;

public class ChangeStatusOfEquipmentHandler(RentDbContext context) : IRequestHandler<ChangeStatusOfEquipment, Guid>
{
    public async Task<Guid> Handle(ChangeStatusOfEquipment command, CancellationToken cancellationToken)
    {
        var equipment = await context.Equipments.FindAsync(command.EquipmentGuid);
        //var equipment = await context.Equipments.FirstOrDefaultAsync(u => u.Id == command.EquipmentGuid, cancellationToken: cancellationToken);

        if (equipment is null)
            throw new ApplicationException($"Equipment {command.EquipmentGuid} does not exist");
            //return Guid.Empty;
        equipment.ChangeStatus(command.EquipmentStatus);
        await context.SaveChangesAsync(cancellationToken);
        return equipment.Id;
        
    }
}