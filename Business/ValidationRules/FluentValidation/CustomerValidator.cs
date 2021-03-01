using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(p => DateTime.Now.Hour).NotEqual(Maintenance.Hour).WithMessage(Messages.OperationFailed);
            RuleFor(p => p.UserId).NotEmpty();
            RuleFor(p => p.CompanyName).NotEmpty();
            RuleFor(p => p.CompanyName).MaximumLength(50);
        }
    }


}
