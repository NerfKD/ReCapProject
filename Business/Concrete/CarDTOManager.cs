using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarDTOManager : ICarDTOService
    {
        List<Car> _cars;
        List<Brand> _brands;
        List<Color> _colors;
        List<CarDTO> carDTOs;
        IBrandDal _iBrandDal;
        ICarDal _iCarDal;
        IColorDal _iColorDal;

        public CarDTOManager(IBrandDal brandDal, ICarDal carDal, IColorDal colorDal)
        {
            _iBrandDal = brandDal;
            _iCarDal = carDal;
            _iColorDal = colorDal;
            _brands = brandDal.GetAll();
            _cars = carDal.GetAll();
            _colors = colorDal.GetAll();
        }
        public List<CarDTO> GetAll()
        {
            carDTOs = (from ca in _cars
                         join b in _brands on ca.BrandId equals b.BrandId
                         join co in _colors on ca.ColorId equals co.ColorId
                         select new CarDTO { Id = ca.Id, BrandName = b.BrandName, ColorName = co.ColorName, DailyPrice = ca.DailyPrice, ModelYear = ca.ModelYear, Description = ca.Description }).ToList();
            return carDTOs;
        }
    }
}
