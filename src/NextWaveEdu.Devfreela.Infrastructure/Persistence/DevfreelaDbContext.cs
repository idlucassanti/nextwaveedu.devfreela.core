using Microsoft.EntityFrameworkCore;
using NextWaveEdu.Devfreela.Domain.Entities;
using System.Reflection;

namespace NextWaveEdu.Devfreela.Infrastructure.Persistence
{
    public class DevfreelaDbContext : DbContext
    {
        public DevfreelaDbContext(DbContextOptions<DevfreelaDbContext> options)
            :base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<UserSkill> UsersSkills { get; set; }

        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // aplica todas as classes de configuração existente no assembly
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
