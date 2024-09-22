using MediatR;
using NextWaveEdu.Devfreela.Application.ViewModels.User;

namespace NextWaveEdu.Devfreela.Application.Queries.User.GetByIdUser
{
    public class GetByIdUserQuery : IRequest<UserViewModel>
    {
        public GetByIdUserQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
