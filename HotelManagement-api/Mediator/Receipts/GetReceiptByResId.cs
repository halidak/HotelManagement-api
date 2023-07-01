using HotelManagement.Data.Models;
using HotelManagement_data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement_api.Mediator.Receipts
{
    public record GetReceiptByResId(int id): IRequest<Receipt>;

    public class GetByIdHandler : IRequestHandler<GetReceiptByResId, Receipt>
    {
        private readonly AppDbContext context;
        public GetByIdHandler(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Receipt> Handle(GetReceiptByResId request, CancellationToken cancellationToken)
        {
            var receipt = await context.Receipts
                .Include(receipts => receipts.Reservation)
                    .ThenInclude(reservation => reservation.Services_Reservations)
                        .ThenInclude(sr => sr.Service)
                .Include(receipts => receipts.Reservation)
                    .ThenInclude(reservation => reservation.Minibar_Reservations)
                        .ThenInclude(mr => mr.Item)
                .Include(receipts => receipts.Reservation.User)
                .Include(u => u.Reservation.AccommodationUnit)
                    .ThenInclude(unit => unit.Prices)
                .FirstOrDefaultAsync(a => a.ReservationId == request.id);

            if (receipt != null)
            {
                receipt.Reservation.AccommodationUnit.Prices = await context.Prices
                    .Where(p => p.AccommodationUnitId == receipt.Reservation.AccommodationUnit.Id && p.PeriodOf <= receipt.Reservation.CheckOut && p.PeriodTo >= receipt.Reservation.CheckIn)
                    .ToListAsync();
            }

            if (receipt == null)
            {
                throw new Exception("Could not find receipt");
            }
            return receipt;
        }
    }
    
}
