using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data.Models
{
    public class Characteristics
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AUnit_Characteristics> AUnit_Characteristics { get; set; }

    }
}
