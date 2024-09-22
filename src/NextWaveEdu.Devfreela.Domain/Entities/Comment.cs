using NextWaveEdu.Devfreela.Domain.SeedWork;

namespace NextWaveEdu.Devfreela.Domain.Entities
{
    public class Comment : Entity
    {
        public Comment(string content, int projectId, int userId)
        {
            Content = content;
            ProjectId = projectId;
            UserId = userId;
            CreatedAt = DateTime.Now;
        }

        public string Content { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public int ProjectId { get; private set; }
        public virtual Project Project { get; set; }
        public int UserId { get; private set; }
        public virtual User User { get; set; }
    }
}
