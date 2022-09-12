using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Technology : Entity
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DebutTime { get; set; }
        public string CurrentVersion { get; set; }
        public virtual ProgrammingLanguage? ProgrammingLanguage { get; set; }

        public Technology()
        {

        }

        public Technology(int id, int programmingLangugageId, string name, string description, DateTime debutTime, string currentVersion) : this()
        {
            Id = id;
            ProgrammingLanguageId = programmingLangugageId;
            Name = name;
            Description = description;
            DebutTime = debutTime;
            CurrentVersion = currentVersion;

        }

    }
}
