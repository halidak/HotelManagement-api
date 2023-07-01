using HotelManagement.Data.Models;
using HotelManagement_data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HotelManagement_api.Mediator.Services
{
    public record GetAllForReceipt : IRequest<List<Service>>;

    public class GetAllForReceiptHandler : IRequestHandler<GetAllForReceipt, List<Service>>
    {
        private readonly AppDbContext context;

        public GetAllForReceiptHandler(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Service>> Handle(GetAllForReceipt request, CancellationToken cancellationToken)
        {
            return await context.Services.Where(s => s.MethodOfPayment == false).ToListAsync();
        }
    }
}
