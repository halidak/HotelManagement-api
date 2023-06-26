using HotelManagement.Data.Models;
using HotelManagement_data.Models;

namespace HotelManagement_api.DTOs
{
    public class ReservationDto
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int NumberOfPeople { get; set; }
        public int AccommodationUnitId { get; set; }
        public string UserId { get; set; }
    }
}
