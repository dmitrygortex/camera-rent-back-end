using System.Text.Json.Serialization;
using Doomsday4.Common.Domain;
using FluentValidation;

namespace Doomsday4.Domain.Models;

public class EquipmentUnit : Entity<Guid>
{
    private EquipmentUnit()
    {
    }

    public EquipmentUnit(Guid equipmentTypeId, string serialNumber, EquipmentStatus status, string notes)
    {
        Id = Guid.NewGuid();
        EquipmentTypeId = equipmentTypeId;
        SerialNumber = serialNumber;
        if (!Enum.IsDefined(typeof(EquipmentStatus), status))
        {
            throw new ValidationException("We dont have this status. Try another");
        }
        Status = status;
        Notes = notes;
    }

    
    public EquipmentType EquipmentType { get; private set; }
    public Guid EquipmentTypeId { get; private set; }

    public string SerialNumber { get; private set; }

    public string Notes { get; private set; }
    
    public EquipmentStatus Status { get; private set; }

    public void ChangeStatus(EquipmentStatus newStatus)
    {

        if (newStatus == null)
            throw new ValidationException("U cant use null status");

        if (newStatus == Status)
            throw new ValidationException("Use different status");

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
            throw new ValidationException("U cant change ur old status to this new status");
        }
        throw new ValidationException("U cant change ur old status to this new status");
        
    }
    
}