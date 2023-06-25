using HotelManagement.Data.Models;

namespace HotelManagement_api.DTOs
{
    public class Minibar_ItemDto
    {
        public int ItemId { get; set; }
        public int MinibarId { get; set; }
        public int Amount { get; set; }
    }
}
