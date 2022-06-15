using FluentValidation;
using FoodManager.Application.DTO.Users;

namespace FoodManager.Application.Validators
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            RuleFor(e => e.FirstName).NotEmpty().NotNull().WithMessage("{propertyName} cannot be null or empty");
            RuleFor(e => e.LastName).NotEmpty().NotNull().WithMessage("{propertyName} cannot be null or empty");
            RuleFor(e => e.PhoneNumber).NotEmpty().NotNull().WithMessage("{propertyName} cannot be null or empty");
            RuleFor(e => e.SmsNotification).NotEmpty().NotNull().WithMessage("{propertyName} cannot be null or empty");
            RuleFor(e => e.EmailNotification).NotEmpty().NotNull().WithMessage("{propertyName} cannot be null or empty");
            RuleFor(e => e.InAppNotification).NotEmpty().NotNull().WithMessage("{propertyName} cannot be null or empty");
            RuleFor(e => e.Id).NotEmpty().NotNull().WithMessage("{propertyName} cannot be null or empty");
            RuleFor(e => e.NewsletterSubscription).NotEmpty().NotNull().WithMessage("{propertyName} cannot be null or empty");
        }
    }
}
