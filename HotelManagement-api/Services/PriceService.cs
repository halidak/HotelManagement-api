using HotelManagement.Data.Models;
using HotelManagement_data;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement_api.Services
{
    public class PriceService
    {
        private readonly AppDbContext context;

        public PriceService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Price> PriceForPeriod(int id, DateTime checkIn)
        {
            var price = await context.Prices.Include(u => u.AccommodationUnit).FirstOrDefaultAsync(p =>
        p.AccommodationUnitId == id &&
        p.PeriodOf.Date <= checkIn.Date && p.PeriodTo.Date >= checkIn.Date);

            if (price == null)
            {
                throw new Exception("Price not found for the specified period");
            }

            return price;
        }

//        public async Task<Price> PriceForPeriod(int id, string checkIn)
        //{
        //    DateTime checkInDate;
        //    if (!DateTime.TryParse(checkIn, out checkInDate))
        //    {
        //        throw new ArgumentException("Invalid checkIn date format");
        //    }

        //    var price = await context.Prices.Include(u => u.AccommodationUnit).FirstOrDefaultAsync(p =>
        //        p.AccommodationUnitId == id &&
        //        p.PeriodOf.Date <= checkInDate.Date && p.PeriodTo.Date >= checkInDate.Date);

        //    if (price == null)
        //    {
        //        throw new Exception("Price not found for the specified period");
        //    }

        //    return price;
        //}
    }
}
