using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    [ValidationAspect(typeof(MaintenanceValidator<Rental>))]
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [ValidationAspect(typeof(RentalValidator))]
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
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<Rental> GetById(int Id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == Id), Messages.RentalListed);
        }

        public IDataResult<Rental> GetLastRental(int carId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.GetLastRental(carId), Messages.RentalListed);
        }

        public IDataResult<List<RentalDto>> GetRentals()
        {
            return new SuccessDataResult<List<RentalDto>>(_rentalDal.GetRentals(), Messages.RentalsListed);
        }

        [ValidationAspect(typeof(RentalValidator))]
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
