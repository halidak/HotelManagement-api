using HotelManagement.Data.Models;

namespace HotelManagement_api.DTOs
{
    public class ReceiptDto
    {
        public int ReservationId { get; set; }
        public List<int>? MinibarItemsIds { get; set; }
        public List<int>? AmountOfItems { get; set; }
    }
}
