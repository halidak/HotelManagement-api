using AutoMapper;
using HotelManagement.Contracts.Models;
using HotelManagement.Data.Models;
using HotelManagement.Infrastructure;
using HotelManagement_api.DTOs;
using MediatR;

namespace HotelManagement_api.Mediator.AccommodationUnits
{
    public record AddUnitQuery(UnitDto dto) : IRequest<Result<UnitDto>>;

   public class AddUnitQueryHandler : IRequestHandler<AddUnitQuery, Result<UnitDto>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public AddUnitQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result<UnitDto>> Handle(AddUnitQuery request, CancellationToken cancellationToken)
        {
            var newUnit = mapper.Map<AccommodationUnit>(request.dto);
            unitOfWork.AccommodationUnitRepository.Add(newUnit);
            var res = await unitOfWork.CompleteAsync();

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
