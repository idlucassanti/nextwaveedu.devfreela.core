using Microsoft.AspNetCore.Mvc;

namespace NextWaveEdu.Devfreela.API.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
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
        public IActionResult Post([FromBody] object input)
        {
            //return BadRequest();

            // Cadastrar o Projeto

            var projectCreatedId = 1;
            return Created(nameof(GetById), new { projectCreatedId });
        }

        // api/projects/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] object updateInput)
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
    }
}
