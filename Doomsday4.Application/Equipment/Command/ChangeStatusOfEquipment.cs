using Doomsday4.Domain;
using MediatR;

namespace Doomsday4.Application.Equipment;

public class ChangeStatusOfEquipment : IRequest<Guid>
{
    public ChangeStatusOfEquipment(EquipmentStatus status, Domain.Equipment equipment)
    {
        EquipmentStatus = status;
        Equipment = equipment;
    }

    public EquipmentStatus EquipmentStatus { get; set; }
    public Domain.Equipment Equipment { get; }
}