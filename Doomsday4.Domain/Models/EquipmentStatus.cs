namespace Doomsday4.Domain;

/// <summary>
/// Статус оборудования: 
/// 0 - доступно 
/// 1 - забронированно 
/// 2 - арендовано 
/// 3 - в ремонте 
/// 4 - недоступно 
/// 5 - в доставке
/// 6 - выведено из эксплуатации
/// </summary>
public enum EquipmentStatus
{
    //доступно
    Available = 0,
    // забронированно
    Reserved = 1,
    // арендовано
    RentedOut = 2,
    // в ремонте
    OnMaintenance = 3,
    // недоступно
    Unavailable = 4,
    // в доставке
    InDelivery = 5,
    // выведено из эксплуатации
    Decommissioned = 6
}