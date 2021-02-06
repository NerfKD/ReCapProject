using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService : IBaseService <Car>
    {
        List<Car> GetCarsByBrandId(int Id);
        List<Car> GetCarsByColorId(int Id);
    }
}
