﻿using NextWaveEdu.Devfreela.Domain.SeedWork;

namespace NextWaveEdu.Devfreela.Domain.Entities
{
    public class User : Entity
    {
        public User(string name, string email, string password, DateTime birthDate, bool active, DateTime createdAt)
        {
            Name = name;
            Email = email;
            Password = password;
            BirthDate = birthDate;
            Active = active;
            CreatedAt = createdAt;
            Skills = new List<UserSkill>();
            OwnerProjects = new List<Project>();
            FreelaProjects = new List<Project>();
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Active { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public List<UserSkill> Skills { get; private set; }
        public List<Project> OwnerProjects { get; private set; }
        public List<Project> FreelaProjects { get; private set; }
    }
}
