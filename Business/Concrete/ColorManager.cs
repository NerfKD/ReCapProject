using Business.Abstract;
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

        public void Add(Color entity)
        {
            _colorDal.Add(entity);
            Console.WriteLine(entity.ColorId + " numaralı renk eklendi.");
        }

        public void Delete(Color entity)
        {
            _colorDal.Delete(entity);
            Console.WriteLine(entity.ColorId + " numaralı renk silindi.");
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetById(int Id)
        {
            return _colorDal.Get(p => p.ColorId == Id);
        }

        public void Update(Color entity)
        {
            _colorDal.Update(entity);
            Console.WriteLine(entity.ColorId + " numaralı renk güncellendi.");
        }
    }
}
