namespace NextWaveEdu.Devfreela.Application.ViewModels.Project
{
    public class CommentViewModel
    {
        public CommentViewModel(string content, int projectId, int userId, DateTime createAt)
        {
            Content = content;
            ProjectId = projectId;
            UserId = userId;
            CreatedAt = createAt;
        }

        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
    }
}
