using Azure.Core;
using HotelManagement.Data.Models;
using HotelManagement.Infrastructure;
using MediatR;

namespace HotelManagement_api.Mediator.AccommodationUnits
{
    public record DeleteUnitQuery(int id) : IRequest<Unit>;

    public class DeleteUnitHandler : IRequestHandler<DeleteUnitQuery, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteUnitHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Unit> Handle(DeleteUnitQuery request, CancellationToken cancellationToken)
        {
            var unit = await _unitOfWork.AccommodationUnitRepository.GetById(request.id);
            if (unit == null)
            {
                throw new Exception("Could not find unit");
            }
            _unitOfWork.AccommodationUnitRepository.Delete(unit);
            await _unitOfWork.CompleteAsync();
            return Unit.Value;
        }
    }

}
