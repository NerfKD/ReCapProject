using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental entity)
        {
            var rentedCar = _rentalDal.GetLastRental(entity.CarId);
            if (rentedCar != null)
            { 
                if (rentedCar.ReturnDate != null)
                {
                    _rentalDal.Add(entity);
                    return new SuccessResult(Messages.RentalAdded);
                }
                else
                {
                    return new ErrorResult(Messages.RentalFailed);
                }
                
            }
            else
            {
                _rentalDal.Add(entity);
                return new SuccessResult(Messages.RentalAdded);
            }
        }

        public IResult Delete(Rental entity)
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorResult(Messages.OperationFailed);
            }
            else
            {
                _rentalDal.Delete(entity);
                return new SuccessResult(Messages.RentalDeleted);
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorDataResult<List<Rental>>(Messages.OperationFailed);
            }
            else
            {
                return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
            }
        }

        public IDataResult<Rental> GetById(int Id)
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorDataResult<Rental>(Messages.OperationFailed);
            }
            else
            {
                return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == Id), Messages.RentalListed);
            }
        }

        public IDataResult<Rental> GetLastRental(int carId)
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorDataResult<Rental>(Messages.OperationFailed);
            }
            else
            {
                return new SuccessDataResult<Rental>(_rentalDal.GetLastRental(carId), Messages.RentalListed);
            }
        }

        public IResult Update(Rental entity)
        {
            var rentedCar = _rentalDal.GetLastRental(entity.CarId);
            if (rentedCar.ReturnDate != null && rentedCar == null)
            {
                return new ErrorResult(Messages.OperationFailed);
            }
            else
            {
                rentedCar.ReturnDate = DateTime.Now;
                _rentalDal.Update(rentedCar);
                return new SuccessResult(Messages.RentalUpdated);
            }
        }
    }
}
