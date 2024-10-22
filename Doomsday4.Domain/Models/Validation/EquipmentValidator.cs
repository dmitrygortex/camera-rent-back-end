// namespace Doomsday4.Domain.Models.Validation;
//
// using FluentValidation;
//
// public class EquipmentValidator : AbstractValidator<EquipmentType>
// {
//     public EquipmentValidator()
//     {
//         
//         RuleFor(x => x.Name)
//             .NotEmpty().WithMessage("U cant use empty name")
//             .MinimumLength(2).WithMessage("Extra short name")
//             .MaximumLength(100).WithMessage("Name should be shorter than 100 characters");
//
//         RuleFor(x => x.Description)
//             .NotEmpty().WithMessage("U cant use empty description")
//             .MinimumLength(10).WithMessage("Extra short description")
//             .MaximumLength(1000).WithMessage("Description should be shorter than 1000 characters");
//
//         RuleFor(x => x.Price)
//             .GreaterThan(0).WithMessage("Price should be greater than 0");
//
//         RuleFor(x => x.Category)
//             .NotNull().WithMessage("Category is necessary in equipment");
//
//         RuleFor(x => x.Status)
//             .NotNull().WithMessage("Status is necessary in equipment")
//             .Must(IsCorrectStatus).WithMessage("We dont have this status. Try another");
//     }
//
//     private bool IsCorrectStatus(EquipmentStatus status)
//     {
//         return EquipmentStatus.IsDefined(status);
//     }
// }
