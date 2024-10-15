using FluentValidation;

namespace Doomsday4.Domain.Models.Validation;

public class RenameEquipmentValidator : AbstractValidator<(string OldName, string NewName)>
{
    public RenameEquipmentValidator()
    {
        RuleFor(x => x.NewName)
            .NotEmpty().WithMessage("U cant use empty name")
            .MinimumLength(2).WithMessage("Extra short name")
            .MaximumLength(100).WithMessage("Name must be shorter than 100 characters");

        RuleFor(x => x)
            .Must(x => !x.NewName.Equals(x.OldName)).WithMessage("Use different name");
    }
}
