using AutoMapper;
using SSOMA.Application.DTOs;
using SSOMA.Application.DTOs.Users;
using SSOMA.Domain.Entities;

namespace SSOMA.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Entidad → DTO de lectura
        CreateMap<User, UserDto>();

        // DTO creación → Entidad (conversión de Password a PasswordHash será lógica de servicio)
        CreateMap<UserCreateDto, User>()
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));

        // DTO actualización → Entidad
        CreateMap<UserUpdateDto, User>();
    }
}