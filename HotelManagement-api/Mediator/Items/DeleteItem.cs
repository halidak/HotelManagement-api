
using HotelManagement.Infrastructure;
using MediatR;

namespace HotelManagement_api.Mediator.Items
{

    public record DeleteItem(int id) : IRequest<Unit>;

    public class DeleteItemHandler : IRequestHandler<DeleteItem, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
   
        public DeleteItemHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteItem request, CancellationToken cancellationToken)
        {
            var item = await unitOfWork.ItemRepository.GetById(request.id);
            if (item == null)
            {
                throw new Exception("Item does not exist");
            }
            unitOfWork.ItemRepository.Delete(item);
            await unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
