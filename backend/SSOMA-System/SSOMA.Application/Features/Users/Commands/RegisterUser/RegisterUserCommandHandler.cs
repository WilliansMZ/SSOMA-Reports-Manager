using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SSOMA.Application.DTOs.Users;
using SSOMA.Domain.Entities;
using SSOMA.Domain.IUnitOfWork;
using SSOMA.Domain.Services;

namespace SSOMA.Application.Features.Users.Commands.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserResponseDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtGenerator _jwtGenerator;
    private readonly IMapper _mapper;

    public RegisterUserCommandHandler(IUnitOfWork unitOfWork, IJwtGenerator jwtGenerator, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _jwtGenerator = jwtGenerator;
        _mapper = mapper;
    }

    public async Task<RegisterUserResponseDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        // Validar si ya existe un usuario con el mismo email
        var existingEmailUser = await _unitOfWork.UserRepository.GetByEmailAsync(request.User.Email);
        if (existingEmailUser != null)
            throw new Exception("El correo ya está registrado.");

        // Validar si ya existe un usuario con el mismo nationalId (DNI, etc.)
        var existingDniUser = await _unitOfWork.UserRepository
            .FindAsync(u => u.NationalId == request.User.NationalId);

        if (existingDniUser != null)
            throw new Exception("El DNI ya está registrado.");

        var user = _mapper.Map<User>(request.User);
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.User.Password);

        await _unitOfWork.UserRepository.AddAsync(user);

        try
        {
            await _unitOfWork.SaveAsync();
        }
        catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("users_national_id_key") == true)
        {
            throw new ApplicationException("El DNI ya está registrado (restricción de base de datos).");
        }

        var token = _jwtGenerator.GenerateToken(user);

        return new RegisterUserResponseDto
        {
            Id = user.Id,
            Email = user.Email,
            Token = token
        };
    }
}
