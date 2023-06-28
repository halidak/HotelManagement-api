using HotelManagement_api.DTOs;
using HotelManagement_api.Mediator.Price;
using HotelManagement_api.Services;
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
        private readonly PriceService priceService;

        public PriceController(IMediator mediator, ILogger<PriceController> logger, PriceService service)
        {
            this.mediator = mediator;
            this.logger = logger;
            priceService = service;
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

        [HttpGet("get-price/{id}")]
        public async Task<IActionResult> Get(int id, [FromQuery]DateTime checkIn)
        {
            logger.LogInformation("Get price");
            try
            {
                var price = await priceService.PriceForPeriod(id, checkIn);
                return Ok(price);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
