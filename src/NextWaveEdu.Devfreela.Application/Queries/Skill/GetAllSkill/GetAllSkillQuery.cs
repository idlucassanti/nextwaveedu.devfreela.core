using MediatR;
using NextWaveEdu.Devfreela.Application.ViewModels.Skill;

namespace NextWaveEdu.Devfreela.Application.Queries.Skill.GetAllSkill
{
    public class GetAllSkillQuery : IRequest<List<SkillViewModel>>
    {
    }
}
