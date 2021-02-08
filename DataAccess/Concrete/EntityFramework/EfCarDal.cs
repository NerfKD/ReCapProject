using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CBCContext>, ICarDal
    {
        public List<CarDto> GetCars()
        {

            using (CBCContext context = new CBCContext())
            {
                var result = from ca in context.Cars
                             join br in context.Brands on ca.BrandId equals br.BrandId
                             join co in context.Colors on ca.ColorId equals co.ColorId
                             select new CarDto { Id = ca.Id, BrandName = br.BrandName, ColorName = co.ColorName, DailyPrice = ca.DailyPrice};
                return result.ToList();
            }
            
        }
    }
}
