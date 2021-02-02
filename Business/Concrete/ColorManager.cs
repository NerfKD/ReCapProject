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
        IColorDal _iColorDal;
        List<Color> _colors;

        public ColorManager(IColorDal iColorDal)
        {
            _iColorDal = iColorDal;
            _colors = _iColorDal.GetAll();
        }

        public void Add(Color item)
        {
            if (item.ColorName != null)
            {
                _iColorDal.Add(item);
                Console.WriteLine(item.ColorId + " numaralı renk eklendi.");
            }
            else
            {
                Console.WriteLine(item.ColorId + " numaralı renk eklenemedi.");
            }
        }

        public void Delete(Color item)
        {
            bool sonuc = _colors.Where(p => p.ColorId == item.ColorId).Any();
            if (sonuc && item.ColorName != null)
            {
                _iColorDal.Delete(item);
                Console.WriteLine(item.ColorId + " numaralı renk silindi.");
            }
            else
            {
                Console.WriteLine(item.ColorId + " numaralı renk silinemedi.");
            }
        }


        public void Update(Color item)
        {
            bool sonuc = _colors.Where(p => p.ColorId == item.ColorId).Any();
            if (sonuc && item.ColorName != null)
            {
                _iColorDal.Update(item);
                Console.WriteLine(item.ColorId + " numaralı renk güncellendi.");
            }
            else
            {
                Console.WriteLine(item.ColorId + " numaralı renk güncellenemedi.");
            }
        }
        public Color GetById(int itemId)
        {
            return _iColorDal.GetById(itemId);
        }

        public List<Color> GetAll()
        {
            return _iColorDal.GetAll();
        }

    }
}
