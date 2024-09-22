namespace NextWaveEdu.Devfreela.Application.ViewModels.User
{
    public class UserAuthViewModel
    {
        public UserAuthViewModel(string email)
        {
            Token = Guid.NewGuid();
            RefreshToken = Guid.NewGuid();
            ExpiredToken = DateTime.Now.AddHours(2);
            Email = email;
        }

        public Guid Token { get; private set; }
        public Guid RefreshToken { get; private set; }
        public DateTime ExpiredToken { get; private set; }
        public string Email { get; private set; }
    }
}
