using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        List<Brand> _brands;

        public InMemoryBrandDal()
        {
            _brands = new List<Brand>
            {
                new Brand{BrandId = 1, BrandName = "BMW"},
                new Brand{BrandId = 2, BrandName = "Mercedes"},
                new Brand{BrandId = 3, BrandName = "Audi"}
            };
        }
        public void Add(Brand item)
        {
            _brands.Add(item);
        }

        public void Delete(Brand item)
        {
            _brands.Remove(_brands.SingleOrDefault(p => p.BrandId == item.BrandId));
        }
        public void Update(Brand item)
        {
            Brand brandU = _brands.SingleOrDefault(p => p.BrandId == item.BrandId);
            brandU.BrandName = item.BrandName;
        }
        public Brand GetById(int itemId)
        {
            return _brands.SingleOrDefault(p => p.BrandId == itemId);
        }

        public List<Brand> GetAll()
        {
            return _brands;
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
