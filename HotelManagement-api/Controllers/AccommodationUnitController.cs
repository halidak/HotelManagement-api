using HotelManagement_api.DTOs;
using HotelManagement_api.Mediator.AccommodationUnits;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccommodationUnitController : Controller
    {
        private readonly IMediator mediator;
        private readonly ILogger<AccommodationUnitController> logger;

        public AccommodationUnitController(IMediator mediator, ILogger<AccommodationUnitController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> Get([FromQuery]UnitQueryDto dto)
        {
            logger.LogInformation("Get all units");
            try
            {
                return Ok(await mediator.Send(new GetAll(dto)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] UnitDto dto)
        {
            logger.LogInformation("Add unit");
            try
            {
                return Ok(await mediator.Send(new AddUnitQuery(dto)));   
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            logger.LogInformation("Delete unit");
            try
            {
                return Ok(await mediator.Send(new DeleteUnitQuery(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            logger.LogInformation("Get unit by id");
            try
            {
                return Ok(await mediator.Send(new GetUnitById(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PutUnitDto dto)
        {
            logger.LogInformation("Update unit");
            try
            {
                return Ok(await mediator.Send(new UpdateUnitQuery(id, dto)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
