using AutoMapper;
using HotelManagement.Contracts.Models;
using HotelManagement.Data.Models;
using HotelManagement_api.DTOs;
using HotelManagement_data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement_api.Mediator.Receipts
{
    public record CreateReceipt(ReceiptDto dto) : IRequest<Result<Receipt>>;

    public class CreateReceiptHandler : IRequestHandler<CreateReceipt, Result<Receipt>>
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public CreateReceiptHandler(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<Result<Receipt>> Handle(CreateReceipt request, CancellationToken cancellationToken)
        {

            var res = await context.Reservations.FirstOrDefaultAsync(r => r.Id == request.dto.ReservationId);

            if (res == null)
            {
                throw new Exception("Reservation does not exist");
            }

            var accUnit = await context.AccommodationUnits.FirstOrDefaultAsync(a => a.Id == res.AccommodationUnitId);

            if (accUnit == null)
            {
                throw new Exception("Unit does not exist");
            }

            var price = await context.Prices.FirstOrDefaultAsync(p => p.PeriodOf <= res.CheckIn && p.PeriodTo >= res.CheckOut);
            var totalPrice = price.PricePerNight * res.NumberOfPeople;

            foreach (var i in request.dto.MinibarItemsIds)
            {
                var item = await context.Items.FirstOrDefaultAsync(it => it.Id == i);

                var index = request.dto.MinibarItemsIds.IndexOf(i);
                var amount = request.dto.AmountOfItems[index];

                totalPrice = totalPrice + (decimal)item.Price * amount;

                var minibarRes = new Minibar_Reservation
                {
                    ItemId = i,
                    ReservationId = request.dto.ReservationId,
                    Amount = amount,
                };
                context.Minibar_Reservations.Add(minibarRes);
                await context.SaveChangesAsync();
            }

            var services = await context.Services_Reservations
                      .Where(s => s.ReservationId == res.Id)
                      .Select(s => s.Service)
                      .ToListAsync();

            if (services == null)
            {
                throw new Exception("Services not found");
            }

            foreach (var s in services)
            {
                if (s != null)
                {
                    totalPrice += s.Price;
                }
            }


            var receipt = new Receipt
            {
                TotalPrice = (double)totalPrice,
                ReservationId = request.dto.ReservationId
            };

            context.Receipts.Add(receipt);
            var rowsAffected = await context.SaveChangesAsync();

            if (rowsAffected == 0)
            {
                return new Result<Receipt>
                {
                    IsSuccess = false,
                    Message = "Receipt not created"
                };
            }
            return new Result<Receipt>
            {
                IsSuccess = true,
                Data = receipt
            };
        }
    }
    
}
