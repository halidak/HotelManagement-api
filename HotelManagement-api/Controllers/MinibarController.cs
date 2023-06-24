using HotelManagement_api.Mediator.Minibar;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MinibarController : Controller
    {
        private readonly IMediator mediator;
        private readonly ILogger<MinibarController> logger;

        public MinibarController(IMediator mediator, ILogger<MinibarController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> Get()
        {
            logger.LogInformation("Get all minibars");
            try
            {
                return Ok(await mediator.Send(new GetAllMinibars()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
