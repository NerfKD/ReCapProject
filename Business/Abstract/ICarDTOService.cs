using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarDTOService
    {
        List<CarDTO> GetAll();
    }
}
