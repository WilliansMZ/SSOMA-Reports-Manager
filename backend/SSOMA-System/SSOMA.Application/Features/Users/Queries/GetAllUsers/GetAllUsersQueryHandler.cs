using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SSOMA.Application.DTOs.Users;
using SSOMA.Infrastructure.DbContext;

namespace SSOMA.Application.Features.Users.Queries.GetAllUsers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
{
    private readonly SsomaDbContext _context;
    private readonly IMapper _mapper;

    public GetAllUsersQueryHandler(SsomaDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _context.Users
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return _mapper.Map<List<UserDto>>(users);
    }
}