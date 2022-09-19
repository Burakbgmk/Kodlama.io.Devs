using Application.Features.Users.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.CreateUser
{
    public partial class CreateUserCommand : IRequest<RegisterDto>
    {
        public UserForRegisterDto UserRegister { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, RegisterDto>
        {
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;
            public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
            {
                _mapper = mapper;
                _userRepository = userRepository;
            }


            public async Task<RegisterDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var user = _mapper.Map<AppUser>(request.UserRegister);
                var created = await _userRepository.AddAsync(user);

                return _mapper.Map<RegisterDto>(created);
            }
        }
    }
}
