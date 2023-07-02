using HotelManagement.Data.Models;
using HotelManagement_data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement_api.Mediator.Reservations
{

    public record GetAllReservations() : IRequest<List<Reservation>>;
    public class GetAllReservationsHandler : IRequestHandler<GetAllReservations, List<Reservation>>
    {

        private readonly AppDbContext context;
        public GetAllReservationsHandler(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Reservation>> Handle(GetAllReservations request, CancellationToken cancellationToken)
        {
            var list = await context.Reservations
                 .Include(r => r.Services_Reservations)
                 .Include(r => r.Minibar_Reservations)
                 .Include(r => r.Receipts)
                 .Include(u => u.AccommodationUnit)
                 .ToListAsync();

            return list;
        }
    }
}
