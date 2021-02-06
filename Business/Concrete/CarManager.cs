using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _iCarDal;
        List<Car> _cars;

        public CarManager(ICarDal iCarDal)
        {
            _iCarDal = iCarDal;
            _cars = iCarDal.GetAll();
        }

        public void Add(Car item)
        {

            if (item.Description.Length > 2 && item.Description != null && item.DailyPrice > 0)
            {

                _iCarDal.Add(item);
                Console.WriteLine(item.Id + " numaralı araç eklendi.");
            }
            else
            {
                Console.WriteLine(item.Id + " numaralı araç eklenemedi.");
            }
        }

        public void Delete(Car item)
        {
            bool sonuc = _cars.Where(p => p.Id == item.Id).Any();
            if (item.Description != null && item.BrandId != 0 && sonuc)
            {
                _iCarDal.Delete(item);
                Console.WriteLine(item.Id + " numaralı araç silindi.");
            }
            else
            {
                Console.WriteLine(item.Id + " numaralı araç silinemedi.");
            }
        }
        public void Update(Car item)
        {
            bool sonuc = _cars.Where(p => p.Id == item.Id).Any();
            if (item.Description != null && item.BrandId != 0 && sonuc)
            {
                _iCarDal.Update(item);
                Console.WriteLine(item.Id + " numaralı araç güncellendi.");
            }
            else
            {
                Console.WriteLine(item.Id + " numaralı araç güncellenemedi.");
            }
        }
        public List<Car> GetById(int itemId)
        {
            return _iCarDal.GetAll(p=> p.Id == itemId);
        }

        public List<Car> GetAll()
        {
            return _iCarDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int Id)
        {
            return _iCarDal.GetAll(p => p.BrandId == Id);
        }

        public List<Car> GetCarsByColorId(int Id)
        {
            return _iCarDal.GetAll(p => p.ColorId == Id);
        }
    }
}
