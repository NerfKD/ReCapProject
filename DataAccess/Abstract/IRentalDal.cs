using Core.DataAccess;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {

        Rental GetLastRental(int id);
        List<RentalDto> GetRentals();
        List<Rental> GetAllByCarId(int carId);
        List<RentalDto> GetAllDtoByCarId(int carId);

    }
}
