using FluentValidation;
using SSOMA.Application.DTOs.Users;

namespace SSOMA.Application.Validators.Users;

public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequestDto>
{
    public RegisterUserRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.RoleId).GreaterThan(0);
    }
}