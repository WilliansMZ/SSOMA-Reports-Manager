using MediatR;
using Microsoft.EntityFrameworkCore;
using SSOMA.Domain.IUnitOfWork;
using SSOMA.Infrastructure.DbContext;

namespace SSOMA.Application.Features.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly SsomaDbContext _context;

    public DeleteUserCommandHandler(SsomaDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

        if (user == null)
            return false;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}