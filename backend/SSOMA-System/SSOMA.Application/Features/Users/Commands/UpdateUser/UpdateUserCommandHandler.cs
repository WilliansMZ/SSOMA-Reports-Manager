using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SSOMA.Domain.IUnitOfWork;
using SSOMA.Infrastructure.DbContext;

namespace SSOMA.Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
{
    private readonly SsomaDbContext _context;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(SsomaDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

        if (user == null)
            return false;

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Email = request.Email;
        user.NationalId = request.NationalId;
        user.RoleId = request.RoleId;

        _context.Users.Update(user);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}