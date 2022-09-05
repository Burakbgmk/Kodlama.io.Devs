using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public partial class UpdateProgrammingLanguageCommand : IRequest<UpdatedProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProgrammingParadigm { get; set; }
        public DateTime DebutTime { get; set; }
        public string CurrentVersion { get; set; }

        public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand, UpdatedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguagesRepository _programmingLanguagesRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguagesBusinessRules _programmingLanguagesBusinessRules;
            public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguagesRepository programmingLanguagesRepository, IMapper mapper, ProgrammingLanguagesBusinessRules programmingLanguagesBusinessRules)
            {
                _programmingLanguagesRepository = programmingLanguagesRepository;
                _mapper = mapper;
                _programmingLanguagesBusinessRules = programmingLanguagesBusinessRules;
            }
            public async Task<UpdatedProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                var programmingLanguage = await _programmingLanguagesRepository.GetAsync(x => x.Id == request.Id);
                _programmingLanguagesBusinessRules.ProgrammingLanguageShouldExistWhenRequested(programmingLanguage);

                programmingLanguage.Name = request.Name == default ? programmingLanguage.Name : request.Name;
                programmingLanguage.Description = request.Description == default ? programmingLanguage.Description : request.Description;
                programmingLanguage.ProgrammingParadigm = request.ProgrammingParadigm == default ? programmingLanguage.ProgrammingParadigm : request.ProgrammingParadigm;
                programmingLanguage.DebutTime = request.DebutTime == default ? programmingLanguage.DebutTime : request.DebutTime;
                programmingLanguage.CurrentVersion = request.CurrentVersion == default ? programmingLanguage.CurrentVersion : request.CurrentVersion;

                var updatedProgrammingLanguage = await _programmingLanguagesRepository.UpdateAsync(programmingLanguage);
                var dto = _mapper.Map<UpdatedProgrammingLanguageDto>(updatedProgrammingLanguage);

                return dto;
            }
        }
    }
}
