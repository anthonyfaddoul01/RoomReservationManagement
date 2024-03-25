using FluentValidation;
using RoomManagement2.Api.Resources;

namespace RoomManagement2.Api.Validators
{
    public class SaveCompanyResourceValidator : AbstractValidator<SaveCompanyResource>
    {
        public SaveCompanyResourceValidator()
        {
            RuleFor(a => a.Name)
            .NotEmpty()
            .MaximumLength(50);

            RuleFor(a => a.Description)
                .MaximumLength(500); 

            RuleFor(a => a.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(100); 

            RuleFor(a => a.Status)
                .NotEmpty()
                .MaximumLength(20);
        }
    }
}
