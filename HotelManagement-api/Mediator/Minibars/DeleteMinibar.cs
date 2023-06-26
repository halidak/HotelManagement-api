using HotelManagement.Infrastructure;
using MediatR;

namespace HotelManagement_api.Mediator.Minibars
{
    public record DeleteMinibar(int id) : IRequest<Unit>;

    public class DeleteMinibarHandler : IRequestHandler<DeleteMinibar, Unit>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteMinibarHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteMinibar request, CancellationToken cancellationToken)
        {
            var minibar = await unitOfWork.minibarRepository.GetById(request.id);
            if (minibar == null)
            {
                throw new Exception("Minibar does not exist");
            }
            unitOfWork.minibarRepository.Delete(minibar);
            await unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }

}
