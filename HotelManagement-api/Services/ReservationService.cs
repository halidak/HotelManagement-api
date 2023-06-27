using AutoMapper;
using HotelManagement.Data.Models;
using HotelManagement_api.DTOs;
using HotelManagement_data;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement_api.Services
{
    public class ReservationService
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public ReservationService(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Reservation> ReservationRequest(ReservationDto dto)
        {
            var accUnit = await context.AccommodationUnits.FirstOrDefaultAsync(a => a.Id == dto.AccommodationUnitId);

            if (accUnit == null)
            {
                throw new Exception("Unit does not exist");
            }

            if (dto.NumberOfPeople > accUnit.Capacity)
            {
                throw new Exception("Can't make a reservation number");
            }

            var overlappingReservation = await context.Reservations
             .Where(r =>
                 r.AccommodationUnitId == dto.AccommodationUnitId &&
                 r.Status &&
                 !(r.CheckOut < dto.CheckIn || r.CheckIn > dto.CheckOut)).ToListAsync();


            if (overlappingReservation.Count == 0)
            {
                var reservation = mapper.Map<Reservation>(dto);
                reservation.Status = false;
                context.Reservations.Add(reservation);
                await context.SaveChangesAsync();

                var services = dto.ServiceIds;

                foreach (var s in services)
                {
                    var rs = new Services_Reservation
                    {
                        ReservationId = reservation.Id,
                        ServiceId = s
                    };

                    context.Services_Reservations.Add(rs);
                }

                await context.SaveChangesAsync();

                return reservation;
            }
            else
            {
                throw new Exception("Can't make a reservation");
            }
        }

        public async Task<Reservation> CancelReservation(int id)
        {
            var res = await context.Reservations.FirstOrDefaultAsync(r => r.Id == id);
            if (res == null)
            {
                throw new Exception("reservation does not exist");
            }

            context.Reservations.Remove(res);
            await context.SaveChangesAsync();

            return res;
        }

        public async Task<Reservation> AcceptReservation(int id)
        {
            var res = await context.Reservations.FirstOrDefaultAsync(r => r.Id == id);
            if (res == null)
            {
                throw new Exception("reservation does not exist");
            }

            res.Status = true;
            await context.SaveChangesAsync();

            return res;
        }

        public async Task<List<Reservation>> GetAllApproved() 
        {
            var res = await context.Reservations.Where(r => r.Status == true).ToListAsync();
            return res;
        }

        public async Task<List<Reservation>> GetNotApproved()
        {
            var res = await context.Reservations.Where(r => r.Status == false).ToListAsync();
            return res;
        }

        public async Task<List<string>> GetUnitReservationDates(int id)
        {
            var res = await context.Reservations.Where(r => r.AccommodationUnitId == id).ToListAsync();

            var reservationDates = res.SelectMany(r =>
                Enumerable.Range(0, (int)(r.CheckOut - r.CheckIn).TotalDays + 1)
                    .Select(offset => r.CheckIn.AddDays(offset).Date.ToString("yyyy-MM-dd"))) // Formatiranje datuma kao "yyyy-MM-dd"
                    .ToList();

            return reservationDates;
        }


        public async Task<List<ReservationDateRange>> GetUnitReservationDates2(int id)
        {
            var reservations = await context.Reservations
        .Where(r => r.AccommodationUnitId == id)
        .ToListAsync();

            var reservationDateRanges = reservations.Select(r => new ReservationDateRange
            {
                CheckIn = r.CheckIn,
                CheckOut = r.CheckOut
            }).ToList();

            return reservationDateRanges;
        }
    }
}
