namespace Doomsday4.Domain;

public enum EquipmentStatus
{
    //доступно
    Available = 0,
    // забронированно
    Reserved = 1,
    // арендовано
    RentedOut = 3,
    // в ремонте
    OnMaintenance = 4,
    // недоступно
    Unavailable = 5,
    // в доставке
    InDelivery = 6,
    // выведено из эксплуатации
    Decommissioned = 7
}