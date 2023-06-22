using HotelManagement_data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int NumberOfPeople { get; set; }
        public int AccommodationUnitId { get; set; }
        public AccommodationUnit AccommodationUnit { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public bool Status { get; set; }
        public List<Services_Reservation> Services_Reservations { get; set; }
        public List<Receipt> Receipts { get; set; }
        public List<Minibar_Reservation> Minibar_Reservations { get; set; }

    }
}
