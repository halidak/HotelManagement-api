using HotelManagement_api.DTOs;
using HotelManagement_api.Mediator.Characteristics;
using HotelManagement_api.Mediator.Minibars;
using HotelManagement_api.Mediator.Services;
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

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            logger.LogInformation("Delete characteristic");
            try
            {
                return Ok(await mediator.Send(new DeleteCharacteristic(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CharacteristicDto dto)
        {
            logger.LogInformation("Add characteristic");
            try
            {
                return Ok(await mediator.Send(new AddCharacteristic(dto)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
