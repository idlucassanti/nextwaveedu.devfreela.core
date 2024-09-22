using MediatR;
using NextWaveEdu.Devfreela.Infrastructure.Persistence;

namespace NextWaveEdu.Devfreela.Application.Commands.Project.StartProject
{
    public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, bool>
    {
        private readonly DevfreelaDbContext _dbContext;

        public StartProjectCommandHandler(DevfreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects.SingleOrDefault(x => x.Id == request.Id);

            if (project is null)
                return false;

            project.Started();

            _dbContext.SaveChanges();

            return true;
        }
    }
}
