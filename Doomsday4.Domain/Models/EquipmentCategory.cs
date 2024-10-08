namespace Doomsday4.Domain;

public class EquipmentCategory
{
    private Guid CategoryId { get; set; }
    private Guid? ParentCategoryId { get; set; }
    private string Name { get; set; }
    public Dictionary<string, object> Parameters { get; set; }
    
    // Cameras
    // Optics
    // Lighting
    // OperatorEquipment
    // ReadySetUps
    // ShootingAccessories
    // ExternalDevice
}