using MediatR;
using NextWaveEdu.Devfreela.Application.ViewModels.Project;

namespace NextWaveEdu.Devfreela.Application.Queries.Project.GetByIdProject
{
    public class GetByIdProjectQuery : IRequest<ProjectDetailsViewModel>
    {
        public GetByIdProjectQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
