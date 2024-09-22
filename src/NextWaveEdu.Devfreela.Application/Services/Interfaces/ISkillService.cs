using NextWaveEdu.Devfreela.Application.InputModels.Skill;
using NextWaveEdu.Devfreela.Application.ViewModels.Skill;

namespace NextWaveEdu.Devfreela.Application.Services.Interfaces
{
    public interface ISkillService
    {
        List<SkillViewModel> Get();
        int Create(CreateSkillInputModel input);
    }
}
