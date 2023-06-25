using AutoMapper;
using HotelManagement.Contracts.Models;
using HotelManagement.Infrastructure;
using HotelManagement_api.DTOs;
using MediatR;

namespace HotelManagement_api.Mediator.Minibars
{
    public record AddMinibar(MinibarDto dto) : IRequest<Result<MinibarDto>>;

    public class AddMinibarHanlder : IRequestHandler<AddMinibar, Result<MinibarDto>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public AddMinibarHanlder(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<Result<MinibarDto>> Handle(AddMinibar request, CancellationToken cancellationToken)
        {
            var newMinibar = mapper.Map<HotelManagement.Data.Models.Minibar>(request.dto);

            unitOfWork.minibarRepository.Add(newMinibar);
            var res = await unitOfWork.CompleteAsync();

            if (!res)
            {
                return new Result<MinibarDto>
                {
                    IsSuccess = false,
                    Message = "Unit not created"
                };
            }

            var minibar = mapper.Map<MinibarDto>(newMinibar);

            return new Result<MinibarDto>
            {
                IsSuccess = true,
                Data = minibar
            };
        }
    }
    
}
