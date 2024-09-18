using Microsoft.AspNetCore.Mvc;
using NextWaveEdu.Devfreela.API.Models.User;

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
        public IActionResult Post([FromBody] CreateUserModel createUserModel)
        {
            return CreatedAtAction(nameof(GetById), new { id = createUserModel.Id }, createUserModel);
        }

        // api/users/login
        public IActionResult Login([FromBody] LoginUserModel loginUserModel)
        {
            return NoContent();
        }
    }
}
