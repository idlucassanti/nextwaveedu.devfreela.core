using NextWaveEdu.Devfreela.Application.InputModels.Skill;
using NextWaveEdu.Devfreela.Application.Services.Interfaces;
using NextWaveEdu.Devfreela.Application.ViewModels.Skill;
using NextWaveEdu.Devfreela.Domain.Entities;
using NextWaveEdu.Devfreela.Infrastructure.Persistence;

namespace NextWaveEdu.Devfreela.Application.Services
{
    public class SkillService : ISkillService
    {
        private DevfreelaDbContext _dbContext;

        public SkillService(DevfreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(CreateSkillInputModel input)
        {
            var id = _dbContext.Skills.Max(x => x.Id) + 1;

            var skill = new Skill(id, input.Description);

            _dbContext.Skills.Add(skill);

            _dbContext.SaveChanges();

            return id;
        }

        public List<SkillViewModel> Get()
        {
            var skillsViewModels = _dbContext.Skills
                .Select(x => new SkillViewModel(x.Id, x.Description, x.CreatedAt))
                .ToList();

            return skillsViewModels;
        }
    }
}
