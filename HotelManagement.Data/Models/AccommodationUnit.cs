using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data.Models
{
    public class AccommodationUnit
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public int Floor { get; set; }
        public string? Image { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
       
        public List<Price> Prices { get; set; }
        public List<Reservation> Reservations { get; set; }
        public int? MinibarId { get; set; }
        public Minibar Minibar { get; set; }
        public string? Description { get; set; }
        public List<AUnit_Characteristics> AUnit_Characteristics { get; set; }

    }
}
