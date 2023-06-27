using HotelManagement.Infrastructure;
using HotelManagement_api.Mediator.Services;
using MediatR;

namespace HotelManagement_api.Mediator.Characteristics
{
    public record DeleteCharacteristic(int id) : IRequest<Unit>;
    public class DeleteCharacteristicHandler : IRequestHandler<DeleteCharacteristic, Unit>
    {

        private readonly IUnitOfWork unitOfWork;
        public DeleteCharacteristicHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCharacteristic request, CancellationToken cancellationToken)
        {
            var characteristic = await unitOfWork.CharacteristicsRepository.GetById(request.id);
            if (characteristic == null)
            {
                throw new Exception("Characteristic does not exist");
            }
            unitOfWork.CharacteristicsRepository.Delete(characteristic);
            await unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}
