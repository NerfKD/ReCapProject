using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase <Rental, CBCContext>, IRentalDal
    {
        public Rental GetLastRental(int id)
        {
            using (CBCContext context = new CBCContext())
            {
                var result = context.Set<Rental>().Where(p=> p.CarId == id).OrderByDescending(x=> x.Id).FirstOrDefault();

                return result;
            }

        }

        public List<RentalDto> GetRentals()
        {
            using (CBCContext context = new CBCContext())
            {
                var result = from re in context.Rentals
                             join cu in context.Customers on re.CustomerId equals cu.Id
                             join us in context.Users on cu.UserId equals us.Id
                             join ca in context.Cars on re.CarId equals ca.Id
                             join br in context.Brands on ca.BrandId equals br.BrandId
                             select new RentalDto
                             {
                                 Id = re.Id,
                                 CarName = br.BrandName,
                                 FullName = us.FirstName + " " + us.LastName,
                                 RentDate = re.RentDate,
                                 ReturnDate = re.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
