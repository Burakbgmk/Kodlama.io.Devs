using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Dtos
{
    public class TechnologiesListDto
    {
        public int Id { get; set; }
        public string ProgrammingLanguageName {get; set;}
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
