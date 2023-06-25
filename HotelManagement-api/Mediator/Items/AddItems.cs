using AutoMapper;
using HotelManagement.Contracts.Models;
using HotelManagement.Data.Models;
using HotelManagement.Infrastructure;
using HotelManagement_api.DTOs;
using MediatR;

namespace HotelManagement_api.Mediator.Items
{
    public record AddItems(ItemDto dto) : IRequest<Result<ItemDto>>;

    public class AddItemsHandler : IRequestHandler<AddItems, Result<ItemDto>>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public AddItemsHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<ItemDto>> Handle(AddItems request, CancellationToken cancellationToken)
        {
            var newItem = mapper.Map<Item>(request.dto);

            unitOfWork.ItemRepository.Add(newItem);
            var res = await unitOfWork.CompleteAsync();
            if (!res)
            {
                return new Result<ItemDto>
                {
                    IsSuccess = false,
                    Message = "Unit not created"
                };
            }
            var itemDto = mapper.Map<ItemDto>(newItem);
            return new Result<ItemDto>
            {
                IsSuccess = true,
                Data = itemDto
            };
        }
    }

}
