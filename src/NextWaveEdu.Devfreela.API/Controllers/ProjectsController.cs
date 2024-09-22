using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NextWaveEdu.Devfreela.API.Constants;
using NextWaveEdu.Devfreela.Application.Commands.Project.CreateComment;
using NextWaveEdu.Devfreela.Application.Commands.Project.CreateProject;
using NextWaveEdu.Devfreela.Application.Commands.Project.DeleteProject;
using NextWaveEdu.Devfreela.Application.Commands.Project.FinishProject;
using NextWaveEdu.Devfreela.Application.Commands.Project.StartProject;
using NextWaveEdu.Devfreela.Application.Commands.Project.UpdateProject;
using NextWaveEdu.Devfreela.Application.Queries.Project.GetAllProject;
using NextWaveEdu.Devfreela.Application.Queries.Project.GetByIdProject;

namespace NextWaveEdu.Devfreela.API.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly OpeningTimeOption _option;
        private readonly IMediator _mediator;
       
        public ProjectsController(IOptions<OpeningTimeOption> option, IMediator mediator)
        {
            _option = option.Value;
            _mediator = mediator;
        }

        // api/projects?filter=aspnetcore
        [HttpGet]
        public async Task<IActionResult> Get(string? filter)
        {
            var query = new GetAllProjectQuery(filter);
            
            var response = _mediator.Send(query);
            
            return Ok(response);
        }

        // api/projects/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdProjectQuery(id);

            var response = _mediator.Send(query);
            
            if (response is null)
                return NotFound();

            return Ok(response);
        }

        // api/projects
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProjectCommand command)
        {
            var responseId = _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = responseId }, command);
        }

        // api/projects/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        {
            command.Id = id;

            await _mediator.Send(command);

            return NoContent();
        }

        // api/projects/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand(id);
            
            await _mediator.Send(command);
            
            return NoContent();
        }

        // api/projects/1/comments
        [HttpPost("{id}/comments")]
        public async Task<IActionResult> CreateCommet(int id, [FromBody] CreateCommentCommand command)
        {
            command.ProjectId = id;

            await _mediator.Send(command);

            return NoContent();
        }

        // api/projects/1/start
        [HttpPut("{id}/start")]
        public async Task<IActionResult> Start(int id)
        {
            var command = new StartProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        // api/projects/1/finish
        [HttpPut("{id}/finish")]
        public async Task<IActionResult> Finish(int id)
        {
            var command = new FinishProjectCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
