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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color entity)
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorResult(Messages.OperationFailed);
            }
            else
            {
                _colorDal.Add(entity);
                return new SuccessResult(Messages.ColorAdded);
            }
        }

        public IResult Delete(Color entity)
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorResult(Messages.OperationFailed);
            }
            else
            {
                _colorDal.Delete(entity);
                return new SuccessResult(Messages.ColorDeleted);
            }
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorDataResult<List<Color>>(Messages.OperationFailed);
            }
            else
            {
                return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.BrandsListed);
            }
        }

        public IDataResult<Color> GetById(int Id)
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorDataResult<Color>(Messages.OperationFailed);
            }
            else
            {
                return new SuccessDataResult<Color>(_colorDal.Get(p => p.ColorId == Id),Messages.ColorsListed);
            }
        }

        public IResult Update(Color entity)
        {
            if (DateTime.Now.Hour == Maintenance.Hour)
            {
                return new ErrorResult(Messages.OperationFailed);
            }
            else
            {
                _colorDal.Update(entity);
                return new SuccessResult(Messages.ColorUpdated);
            }
        }
    }
}
