using MediatR;
using HotelManagement.Data.Models;
using HotelManagement.Infrastructure;
using HotelManagement_data;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement_api.Mediator.Minibar
{
    public record GetAllMinibars : IRequest<List<HotelManagement.Data.Models.Minibar>>;

    public class GetAllMinibarHandler : IRequestHandler<GetAllMinibars, List<HotelManagement.Data.Models.Minibar>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext context;
        public GetAllMinibarHandler(IUnitOfWork unitOfWork, AppDbContext context)
        {
            _unitOfWork = unitOfWork;
            this.context = context;
        }
        public async Task<List<HotelManagement.Data.Models.Minibar>> Handle(GetAllMinibars request, CancellationToken cancellationToken)
        {
            var minibarsWithItems = context.Minibars
                .Include(minibar => minibar.Minibar_Items)
                .ThenInclude(minibarItem => minibarItem.Item)
                .ToList();

            return minibarsWithItems;
        }
    }
}
