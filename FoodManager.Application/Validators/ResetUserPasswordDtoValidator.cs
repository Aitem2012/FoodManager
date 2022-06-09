using FluentValidation;
using FoodManager.Application.DTO.Users;

namespace FoodManager.Application.Validators
{
    public class ResetUserPasswordDtoValidator : AbstractValidator<ResetUserPasswordDto>
    {
        public ResetUserPasswordDtoValidator()
        {
            RuleFor(e => e.Email).EmailAddress().NotEmpty().NotNull().WithMessage("{propertyName} cannot be null or empty");
            RuleFor(e => e.Password).NotEmpty().NotNull().WithMessage("{propertyName} cannot be null or empty");
            RuleFor(e => e.ConfirmPassword).Equal(e => e.Password).WithMessage("Password does not match");
            RuleFor(e => e.Token).NotEmpty().NotNull().WithMessage("{propertyName} cannot be null or empty");
        }
    }
}
