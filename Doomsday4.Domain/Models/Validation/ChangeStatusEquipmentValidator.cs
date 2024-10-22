// namespace Doomsday4.Domain.Models.Validation;
//
// using FluentValidation;
//
// /// <summary>
// /// доступно -> забронировано | в доставке | арендовано | недоступно,
// /// забронировано -> доступно | в доставке | арендовано | недоступно,
// /// арендовано -> доступно | в доставке | недоступно,
// /// в ремонте -> доступно | недоступно | выведено из эксплуатации,
// /// в доставке -> доступно | арендовано | недоступно,
// /// не доступно -> доступно | в ремонте | выведено из эксплуатации,
// /// выведено из эксплуатации -> X
// /// </summary>
// public class ChangeStatusEquipmentValidator : AbstractValidator<(EquipmentStatus OldStatus, EquipmentStatus NewStatus)>
// {
//     public ChangeStatusEquipmentValidator()
//     {
//         RuleFor(x => x.NewStatus)
//             .NotNull().WithMessage("Status is necessary in equipment (not null)");
//         
//         RuleFor(x => x)
//             .Must(x => x.NewStatus != x.OldStatus).WithMessage("Use different status")
//             .Must(IsCorrectChangeStatus)
//             .WithMessage("U cant change ur old status to this new status");
//     }
//
//     private bool IsCorrectChangeStatus((EquipmentStatus NewStatus, EquipmentStatus OldStatus) statuses)
//     {
//         var newStatus = statuses.NewStatus;
//         var oldStatus = statuses.OldStatus;
//         // доступно -> забронировано | в доставке | арендовано | недоступно
//         if (oldStatus is EquipmentStatus.Available &&(
//             newStatus is EquipmentStatus.Reserved ||
//             newStatus is EquipmentStatus.InDelivery ||
//             newStatus is EquipmentStatus.Unavailable ||
//             newStatus is EquipmentStatus.RentedOut))
//             return true;
//         // забронировано -> доступно | в доставке | арендовано | недоступно
//         if (oldStatus is EquipmentStatus.Reserved &&(
//             newStatus is EquipmentStatus.Available ||
//             newStatus is EquipmentStatus.InDelivery ||
//             newStatus is EquipmentStatus.Unavailable ||
//             newStatus is EquipmentStatus.RentedOut))
//             return true;
//         // арендовано -> доступно | в доставке | недоступно
//         if (oldStatus is EquipmentStatus.RentedOut && (
//             newStatus is EquipmentStatus.Available ||
//             newStatus is EquipmentStatus.InDelivery ||
//             newStatus is EquipmentStatus.Unavailable))
//             return true;
//         // в ремонте -> доступно | недоступно | выведено из эксплуатации
//         if (oldStatus is EquipmentStatus.OnMaintenance && (
//             newStatus is EquipmentStatus.Available ||
//             newStatus is EquipmentStatus.Unavailable ||
//             newStatus is EquipmentStatus.Decommissioned))
//             return true;
//         // в доставке -> доступно | арендовано | недоступно
//         if (oldStatus is EquipmentStatus.InDelivery && (
//             newStatus is EquipmentStatus.Available ||
//             newStatus is EquipmentStatus.Unavailable ||
//             newStatus is EquipmentStatus.RentedOut))
//             return true;
//         // не доступно -> доступно | в ремонте | выведено из эксплуатации
//         if (oldStatus is EquipmentStatus.Unavailable && (
//             newStatus is EquipmentStatus.Available ||
//             newStatus is EquipmentStatus.OnMaintenance ||
//             newStatus is EquipmentStatus.Decommissioned))
//             return true;
//         // выведено из эксплуатации -> X
//         if (oldStatus is EquipmentStatus.Decommissioned){
//             return false;
//         }
//         return false;
//     }
// }
//
