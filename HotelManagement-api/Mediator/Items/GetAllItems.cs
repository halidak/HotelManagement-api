using HotelManagement.Data.Models;
using HotelManagement.Infrastructure;
using MediatR;

namespace HotelManagement_api.Mediator.Items
{
    public record GetAllItems : IRequest<List<Item>>;

    public class GetAllHadler : IRequestHandler<GetAllItems, List<Item>>
    {
        private readonly IUnitOfWork unitOfWork;
        public GetAllHadler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<Item>> Handle(GetAllItems request, CancellationToken cancellationToken)
        {
            return await unitOfWork.ItemRepository.GetAll();
        }
    }
    
}
