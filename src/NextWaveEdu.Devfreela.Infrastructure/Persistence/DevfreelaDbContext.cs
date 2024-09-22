using NextWaveEdu.Devfreela.Domain.Entities;

namespace NextWaveEdu.Devfreela.Infrastructure.Persistence
{
    public class DevfreelaDbContext
    {
        public DevfreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project(1, "Sancati Web", "Projeto web desenvolvimento em ReactJs", 1000, 1, 1),
                new Project(2, "Sancati Core", "Projeto backend desenvolvimento em .NET Core", 2000, 2, 1),
                new Project(3, "Sancati Mobile", "Projeto mobile desenvolvimento em React Native", 3000, 3, 1),
            };

            Users = new List<User>
            {
                new User(1, "Lucas Santi", "lucas@sancati.com", "123", new DateTime(1997, 1, 1)),
                new User(2, "Dyovana Kerly Moura Santi", "dyo@sancati.com", "123", new DateTime(1998, 1, 1)),
                new User(3, "Matteo Moura Santi", "matteo@sancati.com", "123", new DateTime(2023, 3, 30)),
            };

            Skills = new List<Skill>
            {
                new Skill(1, ".NET Core"),
                new Skill(2, "ReactJS"),
                new Skill(3, "React Native"),
            };
        }

        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
