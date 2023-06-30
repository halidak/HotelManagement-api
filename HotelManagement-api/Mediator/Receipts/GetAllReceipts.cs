using MediatR;
using HotelManagement.Data.Models;
using HotelManagement.Infrastructure;
using HotelManagement_data;
using Microsoft.EntityFrameworkCore;
using HotelManagement_api.Mediator.Minibar;

namespace HotelManagement_api.Mediator.Receipts
{
    public record GetAllReceipts : IRequest<List<HotelManagement.Data.Models.Receipt>>;

    public class GetAllReceiptsHandler : IRequestHandler<GetAllReceipts, List<HotelManagement.Data.Models.Receipt>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext context;
        public GetAllReceiptsHandler(IUnitOfWork unitOfWork, AppDbContext context)
        {
            _unitOfWork = unitOfWork;
            this.context = context;
        }

        public async Task<List<HotelManagement.Data.Models.Receipt>> Handle(GetAllReceipts request, CancellationToken cancellationToken)
        {
            var receipts = context.Receipts
                .Include(receipts => receipts.Reservation)
                .ThenInclude(service => service.Services_Reservations)
                .Include(receipts => receipts.Reservation)
                .ThenInclude(items => items.Minibar_Reservations)
                .ToList();

            return receipts;
        }
    }
}
