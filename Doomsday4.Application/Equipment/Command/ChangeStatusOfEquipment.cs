using Doomsday4.Domain.Models;
using MediatR;

namespace Doomsday4.Application.Equipment.Command;

public class ChangeStatusOfEquipment : IRequest<Guid>
{
    public ChangeStatusOfEquipment(EquipmentStatus status, Domain.Models.Equipment equipment)
    {
        EquipmentStatus = status;
        Equipment = equipment;
    }

    public EquipmentStatus EquipmentStatus { get; }
    
    public Domain.Models.Equipment Equipment { get; }
}