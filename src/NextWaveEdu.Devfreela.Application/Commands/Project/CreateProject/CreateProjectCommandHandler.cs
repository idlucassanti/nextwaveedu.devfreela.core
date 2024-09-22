using MediatR;
using NextWaveEdu.Devfreela.Infrastructure.Persistence;
using Entity = NextWaveEdu.Devfreela.Domain.Entities;

namespace NextWaveEdu.Devfreela.Application.Commands.Project.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly DevfreelaDbContext _dbContext;

        public CreateProjectCommandHandler(DevfreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Entity.Project(request.Title, request.Description, request.TotalCost, request.OwnerId, request.FreelancerId);
            
            await _dbContext.Projects.AddAsync(project);

            await _dbContext.SaveChangesAsync();

            return project.Id;
        }
    }
}
