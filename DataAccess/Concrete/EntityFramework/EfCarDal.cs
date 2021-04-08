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
        public CarDto GetCarById(int id)
        {
            using (CBCContext context = new CBCContext())
            {
                var result = (from ca in context.Cars
                             where ca.Id == id
                             join br in context.Brands on ca.BrandId equals br.BrandId
                             join co in context.Colors on ca.ColorId equals co.ColorId
                             select new CarDto
                             {
                                 Id = ca.Id,
                                 BrandId = ca.BrandId,
                                 BrandName = br.BrandName,
                                 ColorId = ca.ColorId,
                                 ColorName = co.ColorName,
                                 ModelYear = ca.ModelYear,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description
                             }).Single();
                return result;
            }
        }

        public List<CarDto> GetCars()
        {

            using (CBCContext context = new CBCContext())
            {
                var result = from ca in context.Cars
                             join br in context.Brands on ca.BrandId equals br.BrandId
                             join co in context.Colors on ca.ColorId equals co.ColorId
                             select new CarDto { 
                                 Id = ca.Id, 
                                 BrandId = ca.BrandId,
                                 BrandName = br.BrandName,
                                 ColorId = ca.ColorId,
                                 ColorName = co.ColorName,
                                 ModelYear = ca.ModelYear,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description
                             };
                return result.ToList();
            }

        }

        public List<CarDto> GetCarsByBrand(int brandId)
        {
            using (CBCContext context = new CBCContext())
            {
                var result = from ca in context.Cars
                             where ca.BrandId == brandId
                             join br in context.Brands on ca.BrandId equals br.BrandId 
                             join co in context.Colors on ca.ColorId equals co.ColorId
                             select new CarDto
                             {
                                 Id = ca.Id,
                                 BrandId = ca.BrandId,
                                 BrandName = br.BrandName,
                                 ColorId = ca.ColorId,
                                 ColorName = co.ColorName,
                                 ModelYear = ca.ModelYear,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description
                             };
                return result.ToList();
            }
        }

        public List<CarDto> GetCarsByColor(int colorId)
        {
            using (CBCContext context = new CBCContext())
            {
                var result = from ca in context.Cars
                             where ca.ColorId == colorId
                             join br in context.Brands on ca.BrandId equals br.BrandId
                             join co in context.Colors on ca.ColorId equals co.ColorId
                             select new CarDto
                             {
                                 Id = ca.Id,
                                 BrandId = ca.BrandId,
                                 BrandName = br.BrandName,
                                 ColorId = ca.ColorId,
                                 ColorName = co.ColorName,
                                 ModelYear = ca.ModelYear,
                                 DailyPrice = ca.DailyPrice,
                                 Description = ca.Description
                             };
                return result.ToList();
            }
        }
    }
}
