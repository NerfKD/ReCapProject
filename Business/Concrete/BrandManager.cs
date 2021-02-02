using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _iBrandDal;
        List<Brand> _brands;
        public BrandManager(IBrandDal brandDal)
        {
            _iBrandDal = brandDal;
            _brands = _iBrandDal.GetAll();
        }

        public void Add(Brand item)
        {
            if (item.BrandName != null)
            {
                _iBrandDal.Add(item);
                Console.WriteLine(item.BrandId + " numaralı marka eklendi.");
            }
            else
            {
                Console.WriteLine(item.BrandId + " numaralı marka eklenemedi.");
            }
        }

        public void Delete(Brand item)
        {
            bool sonuc = _brands.Where(p => p.BrandId == item.BrandId).Any();
            if (sonuc && item.BrandName != null)
            {
                _iBrandDal.Delete(item);
                Console.WriteLine(item.BrandId + " numaralı marka silindi.");
            }
            else
            {
                Console.WriteLine(item.BrandId + " numaralı marka silinemedi.");
            }
        }
        public void Update(Brand item)
        {
            bool sonuc = _brands.Where(p => p.BrandId == item.BrandId).Any();
            if (sonuc && item.BrandName != null)
            {
                _iBrandDal.Add(item);
                Console.WriteLine(item.BrandId + " numaralı marka güncellendi.");
            }
            else
            {
                Console.WriteLine(item.BrandId + " numaralı marka güncellemenedi.");
            }
        }
        public Brand GetById(int itemId)
        {
            return _iBrandDal.GetById(itemId);
        }
        public List<Brand> GetAll()
        {
            return _iBrandDal.GetAll();
        }




    }
}
