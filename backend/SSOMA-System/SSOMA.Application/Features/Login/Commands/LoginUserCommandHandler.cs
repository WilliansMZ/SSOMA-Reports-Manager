using MediatR;
using Microsoft.AspNetCore.Identity;
using SSOMA.Application.DTOs.Login;
using SSOMA.Domain.Entities;
using SSOMA.Domain.IUnitOfWork;
using SSOMA.Domain.Services;

namespace SSOMA.Application.Features.Login.Commands
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginResponseDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IPasswordHasher<User> _passwordHasher;

        public LoginUserCommandHandler(
            IUnitOfWork unitOfWork,
            IJwtGenerator jwtGenerator,
            IPasswordHasher<User> passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _jwtGenerator = jwtGenerator;
            _passwordHasher = passwordHasher;
        }

        public async Task<LoginResponseDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetByEmailAsync(request.Request.Email);
            if (user == null)
                throw new UnauthorizedAccessException("Credenciales inválidas");

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Request.Password);
            if (result == PasswordVerificationResult.Failed)
                throw new UnauthorizedAccessException("Credenciales inválidas");

            var token = _jwtGenerator.GenerateToken(user);

            return new LoginResponseDto
            {
                Token = token,
                Email = user.Email,
                Rol = user.Role.Name

            };
        }
    }
}