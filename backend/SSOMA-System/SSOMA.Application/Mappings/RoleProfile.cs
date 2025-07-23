using AutoMapper;
using SSOMA.Application.DTOs.UserRoles;
using SSOMA.Domain.Entities;

namespace SSOMA.Application.Mappings;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<Role, RoleDto>();
    }
}