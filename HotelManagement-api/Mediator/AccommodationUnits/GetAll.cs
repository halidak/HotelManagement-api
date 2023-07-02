using MediatR;
using HotelManagement_data.Models;
using HotelManagement.Data.Models;
using HotelManagement.Infrastructure.Interfaces;
using HotelManagement.Infrastructure;
using HotelManagement_data;
using Microsoft.EntityFrameworkCore;
using HotelManagement_api.DTOs;
using System.Linq;
using System.Linq.Expressions;
using HotelManagement_api.Extensions;

namespace HotelManagement_api.Mediator.AccommodationUnits
{
    public record GetAll(UnitQueryDto dto) : IRequest<QueryResultsDTO<AccommodationUnit>>;

    public class GetAllHandler : IRequestHandler<GetAll, QueryResultsDTO<AccommodationUnit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext context;

        public GetAllHandler(IUnitOfWork unitOfWork, AppDbContext context)
        {
            _unitOfWork = unitOfWork;
            this.context = context;
        }

        public async Task<QueryResultsDTO<AccommodationUnit>> Handle(GetAll request, CancellationToken cancellationToken)
        {
            var query = context.AccommodationUnits
                .Include(r => r.Reservations)
                .Include(a => a.Prices.Where(p => p.PeriodOf <= DateTime.Now && p.PeriodTo >= DateTime.Now))
                .Include(a => a.AUnit_Characteristics)
                    .ThenInclude(ac => ac.Characteristics)
                .AsQueryable();

            if (request.dto.Floor.HasValue)
            {
                query = query.Where(a => a.Floor == request.dto.Floor.Value);
            }

            if (request.dto.NumberOfPeople.HasValue)
            {
                query = query.Where(a => a.Capacity >= request.dto.NumberOfPeople.Value);
            }

            if (request.dto.PeriodOf.HasValue && request.dto.PeriodTo.HasValue)
            {
                DateTime periodOf = request.dto.PeriodOf.Value.Date;
                DateTime periodTo = request.dto.PeriodTo.Value.Date;

                query = query.Where(a => a.Reservations.All(r =>
                    periodOf >= r.CheckOut.Date || periodTo <= r.CheckIn.Date));
            }

            var sortColumns = new Dictionary<string, Expression<Func<AccommodationUnit, object>>>()
            {
                ["Price"] = c => c.Prices.Min(p => p.PricePerNight)
            };

            Expression<Func<AccommodationUnit, object>> selectedColumn = null;
            if (!string.IsNullOrEmpty(request.dto.SortBy) && sortColumns.ContainsKey(request.dto.SortBy))
            {
                selectedColumn = sortColumns[request.dto.SortBy];
            }

            request.dto.PageSize = 2;

            query = query.ApplySorting(request.dto, sortColumns);
            query = query.ApplyPaging(request.dto);

            var list = await query.ToListAsync();

            QueryResultsDTO<AccommodationUnit> result = new QueryResultsDTO<AccommodationUnit>
            {
                TotalItems = list.Count,
                Items = list
            };

            return result;
        }
    }
}
