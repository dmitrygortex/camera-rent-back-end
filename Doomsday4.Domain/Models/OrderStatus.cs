namespace Doomsday4.Domain.Models;

// TODO: add summary documentation to this and validation like my in EquipmentUnit.cs
public enum OrderStatus
{
    Received = 0,
    Processing = 1,
    Cancelled = 2,
    OnHold = 3,
    PendingPayment = 4,
    AwaitingPickup = 5,
    Completed = 6
}