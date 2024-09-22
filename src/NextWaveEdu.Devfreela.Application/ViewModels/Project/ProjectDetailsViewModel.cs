using NextWaveEdu.Devfreela.Domain.Entities;
using NextWaveEdu.Devfreela.Domain.Enums;

namespace NextWaveEdu.Devfreela.Application.ViewModels.Project
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel(
            int id,
            string title,
            string description, 
            DateTime createdAt,
            DateTime? startedAt,
            DateTime? finishedAt,
            decimal totalCost,
            ProjectStatusEnum status,
            int ownerId, 
            int freelancerId,
            List<CommentViewModel> comments
        )
        {
            Id = id;
            Title = title;
            Description = description;
            CreatedAt = createdAt;
            StartedAt = startedAt;
            FinishedAt = finishedAt;
            TotalCost = totalCost;
            Status = status;
            OwnerId = ownerId;
            FreelancerId = freelancerId;
            Comments = comments;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public decimal TotalCost { get; set; }
        public ProjectStatusEnum Status { get; set; }
        public int OwnerId { get; set; }
        public int FreelancerId { get; set; }
        public List<CommentViewModel> Comments { get; set; }
    }
}
