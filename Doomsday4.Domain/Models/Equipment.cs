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
    public string Name { get; private set; }

    public void Rename(string newName)
    {
        if (newName == null) 
            throw new ArgumentException("U cant use empty name");
        
        switch (newName.Length)
        {
            case < 2:
                throw new ArgumentException("Extra short name");
            case >= 100:
                throw new ArgumentException("Name must be less than 100 characters long");
        }

        if (Name == newName)
            throw new ArgumentException("Use different name");
            
        this.Name = newName;
        
    }
    public string Description { get; private set; }

    public void ChangeDescription(string newDescription)
    {
        if (newDescription == null) 
            throw new ArgumentException("U cant use empty description");
        
        switch (newDescription.Length)
        {
            case < 10:
                throw new ArgumentException("Extra short description");
            case >= 1000:
                throw new ArgumentException("Description must be less than 1000 characters long");
        }
        
        if (Description == newDescription)
            throw new ArgumentException("Use different description");
        
        
            
        this.Description = newDescription;
    }
    public double Price { get; private set; }
    
    
    public void ChangePrice(double newPrice)
    {
        if (newPrice <= 0) 
            throw new ArgumentException("Price should be greater than 0");
        
        if (Math.Abs(newPrice - Price) < 0.0001)
            throw new ArgumentException("Use different price");
        
        this.Price = newPrice;
    }
    public EquipmentCategory Category { get; private set; }
    public EquipmentStatus Status { get; private set; }

    public void ChangeStatus(EquipmentStatus newStatus)
    {

        if (newStatus == null)
            throw new ArgumentException("U cant use null status");

        if (newStatus == Status)
            throw new ArgumentException("Use different status");

        var oldStatus = Status;
        // доступно -> забронировано | в доставке | арендовано | недоступно
        if (oldStatus is EquipmentStatus.Available && (
                newStatus is EquipmentStatus.Reserved ||
                newStatus is EquipmentStatus.InDelivery ||
                newStatus is EquipmentStatus.Unavailable ||
                newStatus is EquipmentStatus.RentedOut))
        {
            this.Status = newStatus;
            return;
        }
        // забронировано -> доступно | в доставке | арендовано | недоступно
        if (oldStatus is EquipmentStatus.Reserved && (
                newStatus is EquipmentStatus.Available ||
                newStatus is EquipmentStatus.InDelivery ||
                newStatus is EquipmentStatus.Unavailable ||
                newStatus is EquipmentStatus.RentedOut))
        {
            this.Status = newStatus;
            return;
        }

        // арендовано -> доступно | в доставке | недоступно
        if (oldStatus is EquipmentStatus.RentedOut && (
                newStatus is EquipmentStatus.Available ||
                newStatus is EquipmentStatus.InDelivery ||
                newStatus is EquipmentStatus.Unavailable))
        {
            this.Status = newStatus;
            return;
        }

        // в ремонте -> доступно | недоступно | выведено из эксплуатации
        if (oldStatus is EquipmentStatus.OnMaintenance && (
                newStatus is EquipmentStatus.Available ||
                newStatus is EquipmentStatus.Unavailable ||
                newStatus is EquipmentStatus.Decommissioned)) {
            this.Status = newStatus;
            return;
        }

        // в доставке -> доступно | арендовано | недоступно
        if (oldStatus is EquipmentStatus.InDelivery && (
                newStatus is EquipmentStatus.Available ||
                newStatus is EquipmentStatus.Unavailable ||
                newStatus is EquipmentStatus.RentedOut)){
            this.Status = newStatus;
            return;
        }
        // не доступно -> доступно | в ремонте | выведено из эксплуатации
        if (oldStatus is EquipmentStatus.Unavailable && (
                newStatus is EquipmentStatus.Available ||
                newStatus is EquipmentStatus.OnMaintenance ||
                newStatus is EquipmentStatus.Decommissioned)){
            this.Status = newStatus;
            return;
        }
        // выведено из эксплуатации -> X
        if (oldStatus is EquipmentStatus.Decommissioned){
            throw new ArgumentException("U cant change ur old status to this new status");
        }
        throw new ArgumentException("U cant change ur old status to this new status");
        
    }

}