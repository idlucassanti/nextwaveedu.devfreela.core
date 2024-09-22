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
        public IActionResult GetById(int id)
        {
            var query = new GetByIdUserQuery(id);

            var response = _mediator.Send(query).Result;

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        // api/users
        [HttpPost]
        public IActionResult Create([FromBody] CreateUserCommand command)
        {
            var responseId = _mediator.Send(command).Result;

            return CreatedAtAction(nameof(GetById), new { id = responseId }, command);
        }

        // api/users/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUserCommand command)
        {
            var response = _mediator.Send(command).Result;

            return Ok(response);
        }
    }
}
