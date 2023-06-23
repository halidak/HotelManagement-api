using MediatR;
using HotelManagement_data.Models;
using HotelManagement.Data.Models;
using HotelManagement.Infrastructure.Interfaces;
using HotelManagement.Infrastructure;
using HotelManagement_data;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement_api.Mediator.AccommodationUnits
{
    public record GetAll : IRequest<List<AccommodationUnit>>;

    public class GetAllHandler : IRequestHandler<GetAll, List<AccommodationUnit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext context;

        public GetAllHandler(IUnitOfWork unitOfWork, AppDbContext context)
        {
            _unitOfWork = unitOfWork;
            this.context = context;
        }
        public async Task<List<AccommodationUnit>> Handle(GetAll request, CancellationToken cancellationToken)
        {
            return await context.AccommodationUnits
                .Include(a => a.Prices.Where(p => p.PeriodOf <= DateTime.Now && p.PeriodTo >= DateTime.Now))
                .Include(a => a.AUnit_Characteristics)
                    .ThenInclude(ac => ac.Characteristics)
                .ToListAsync();

        }

    }
   
}
