using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    [ValidationAspect(typeof(MaintenanceValidator<CarImage>))]
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {

            _carImageDal = carImageDal;
        }
        [ValidationAspect(typeof(CarImageValidatior))]
        public IResult Add(IFormFile file, CarImage entity)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(entity.CarId));
            if (result != null)
            {
                return result;
            }
            var fileResult = FileHelper.Add(file);
            entity.ImageId = fileResult.Split(',')[1];
            entity.ImagePath = fileResult.Split(',')[0];
            entity.Date = DateTime.Now;
            _carImageDal.Add(entity);
            return new SuccessResult(Messages.CarImageAdded);
        }
        [ValidationAspect(typeof(CarImageValidatior))]
        public IResult Delete(CarImage entity)
        {
            FileHelper.Delete(entity.ImagePath);
            _carImageDal.Delete(entity);
            return new SuccessResult(Messages.CarImageDeleted);
        }
        [ValidationAspect(typeof(CarImageValidatior))]
        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarsImagesListed);
        }

        [ValidationAspect(typeof(CarImageValidatior))]
        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(carId), Messages.CarImagesListed);
        }

        [ValidationAspect(typeof(CarImageValidatior))]
        public IResult Update(IFormFile file, CarImage entity)
        {
            entity.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.Id == entity.Id).ImagePath, file);
            entity.Date = DateTime.Now;
            _carImageDal.Update(entity);
            return new SuccessResult(Messages.CarImageUpdate);
        }

        private IResult CheckImageLimitExceeded(int carId)
        {
            var carImagecount = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();
        }
        private List<CarImage> CheckIfCarImageNull(int carId)
        {
            string path = @"\wwwroot\uploads\default.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
            if (!result)
            {
                return new List<CarImage> { new CarImage { CarId = carId, ImageId = "default.jpg", ImagePath = path, Date = DateTime.Now } };
            }
            return _carImageDal.GetAll(p => p.CarId == carId);
        }
    }
}
