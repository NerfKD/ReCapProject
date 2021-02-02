using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {
        List<Color> _colors;

        public InMemoryColorDal()
        {
            _colors = new List<Color>
            {
                new Color {ColorId = 1, ColorName = "Mavi"},
                new Color {ColorId = 2, ColorName = "Kırmızı"},
                new Color {ColorId = 3, ColorName = "Beyaz"},
                new Color {ColorId = 4, ColorName = "Metal"}
            };
        }
        public void Add(Color item)
        {
            _colors.Add(item);
        }

        public void Delete(Color item)
        {
            _colors.Remove(_colors.SingleOrDefault(p => p.ColorId == item.ColorId));
        }
        public void Update(Color item)
        {
            Color colorU = _colors.SingleOrDefault(p => p.ColorId == item.ColorId);
            colorU.ColorName = item.ColorName;
        }

        public Color GetById(int itemId)
        {
            return _colors.SingleOrDefault(p => p.ColorId == itemId);
        }

        public List<Color> GetAll()
        {
            return _colors;
        }

    }
}
