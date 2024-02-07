using Domain.Entities;
using FluentValidation;

namespace WebApi.Validators
{
    public class ContactPhoneValidator : AbstractValidator<ContactPhone>
    {
        public ContactPhoneValidator()
        {
            RuleFor(x => x.Number).NotNull().MaximumLength(20);
            RuleFor(x => x.PhoneType).IsInEnum();
        }
    }
}
