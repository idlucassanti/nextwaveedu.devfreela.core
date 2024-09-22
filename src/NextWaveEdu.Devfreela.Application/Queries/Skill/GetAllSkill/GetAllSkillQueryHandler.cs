using MediatR;
using Microsoft.EntityFrameworkCore;
using NextWaveEdu.Devfreela.Application.ViewModels.Skill;
using NextWaveEdu.Devfreela.Infrastructure.Persistence;

namespace NextWaveEdu.Devfreela.Application.Queries.Skill.GetAllSkill
{
    public class GetAllSkillQueryHandler : IRequestHandler<GetAllSkillQuery, List<SkillViewModel>>
    {
        private readonly DevfreelaDbContext _dbContext;

        public GetAllSkillQueryHandler(DevfreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SkillViewModel>> Handle(GetAllSkillQuery request, CancellationToken cancellationToken)
        {
            var skills = _dbContext.Skills;

            if (skills == null)
                return null;

            var skillsViewModel = await skills.Select(x => new SkillViewModel(x.Id, x.Description, x.CreatedAt)).ToListAsync();

            return skillsViewModel;
        }
    }
}
