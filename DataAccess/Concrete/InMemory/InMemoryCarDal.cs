using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            
            _cars = new List<Car>
            {
                new Car{Id = 1, BrandId=1, ColorId=1, DailyPrice=90000,  ModelYear=2008, Description="A"},
                new Car{Id = 2, BrandId=1, ColorId=2, DailyPrice=400000, ModelYear=2015, Description="B"},
                new Car{Id = 3, BrandId=2, ColorId=2, DailyPrice=800000, ModelYear=2021, Description = "C"},
                new Car{Id = 4, BrandId=2, ColorId=3, DailyPrice=60000, ModelYear=2002, Description="D"},
                new Car{Id = 5, BrandId=3, ColorId=4, DailyPrice=35000, ModelYear=1992, Description = "E" }
            };
        }

        public void Add(Car item)
        {
            _cars.Add(item);
        }

        public void Delete(Car item)
        {
            _cars.Remove(_cars.SingleOrDefault(p => p.Id == item.Id));
        }

        public void Update(Car item)
        {
            Car carU =_cars.SingleOrDefault(p => p.Id == item.Id);
            carU.BrandId = item.BrandId;
            carU.ColorId = item.ColorId;
            carU.DailyPrice = item.DailyPrice;
            carU.ModelYear = item.ModelYear;
            carU.Description = item.Description;
        }

        public Car GetById(int itemId)
        {
            return _cars.SingleOrDefault(p => p.Id == itemId);
        }
        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDto> GetCars()
        {
            throw new NotImplementedException();
        }

        public List<CarDto> GetCarsByBrand(int brandId)
        {
            throw new NotImplementedException();
        }

        public List<CarDto> GetCarsByColor(int colorId)
        {
            throw new NotImplementedException();
        }
    }
}
