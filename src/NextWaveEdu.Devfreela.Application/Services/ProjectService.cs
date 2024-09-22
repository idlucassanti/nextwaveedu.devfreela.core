using NextWaveEdu.Devfreela.Application.Services.Interfaces;
using NextWaveEdu.Devfreela.Application.InputModels.Project;
using NextWaveEdu.Devfreela.Application.ViewModels.Project;
using NextWaveEdu.Devfreela.Infrastructure.Persistence;
using NextWaveEdu.Devfreela.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NextWaveEdu.Devfreela.Application.ViewModels.User;

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
            var project = new Project(input.Title, input.Description, input.TotalCost, input.OwnerId, input.FreelancerId);
            
            _dbContext.Projects.Add(project);

            _dbContext.SaveChanges();

            return project.Id;
        }

        public void CreateComment(int projectId, CreateCommentInputModel commentInput)
        {
            var project = _dbContext.Projects.FirstOrDefault(x => x.Id.Equals(projectId));

            if (project is null)
                return;

            var comment = new Comment(commentInput.Content, projectId, commentInput.UserId);

            //_dbContext.Comments.Add(comment);

            _dbContext.Comments.Add(comment);

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var project = _dbContext.Projects.FirstOrDefault(x => x.Id.Equals(id));

            if (project is null)
                return;

            project.Cancellated();

            _dbContext.SaveChanges();
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
            var project = _dbContext.Projects
                .Include(x => x.Owner)
                .Include(x => x.Freelancer)
                .Include(x => x.Comments)
                .FirstOrDefault(x => x.Id.Equals(id));

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
                commentsViewModel,
                new UserViewModel(project.Owner.Id, project.Owner.Name, project.Owner.Email, project.Owner.BirthDate),
                new UserViewModel(project.Freelancer.Id, project.Freelancer.Name, project.Freelancer.Email, project.Freelancer.BirthDate)
            );

            return projectDetailsViewModel;
        }

        public void Start(int id)
        {
            var project = _dbContext.Projects.FirstOrDefault(x => x.Id == id);

            if (project is null)
                return;

            project.Started();

            _dbContext.SaveChanges();
        }

        public void Finish(int id)
        {
            var project = _dbContext.Projects.FirstOrDefault(x => x.Id == id);

            if (project is null)
                return;

            project.Finished();

            _dbContext.SaveChanges();
        }

        public void Update(int id, UpdateProjectInputModel input)
        {
            var project = _dbContext.Projects.FirstOrDefault(x => x.Id == id);

            if (project is null)
                return;

            project.UpdateInfos(input.Title, input.Description, input.TotalCost);

            _dbContext.SaveChanges();
        }
    }
}
