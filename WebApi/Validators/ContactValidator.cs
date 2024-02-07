using Domain.Entities;
using FluentValidation;
using System;

namespace WebApi.Validators
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(contact => contact.Company).NotNull().MaximumLength(100);
            RuleFor(contact => contact.Email).EmailAddress().MaximumLength(100);
            RuleFor(contact => contact.Image).MaximumLength(100);
            RuleFor(contact => contact.Name).NotNull().MaximumLength(100);
            RuleFor(contact => contact.Profile).MaximumLength(100);
            RuleFor(contact => contact.Address).SetValidator(new AddressValidator());
        }
    }
}
