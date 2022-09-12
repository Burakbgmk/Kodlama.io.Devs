using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.UpdateTechnology
{
    public partial class UpdateTechnologyCommand : IRequest<UpdatedTechnologyDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Description { get; set; }
        public DateTime DebutTime { get; set; }
        public string CurrentVersion { get; set; }

        public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, UpdatedTechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly ITechnologiesRepository _technologiesRepository;
            private readonly TechnologiesBusinessRules _technologiesBusinessRules;
            public UpdateTechnologyCommandHandler(IMapper mapper, ITechnologiesRepository technologiesRepository, TechnologiesBusinessRules technologiesBusinessRules)
            {
                _mapper = mapper;
                _technologiesRepository = technologiesRepository;
                _technologiesBusinessRules = technologiesBusinessRules;

            }
            public async Task<UpdatedTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
            {
                var technology = await _technologiesRepository.GetAsync(x => x.Id == request.Id);
                _technologiesBusinessRules.TechnologyShouldExistWhenRequested(technology);

                technology.Name = request.Name == default ? technology.Name : request.Name;
                technology.Description = request.Description == default ? technology.Description : request.Description;
                technology.DebutTime = request.DebutTime == default ? technology.DebutTime : request.DebutTime;
                technology.CurrentVersion = request.CurrentVersion == default ? technology.CurrentVersion : request.CurrentVersion;
                technology.ProgrammingLanguageId = request.ProgrammingLanguageId == default ? technology.ProgrammingLanguageId : request.ProgrammingLanguageId;

                var updatedProgrammingLanguage = await _technologiesRepository.UpdateAsync(technology);
                var dto = _mapper.Map<UpdatedTechnologyDto>(updatedProgrammingLanguage);

                return dto;
            }
        }
    }
}
