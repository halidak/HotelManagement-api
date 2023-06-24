using MediatR;
using HotelManagement.Data.Models;
using HotelManagement.Infrastructure;

namespace HotelManagement_api.Mediator.Services
{
    public record GetAllSerives : IRequest<List<Service>>;

    public class GetAllServicesHandler : IRequestHandler<GetAllSerives, List<Service>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllServicesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Service>> Handle(GetAllSerives request, CancellationToken cancellationToken)
        {
           return await _unitOfWork.ServiceRepository.GetAll();
        }
    }
   
}
