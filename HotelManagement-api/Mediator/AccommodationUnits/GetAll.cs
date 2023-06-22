using MediatR;
using HotelManagement_data.Models;
using HotelManagement.Data.Models;
using HotelManagement.Infrastructure.Interfaces;
using HotelManagement.Infrastructure;

namespace HotelManagement_api.Mediator.AccommodationUnits
{
    public record GetAll : IRequest<List<AccommodationUnit>>;

    public class GetAllHandler : IRequestHandler<GetAll, List<AccommodationUnit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<AccommodationUnit>> Handle(GetAll request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.AccommodationUnitRepository.GetAll();
        }

    }
   
}
