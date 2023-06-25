using HotelManagement_api.DTOs;
using HotelManagement_api.Mediator.Items;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : Controller
    {
        private readonly IMediator mediator;
        private readonly ILogger<ItemController> logger;

        public ItemController(IMediator mediator, ILogger<ItemController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> Get()
        {
            logger.LogInformation("Get all items");
            try
            {
                return Ok(await mediator.Send(new GetAllItems()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ItemDto dto)
        {
            logger.LogInformation("Add item");
            try
            {
                return Ok(await mediator.Send(new AddItems(dto)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
