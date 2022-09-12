using Application.Features.Technologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Querries.GetTechnologies
{
    public partial class GetTechnologiesByDynamicQuerry : IRequest<TechnologiesListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetTechnologiesByDynamicQuerryHandler : IRequestHandler<GetTechnologiesByDynamicQuerry, TechnologiesListModel>
        {

            private readonly IMapper _mapper;
            private readonly ITechnologiesRepository _technologiesRepository;
            public GetTechnologiesByDynamicQuerryHandler(IMapper mapper, ITechnologiesRepository technologiesRepository)
            {
                _mapper = mapper;
                _technologiesRepository = technologiesRepository;
            }
            public async Task<TechnologiesListModel> Handle(GetTechnologiesByDynamicQuerry request, CancellationToken cancellationToken)
            {
                var technologies = await _technologiesRepository.GetListByDynamicAsync(
                    dynamic: request.Dynamic,
                    include: m => m.Include(c => c.ProgrammingLanguage),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                var mappedTechnologies = _mapper.Map<TechnologiesListModel>(technologies);
                return mappedTechnologies;
            }
        }

    }
}
