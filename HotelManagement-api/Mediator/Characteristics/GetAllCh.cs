using HotelManagement.Data.Models;
using HotelManagement.Infrastructure;
using MediatR;

namespace HotelManagement_api.Mediator.Characteristics
{
    public record GetAllCh : IRequest<List<HotelManagement.Data.Models.Characteristics>>;

    public class GetAllChHandler : IRequestHandler<GetAllCh, List<HotelManagement.Data.Models.Characteristics>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllChHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<HotelManagement.Data.Models.Characteristics>> Handle(GetAllCh request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.CharacteristicsRepository.GetAll();
        }
    }
    
}
