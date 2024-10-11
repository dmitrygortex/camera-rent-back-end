using Doomsday4.Common.Domain;

namespace Doomsday4.Domain.Models;

public class EquipmentCategory : ValueObject
{
    
    public EquipmentCategory() { }
    public EquipmentCategory(Guid categoryId, Guid? parentCategoryId, string name, Dictionary<string, object> parameters)
    {
        CategoryId = categoryId;
        ParentCategoryId = parentCategoryId;
        Name = name;
        Parameters = parameters;
    }

    public Guid CategoryId { get; set; }
    public Guid? ParentCategoryId { get; set; }
    public string Name { get; set; }
    public Dictionary<string, object> Parameters = new Dictionary<string, object>();
    
    // Cameras
    // Optics
    // Lighting
    // OperatorEquipment
    // ReadySetUps
    // ShootingAccessories
    // ExternalDevice
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return CategoryId;
        yield return ParentCategoryId;
        yield return Name;
        yield return Parameters;
    }
}