using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidatior : AbstractValidator<CarImage>
    {
        public CarImageValidatior()
        {
            RuleFor(p=> p.CarId).NotEmpty();
        }
    }
}
