using HotelManagement_api.DTOs;
using HotelManagement_api.Mediator.Receipts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : Controller
    {
        private readonly IMediator mediator;
        private readonly ILogger<ReceiptController> logger;

        public ReceiptController(IMediator mediator, ILogger<ReceiptController> logger)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        [HttpPost("create-receipt")]
        public async Task<IActionResult> Create([FromBody]ReceiptDto dto)
        {
            logger.LogInformation("creating receipt");
            try
            {
                return Ok(await mediator.Send(new CreateReceipt(dto)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
