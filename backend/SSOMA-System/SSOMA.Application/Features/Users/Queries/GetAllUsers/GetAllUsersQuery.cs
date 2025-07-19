using MediatR;
using SSOMA.Application.DTOs.Users;

namespace SSOMA.Application.Features.Users.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<List<UserDto>>
{
}