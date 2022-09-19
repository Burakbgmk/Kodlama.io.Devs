using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Dtos;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Hashing;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<UserForRegisterDto, AppUser>()
                .ForMember(x => x.PasswordHash, opt => opt.MapFrom(y => GetHash(y.Password)))
                .ForMember(x => x.PasswordSalt, opt => opt.MapFrom(y => GetSalt(y.Password)))
                .ReverseMap();
            CreateMap<AppUser, RegisterDto>().ReverseMap();
            CreateMap<UserForRegisterDto, CreateUserCommand>().ReverseMap();
            CreateMap<AppUser, CreateUserCommand>().ReverseMap();
        }

        private byte[] GetHash(string password)
        {
            HashingHelper.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            return passwordHash;
        }
        private byte[] GetSalt(string password)
        {
            HashingHelper.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            return passwordSalt;
        }

    }
}
