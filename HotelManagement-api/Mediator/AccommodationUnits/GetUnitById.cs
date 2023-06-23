﻿using HotelManagement.Data.Models;
using HotelManagement.Infrastructure;
using HotelManagement_data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement_api.Mediator.AccommodationUnits
{
    public record GetUnitById(int id) : IRequest<AccommodationUnit>;

    public class GetUnitByIdHandler : IRequestHandler<GetUnitById, AccommodationUnit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext context;
        public GetUnitByIdHandler(IUnitOfWork unitOfWork, AppDbContext context)
        {
            _unitOfWork = unitOfWork;
            this.context = context;
        }
        public async Task<AccommodationUnit> Handle(GetUnitById request, CancellationToken cancellationToken)
        {
            var unit = await context.AccommodationUnits.Include(a => a.Prices.Where(p => p.PeriodOf <= DateTime.Now || p.PeriodTo >= DateTime.Now)).Include(a => a.AUnit_Characteristics)
                 .ThenInclude(ac => ac.Characteristics).FirstOrDefaultAsync(a => a.Id == request.id);
            if (unit == null)
            {
                throw new Exception("Could not find unit");
            }
            return unit;
        }
    }
    
}
