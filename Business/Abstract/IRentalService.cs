﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService : IServiceBase<Rental>
    {
        IDataResult<Rental> GetLastRental(int carId);
    }
}
