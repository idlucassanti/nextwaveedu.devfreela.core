using MediatR;
using Microsoft.EntityFrameworkCore;
using NextWaveEdu.Devfreela.Infrastructure.Persistence;

namespace NextWaveEdu.Devfreela.Application.Commands.Project.DeleteProject
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, bool>
    {
        private readonly DevfreelaDbContext _dbContext;

        public DeleteProjectCommandHandler(DevfreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects.SingleOrDefault(x => x.Id == request.Id);

            if (project == null)
                return false;

            project.Cancellated();

            _dbContext.SaveChanges();

            return true;
        }
    }
}
