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

        public PriceController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("add-price")]
        public async Task<IActionResult> Add([FromBody] PriceDto dto)
        {
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
