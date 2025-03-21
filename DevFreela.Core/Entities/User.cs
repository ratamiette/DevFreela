﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DevFreela.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime birthDate)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;

            CreatedAt = DateTime.Now;
            Active = true;
            Skills = new List<UserSkill>();
            OwnedProjects = new List<Project>();
            FreelanceProjects = new List<Project>();
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; set; } // why not private set?
        public List<UserSkill> Skills { get; private set; }
        [InverseProperty("Client")]
        public List<Project> OwnedProjects { get; private set; }
        [InverseProperty("Freelancer")]
        public List<Project> FreelanceProjects { get; private set; } // why not private set?
        public List<ProjectComment> Comments { get; private set; } // why not private set?
    }
}
