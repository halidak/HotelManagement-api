using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data.Models
{
    public class Price
    {
        public int Id { get; set; }
        public int AccommodationUnitId { get; set; }
        public AccommodationUnit AccommodationUnit { get; set; }
        public DateTime PeriodOf { get; set; }
        public DateTime PeriodTo { get; set; }
        public decimal PricePerNight { get; set; }
        public decimal PricePerPerson { get; set; }
    }
}
