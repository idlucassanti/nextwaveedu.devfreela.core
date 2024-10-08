﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using NextWaveEdu.Devfreela.Application.Queries.Skill.GetAllSkill;

namespace NextWaveEdu.Devfreela.API.Controllers
{
    [Route("api/skills")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // api/skills
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllSkillQuery();

            var response = await _mediator.Send(query);

            if (response is null)
                return NoContent();

            return Ok(response);
        }
    }
}
