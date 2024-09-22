using MediatR;

namespace NextWaveEdu.Devfreela.Application.Commands.Project.StartProject
{
    public class StartProjectCommand : IRequest<bool>
    {
        public StartProjectCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
