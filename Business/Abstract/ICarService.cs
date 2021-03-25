using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int Id);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<CarDto>> GetCarsByBrandId(int Id);
        IDataResult<List<CarDto>> GetCarsByColorId(int Id);
        IDataResult<List<CarDto>> GetCars();
        IResult AddTransactionalTest(Car car);
    }
}
