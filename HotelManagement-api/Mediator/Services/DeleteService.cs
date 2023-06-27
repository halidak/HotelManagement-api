using HotelManagement.Infrastructure;
using HotelManagement_api.Mediator.Items;
using MediatR;

namespace HotelManagement_api.Mediator.Services
{
    public record DeleteService(int id) : IRequest<Unit>;

    public class DeleteServiceHandler : IRequestHandler<DeleteService, Unit>
    {
        private readonly IUnitOfWork unitOfWork;
        public DeleteServiceHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteService request, CancellationToken cancellationToken)
        {
            var service = await unitOfWork.ServiceRepository.GetById(request.id);
            if (service == null)
            {
                throw new Exception("Item does not exist");
            }
            unitOfWork.ServiceRepository.Delete(service);
            await unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
