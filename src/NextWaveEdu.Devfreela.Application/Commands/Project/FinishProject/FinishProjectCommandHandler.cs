using MediatR;
using Microsoft.EntityFrameworkCore;
using NextWaveEdu.Devfreela.Infrastructure.Persistence;

namespace NextWaveEdu.Devfreela.Application.Commands.Project.FinishProject
{
    public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, bool>
    {
        private readonly DevfreelaDbContext _dbContext;

        public FinishProjectCommandHandler(DevfreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects.SingleOrDefault(x => x.Id == request.Id);

            if (project is null)
                return false;

            project.Finished();

            _dbContext.SaveChanges();

            return true;
        }
    }
}
