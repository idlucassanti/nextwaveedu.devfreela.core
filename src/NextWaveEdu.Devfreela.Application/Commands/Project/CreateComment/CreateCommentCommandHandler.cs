using MediatR;
using Microsoft.EntityFrameworkCore;
using NextWaveEdu.Devfreela.Domain.Entities;
using NextWaveEdu.Devfreela.Infrastructure.Persistence;

namespace NextWaveEdu.Devfreela.Application.Commands.Project.CreateComment
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
    {
        private readonly DevfreelaDbContext _dbContexnt;

        public CreateCommentCommandHandler(DevfreelaDbContext dbContexnt)
        {
            _dbContexnt = dbContexnt;
        }

        public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var project = await _dbContexnt.Projects.SingleOrDefaultAsync(x => x.Id == request.ProjectId);

            if (project is null)
                throw new Exception();

            var comment = new Comment(request.Content, request.ProjectId, request.UserId);

            await _dbContexnt.Comments.AddAsync(comment);

            await _dbContexnt.SaveChangesAsync();

            return comment.Id;
        }
    }
}
