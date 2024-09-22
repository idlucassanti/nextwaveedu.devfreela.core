using MediatR;

namespace NextWaveEdu.Devfreela.Application.Commands.Project.CreateComment
{
    public class CreateCommentCommand : IRequest<int>
    {
        public int ProjectId { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
    }
}
