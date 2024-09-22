using NextWaveEdu.Devfreela.Domain.Enums;
using NextWaveEdu.Devfreela.Domain.SeedWork;

namespace NextWaveEdu.Devfreela.Domain.Entities
{
    public class Project : Entity
    {
        public Project(string title, string description, decimal totalCost, int ownerId, int freelancerId)
        {
            Title = title;
            Description = description;
            CreatedAt = DateTime.Now;
            TotalCost = totalCost;
            Status = ProjectStatusEnum.Created;
            OwnerId = ownerId;
            FreelancerId = freelancerId;
            Comments = new List<Comment>();
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public decimal TotalCost { get; private set; }
        public ProjectStatusEnum Status { get; private set; }
        public int OwnerId { get; private set; }
        public User Owner { get; set; }
        public int FreelancerId { get; private set; }
        public User Freelancer { get; private set; }
        public List<Comment> Comments { get; private set; }

        public void Cancellated()
        {
            if(this.Status == ProjectStatusEnum.Created || this.Status == ProjectStatusEnum.InProgress)
            {
                this.Status = ProjectStatusEnum.Cancelled;
            }
        }

        public void Started()
        {
            if(this.Status == ProjectStatusEnum.Created)
            {
                this.Status = ProjectStatusEnum.InProgress;
                this.StartedAt = DateTime.Now;
            }
        }

        public void Finished()
        {
            if (this.Status == ProjectStatusEnum.InProgress)
            {
                this.Status = ProjectStatusEnum.Finished;
                this.FinishedAt = DateTime.Now;
            }
        }

        public void UpdateInfos(string newTitle, string newDescription, decimal newCost)
        {
            this.Title = string.IsNullOrWhiteSpace(newTitle) ? this.Title : newTitle;
            this.Description = string.IsNullOrWhiteSpace(newDescription) ? this.Description : newDescription;
            this.TotalCost = newCost;
        }
    }
}
