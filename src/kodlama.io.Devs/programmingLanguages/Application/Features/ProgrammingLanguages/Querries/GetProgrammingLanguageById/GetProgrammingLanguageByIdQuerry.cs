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

namespace Application.Features.ProgrammingLanguages.Querries.GetProgrammingLanguageById
{
    public partial class GetProgrammingLanguageByIdQuerry : IRequest<ProgrammingLanguageDto>
    {
        public int Id { get; set; }

        public class GetProgrammingLanguageByIdQuerryHandler : IRequestHandler<GetProgrammingLanguageByIdQuerry, ProgrammingLanguageDto>
        {

            private readonly IProgrammingLanguagesRepository _programmingLanguagesRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguagesBusinessRules _programmingLanguagesBusinessRules;
            public GetProgrammingLanguageByIdQuerryHandler(IProgrammingLanguagesRepository programmingLanguagesRepository, IMapper mapper, ProgrammingLanguagesBusinessRules programmingLanguagesBusinessRules)
            {
                _programmingLanguagesRepository = programmingLanguagesRepository;
                _mapper = mapper;
                _programmingLanguagesBusinessRules = programmingLanguagesBusinessRules;

            }
            public async Task<ProgrammingLanguageDto> Handle(GetProgrammingLanguageByIdQuerry request, CancellationToken cancellationToken)
            {
                var programmingLanguage = await _programmingLanguagesRepository.GetAsync(x => x.Id == request.Id);

                _programmingLanguagesBusinessRules.ProgrammingLanguageShouldExistWhenRequested(programmingLanguage);

                var dto = _mapper.Map<ProgrammingLanguageDto>(programmingLanguage);

                return dto;
            }
        }

    }
}
