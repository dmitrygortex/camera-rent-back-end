// using FluentValidation;
//
// namespace Doomsday4.Domain.Models.Validation;
//
// public class ChangePriceValidator : AbstractValidator<(double OldPrice, double NewPrice)>
// {
//     public ChangePriceValidator()
//     {
//         RuleFor(x => x)
//             // Rider подсказывал:
//             // "Равенство при сравнении чисел с плавающей точкой.
//             // Возможна потеря точности при округлении значений"
//             // Ранее было .Must(x => x.newPrice != x.oldPrice);
//             .Must(x => Math.Abs(x.NewPrice - x.OldPrice) > 0.0001);
//         
//         RuleFor(x => x.NewPrice)
//             .GreaterThan(0).WithMessage("Price should be greater than 0");
//     }
// }
