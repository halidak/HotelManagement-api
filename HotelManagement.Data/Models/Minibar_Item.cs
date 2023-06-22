using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data.Models
{
    public class Minibar_Item
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int MinibarId { get; set; }
        public Minibar Minibar { get; set; }
        public int Amount { get; set; }
    }
}
