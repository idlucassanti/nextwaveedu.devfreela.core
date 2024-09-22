using MediatR;
using NextWaveEdu.Devfreela.Application.ViewModels.Project;

namespace NextWaveEdu.Devfreela.Application.Queries.Project.GetAllProject
{
    public class GetAllProjectQuery : IRequest<List<ProjectViewModel>>
    {
        public GetAllProjectQuery(string? filter)
        {
            Filter = filter;
        }
        
        public string? Filter { get; set; }
    }
}
