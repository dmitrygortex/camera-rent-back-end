using System.Text.Json.Serialization;
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
    
    // Нормально ли что не приватные сетеры
    public string Name { get; private set; }

    public void Rename(string newName)
    {
        this.Name = newName;
    }
    public string Description { get; private set; }

    public void ChangeDescription(string newDescription)
    {
        this.Description = newDescription;
    }
    public double Price { get; private set; }
    public void ChangePrice(double newPrice)
    {
        this.Price = newPrice;
    }
    public EquipmentCategory Category { get; private set; }
    public EquipmentStatus Status { get; private set; }
    
    public void ChangeStatus(EquipmentStatus newStatus)
    {
        this.Status = newStatus;
    }

}