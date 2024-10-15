using Doomsday4.Domain.Models;
using MediatR;
using Newtonsoft.Json;

namespace Doomsday4.Application.Equipment.Command;

public class ChangeStatusOfEquipment : IRequest<Guid>
{
    public ChangeStatusOfEquipment(EquipmentStatus status, Guid equipmentGuid)
    {
        EquipmentStatus = status;
        EquipmentGuid = equipmentGuid;
    }

    public EquipmentStatus EquipmentStatus { get; }
    
    public Guid EquipmentGuid { get; }
}