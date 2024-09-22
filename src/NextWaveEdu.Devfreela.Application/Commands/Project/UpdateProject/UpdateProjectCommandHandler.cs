using MediatR;
using Microsoft.EntityFrameworkCore;
using NextWaveEdu.Devfreela.Infrastructure.Persistence;

namespace NextWaveEdu.Devfreela.Application.Commands.Project.UpdateProject
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, bool>
    {
        private readonly DevfreelaDbContext _dbContext;

        public UpdateProjectCommandHandler(DevfreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _dbContext.Projects.SingleOrDefaultAsync(x => x.Id == request.Id);

            if (project is null)
                return false;

            project.UpdateInfos(request.Title, request.Description, request.TotalCost);

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
