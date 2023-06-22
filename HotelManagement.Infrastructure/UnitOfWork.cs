using HotelManagement.Infrastructure.Interfaces;
using HotelManagement_data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        public IAccommodationUnitRepository AccommodationUnitRepository { get; }

        public UnitOfWork(AppDbContext context, IAccommodationUnitRepository accommodationUnitRepository)
        {
            AccommodationUnitRepository = accommodationUnitRepository;
            this.context = context;
        }


        public async Task<bool> CompleteAsync()
        {
            var result = await context.SaveChangesAsync();
            return result > 0;
        }
    }
}
