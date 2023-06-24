using HotelManagement_api.DTOs;
using HotelManagement_api.Mediator.Characteristics;
using HotelManagement_api.Mediator.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : Controller
    {
        private readonly IMediator mediator;
        private readonly ILogger<ServiceController> logger;

        public ServiceController(IMediator mediator, ILogger<ServiceController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            logger.LogInformation("all servises");
            try
            {
                return Ok(await mediator.Send(new GetAllSerives()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ServiceDto dto)
        {
            logger.LogInformation("add servise");
            try
            {
                return Ok(await mediator.Send(new AddService(dto)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
