using HotelManagement.Data.Models;
using HotelManagement_data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HotelManagement_api.Mediator.Services
{
    public record GetAllForUnit : IRequest<List<Service>>;

    public class GetAllServicesForUnitHandler : IRequestHandler<GetAllForUnit, List<Service>>
    {
        private readonly AppDbContext context;

        public GetAllServicesForUnitHandler(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Service>> Handle(GetAllForUnit request, CancellationToken cancellationToken)
        {
            return await context.Services.Where(s => s.MethodOfPayment == true).ToListAsync();
        }
    }
}
