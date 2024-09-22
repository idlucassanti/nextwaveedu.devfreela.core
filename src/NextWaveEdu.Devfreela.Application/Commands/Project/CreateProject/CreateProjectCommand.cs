using MediatR;

namespace NextWaveEdu.Devfreela.Application.Commands.Project.CreateProject
{
    public class CreateProjectCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalCost { get; set; }
        public int OwnerId { get; set; }
        public int FreelancerId { get; set; }
    }
}
