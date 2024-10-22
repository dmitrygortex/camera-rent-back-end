using System.Text.Json.Serialization;
using Doomsday4.Common.Domain;
using FluentValidation;

namespace Doomsday4.Domain.Models;

public class EquipmentType : Entity<Guid>
{
    private EquipmentType()
    {
    }

    public EquipmentType(string name, string description, double price, EquipmentCategory category)
    {
        Id = Guid.NewGuid();
        if (name == null)
        {
            throw new ValidationException("U cant use empty name");
        }
        if (name.Length < 3)
        {
            throw new ValidationException("U cant use empty nameExtra short name");
        }
        if (name.Length > 100)
        {
            throw new ValidationException("Name should be shorter than 100 characters");
        }
        Name = name;
        
        if (description == null)
        {
            throw new ValidationException("U cant use empty description");
        }
        if (description.Length < 10)
        {
            throw new ValidationException("Extra short description");
        }
        if (description.Length > 1000)
        {
            throw new ValidationException("Description should be shorter than 1000 characters");
        }
        Description = description;
        
        if (price == null)
        {
            throw new ValidationException("Price is necessary in equipment");
        }
        if (price <= 0)
        {
            throw new ValidationException("Price should be greater than 0");
        }
        Price = price;
        
        if (category == null)
        {
            throw new ValidationException("Category is necessary in equipment");
        }
        Category = category;
        
    }
    public string Name { get; private set; }

    public void Rename(string newName)
    {
        if (newName == null) 
            throw new ValidationException("U cant use empty name");
        
        switch (newName.Length)
        {
            case < 2:
                throw new ValidationException("Extra short name");
            case >= 100:
                throw new ValidationException("Name must be less than 100 characters long");
        }

        if (Name == newName)
            throw new ValidationException("Use different name");
            
        this.Name = newName;
        
    }
    public string Description { get; private set; }

    public void ChangeDescription(string newDescription)
    {
        if (newDescription == null) 
            throw new ValidationException("U cant use empty description");
        
        switch (newDescription.Length)
        {
            case < 10:
                throw new ValidationException("Extra short description");
            case >= 1000:
                throw new ValidationException("Description must be less than 1000 characters long");
        }
        
        if (Description == newDescription)
            throw new ValidationException("Use different description");
        
        
            
        this.Description = newDescription;
    }
    public double Price { get; private set; }
    
    
    public void ChangePrice(double newPrice)
    {
        if (newPrice <= 0) 
            throw new ValidationException("Price should be greater than 0");
        
        if (Math.Abs(newPrice - Price) < 0.0001)
            throw new ValidationException("Use different price");
        
        this.Price = newPrice;
    }
    public EquipmentCategory Category { get; private set; }
    
    
    public virtual ICollection<EquipmentUnit> EquipmentsUnits { get; private set; }= new List<EquipmentUnit>();

}