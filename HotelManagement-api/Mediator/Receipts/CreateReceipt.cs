﻿using AutoMapper;
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

            DateTime checkInDate = res.CheckIn;
            DateTime checkOutDate = res.CheckOut;

            int numberOfDays = (int)(checkOutDate - checkInDate).TotalDays;

            var price = await context.Prices.FirstOrDefaultAsync(p => p.PeriodOf <= res.CheckIn && p.PeriodTo >= res.CheckOut && p.AccommodationUnitId == accUnit.Id);
            if (price == null)
            {
                throw new Exception("Nema cene");
            }
            var totalPrice = price.PricePerNight * res.NumberOfPeople * numberOfDays;

            var minibarItems = await context.Minibar_Reservations.Include(u => u.Item)
               .Where(m => m.ReservationId == request.dto.ReservationId)
               .ToListAsync();

            foreach (var item in minibarItems)
            {
                if (item.Item != null && item.Item.Price != null)
                {
                    totalPrice += (decimal)item.Item.Price * item.Amount;
                }
            }

            var services = await context.Services_Reservations
                      .Where(s => s.ReservationId == res.Id)
                      .Select(s => s.Service)
                      .Where(s => s.MethodOfPayment == true)
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

            var services2 = await context.Services_Reservations
                .Where(s => s.ReservationId == res.Id)
                .Select(s => new { Service = s.Service, Uses = s.Uses })
                .Where(s => s.Service.MethodOfPayment == false)
                .ToListAsync();

            if (services2 == null)
            {
                throw new Exception("Services not found");
            }

            foreach (var s in services2)
            {
                if (s.Service != null)
                {
                    totalPrice += (decimal)(s.Service.Price * s.Uses);
                }
            }



            var receipt = new Receipt
            {
                TotalPrice = (double)totalPrice,
                ReservationId = request.dto.ReservationId
            };

            context.Receipts.Add(receipt);
            res.Status = false;
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
