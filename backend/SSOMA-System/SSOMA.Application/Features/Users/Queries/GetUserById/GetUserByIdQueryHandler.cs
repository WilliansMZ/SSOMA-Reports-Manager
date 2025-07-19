using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SSOMA.Application.DTOs.Users;
using SSOMA.Infrastructure.DbContext;

namespace SSOMA.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private readonly SsomaDbContext _context;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(SsomaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            return user != null ? _mapper.Map<UserDto>(user) : null!;
        }
    }
}