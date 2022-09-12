using Application.Features.Technologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Querries.GetTechnologies
{
    public partial class GetTechnologiesQuerry : IRequest<TechnologiesListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetTechnologiesQuerryHandler : IRequestHandler<GetTechnologiesQuerry, TechnologiesListModel>
        {
            private readonly IMapper _mapper;
            private readonly ITechnologiesRepository _technologiesRepository;
            public GetTechnologiesQuerryHandler(IMapper mapper, ITechnologiesRepository technologiesRepository)
            {
                _mapper = mapper;
                _technologiesRepository = technologiesRepository;
            }


            public async Task<TechnologiesListModel> Handle(GetTechnologiesQuerry request, CancellationToken cancellationToken)
            {
                var technologies = await _technologiesRepository.GetListAsync(
                    include: m => m.Include(c => c.ProgrammingLanguage),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                var mappedTechnologies = _mapper.Map<TechnologiesListModel>(technologies);
                return mappedTechnologies;
            }
        }

    }
}
