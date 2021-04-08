using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ServiceAdapters
{
    public interface ICreditCardService
    {
        bool ValidatePayment(RentWithCreditCard rentWithCreditCard);
    }
}
