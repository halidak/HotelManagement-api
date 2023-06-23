using AutoMapper;
using HotelManagement.Contracts.Models;
using HotelManagement.Data.Models;
using HotelManagement.Infrastructure;
using HotelManagement_api.DTOs;
using HotelManagement_data.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HotelManagement_api.Mediator.Users
{
    public record UpdateUser(string id, UserDto dto) : IRequest<Result<User>>;


    public class UpdateUserHandler : IRequestHandler<UpdateUser, Result<User>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> userManager;
        private readonly IMapper _mapper;
        public UpdateUserHandler(IUnitOfWork unitOfWork, UserManager<User> userManager, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.userManager = userManager;
            this._mapper = mapper;
        }

        public async Task<Result<User>> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(request.id);
            if (user == null)
            {
                throw new Exception("Could not find user");
            }

            _mapper.Map(request.dto, user);
            await _unitOfWork.CompleteAsync();

            var updatedUser = _mapper.Map<User>(user);
            var result = new Result<User>
            {
                IsSuccess = true,
                Data = updatedUser
            };

            return result;

        }
    }


    
}
