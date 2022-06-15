using FluentValidation;
using FoodManager.Application.DTO.Users;

namespace FoodManager.Application.Validators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(e => e.Email).EmailAddress().NotEmpty().NotNull().WithMessage("{propertyName} cannot be null or empty");
            RuleFor(e => e.PhoneNumber).NotEmpty().NotNull().WithMessage("{propertyName} cannot be null or empty");
            RuleFor(e => e.FirstName).NotEmpty().NotNull().WithMessage("{propertyName} cannot be null or empty");
            RuleFor(e => e.LastName).NotEmpty().NotNull().WithMessage("{propertyName} cannot be null or empty");
            RuleFor(e => e.ConfirmEmail).Equal(e => e.Email).EmailAddress().WithMessage("Email does not match");
            RuleFor(e => e.Password).NotEmpty().NotNull().WithMessage("{propertyName} cannot be null or empty");
            RuleFor(e => e.ConfirmPassword).Equal(e => e.Password).WithMessage("Password does not match");

        }
    }
}
