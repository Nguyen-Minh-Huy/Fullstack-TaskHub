using FluentValidation;
using TaskHub.Application.DTOs.Auth;

namespace TaskHub.Application.Validators.Auth;

public class LoginRequestValidator : AbstractValidator<LoginRequestDto>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email là bắt buộc")
            .EmailAddress().WithMessage("Email không đúng định dạng");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Mật khẩu là bắt buộc");
    }
}