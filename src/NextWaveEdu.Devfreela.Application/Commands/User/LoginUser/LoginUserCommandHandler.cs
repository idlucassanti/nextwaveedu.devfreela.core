using MediatR;
using NextWaveEdu.Devfreela.Application.ViewModels.User;
using NextWaveEdu.Devfreela.Infrastructure.Persistence;

namespace NextWaveEdu.Devfreela.Application.Commands.User.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, UserAuthViewModel>
    {
        private readonly DevfreelaDbContext _dbContext;

        public LoginUserCommandHandler(DevfreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserAuthViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Email == request.Email && x.Password == request.Password);

            if (user is null)
                return null;

            return new UserAuthViewModel(user.Email);
        }
    }
}
