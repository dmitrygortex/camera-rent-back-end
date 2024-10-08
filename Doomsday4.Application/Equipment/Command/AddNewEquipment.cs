using Doomsday4.Domain.Models;
using MediatR;

namespace Doomsday4.Application.Equipment.Command;

public class AddNewEquipment : IRequest<Guid>
{
    public AddNewEquipment(string name, string description, double price, EquipmentCategory category, EquipmentStatus status)
    {
        Name = name;
        Description = description;
        Price = price;
        Category = category;
        Status = status;
    }
    public string Name { get; }
    public string Description { get; }
    public double Price { get; }
    public EquipmentCategory Category { get; }
    public EquipmentStatus Status { get; }

}