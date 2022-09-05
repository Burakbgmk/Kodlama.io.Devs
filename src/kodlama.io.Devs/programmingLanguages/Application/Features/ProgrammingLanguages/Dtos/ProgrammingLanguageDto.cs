using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Dtos
{
    public class ProgrammingLanguageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProgrammingParadigm { get; set; }
        public DateTime DebutTime { get; set; }
        public string CurrentVersion { get; set; }
    }
}
