using HotelManagement.Data.Models;

namespace HotelManagement_api.DTOs
{
    public class PutUnitDto
    {
        public int Capacity { get; set; }
        public int Floor { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
