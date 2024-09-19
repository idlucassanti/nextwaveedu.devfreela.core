using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NextWaveEdu.Devfreela.API.Constants;
using NextWaveEdu.Devfreela.API.Models.Project;

namespace NextWaveEdu.Devfreela.API.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly OpeningTimeOption _option;

        public ProjectsController(IOptions<OpeningTimeOption> option)
        {
            _option = option.Value;
        }

        // api/projects?query=aspnetcore
        [HttpGet]
        public IActionResult Get(string query)
        {
            return Ok();
        }

        // api/projects/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            //return NotFound();
            return Ok();
        }

        // api/projecets
        [HttpPost]
        public IActionResult Post([FromBody] CreateProjectModel input)
        {
            //return BadRequest();

            // Cadastrar o Projeto
            return Created(nameof(GetById), new { id = input.Id });
        }

        // api/projects/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectModel input)
        {
            // Atualizar o Projeot pelo Id

            return NoContent();
        }

        // api/projects/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //return NotFound();

            // Remoção do id
            return NoContent();
        }

        // api/projects/1/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostCommet(int id, [FromBody] CreateCommentModel createComment)
        {
            return NoContent();
        }

        // api/projects/1/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            return NoContent();
        }

        // api/projects/1/finish
        [HttpPut("{id}")]
        public IActionResult Finish(int id)
        {
            return NoContent();
        }
    }
}
