using NextWaveEdu.Devfreela.Application.InputModels.Project;
using NextWaveEdu.Devfreela.Application.ViewModels.Project;

namespace NextWaveEdu.Devfreela.Application.Services.Interfaces
{
    public interface IProjectService
    {
        List<ProjectViewModel> Get(string query);
        ProjectDetailsViewModel GetById(int id);
        int Create(CreateProjectInputModel input);
        void Update(int id, UpdateProjectInputModel input);
        void Delete(int id);
        void CreatedComment(int id, CreateCommentInputModel input);
        void Start(int id);
        void Finish(int id);
    }
}
