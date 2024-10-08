using Doomsday4.Domain.Models;
using MediatR;

namespace Doomsday4.Application.Equipment.Command;

public class UpdateEquipment: IRequest<Guid>
{
    public UpdateEquipment(Guid lastEquipmentGuid, string name, string description, double price, EquipmentStatus status)
    {
        LastEquipmentGuid = lastEquipmentGuid;
        Name = name;
        Description = description;
        Price = price;
        Status = status;
    }
    
    public Guid LastEquipmentGuid { get; set; }
    public string Name { get; set; }
    public string Description { get; set;}
    public double Price { get; set;}
    public EquipmentStatus Status { get; set;}

}