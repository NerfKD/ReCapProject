using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car entity)
        {
            _carDal.Add(entity);
            Console.WriteLine(entity.Id + " numaralı araç eklendi.");
           
        }

        public void Delete(Car entity)
        {

            _carDal.Delete(entity);
            Console.WriteLine(entity.Id + " numaralı araç silindi.");
           
        }
        public void Update(Car entity)
        {

            _carDal.Update(entity);
            Console.WriteLine(entity.Id + " numaralı araç güncellendi.");

        }
        public Car GetById(int Id)
        {
            return _carDal.Get(p=> p.Id == Id);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int Id)
        {
            return _carDal.GetAll(p => p.BrandId == Id);
        }

        public List<Car> GetCarsByColorId(int Id)
        {
            return _carDal.GetAll(p => p.ColorId == Id);
        }

        public List<CarDto> GetCars()
        {
            return _carDal.GetCars();
        }
    }
}
