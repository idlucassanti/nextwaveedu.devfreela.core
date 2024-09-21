using NextWaveEdu.Devfreela.Domain.Entities;

namespace NextWaveEdu.Devfreela.Infrastructure.Persistence
{
    public class DevfreelaDbContext
    {
        public DevfreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Projeto 1", "Descrição projeto 1", 1000, 1, 1),
                new Project("Projeto 2", "Descrição projeto 2", 2000, 1, 1),
                new Project("Projeto 3", "Descrição projeto 3", 3000, 1, 1),
            };

            Users = new List<User>
            {
                new User("User 1", "email@user1.com", "123", new DateTime(1997, 1,1)),
                new User("User 2", "email@user2.com", "123", new DateTime(1997, 1,1)),
                new User("User 3", "email@user3.com", "123", new DateTime(1997, 1,1)),
            };

            Skills = new List<Skill>
            {
                new Skill(".NET Core"),
                new Skill("ReactJS"),
                new Skill("React Native"),
            };
        }

        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
