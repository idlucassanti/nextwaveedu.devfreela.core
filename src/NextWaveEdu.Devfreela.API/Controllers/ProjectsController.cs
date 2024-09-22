using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NextWaveEdu.Devfreela.API.Constants;
using NextWaveEdu.Devfreela.Application.InputModels.Project;
using NextWaveEdu.Devfreela.Application.Services.Interfaces;

namespace NextWaveEdu.Devfreela.API.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly OpeningTimeOption _option;
        private readonly IProjectService _projectService;

        public ProjectsController(IOptions<OpeningTimeOption> option, IProjectService projectService)
        {
            _option = option.Value;
            _projectService = projectService;
        }

        // api/projects?query=aspnetcore
        [HttpGet]
        public IActionResult Get(string? query)
        {
            var response = _projectService.Get(query);
            return Ok(response);
        }

        // api/projects/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var response = _projectService.GetById(id);
            
            if (response is null)
                return NotFound();

            return Ok(response);
        }

        // api/projects
        [HttpPost]
        public IActionResult Create([FromBody] CreateProjectInputModel input)
        {
            //return BadRequest();

            var responseId = _projectService.Create(input);

            // Cadastrar o Projeto
            return Created(nameof(GetById), new { id = responseId });
        }

        // api/projects/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectInputModel input)
        {
            _projectService.Update(id, input);

            return NoContent();
        }

        // api/projects/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _projectService.Delete(id);
            return NoContent();
            
            //return NotFound();
        }

        // api/projects/1/comments
        [HttpPost("{id}/comments")]
        public IActionResult CreateCommet(int id, [FromBody] CreateCommentInputModel input)
        {
            _projectService.CreateComment(id, input);
            return NoContent();
        }

        // api/projects/1/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            _projectService.Start(id);
            
            return NoContent();
        }

        // api/projects/1/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            _projectService.Finish(id);
            return NoContent();
        }
    }
}
