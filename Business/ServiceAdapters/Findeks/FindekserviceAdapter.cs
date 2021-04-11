using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ServiceAdapters.Findeks
{
    public class FindekserviceAdapter : IFindeksService
    {
        public bool ValidateFindeks(Car car, User user)
        {
            Random random = new Random();
            int findeksPoint = 0;
            if (user.Id == 1)
            {
                findeksPoint = random.Next(1700, 1900);
            }
            else
            {
                findeksPoint = random.Next(0, 500);
            }

            if (findeksPoint >= car.FindeksPoint)
            {
                return true;
            }
            return false;

        }
    }
}
