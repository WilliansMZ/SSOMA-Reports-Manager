using MediatR;
using SSOMA.Application.DTOs.UserRoles;

namespace SSOMA.Application.Features.UserRoles.Queries;

public class GetRolesQuery : IRequest<List<RoleDto>> { }