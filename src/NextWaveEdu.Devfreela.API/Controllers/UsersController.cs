using MediatR;
using Microsoft.AspNetCore.Mvc;
using NextWaveEdu.Devfreela.Application.Commands.User.CreateUser;
using NextWaveEdu.Devfreela.Application.Commands.User.LoginUser;
using NextWaveEdu.Devfreela.Application.Queries.User.GetByIdUser;

namespace NextWaveEdu.Devfreela.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // api/users/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdUserQuery(id);

            var response = await _mediator.Send(query);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        // api/users
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var responseId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = responseId }, command);
        }

        // api/users/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
