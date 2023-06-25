using AutoMapper;
using HotelManagement.Contracts.Models;
using HotelManagement.Data.Models;
using HotelManagement_api.DTOs;
using HotelManagement_data;

namespace HotelManagement_api.Services
{
    public class Minibar_ItemService
    {
        private readonly IMapper mapper;
        private readonly AppDbContext context;

        public Minibar_ItemService(IMapper mapper, AppDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<Minibar_Item> Add(Minibar_ItemDto request)
        {
            var minibar = context.Minibars.FirstOrDefault(m => m.Id == request.MinibarId);
            if (minibar == null)
            {
                throw new Exception("Could not find minibar");
            }

            var item = context.Items.FirstOrDefault(i => i.Id == request.ItemId);
            if (item == null)
            {
                throw new Exception("Could not find item");
            }

            var newItem = new Minibar_Item
            {
                MinibarId = request.MinibarId,
                ItemId = request.ItemId,
                Amount = request.Amount
            };

            context.Minibar_Items.Add(newItem);
            await context.SaveChangesAsync();

            return newItem;

        }
    }
}
