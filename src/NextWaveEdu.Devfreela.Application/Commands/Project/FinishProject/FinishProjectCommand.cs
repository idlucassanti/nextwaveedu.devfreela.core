using MediatR;

namespace NextWaveEdu.Devfreela.Application.Commands.Project.FinishProject
{
    public class FinishProjectCommand : IRequest<bool>
    {
        public FinishProjectCommand(int id)
        {
            Id = id;    
        }

        public int Id { get; private set; }
    }
}
