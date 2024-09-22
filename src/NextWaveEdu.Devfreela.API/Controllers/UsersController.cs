using Microsoft.AspNetCore.Mvc;
using NextWaveEdu.Devfreela.Application.InputModels.User;
using NextWaveEdu.Devfreela.Application.Services.Interfaces;

namespace NextWaveEdu.Devfreela.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // api/users/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var response = _userService.GetById(id);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        // api/users
        [HttpPost]
        public IActionResult Create([FromBody] CreateUserInputModel createUserModel)
        {
            var responseId = _userService.Create(createUserModel);

            return CreatedAtAction(nameof(GetById), new { id = responseId }, createUserModel);
        }

        // api/users/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUserInputModel loginUserModel)
        {
            var response = _userService.Login(loginUserModel);

            return Ok(response);
        }
    }
}
