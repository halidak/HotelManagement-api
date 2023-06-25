using AutoMapper;
using HotelManagement_api.DTOs;
using HotelManagement_api.Mediator.AccommodationUnits;
using HotelManagement_api.Mediator.Users;
using HotelManagement_api.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly AuthService authService;
        private readonly IMediator mediator;

        public UserController(AuthService authService, IMediator mediator)
        {
            this.authService = authService;
            this.mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto user)
        {
            try
            {
                var res = await authService.Register(user);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto user)
        {
            try
            {
                var res = await authService.Login(user);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //get all users
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var res = await mediator.Send(new GetAllUsers());
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //get user by id

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                return Ok(await mediator.Send(new GetUserById(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //update user

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] UserDto dto)
        {
            try
            {
                return Ok(await mediator.Send(new UpdateUser(id, dto)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //delete user

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                return Ok(await mediator.Send(new DeleteUser(id)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("approve/{userId}")]
        public async Task<IActionResult> Approve(string userId)
        {
            try
            {
                var res = await authService.ApproveEmployee(userId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("change-password/{id}")]
        public async Task<IActionResult> ChangePassword(string id, [FromBody] ChangePasswordDto user)
        {
            try
            {
                var res = await authService.ChangePassword(id, user);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("all-approved")]
        public async Task<IActionResult> GetAllApproved()
        {
            try
            {
                var res = await mediator.Send(new GetAllEmployees());
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("all-unapproved")]
        public async Task<IActionResult> GetAllUnapproved()
        {
            try
            {
                var res = await mediator.Send(new GetNotApproved());
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
