using FluentValidation;
using RoomManagement2.Api.Resources;

namespace RoomManagement2.Api.Validators
{
    public class SaveUserResourceValidator : AbstractValidator<SaveUserResource>
    {
        public SaveUserResourceValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(m => m.CompanyId)
                .NotEmpty()
                .WithMessage("'Cpmpany Id' must not be 0.");
        }
    }
}
