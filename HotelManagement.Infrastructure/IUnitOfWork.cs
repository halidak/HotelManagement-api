using HotelManagement.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Infrastructure
{
    public interface IUnitOfWork
    {
        IAccommodationUnitRepository AccommodationUnitRepository { get; }
        IUserRepository UserRepository { get; }
        ICharacteristicsRepository CharacteristicsRepository { get; }
        IMinibarRepository minibarRepository { get; }
        IPriceRepository PriceRepository { get; }
        IServiceRepository ServiceRepository { get; }

        Task<bool> CompleteAsync();
    }
}
