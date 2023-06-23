using HotelManagement.Infrastructure;
using HotelManagement_data.Models;
using MediatR;

namespace HotelManagement_api.Mediator.Users
{
    public record GetAllUsers : IRequest<List<User>>;

    public class GetAllUsersHandler : IRequestHandler<GetAllUsers, List<User>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllUsersHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<User>> Handle(GetAllUsers request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.UserRepository.GetAll();
        }
    }
    
}
