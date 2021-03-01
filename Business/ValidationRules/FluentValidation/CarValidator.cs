using Business.Constants;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.DailyPrice).NotEmpty();
            RuleFor(p => p.DailyPrice).GreaterThan(5000);
            RuleFor(p => p.DailyPrice).GreaterThanOrEqualTo(100000).When(p => p.BrandId == 1);
            RuleFor(p => p.ColorId).NotEmpty();
            RuleFor(p => p.BrandId).NotEmpty();
            RuleFor(p => p.ModelYear).GreaterThanOrEqualTo(1945);
            RuleFor(p => p.ModelYear).NotEmpty();
            RuleFor(p => p.Description).MaximumLength(150);
            RuleFor(p => p.Description).Must(StartWithA).WithMessage("Tüm açıklamalar A harfi ile başlamalıdır.");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
