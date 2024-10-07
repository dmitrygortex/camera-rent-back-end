using Doomsday4.Domain;
using Doomsday4.Domain.Data;
using MediatR;

namespace Doomsday4.Application.Equipment;

public class ChangeStatusOfEquipmentHandler(RentDbContext context) : IRequestHandler<ChangeStatusOfEquipment, Guid>
{
    public async Task<Guid> Handle(ChangeStatusOfEquipment command, CancellationToken cancellationToken)
    {
        var equipment = await context.Equipments.FindAsync(new object[] { command.Equipment.Id });
        if (equipment != null)
        {
            equipment.Status = EquipmentStatus.Available;
            await context.SaveChangesAsync();
            return equipment.Id;
        }
        // можно ли так и тут обрабатывать ошибки или же это не верно и не тут делается
        throw new ArgumentException($"Equipment {Guid.Empty} does not exist");
    }
}