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
        private readonly ILogger<CharacteristicsController> logger;

        public CharacteristicsController(IMediator mediator, ILogger<CharacteristicsController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> Get()
        {
            logger.LogInformation("Get all characteristics");
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
