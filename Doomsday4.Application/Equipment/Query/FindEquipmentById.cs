using Doomsday4.Application.Equipment.Models;
using MediatR;

namespace Doomsday4.Application.Equipment.Query;

public class FindEquipmentById: IRequest<EquipmentInfo>
{
    public FindEquipmentById(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; }
}