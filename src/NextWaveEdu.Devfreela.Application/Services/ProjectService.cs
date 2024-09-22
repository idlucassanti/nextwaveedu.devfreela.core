using NextWaveEdu.Devfreela.Application.Services.Interfaces;
using NextWaveEdu.Devfreela.Application.InputModels.Project;
using NextWaveEdu.Devfreela.Application.ViewModels.Project;
using NextWaveEdu.Devfreela.Infrastructure.Persistence;
using NextWaveEdu.Devfreela.Domain.Entities;

namespace NextWaveEdu.Devfreela.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly DevfreelaDbContext _dbContext;

        public ProjectService(DevfreelaDbContext context)
        {
            _dbContext = context;
        }

        public int Create(CreateProjectInputModel input)
        {
            var id = _dbContext.Projects.Max(x => x.Id) + 1;

            var project = new Project(id, input.Title, input.Description, input.TotalCost, input.OwnerId, input.FreelancerId);
            
            _dbContext.Projects.Add(project);

            return project.Id;
        }

        public void CreateComment(int projectId, CreateCommentInputModel commentInput)
        {
            var project = _dbContext.Projects.FirstOrDefault(x => x.Id.Equals(projectId));

            if (project is null)
                return;

            var comment = new Comment(commentInput.Content, projectId, commentInput.UserId);

            //_dbContext.Comments.Add(comment);

            project.Comments.Add(comment);
        }

        public void Delete(int id)
        {
            var project = _dbContext.Projects.FirstOrDefault(x => x.Id.Equals(id));

            if (project is null)
                return;

            project.Cancellated();
        }

        public List<ProjectViewModel> Get(string? query)
        {
            var projects = _dbContext.Projects;

            var projectsViewModel = projects
                .Select(x => new ProjectViewModel(x.Id, x.Title, x.CreatedAt, x.Status))
                .ToList();

            return projectsViewModel;
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            var project = _dbContext.Projects.FirstOrDefault(x => x.Id.Equals(id));

            if (project is null)
                return null;

            var commentsViewModel = new List<CommentViewModel>();

            if (project.Comments.Any())
            {
                foreach (var comment in project.Comments)
                {
                    commentsViewModel.Add(new CommentViewModel(comment.Content, comment.ProjectId, comment.UserId, comment.CreatedAt));
                }
            }

            var projectDetailsViewModel = new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.CreatedAt,
                project.StartedAt,
                project.FinishedAt,
                project.TotalCost,
                project.Status,
                project.OwnerId,
                project.FreelancerId,
                commentsViewModel
            );

            return projectDetailsViewModel;
        }

        public void Start(int id)
        {
            var project = _dbContext.Projects.FirstOrDefault(x => x.Id == id);

            if (project is null)
                return;

            project.Started();
        }

        public void Finish(int id)
        {
            var project = _dbContext.Projects.FirstOrDefault(x => x.Id == id);

            if (project is null)
                return;

            project.Finished();
        }

        public void Update(int id, UpdateProjectInputModel input)
        {
            var project = _dbContext.Projects.FirstOrDefault(x => x.Id == id);

            if (project is null)
                return;

            project.UpdateInfos(input.Title, input.Description, input.TotalCost);
        }
    }
}
