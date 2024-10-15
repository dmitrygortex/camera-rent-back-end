using FluentValidation;

namespace Doomsday4.Domain.Models.Validation;

public class ChangeDescriptionValidator : AbstractValidator<(string OldDescription, string NewDescription)>
{
    public ChangeDescriptionValidator()
    {
        RuleFor(x => x)
            .Must(x => !x.NewDescription.Equals(x.OldDescription));
        
        RuleFor(x => x.NewDescription)
            .NotEmpty().WithMessage("U cant use empty description")
            .MinimumLength(10).WithMessage("Extra short description")
            .MaximumLength(1000).WithMessage("Description must be shorter than 1000 characters");
    }
}
