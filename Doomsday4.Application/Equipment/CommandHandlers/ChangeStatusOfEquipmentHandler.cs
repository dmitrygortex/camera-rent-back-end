using Doomsday4.Domain;
using Doomsday4.Domain.Data;
using MediatR;
using MongoDB.Bson;

namespace Doomsday4.Application.Equipment;

public class ChangeStatusOfEquipmentHandler(RentDbContext context) : IRequestHandler<ChangeStatusOfEquipment, Guid>
{
    public async Task<Guid> Handle(ChangeStatusOfEquipment command, CancellationToken cancellationToken)
    {
        var equipment = await context.Equipments.FindAsync(new object[] { command.Equipment.Id });
        if (equipment != null)
        {
            equipment.changeStatus(command.EquipmentStatus);
            await context.SaveChangesAsync(cancellationToken);
            return equipment.Id;
        }
        throw new ApplicationException($"Equipment {Guid.Empty} does not exist");
    }
}