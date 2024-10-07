using Doomsday4.Domain;

namespace Doomsday4.Application.Equipment.Models;

public class EquipmentInfo
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public EquipmentCategory Category { get; set; }
    public EquipmentStatus Status { get; set; }
}