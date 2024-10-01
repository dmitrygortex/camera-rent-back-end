using Doomsday4.Common.Domain;

namespace Doomsday4.Domain;

public class Equipment : Entity<Guid>
{
    public Equipment()
    {
    }

    public Equipment(string name, string description, double price, EquipmentCategory category, EquipmentSubCategory subCategory, EquipmentStatus status)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Price = price;
        Category = category;
        Status = status;
        SubCategory = subCategory;
    }
    
    public string Name { get; private set; }
    public string Description { get; private set; }
    public double Price { get; private set; }
    public EquipmentCategory Category { get; private set; }
    public EquipmentSubCategory SubCategory { get; private set; }

    public EquipmentStatus Status { get; private set; }
    

}