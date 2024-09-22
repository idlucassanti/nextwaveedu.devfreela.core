using NextWaveEdu.Devfreela.Application.InputModels.User;
using NextWaveEdu.Devfreela.Application.Services.Interfaces;
using NextWaveEdu.Devfreela.Application.ViewModels.User;
using NextWaveEdu.Devfreela.Domain.Entities;
using NextWaveEdu.Devfreela.Infrastructure.Persistence;

namespace NextWaveEdu.Devfreela.Application.Services
{
    public class UserService : IUserService
    {
        private readonly DevfreelaDbContext _dbContext;

        public UserService(DevfreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(CreateUserInputModel input)
        {
            var userId = _dbContext.Users.Max(x => x.Id) + 1;

            var user = new User(userId, input.Name, input.Email, input.Password, input.BirthDate);

            _dbContext.Users.Add(user);

            return userId;
        }

        public UserViewModel GetById(int id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);

            if (user is null)
                return null;

            return new UserViewModel(user.Id, user.Name, user.Email, user.BirthDate);
        }

        public UserAuthViewModel Login(LoginUserInputModel input)
        {
            var user = _dbContext.Users
                .FirstOrDefault(x => 
                        x.Email.Equals(input.Email) 
                    &&  x.Password.Equals(input.Password));

            if (user is null)
                return null;

            return new UserAuthViewModel(user.Email);
        }
    }
}
