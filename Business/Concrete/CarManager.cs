using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car entity)
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorResult(Messages.OperationFailed);
            }
            else
            {
                _carDal.Add(entity);
                return new SuccessResult(Messages.CarAdded);
            }
        }

        public IResult Delete(Car entity)
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorResult(Messages.OperationFailed);
            }
            else
            {
                _carDal.Delete(entity);
                return new SuccessResult(Messages.CarDeleted);
            }
        }
        public IResult Update(Car entity)
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorResult(Messages.OperationFailed);
            }
            else
            {
                _carDal.Update(entity);
                return new SuccessResult(Messages.CarUpdated);
            }
        }
        public IDataResult<Car> GetById(int Id)
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorDataResult<Car>(Messages.OperationFailed);
            }
            else
            {
                return new SuccessDataResult<Car>(_carDal.Get(p => p.Id == Id), Messages.CarListed);
            }
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorDataResult<List<Car>>(Messages.OperationFailed);
            }
            else
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
            }
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int Id)
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorDataResult<List<Car>>(Messages.OperationFailed);
            }
            else
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == Id), Messages.CarsListed);
            }
        }

        public IDataResult<List<Car>> GetCarsByColorId(int Id)
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorDataResult<List<Car>>(Messages.OperationFailed);
            }
            else
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == Id), Messages.CarsListed);
            }
        }

        public IDataResult<List<CarDto>> GetCars()
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorDataResult<List<CarDto>>(Messages.OperationFailed);
            }
            else
            {
                return new SuccessDataResult<List<CarDto>>(_carDal.GetCars(), Messages.CarsListed);
            }
        }
    }
}
