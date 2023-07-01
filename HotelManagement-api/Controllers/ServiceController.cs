﻿using HotelManagement_api.DTOs;
using HotelManagement_api.Mediator.Characteristics;
using HotelManagement_api.Mediator.Items;
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

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            logger.LogInformation("Delete service");
            try
            {
                return Ok(await mediator.Send(new DeleteService(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("all-true")]
        public async Task<IActionResult> AllTrue()
        {
            logger.LogInformation("all true services");
            try
            {
                return Ok(await mediator.Send(new GetAllForUnit()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("all-false")]
        public async Task<IActionResult> AllFalse()
        {
            logger.LogInformation("all true services");
            try
            {
                return Ok(await mediator.Send(new GetAllForReceipt()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
