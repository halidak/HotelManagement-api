using HotelManagement.Infrastructure;
using HotelManagement_api.Mediator.Minibar;
using HotelManagement_data;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement_api.Mediator.Minibars
{

    public record GetMinibarById(int id) : IRequest<HotelManagement.Data.Models.Minibar>;
    public class GetMinibarByIdHandler: IRequestHandler<GetMinibarById, HotelManagement.Data.Models.Minibar>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext context;
        public GetMinibarByIdHandler(IUnitOfWork unitOfWork, AppDbContext context)
        {
            _unitOfWork = unitOfWork;
            this.context = context;
        }
        public async Task<HotelManagement.Data.Models.Minibar> Handle(GetMinibarById request, CancellationToken cancellationToken)
        {
            var minibar = await context.Minibars
                .Include(minibar => minibar.Minibar_Items)
                .ThenInclude(minibarItem => minibarItem.Item)
              .FirstOrDefaultAsync(a => a.Id == request.id);

            if (minibar == null)
            {
                throw new Exception("Could not find minibar");
            }
            
            return minibar;
        }

    }
}
