using MediatR;
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

        public LoginUserCommandHandler(
            IUnitOfWork unitOfWork,
            IJwtGenerator jwtGenerator)
        {
            _unitOfWork = unitOfWork;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<LoginResponseDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetByEmailAsync(request.Request.Email);
            if (user == null)
                throw new UnauthorizedAccessException("Credenciales inválidas");

            // Verificar la contraseña con BCrypt
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(request.Request.Password, user.PasswordHash);
            if (!isValidPassword)
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