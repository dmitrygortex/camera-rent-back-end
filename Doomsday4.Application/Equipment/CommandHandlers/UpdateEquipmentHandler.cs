using Doomsday4.Application.User.Command;
using Doomsday4.Domain.Data;
using MediatR;

namespace Doomsday4.Application.Equipment;

public class UpdateEquipmentHandler(RentDbContext context) : IRequestHandler<UpdateEquipment, Guid>
{
    public async Task<Guid> Handle(UpdateEquipment command, CancellationToken cancellationToken)
    {
        var equipmentToEdit = await context.Equipments.FindAsync(command.LastEquipmentGuid, cancellationToken);
        equipmentToEdit.rename(command.Name);
        equipmentToEdit.changeDescription(command.Description);
        equipmentToEdit.changePrice(command.Price);
        equipmentToEdit.changeStatus(command.Status);
        await context.SaveChangesAsync(cancellationToken);
        return equipmentToEdit.Id;
    }
}