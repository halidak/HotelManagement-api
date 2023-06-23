using HotelManagement.Data.Models;
using HotelManagement.Infrastructure.Interfaces;
using HotelManagement_data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Infrastructure.Repositories
{
    public class MinibarRepository : Repository<Minibar>, IMinibarRepository
    {
        public MinibarRepository(AppDbContext context) : base(context)
        {
        }
    }
}
