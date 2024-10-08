using Doomsday4.Common.Domain;

namespace Doomsday4.Domain;

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
    
    // Нормально ли что не приватные сетеры
    public string Name { get; private set; }

    public void rename(string newName)
    {
        this.Name = newName;
    }
    public string Description { get; private set; }

    public void changeDescription(string newDescription)
    {
        this.Description = newDescription;
    }
    public double Price { get; private set; }
    public void changePrice(double newPrice)
    {
        this.Price = newPrice;
    }
    public EquipmentCategory Category { get; private set; }
    public EquipmentStatus Status { get; private set; }
    
    public void changeStatus(EquipmentStatus newStatus)
    {
        this.Status = newStatus;
    }

}