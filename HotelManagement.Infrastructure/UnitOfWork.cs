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

        public IUserRepository UserRepository { get; }

        public ICharacteristicsRepository CharacteristicsRepository { get; }

        public IMinibarRepository minibarRepository { get; }

        public IPriceRepository PriceRepository { get; }

        public IServiceRepository ServiceRepository { get; }

        public UnitOfWork(AppDbContext context, 
            IAccommodationUnitRepository accommodationUnitRepository, 
            IUserRepository userRepository,
            ICharacteristicsRepository characteristics,
            IMinibarRepository minibarRepository,
            IPriceRepository priceRepository,
            IServiceRepository serviceRepository)
        {
            AccommodationUnitRepository = accommodationUnitRepository;
            this.context = context;
            UserRepository = userRepository;
            CharacteristicsRepository = characteristics;
            this.minibarRepository = minibarRepository;
            PriceRepository = priceRepository;
            ServiceRepository = serviceRepository;
        }


        public async Task<bool> CompleteAsync()
        {
            var result = await context.SaveChangesAsync();
            return result > 0;
        }
    }
}
