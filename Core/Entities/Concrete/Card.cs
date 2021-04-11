using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class Card : IEntity
    {
        public int Id { get; set; }
        public string CardHoldersName { get; set; }
        public string CardNumber { get; set; }
        public int CardExpirationMonth { get; set; }
        public int CardExpirationYear { get; set; }
        public int CardCvcNumber { get; set; }
    }
}
