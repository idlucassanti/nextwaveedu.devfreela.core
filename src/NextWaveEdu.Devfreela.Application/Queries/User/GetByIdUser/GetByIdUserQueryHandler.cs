using MediatR;
using NextWaveEdu.Devfreela.Application.ViewModels.User;
using NextWaveEdu.Devfreela.Infrastructure.Persistence;

namespace NextWaveEdu.Devfreela.Application.Queries.User.GetByIdUser
{
    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, UserViewModel>
    {
        private readonly DevfreelaDbContext _dbContext;

        public GetByIdUserQueryHandler(DevfreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserViewModel> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Id == request.Id);

            if (user is null)
                return null;

            return new UserViewModel(user.Id, user.Name, user.Email, user.BirthDate);
        }
    }
}
