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
        IBrandDal _iBrandDal;
        List<Brand> _brands;
        List<Car> _cars;

        public CarManager(ICarDal iCarDal, IBrandDal ibrandDal)
        {
            _iCarDal = iCarDal;
            _iBrandDal = ibrandDal;
            _brands = _iBrandDal.GetAll();
            _cars = iCarDal.GetAll();
        }

        public void Add(Car item)
        {

            if (item.Description != null && item.BrandId != 0)
            {
                string brandI = _brands.FirstOrDefault(p => p.BrandId == item.BrandId).BrandName;

                _iCarDal.Add(item);
                Console.WriteLine(brandI + " marka " + item.Id + " numaralı araç eklendi.");
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
        public Car GetById(int itemId)
        {
            return _iCarDal.GetById(itemId);
        }

        public List<Car> GetAll()
        {
            return _iCarDal.GetAll();
        }

    }
}
