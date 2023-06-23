using AutoMapper;
using HotelManagement.Contracts.Models;
using HotelManagement.Data.Models;
using HotelManagement.Infrastructure;
using HotelManagement_api.DTOs;
using MediatR;

namespace HotelManagement_api.Mediator.Price
{
    public record AddPrice(PriceDto dto) : IRequest<Result<PriceDto>>;

    public class AddPriceHandler : IRequestHandler<AddPrice, Result<PriceDto>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AddPriceHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<PriceDto>> Handle(AddPrice request, CancellationToken cancellationToken)
        {
            var newPrice = mapper.Map< HotelManagement.Data.Models.Price >(request.dto);
            unitOfWork.PriceRepository.Add(newPrice);

            var res = await unitOfWork.CompleteAsync();

            if (!res)
            {
                return new Result<PriceDto>
                {
                    IsSuccess = false,
                    Message = "Unit not created"
                };
            }

            var priceDto = mapper.Map<PriceDto>(newPrice);
            return new Result<PriceDto>
            {
                IsSuccess = true,
                Data = priceDto
            };
        }
    }
}
