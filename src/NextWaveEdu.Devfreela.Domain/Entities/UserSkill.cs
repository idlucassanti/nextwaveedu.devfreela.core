using NextWaveEdu.Devfreela.Domain.SeedWork;

namespace NextWaveEdu.Devfreela.Domain.Entities
{
    public class UserSkill : Entity
    {
        public int UserId { get; private set; }
        public int SkillId { get; private set; }
    }
}
