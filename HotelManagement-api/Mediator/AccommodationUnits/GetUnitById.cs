using HotelManagement.Data.Models;
using HotelManagement.Infrastructure;
using MediatR;

namespace HotelManagement_api.Mediator.AccommodationUnits
{
    public record GetUnitById(int id) : IRequest<AccommodationUnit>;

    public class GetUnitByIdHandler : IRequestHandler<GetUnitById, AccommodationUnit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetUnitByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<AccommodationUnit> Handle(GetUnitById request, CancellationToken cancellationToken)
        {
            var unit = await _unitOfWork.AccommodationUnitRepository.GetById(request.id);
            if (unit == null)
            {
                throw new Exception("Could not find unit");
            }
            return unit;
        }
    }
    
}
