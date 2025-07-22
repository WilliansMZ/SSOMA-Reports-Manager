using AutoMapper;
using SSOMA.Application.DTOs.Users;
using SSOMA.Domain.Entities;

namespace SSOMA.Application.Mappings;

public class UserProfile : Profile
{
    public UserProfile()
    {
        // Para retornar datos de usuario
        CreateMap<User, UserDto>();

        // Para creación general
        CreateMap<UserCreateDto, User>();

        // Para actualización, solo mapea campos no nulos
        CreateMap<UserUpdateDto, User>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

        // 🔁 Para registro de usuario (necesario en RegisterUserCommandHandler)
        CreateMap<RegisterUserRequestDto, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedAt, 
                opt => opt.MapFrom(_ => DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified)))
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());}
}