using HotelManagement.Infrastructure;
using HotelManagement_data.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HotelManagement_api.Mediator.Users
{
    public record GetUserById(string id) : IRequest<User>;

    public class GetUserByIdHandler : IRequestHandler<GetUserById, User>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> userManager;
        public GetUserByIdHandler(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            this.userManager = userManager;
        }
        public async Task<User> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(request.id);
            if (user == null)
            {
                throw new Exception("Could not find user");
            }
            return user;
        }
    }
    
}
