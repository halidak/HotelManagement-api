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

        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext context;
        public GetReceiptByIdHandler(IUnitOfWork unitOfWork, AppDbContext context)
        {
            _unitOfWork = unitOfWork;
            this.context = context;
        }

        public async Task<HotelManagement.Data.Models.Receipt> Handle(GetReceiptById request, CancellationToken cancellationToken)
        {
            var receipt = context.Receipts
                .Include(receipts => receipts.Reservation)
                .ThenInclude(service => service.Services_Reservations)
                .Include(receipts => receipts.Reservation)
                .ThenInclude(items => items.Minibar_Reservations)
                .FirstOrDefaultAsync(a => a.Id == request.id);

            if (receipt == null)
            {
                throw new Exception("Could not find receipt");
            }

            return await receipt;
        }

    }
}
