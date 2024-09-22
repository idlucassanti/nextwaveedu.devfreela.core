using Microsoft.AspNetCore.Mvc;
using NextWaveEdu.Devfreela.Application.InputModels.User;

namespace NextWaveEdu.Devfreela.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // api/users/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //return NotFound();

            return Ok();
        }

        // api/users
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserInputModel createUserModel)
        {
            return CreatedAtAction(nameof(GetById), new { id = createUserModel.Id }, createUserModel);
        }

        // api/users/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUserInputModel loginUserModel)
        {
            return NoContent();
        }
    }
}
