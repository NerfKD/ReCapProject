using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class RentalDto :IDto
    {
        public int Id { get; set; }
        public string CarName { get; set; }
        public string FullName { get; set; }
        public DateTime RentDate { get; set; }
        public Nullable<DateTime> ReturnDate { get; set; }
    }
}
