using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data.Models
{
    public class AUnit_Characteristics
    {
        public int Id { get; set; }
        public int AccommodationUnitId { get; set; }
        public AccommodationUnit AccommodationUnit { get; set; }
        public int CharacteristicsId { get; set; }
        public Characteristics Characteristics { get; set; }
    }
}
