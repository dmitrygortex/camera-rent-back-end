using Doomsday4.Common.Domain;

namespace Doomsday4.Domain.Models;

public class Equipment : Entity<Guid>
{
    private Equipment()
    {
    }

    public Equipment(string name, string description, double price, EquipmentCategory category, EquipmentStatus status)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Price = price;
        Category = category;
        Status = status;
    }
    
    // TODO: приватные сетеры!
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public EquipmentCategory Category { get; private set; }
    public EquipmentStatus Status { get; set; }

}