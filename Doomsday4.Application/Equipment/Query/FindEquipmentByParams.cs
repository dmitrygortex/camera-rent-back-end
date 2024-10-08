using Doomsday4.Application.Equipment.Models;
using Doomsday4.Domain.Models;
using MediatR;

namespace Doomsday4.Application.Equipment.Query;

public class FindEquipmentByParams : IRequest<EquipmentInfo>
{
    
    public FindEquipmentByParams(string name, string description, double price, EquipmentCategory category, EquipmentStatus status)
    {
        Name = name;
        Description = description;
        // min & max price
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