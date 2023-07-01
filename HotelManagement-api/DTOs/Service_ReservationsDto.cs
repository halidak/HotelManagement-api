using HotelManagement.Data.Models;

namespace HotelManagement_api.DTOs
{
    public class Service_ReservationsDto
    {
        public int ReservationId { get; set; }
        public int ServiceId { get; set; }
        public int? Uses { get; set; }
    }
}
