using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int Id);
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<Rental> GetLastRental(int carId);
        IDataResult<List<RentalDto>> GetRentals();
        IDataResult<List<Rental>> GetAllByCarId(int carId);
        IDataResult<List<RentalDto>> GetAllDtoByCarId(int carId);
        IResult RentWithCreditCard(RentWithCreditCard rentWithCreditCard);
        IResult CheckRentalDate(Rental rental);
        IResult CheckUserFindeks(Rental rental);
    }
}
