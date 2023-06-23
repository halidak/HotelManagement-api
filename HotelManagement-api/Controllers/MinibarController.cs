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

        public MinibarController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> Get()
        {
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
