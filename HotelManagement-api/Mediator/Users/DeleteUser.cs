using HotelManagement_data;
using HotelManagement_data.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HotelManagement_api.Mediator.Users
{
    public record DeleteUser(string id) : IRequest<Unit>;

    public class DeleteUserHandler : IRequestHandler<DeleteUser, Unit>
    {
        private readonly AppDbContext context;
        private readonly UserManager<User> userManager;
        public DeleteUserHandler(AppDbContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public async Task<Unit> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            var unit = await userManager.FindByIdAsync(request.id);
            if (unit == null)
            {
                throw new Exception("user not found");
            }

            await userManager.DeleteAsync(unit);

            return Unit.Value;


        }
    }

}
