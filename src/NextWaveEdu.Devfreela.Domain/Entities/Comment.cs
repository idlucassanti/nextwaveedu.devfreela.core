using NextWaveEdu.Devfreela.Domain.SeedWork;

namespace NextWaveEdu.Devfreela.Domain.Entities
{
    public class Comment : Entity
    {
        public Comment(string description, int projectId, int userId)
        {
            Description = description;
            ProjectId = projectId;
            UserId = userId;
            CreatedAt = DateTime.Now;
        }

        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public int ProjectId { get; private set; }
        public int UserId { get; private set; }
    }
}
