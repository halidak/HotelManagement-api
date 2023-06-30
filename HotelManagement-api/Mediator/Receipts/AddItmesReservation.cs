using HotelManagement.Contracts.Models;
using HotelManagement.Data.Models;
using HotelManagement_api.DTOs;
using HotelManagement_data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement_api.Mediator.Receipts
{
    public record AddItmesReservation(Minibar_ReservationsDto dto) : IRequest<Result<Minibar_Reservation>>;

    public class AddItemsHandler : IRequestHandler<AddItmesReservation, Result<Minibar_Reservation>>
    {
        private readonly AppDbContext context;
        public AddItemsHandler(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Result<Minibar_Reservation>> Handle(AddItmesReservation request, CancellationToken cancellationToken)
        {
            var res = await context.Reservations.FirstOrDefaultAsync(r => r.Id == request.dto.ReservationId);
            if (res == null)
            {
                throw new Exception("res  not found");
            }

            var item = await context.Items.FirstOrDefaultAsync(i => i.Id == request.dto.ItemId);
            if (item == null)
            {
                throw new Exception("item  not found");
            }

            var minibarRes = new Minibar_Reservation
            {
                ItemId = request.dto.ItemId,
                ReservationId = request.dto.ReservationId,
                Amount = request.dto.Amount,
            };

            context.Minibar_Reservations.Add(minibarRes);
            var rowsAffected = await context.SaveChangesAsync();
            if (rowsAffected == 0)
            {
                return new Result<Minibar_Reservation>
                {
                    IsSuccess = false,
                    Message = "Receipt not created"
                };
            }
            return new Result<Minibar_Reservation>
            {
                IsSuccess = true,
                Data = minibarRes
            };
        }
    }
    
}
