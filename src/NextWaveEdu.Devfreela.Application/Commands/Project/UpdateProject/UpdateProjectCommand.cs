using MediatR;

namespace NextWaveEdu.Devfreela.Application.Commands.Project.UpdateProject
{
    public class UpdateProjectCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalCost { get; set; }
    }
}
