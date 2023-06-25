using HotelManagement.Infrastructure;
using HotelManagement_data.Models;
using MediatR;

namespace HotelManagement_api.Mediator.Users
{
    public record GetAllEmployees : IRequest<List<User>>;

    public class GettAllEmployeesHanler : IRequestHandler<GetAllEmployees, List<User>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GettAllEmployeesHanler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<User>> Handle(GetAllEmployees request, CancellationToken cancellationToken)
        {
            var list = await unitOfWork.UserRepository.GetAll();
            list = list.Where(u => u.Approved == true).ToList();
            return list;
        }
    }

}
