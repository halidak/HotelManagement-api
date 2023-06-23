using HotelManagement.Data.Models;

namespace HotelManagement_api.DTOs
{
    public class PriceDto
    {
        public int AccommodationUnitId { get; set; }
        public DateTime PeriodOf { get; set; }
        public DateTime PeriodTo { get; set; }
        public decimal PricePerNight { get; set; }
        public decimal PricePerPerson { get; set; }
    }
}
