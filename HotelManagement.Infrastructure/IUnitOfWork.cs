﻿using HotelManagement.Infrastructure.Interfaces;
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

        Task<bool> CompleteAsync();
    }
}
