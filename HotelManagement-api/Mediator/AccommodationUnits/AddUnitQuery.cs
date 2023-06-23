using AutoMapper;
using HotelManagement.Contracts.Models;
using HotelManagement.Data.Models;
using HotelManagement.Infrastructure;
using HotelManagement_api.DTOs;
using HotelManagement_data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement_api.Mediator.AccommodationUnits
{
    public record AddUnitQuery(UnitDto dto) : IRequest<Result<UnitDto>>;

   public class AddUnitQueryHandler : IRequestHandler<AddUnitQuery, Result<UnitDto>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly AppDbContext dbContext;
        public AddUnitQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, AppDbContext dbContext)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.dbContext = dbContext;
        }
        public async Task<Result<UnitDto>> Handle(AddUnitQuery request, CancellationToken cancellationToken)
        {
            var newUnit = mapper.Map<AccommodationUnit>(request.dto);

            //var characteristics = await dbContext.Characteristics
            //.Where(c => request.dto.CharacteristicsIds.Contains(c.Id))
            //.ToListAsync();


            unitOfWork.AccommodationUnitRepository.Add(newUnit);
            var res = await unitOfWork.CompleteAsync();

            foreach (var characteristic in request.dto.CharacteristicsIds)
            {
                var uc = new AUnit_Characteristics
                {
                    AccommodationUnitId = newUnit.Id,
                    CharacteristicsId = characteristic
                };
                await dbContext.AUnit_Characteristics.AddAsync(uc);
            }
                dbContext.SaveChangesAsync();
            if (!res)
            {
                return new Result<UnitDto>
                {
                    IsSuccess = false,
                    Message = "Unit not created"
                };
            }

            // Return a success result with the created unit
            var unitDto = mapper.Map<UnitDto>(newUnit);
            return new Result<UnitDto>
            {
                IsSuccess = true,
                Data = unitDto
            };
        }

    }

}
