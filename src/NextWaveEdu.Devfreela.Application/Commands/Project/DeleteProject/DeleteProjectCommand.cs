using MediatR;

namespace NextWaveEdu.Devfreela.Application.Commands.Project.DeleteProject
{
    public class DeleteProjectCommand : IRequest<bool>
    {
        public DeleteProjectCommand(int id)
        {
            Id = id;    
        }

        public int Id { get; private set; }
    }
}
