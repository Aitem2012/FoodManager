using FluentValidation;
using FoodManager.Application.DTO.Users;

namespace FoodManager.Application.Validators
{
    public class UserLoginDtoValidator : AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidator()
        {
            RuleFor(e => e.Email).EmailAddress().NotEmpty().NotNull().WithMessage("{propertyName} cannot be null or empty");
            RuleFor(e => e.Password).NotEmpty().NotNull().WithMessage("{propertyName} cannot be null or empty");
        }
    }
}
