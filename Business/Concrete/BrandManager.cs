using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
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

        public IResult Add(Brand entity)
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorResult(Messages.OperationFailed);
            }
            else
            {
                _brandDal.Add(entity);
                return new SuccessResult(Messages.BrandAdded);
            }
        }

        public IResult Delete(Brand entity)
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorResult(Messages.OperationFailed);
            }
            else
            {
                _brandDal.Delete(entity);
                return new SuccessResult(Messages.BrandDeleted);
            }
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorDataResult<List<Brand>>(Messages.OperationFailed);
            }
            else
            {
                return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandsListed);
            }
        }

        public IDataResult<Brand> GetById(int Id)
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorDataResult<Brand>(Messages.OperationFailed);
            }
            else
            {
                return new SuccessDataResult<Brand>(_brandDal.Get(p => p.BrandId == Id), Messages.BrandListed);
            }
        }

        public IResult Update(Brand entity)
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorResult(Messages.OperationFailed);
            }
            else
            {
                _brandDal.Update(entity);
                return new SuccessResult(Messages.BrandUpdated);
            }
        }
    }
}
