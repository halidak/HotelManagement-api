using HotelManagement_api.DTOs;
using HotelManagement_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : Controller
    {
        private readonly ReservationService service;
        private readonly ILogger<ReservationController> logger;

        public ReservationController(ReservationService service, ILogger<ReservationController> logger)
        {
            this.logger = logger;
            this.service = service;
        }

        [HttpPost("request-reservation")]
        public async Task<IActionResult> RequestReservation([FromBody]ReservationDto dto)
        {
            logger.LogInformation("request for reservation");
            try
            {
                var res = await service.ReservationRequest(dto);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("accept/{id}")]
        public async Task<IActionResult> Accept(int id)
        {
            logger.LogInformation("accept reservation");
            try
            {
                var res = await service.AcceptReservation(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            logger.LogInformation("get reservation by id");
            try
            {
                var res = await service.ReservationById(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("approved")]
        public async Task<IActionResult> GetAllAproved()
        {
            logger.LogInformation("all approved reservations");
            try
            {
                var res = await service.GetAllApproved();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("not-approved")]
        public async Task<IActionResult> GetNotAproved()
        {
            logger.LogInformation("all not approved reservations");
            try
            {
                var res = await service.GetNotApproved();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("without-receipts")]
        public async Task<IActionResult> GetWithoutReceipt()
        {
            logger.LogInformation("all approved reservations without receipts");
            try
            {
                var res = await service.GetWithoutReceipt();
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
            logger.LogInformation("cancel reservation");
            try
            {
                var res = await service.CancelReservation(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("dates/{id}")]
        public async Task<IActionResult> Dates(int id)
        {
            logger.LogInformation("get dates");
            try
            {
                var res = await service.GetUnitReservationDates(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("date-range/{id}")]
        public async Task<IActionResult> Dates2(int id)
        {
            logger.LogInformation("get dates");
            try
            {
                var res = await service.GetUnitReservationDates2(id);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
