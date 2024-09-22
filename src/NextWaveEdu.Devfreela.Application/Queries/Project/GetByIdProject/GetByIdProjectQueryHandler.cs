using MediatR;
using Microsoft.EntityFrameworkCore;
using NextWaveEdu.Devfreela.Application.ViewModels.Project;
using NextWaveEdu.Devfreela.Application.ViewModels.User;
using NextWaveEdu.Devfreela.Infrastructure.Persistence;

namespace NextWaveEdu.Devfreela.Application.Queries.Project.GetByIdProject
{
    public class GetByIdProjectQueryHandler : IRequestHandler<GetByIdProjectQuery, ProjectDetailsViewModel>
    {
        private readonly DevfreelaDbContext _dbContext;

        public GetByIdProjectQueryHandler(DevfreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ProjectDetailsViewModel> Handle(GetByIdProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects
                .Include(x => x.Owner)
                .Include(x => x.Freelancer)
                .Include(x => x.Comments)
                .SingleOrDefaultAsync(x => x.Id == request.Id);

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

            var projectViewModel = new ProjectDetailsViewModel(
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

            return projectViewModel;
        }
    }
}
