using HotelManagement_api.DTOs;
using HotelManagement_api.Mediator.Minibars;
using HotelManagement_api.Mediator.Receipts;
using HotelManagement_api.Mediator.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace HotelManagement_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : Controller
    {
        private readonly IMediator mediator;
        private readonly ILogger<ReceiptController> logger;

        public ReceiptController(IMediator mediator, ILogger<ReceiptController> logger)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        [HttpPost("create-receipt")]
        public async Task<IActionResult> Create([FromBody]ReceiptDto dto)
        {
            logger.LogInformation("creating receipt");
            try
            {
                return Ok(await mediator.Send(new CreateReceipt(dto)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            logger.LogInformation("all receipts");
            try
            {
                return Ok(await mediator.Send(new GetAllReceipts()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            logger.LogInformation("Get receipt by id");
            try
            {
                return Ok(await mediator.Send(new GetReceiptById(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-by-user-id/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            logger.LogInformation("Get receipt by user id");
            try
            {
                return Ok(await mediator.Send(new GetReceiptByUserId(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-items-reservations")]
        public async Task<IActionResult> Add([FromBody] Minibar_ReservationsDto dto)
        {
            logger.LogInformation("add items");
            try
            {
                return Ok(await mediator.Send(new AddItmesReservation(dto)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-by-resId/{id}")]
        public async Task<IActionResult> GetByResId(int id)
        {
            try
            {
                return Ok(await mediator.Send(new GetReceiptByResId(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
