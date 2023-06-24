using HotelManagement_api.DTOs;
using HotelManagement_api.Mediator.Price;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : Controller
    {
        private readonly IMediator mediator;
        private readonly ILogger<PriceController> logger;

        public PriceController(IMediator mediator, ILogger<PriceController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;

        }

        [HttpPost("add-price")]
        public async Task<IActionResult> Add([FromBody] PriceDto dto)
        {
            logger.LogInformation("Add price");
            try
            {
                return Ok(await mediator.Send(new AddPrice(dto)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
