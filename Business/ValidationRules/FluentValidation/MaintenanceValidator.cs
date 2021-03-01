using Business.Constants;
using Core.Entities;
using FluentValidation;
using System;

namespace Business.ValidationRules.FluentValidation
{
    public class MaintenanceValidator<T> : AbstractValidator<T>
    {
        public MaintenanceValidator()
        {
            RuleFor(p => DateTime.Now.Hour).NotEqual(Maintenance.Hour).WithMessage(Messages.OperationFailed);
        }
    }

}
