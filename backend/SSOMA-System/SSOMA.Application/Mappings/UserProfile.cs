using AutoMapper;
using SSOMA.Application.DTOs.Users;
using SSOMA.Domain.Entities;

namespace SSOMA.Application.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserCreateDto, User>();
        CreateMap<UserUpdateDto, User>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null)); // Solo actualiza campos no nulos
    }
}