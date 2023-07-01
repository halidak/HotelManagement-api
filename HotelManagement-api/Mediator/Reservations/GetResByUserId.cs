using HotelManagement.Data.Models;
using HotelManagement_data;
using HotelManagement_data.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement_api.Mediator.Reservations
{
    public record GetResByUserId(string id) : IRequest<List<Reservation>>;

    public class GetResByUserIdHandler : IRequestHandler<GetResByUserId, List<Reservation>>
    {
        private readonly AppDbContext context;
        public GetResByUserIdHandler(AppDbContext context)
        {
            this.context = context; 
        }
        public async Task<List<Reservation>> Handle(GetResByUserId request, CancellationToken cancellationToken)
        {
           var list = await context.Reservations
                .Include(r => r.Services_Reservations)
                .Include(r => r.Minibar_Reservations)
                .Include(r => r.Receipts)
                .Where(r => r.UserId == request.id)
                .ToListAsync();

            return list;
        }
    }
    
}
