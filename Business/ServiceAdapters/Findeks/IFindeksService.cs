using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ServiceAdapters.Findeks
{
    public interface IFindeksService
    {
        bool ValidateFindeks(Car car, User user);
    }
}
