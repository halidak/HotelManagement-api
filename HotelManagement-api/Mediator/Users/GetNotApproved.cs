using HotelManagement.Infrastructure;
using HotelManagement_data.Models;
using MediatR;

namespace HotelManagement_api.Mediator.Users
{
    public record GetNotApproved : IRequest<List<User>>;

    public class GetNotApprovedHanler : IRequestHandler<GetNotApproved, List<User>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetNotApprovedHanler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<User>> Handle(GetNotApproved request, CancellationToken cancellationToken)
        {
            var list = await unitOfWork.UserRepository.GetAll();
            list = list.Where(u => u.Approved == false && u.RoleId == 2)
                .ToList();
            return list;
        }
    }
}
