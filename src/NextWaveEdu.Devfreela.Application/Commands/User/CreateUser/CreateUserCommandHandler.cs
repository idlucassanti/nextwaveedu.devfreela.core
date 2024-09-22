using MediatR;
using NextWaveEdu.Devfreela.Infrastructure.Persistence;

namespace NextWaveEdu.Devfreela.Application.Commands.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly DevfreelaDbContext _dbContext;

        public CreateUserCommandHandler(DevfreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new Domain.Entities.User(request.Name, request.Email, request.Password, request.BirthDate);

            _dbContext.Users.Add(user);

            _dbContext.SaveChanges();

            return user.Id;
        }
    }
}
