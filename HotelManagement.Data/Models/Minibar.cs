using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data.Models
{
    public class Minibar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Minibar_Item> Minibar_Items { get; set; }
        public List<AccommodationUnit> AccommodationUnits { get; set; }
    }
}
