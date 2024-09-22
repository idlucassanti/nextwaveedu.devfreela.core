using MediatR;
using Microsoft.EntityFrameworkCore;
using NextWaveEdu.Devfreela.Application.ViewModels.Project;
using NextWaveEdu.Devfreela.Infrastructure.Persistence;

namespace NextWaveEdu.Devfreela.Application.Queries.Project.GetAllProject
{
    public class GetAllProjectQueryHandler : IRequestHandler<GetAllProjectQuery, List<ProjectViewModel>>
    {
        private readonly DevfreelaDbContext _dbContext;

        public GetAllProjectQueryHandler(DevfreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProjectViewModel>> Handle(GetAllProjectQuery request, CancellationToken cancellationToken)
        {
            var projects = _dbContext.Projects;

            if (projects is null)
                return null;

            var projectsViewModel = projects.Select(x => new ProjectViewModel(x.Id, x.Title, x.CreatedAt, x.Status)).ToList();
        
            return projectsViewModel;
        }
    }
}
