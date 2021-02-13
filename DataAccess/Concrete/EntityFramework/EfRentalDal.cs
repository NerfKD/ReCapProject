using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
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
    }
}
