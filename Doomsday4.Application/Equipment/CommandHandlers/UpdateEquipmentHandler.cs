using Doomsday4.Application.Equipment.Command;
using Doomsday4.Domain.Data;
using MediatR;

namespace Doomsday4.Application.Equipment.CommandHandlers;

public class UpdateEquipmentHandler(RentDbContext context) : IRequestHandler<UpdateEquipment, Guid>
{
    public async Task<Guid> Handle(UpdateEquipment command, CancellationToken cancellationToken)
    {
        var equipmentToEdit = await context.Equipments.FindAsync(command.LastEquipmentGuid, cancellationToken);
        equipmentToEdit.Rename(command.Name);
        equipmentToEdit.ChangeDescription(command.Description);
        equipmentToEdit.ChangePrice(command.Price);
        equipmentToEdit.ChangeStatus(command.Status);
        await context.SaveChangesAsync(cancellationToken);
        return equipmentToEdit.Id;
    }
}