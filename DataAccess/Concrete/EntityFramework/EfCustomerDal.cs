using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CBCContext>, ICustomerDal
    {
        public List<CustomerDto> GetCustomers()
        {
            using (CBCContext context = new CBCContext())
            {
                var result = from cu in context.Customers
                             join us in context.Users on cu.UserId equals us.Id
                             select new CustomerDto
                             {
                                 Id = cu.Id,
                                 UserId = cu.UserId,
                                 FirstName = us.FirstName,
                                 LastName = us.LastName,
                                 CompanyName = cu.CompanyName,
                             };
                return result.ToList();
            }
        }
    }
}
