using AutoMapper;
using eTicaret.Application.DTOs.Users;
using eTicaret.Domain.Entities;
using eTicaret.Domain.ValueObjects;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicaret.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegistrationDto, User>()
                .ForMember(
                dest => dest.FirstName,
                opt => opt.MapFrom(src => string.Empty)
                )
                .ForMember(
                dest => dest.LastName,
                opt => opt.MapFrom(src => string.Empty)
                )
                .ForMember(dest => dest.UserRole,
                opt => opt.Ignore()
                )
                .ForMember(dest => dest.Address,
                opt => opt.Ignore()
                );

            CreateMap<User, UserDto>()
                .ForMember(
                dest => dest.FullName,
                opt => opt.MapFrom(src => src.GetFullName())
                )
                .ForMember(
                dest => dest.UserRole,
                opt => opt.MapFrom(src => src.UserRole.ToString())
                )
                .ForMember(
                dest => dest.AddressDescription,
                opt => opt.MapFrom(src => src.Address != null ? "Address available." : "Address information is not available.")
                );
        }
    }
}
