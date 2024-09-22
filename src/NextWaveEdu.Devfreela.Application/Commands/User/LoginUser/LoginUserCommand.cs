using MediatR;
using NextWaveEdu.Devfreela.Application.ViewModels.User;

namespace NextWaveEdu.Devfreela.Application.Commands.User.LoginUser
{
    public class LoginUserCommand : IRequest<UserAuthViewModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
