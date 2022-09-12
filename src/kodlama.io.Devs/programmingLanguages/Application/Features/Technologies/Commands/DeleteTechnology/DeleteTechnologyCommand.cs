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

namespace Application.Features.Technologies.Commands.DeleteTechnology
{
    public partial class DeleteTechnologyCommand : IRequest<TechnologyDto>
    {
        public int Id { get; set; }

        public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, TechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly ITechnologiesRepository _technologiesRepository;
            private readonly TechnologiesBusinessRules _technologiesBusinessRules;
            public DeleteTechnologyCommandHandler(IMapper mapper, ITechnologiesRepository technologiesRepository, TechnologiesBusinessRules technologiesBusinessRules)
            {
                _mapper = mapper;
                _technologiesRepository = technologiesRepository;
                _technologiesBusinessRules = technologiesBusinessRules;

            }
            public async Task<TechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
            {

                var technology = await _technologiesRepository.GetAsync(x => x.Id == request.Id);
                _technologiesBusinessRules.TechnologyShouldExistWhenRequested(technology);

                var deleted = await _technologiesRepository.DeleteAsync(technology);

                return _mapper.Map<TechnologyDto>(deleted);
            }
        }
    }
}
