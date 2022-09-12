using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class ProgrammingLanguage : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProgrammingParadigm { get; set; }
        public DateTime DebutTime { get; set; }
        public string CurrentVersion { get; set; }
        public virtual ICollection<Technology> Technologies { get; set; }

        public ProgrammingLanguage()
        {

        }
        public ProgrammingLanguage(int id, string name, string description, string programmingParadigm, DateTime debutTime, string currentVersion) : this()
        {
            Name = name;
            Id = id;
            Description = description;
            ProgrammingParadigm = programmingParadigm;
            DebutTime = debutTime;
            CurrentVersion = currentVersion;
        }
    }
}
