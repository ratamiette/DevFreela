using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                new Project("Meu Projeto AspNet Core 1", "Minha Descricao 1", 1, 1, 10000),
                new Project("Meu Projeto AspNet Core 2", "Minha Descricao 2", 1, 1, 20000),
                new Project("Meu Projeto AspNet Core 3", "Minha Descricao 3", 1, 1, 30000)
            };

            Users = new List<User>
            {
                new User("Raphaela Lara", "ratamiette@gmail.com", new DateTime(1990, 7, 5)),
                new User("Robert C Martin", "robert@gmail.com", new DateTime(1990, 12, 18)),
                new User("Anderson", "anderson@gmail.com", new DateTime(1970, 3, 2))
            };

            Skills = new List<Skill>
            {
                new Skill(".NET Core"),
                new Skill("C#"),
                new Skill("SQL")
            };
        }
        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
