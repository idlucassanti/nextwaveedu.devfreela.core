using MediatR;
using Microsoft.EntityFrameworkCore;
using Entity = NextWaveEdu.Devfreela.Domain.Entities;
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
            var project = _dbContexnt.Projects.SingleOrDefault(x => x.Id == request.ProjectId);

            if (project is null)
                throw new Exception();

            var comment = new Entity.Comment(request.Content, request.ProjectId, request.UserId);

            _dbContexnt.Comments.Add(comment);

            _dbContexnt.SaveChanges();

            return comment.Id;
        }
    }
}
