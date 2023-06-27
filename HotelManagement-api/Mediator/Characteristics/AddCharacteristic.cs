using AutoMapper;
using HotelManagement.Contracts.Models;
using HotelManagement.Infrastructure;
using HotelManagement_api.DTOs;
using HotelManagement_api.Mediator.Minibars;
using MediatR;

namespace HotelManagement_api.Mediator.Characteristics
{
    public record AddCharacteristic(CharacteristicDto dto) : IRequest<Result<CharacteristicDto>>;
    public class  AddCharacteristicHandler : IRequestHandler<AddCharacteristic, Result<CharacteristicDto>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AddCharacteristicHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Result<CharacteristicDto>> Handle(AddCharacteristic request, CancellationToken cancellationToken)
        {
            var ch = mapper.Map<HotelManagement.Data.Models.Characteristics>(request.dto);

            unitOfWork.CharacteristicsRepository.Add(ch);
            var res = await unitOfWork.CompleteAsync();

            if (!res)
            {
                return new Result<CharacteristicDto>
                {
                    IsSuccess = false,
                    Message = "Characteristic not created"
                };
            }

            var characteristic = mapper.Map<CharacteristicDto>(ch);

            return new Result<CharacteristicDto>
            {
                IsSuccess = true,
                Data = characteristic
            };
        }
    }

}
