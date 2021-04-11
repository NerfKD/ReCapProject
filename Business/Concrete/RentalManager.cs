using Business.Abstract;
using Business.Constants;
using Business.ServiceAdapters;
using Business.ServiceAdapters.Findeks;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
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
        IUserService _userService;
        ICarService _carService;
        ICreditCardService _creditCardService;
        IFindeksService _findeksService;
        public RentalManager(IRentalDal rentalDal, ICreditCardService creditCardService, IFindeksService findeksService, IUserService userService, ICarService carService)
        {
            _rentalDal = rentalDal;
            _creditCardService = creditCardService;
            _findeksService = findeksService;
            _userService = userService;
            _carService = carService;
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental entity)
        {
            _rentalDal.Add(entity);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult RentWithCreditCard(RentWithCreditCard rentWithCreditCard)
        {
            if (_creditCardService.ValidatePayment(rentWithCreditCard))
            {
                _rentalDal.Add(rentWithCreditCard.Rental);
                return new SuccessResult(Messages.PaymentSuccess);
            }
            return new ErrorResult(Messages.PaymentUnsuccessful);
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

        public IDataResult<List<Rental>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAllByCarId(carId), Messages.RentalsListed);
        }
        public IDataResult<List<RentalDto>> GetAllDtoByCarId(int carId)
        {
            return new SuccessDataResult<List<RentalDto>>(_rentalDal.GetAllDtoByCarId(carId), Messages.RentalsListed);
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
            if (rentedCar == null)
            {
                return new ErrorResult(Messages.OperationFailed);
            }
            else
            {
                rentedCar.ReturnDate = entity.ReturnDate;
                _rentalDal.Update(rentedCar);
                return new SuccessResult(Messages.RentalUpdated);
            }
        }


        public IResult CheckRentalDate(Rental entity)
        {
            if (entity.RentDate < DateTime.Now || entity.ReturnDate < DateTime.Now)
            {
                return new ErrorResult(Messages.DateTimeNowError);
            }

            List<Rental> carRentals = _rentalDal.GetAllByCarId(entity.CarId);
            if (carRentals != null)
            {
                foreach (Rental rental in carRentals)
                {
                    if (entity.RentDate >= rental.RentDate && entity.RentDate <= rental.ReturnDate)
                    {
                        return new ErrorResult(Messages.RentDateError);
                    }
                    else if (entity.ReturnDate >= rental.RentDate && entity.ReturnDate <= rental.ReturnDate)
                    {
                        return new ErrorResult(Messages.ReturnDateError);
                    }
                }
            }
            return new SuccessResult(Messages.RentalValid);
        }

        public IResult CheckUserFindeks(Rental rental)
        {
            var car = _carService.GetById(rental.CarId).Data;
            var user = _userService.GetById(rental.CustomerId).Data;

            if (_findeksService.ValidateFindeks(car, user))
            {
                return new SuccessResult(Messages.FindeksPointPositive);
            }
            return new ErrorResult(Messages.FindeksPointNegative);
        }
    }
}
