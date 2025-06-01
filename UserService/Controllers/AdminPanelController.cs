using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.Application.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminPanelController : ControllerBase
    {
        private IUserService _userService;
        public AdminPanelController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Get()
        {
            var result = await _userService.GetAllUsersAsync();

            return Ok(result);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _userService.GetUserByIdAsync(id);

            return Ok(result);
        }
    }
}
