using Microsoft.AspNetCore.Mvc;
using NextWaveEdu.Devfreela.Application.InputModels.Skill;
using NextWaveEdu.Devfreela.Application.Services.Interfaces;

namespace NextWaveEdu.Devfreela.API.Controllers
{
    [Route("api/skills")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        // api/skills
        [HttpGet]
        public IActionResult Get()
        {
            var response = _skillService.Get();

            if (response is null)
                return NoContent();

            return Ok(response);
        }

        // api/skills
        [HttpPost]
        public IActionResult Create([FromBody] CreateSkillInputModel input)
        {
            var responseId = _skillService.Create(input);

            return CreatedAtAction(nameof(Get), new { id = responseId }, input);
        }
    }
}
