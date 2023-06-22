using AutoMapper;
using HotelManagement.Contracts.Models;
using HotelManagement.Data.Models;
using HotelManagement.Infrastructure;
using HotelManagement_api.DTOs;
using MediatR;

namespace HotelManagement_api.Mediator.AccommodationUnits
{
    public record UpdateUnitQuery(int id, UnitDto dto) : IRequest<Result<AccommodationUnit>>;

    public class UpdateUnitHandler : IRequestHandler<UpdateUnitQuery, Result<AccommodationUnit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateUnitHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<AccommodationUnit>> Handle(UpdateUnitQuery request, CancellationToken cancellationToken)
        {
            var unit = await _unitOfWork.AccommodationUnitRepository.GetById(request.id);
            if (unit == null)
            {
                throw new Exception("Could not find unit");
            }
            _mapper.Map(request.dto, unit);
            await _unitOfWork.CompleteAsync();

            var updatedUnitDto = _mapper.Map<UnitDto>(unit);

            var result = new Result<AccommodationUnit>
            {
                IsSuccess = true,
                Data = updatedUnitDto
            };

            return result;
        }
    }
    
}
