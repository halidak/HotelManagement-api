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


        public AccommodationUnitController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await mediator.Send(new GetAll()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] UnitDto dto)
        {
            try
            {
                return Ok(await mediator.Send(new AddUnitQuery(dto)));   
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await mediator.Send(new DeleteUnitQuery(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
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
        public async Task<IActionResult> Update(int id, [FromBody] UnitDto dto)
        {
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
