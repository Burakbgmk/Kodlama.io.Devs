using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.CreateTechnology
{
    public partial class CreateTechnologyCommand : IRequest<CreatedTechnologyDto>
    {
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Description { get; set; }
        public DateTime DebutTime { get; set; }
        public string CurrentVersion { get; set; }

        public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreatedTechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly ITechnologiesRepository _technologiesRepository;
            private readonly TechnologiesBusinessRules _technologiesBusinessRules;
            public CreateTechnologyCommandHandler(IMapper mapper, ITechnologiesRepository technologiesRepository, TechnologiesBusinessRules technologiesBusinessRules)
            {
                _mapper = mapper;
                _technologiesRepository = technologiesRepository;
                _technologiesBusinessRules = technologiesBusinessRules;

            }
            public async Task<CreatedTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _technologiesBusinessRules.TechnologyNameCanNotBeDuplicatedWhenInserted(request.Name);
                var technology = _mapper.Map<Technology>(request);
                var created = await _technologiesRepository.AddAsync(technology);
                return _mapper.Map<CreatedTechnologyDto>(created);
            }
        }
    }
}
