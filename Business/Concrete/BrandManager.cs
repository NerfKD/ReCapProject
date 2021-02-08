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
        IBrandDal _brandDal;
       
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand entity)
        {
            _brandDal.Add(entity);
            Console.WriteLine(entity.BrandId + " numaralı marka eklendi.");
        }

        public void Delete(Brand entity)
        {
            _brandDal.Delete(entity);
            Console.WriteLine(entity.BrandId + " numaralı marka silindi.");
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int Id)
        {
            return _brandDal.Get(p => p.BrandId == Id);
        }

        public void Update(Brand entity)
        {
            _brandDal.Update(entity);
            Console.WriteLine(entity.BrandId + " numaralı marka güncellendi.");
        }
    }
}
