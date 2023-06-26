using HotelManagement_api.DTOs;
using HotelManagement_api.Mediator.Minibar;
using HotelManagement_api.Mediator.Minibars;
using HotelManagement_api.Services;
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
        private readonly Minibar_ItemService service;

        public MinibarController(IMediator mediator, ILogger<MinibarController> logger, Minibar_ItemService service)
        {
            this.mediator = mediator;
            this.logger = logger;
            this.service = service;
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

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            logger.LogInformation("Get minibar by id");
            try
            {
                return Ok(await mediator.Send(new GetMinibarById(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] MinibarDto dto)
        {
            logger.LogInformation("Add minibar");
            try
            {
                return Ok(await mediator.Send(new AddMinibar(dto)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-items")]
        public async Task<IActionResult> AddItems([FromBody] Minibar_ItemDto dto)
        {
            logger.LogInformation("Add minibar items");
            try
            {
                var res = await service.Add(dto);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            logger.LogInformation("Delete minibar");
            try
            {
                return Ok(await mediator.Send(new DeleteMinibar(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-items/{minibarId}/{itemId}")]
        public async Task<IActionResult> DeleteItems(int minibarId, int itemId)
        {
            logger.LogInformation("Delete minibar items");
            try
            {
                var item = await service.DeleteMinibarItems(minibarId, itemId);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
