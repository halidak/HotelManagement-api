using HotelManagement.Infrastructure;
using HotelManagement_data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HotelManagement_api.Mediator.Receipts
{
    public record GetReceiptByUserId(string id) : IRequest<List<HotelManagement.Data.Models.Receipt>>;
    public class GetReceiptByUserIdHandler : IRequestHandler<GetReceiptByUserId, List<HotelManagement.Data.Models.Receipt>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext context;
        public GetReceiptByUserIdHandler(IUnitOfWork unitOfWork, AppDbContext context)
        {
            _unitOfWork = unitOfWork;
            this.context = context;
        }

        public async Task<List<HotelManagement.Data.Models.Receipt>> Handle(GetReceiptByUserId request, CancellationToken cancellationToken)
        {
            var receipt = context.Receipts
                .Include(receipts => receipts.Reservation)
                .ThenInclude(service => service.Services_Reservations)
                .Include(receipts => receipts.Reservation)
                .ThenInclude(items => items.Minibar_Reservations)
                .Include(r => r.Reservation.AccommodationUnit)
                .ThenInclude(unit => unit.Prices)
                .Where(a => a.Reservation.UserId == request.id)
                .ToList();

            //if (receipt != null)
            //{
            //    receipt.Reservation.AccommodationUnit.Prices = await context.Prices
            //        .Where(p => p.AccommodationUnitId == receipt.Reservation.AccommodationUnit.Id && p.PeriodOf <= DateTime.Now && p.PeriodTo >= DateTime.Now)
            //        .ToListAsync();
            //}

            if (receipt == null)
            {
                throw new Exception("The user does not have receipts");
            }

            return  receipt;
        }
    }
}
