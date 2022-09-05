using Application.Features.ProgrammingLanguages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Querries.GetProgrammingLanguages
{
    public partial class GetProgrammingLanguagesQuerry : IRequest<ProgrammingLanguagesListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetProgrammingLanguagesQuerryHandler : IRequestHandler<GetProgrammingLanguagesQuerry, ProgrammingLanguagesListModel>
        {
            private readonly IProgrammingLanguagesRepository _programmingLanguagesRepository;
            private readonly IMapper _mapper;
            public GetProgrammingLanguagesQuerryHandler(IProgrammingLanguagesRepository programmingLanguagesRepository, IMapper mapper)
            {
                _programmingLanguagesRepository = programmingLanguagesRepository;
                _mapper = mapper;

            }

            public async Task<ProgrammingLanguagesListModel> Handle(GetProgrammingLanguagesQuerry request, CancellationToken cancellationToken)
            {
                var programmingLanguages = await _programmingLanguagesRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                var model = _mapper.Map<ProgrammingLanguagesListModel>(programmingLanguages);
                return model;

            }
        }
    }
}
