using HotelManagement_api.Mediator.Characteristics;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacteristicsController : Controller
    {
        private readonly IMediator mediator;

        public CharacteristicsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await mediator.Send(new GetAllCh()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
