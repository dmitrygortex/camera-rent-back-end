namespace Doomsday4.Domain.Models;

/// <summary>
/// Статус оборудования: 
/// 0 - доступно,
/// 1 - забронированно,
/// 2 - арендовано,
/// 3 - в ремонте,
/// 4 - недоступно,
/// 5 - в доставке,
/// 6 - выведено из эксплуатации,
/// </summary>
public enum EquipmentStatus
{
    /// <summary>
    /// 0 - доступно 
    /// </summary>
    Available = 0,
    /// <summary>
    /// забронированно
    /// </summary>
    Reserved = 1,
    /// <summary>
    /// арендовано
    /// </summary>
    RentedOut = 2,
    /// <summary>
    /// в ремонте
    /// </summary>
    OnMaintenance = 3,
    /// <summary>
    /// недоступно
    /// </summary>
    Unavailable = 4,
    /// <summary>
    /// в доставке
    /// </summary>
    InDelivery = 5,
    /// <summary>
    /// выведено из эксплуатации
    /// </summary>
    Decommissioned = 6
}