using AutoMapper;
using HotelManagement.Contracts.Models;
using HotelManagement.Data.Models;
using HotelManagement.Infrastructure;
using HotelManagement_api.DTOs;
using MediatR;

namespace HotelManagement_api.Mediator.Characteristics
{
    public record AddService(ServiceDto ServiceDto) : IRequest<Result<ServiceDto>>;

    public class AddServiceHandler : IRequestHandler<AddService, Result<ServiceDto>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AddServiceHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Result<ServiceDto>> Handle(AddService request, CancellationToken cancellationToken)
        {
            var newService = mapper.Map<Service>(request.ServiceDto);
            unitOfWork.ServiceRepository.Add(newService);
            var res = await unitOfWork.CompleteAsync();
            if (!res)
            {
                return new Result<ServiceDto>
                {
                    IsSuccess = false,
                    Message = "Service not created"
                };
            }
            var serviceDto = mapper.Map<ServiceDto>(newService);
            return new Result<ServiceDto>
            {
                IsSuccess = true,
                Data = serviceDto
            };
        }
    }
}
