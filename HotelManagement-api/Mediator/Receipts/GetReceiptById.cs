using HotelManagement.Infrastructure;
using HotelManagement_api.Mediator.Receipts;
using HotelManagement_data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement_api.Mediator.Receipts
{
    public record GetReceiptById(int id) : IRequest<HotelManagement.Data.Models.Receipt>;
    public class GetReceiptByIdHandler : IRequestHandler<GetReceiptById, HotelManagement.Data.Models.Receipt>
    {

        private readonly AppDbContext context;
        public GetReceiptByIdHandler(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<HotelManagement.Data.Models.Receipt> Handle(GetReceiptById request, CancellationToken cancellationToken)
        {
            var receipt = await context.Receipts
                .Include(receipts => receipts.Reservation)
                    .ThenInclude(reservation => reservation.Services_Reservations)
                        .ThenInclude(sr => sr.Service)
                .Include(receipts => receipts.Reservation)
                    .ThenInclude(reservation => reservation.Minibar_Reservations)
                        .ThenInclude(mr => mr.Item)
                .Include(r => r.Reservation.AccommodationUnit)
                .FirstOrDefaultAsync(a => a.Id == request.id);

            if (receipt == null)
            {
                throw new Exception("Could not find receipt");
            }

            return receipt;
        }


    }
}
