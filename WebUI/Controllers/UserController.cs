using System.Threading.Tasks;
using Application.DTOs.Account;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        // [HttpGet]
        // public async Task<IActionResult> Get()
        // {
        //     var query = await Mediator.Send(new GetAllUserQuery());
        //     return Ok(query);
        // }

        // [HttpGet("{id}")]
        // public async Task<IActionResult> Get([FromRoute] int id)
        // {
        //     var query = await Mediator.Send(new GetUserByIdQuery(id));
        //     return Ok(query);
        // }

        // POST api/<controller>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var origin = Request.Headers["origin"];
            return Ok(await _userService.RegisterAsync(request, origin));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthRequest request)
        {
            _logger.LogDebug("Login was called");
            return Ok(await _userService.AuthenticateAsync(request, GenerateIpAddress()));
        }

        [HttpGet("verify-email")]
        public async Task<IActionResult> VerifyEmail([FromQuery] string userId, string token)
        {
            return Ok(await _userService.VerifyEmailAsync(userId, token));
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            await _userService.ForgotPasswordAsync(request, Request.Headers["origin"]);
            return Ok(new {message = "Please check your email for password reset instructions"});
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest request)
        {
            return Ok(await _userService.ResetPasswordAsync(request));
        }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> Update(int id, [FromBody] UpdateShopCommand command)
        // {
        //     if (id != command.Id) return BadRequest();
        //     return Ok(await Mediator.Send(command));
        // }

        // DELETE api/<controller>/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> Delete(int id)
        // {
        //     var query = await Mediator.Send(new GetUserByIdQuery(id));
        //     return Ok(await Mediator.Send(new DeleteUserCommand(query)));
        // }

        private string GenerateIpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}