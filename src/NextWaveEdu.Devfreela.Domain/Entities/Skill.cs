using NextWaveEdu.Devfreela.Domain.SeedWork;

namespace NextWaveEdu.Devfreela.Domain.Entities
{
    public class Skill : Entity
    {
        public Skill(string description)
        {
            Description = description;
            CreatedAt = DateTime.Now;
        }

        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
