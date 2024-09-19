using NextWaveEdu.Devfreela.Domain.Enums;
using NextWaveEdu.Devfreela.Domain.SeedWork;

namespace NextWaveEdu.Devfreela.Domain.Entities
{
    public class Project : Entity
    {
        public Project(string title, string description, decimal totalCost, int idOwner, int idFreelancer)
        {
            Title = title;
            Description = description;
            CreatedAt = DateTime.Now;
            TotalCost = totalCost;
            Status = ProjectStatusEnum.Created;
            IdOwner = idOwner;
            IdFreelancer = idFreelancer;
            Comments = new List<Comment>();
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public decimal TotalCost { get; private set; }
        public ProjectStatusEnum Status { get; private set; }
        public int IdOwner { get; private set; }
        public int IdFreelancer { get; private set; }
        public List<Comment> Comments { get; private set; }
    }
}
