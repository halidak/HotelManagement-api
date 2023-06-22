using HotelManagement.Data.Models;

namespace HotelManagement_api.DTOs
{
    public class UnitDto
    {
        public int Capacity { get; set; }
        public int Floor { get; set; }
        public string? Image { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int CharacteristicsId { get; set; }
        public int MinibarId { get; set; }
    }
}
