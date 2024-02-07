using Domain.Entities;
using FluentValidation;

namespace WebApi.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.City).NotNull().MaximumLength(100);
            RuleFor(x => x.State).NotNull().MaximumLength(100);
            RuleFor(x => x.Street).NotNull().MaximumLength(200);
            RuleFor(x => x.ZipCode).NotNull().MaximumLength(10);
            RuleFor(x => x.Country).NotNull().MaximumLength(100);
        }
    }
}
