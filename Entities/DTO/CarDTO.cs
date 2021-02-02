using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class CarDTO : IEntity
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public int ModelYear { get; set; }
        public double DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
