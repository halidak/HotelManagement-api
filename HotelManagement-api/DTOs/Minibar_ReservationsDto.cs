using HotelManagement.Data.Models;

namespace HotelManagement_api.DTOs
{
    public class Minibar_ReservationsDto
    {
        public int ReservationId { get; set; }
        public int ItemId { get; set; }
        public int Amount { get; set; }
    }
}
