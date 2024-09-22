using NextWaveEdu.Devfreela.Application.InputModels.User;
using NextWaveEdu.Devfreela.Application.ViewModels.User;

namespace NextWaveEdu.Devfreela.Application.Services.Interfaces
{
    public interface IUserService
    {
        UserViewModel GetById(int id);
        int Create(CreateUserInputModel input);
        UserAuthViewModel Login(LoginUserInputModel input);
    }
}
