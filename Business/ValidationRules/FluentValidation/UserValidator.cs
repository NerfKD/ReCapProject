using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => DateTime.Now.Hour).NotEqual(Maintenance.Hour).WithMessage(Messages.OperationFailed);
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.Email).EmailAddress();
            RuleFor(p => p.Password).NotEmpty();
        }
    }
}
