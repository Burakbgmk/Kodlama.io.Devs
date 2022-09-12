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

namespace Application.Features.Technologies.Querries.GetTechnologyById
{
    public partial class GetTechnologyByIdQuerry : IRequest<TechnologyDto>
    {
        public int Id { get; set; }

        public class GetTechnologyByIdQuerryHandler : IRequestHandler<GetTechnologyByIdQuerry, TechnologyDto>
        {
            private readonly IMapper _mapper;
            private readonly ITechnologiesRepository _technologiesRepository;
            private readonly TechnologiesBusinessRules _technologiesBusinessRules;
            public GetTechnologyByIdQuerryHandler(IMapper mapper, ITechnologiesRepository technologiesRepository, TechnologiesBusinessRules technologiesBusinessRules)
            {
                _mapper = mapper;
                _technologiesRepository = technologiesRepository;
                _technologiesBusinessRules = technologiesBusinessRules;

            }
            public async Task<TechnologyDto> Handle(GetTechnologyByIdQuerry request, CancellationToken cancellationToken)
            {
                var technology = await _technologiesRepository.GetAsync(x => x.Id == request.Id);
                _technologiesBusinessRules.TechnologyShouldExistWhenRequested(technology);

                var dto = _mapper.Map<TechnologyDto>(technology);

                return dto;
            }
        }
    }
}
