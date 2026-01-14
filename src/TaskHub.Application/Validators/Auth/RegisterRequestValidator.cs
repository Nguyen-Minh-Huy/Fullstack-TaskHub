using FluentValidation;
using TaskHub.Application.DTOs.Auth;

namespace TaskHub.Application.Validators.Auth;

public class RegisterRequestValidator : AbstractValidator<RegisterRequestDto>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Tên là bắt buộc")
            .MinimumLength(3).WithMessage("Tên phải có ít nhất 3 ký tự")
            .MaximumLength(150).WithMessage("Tên không được vượt quá 150 ký tự");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email là bắt buộc")
            .EmailAddress().WithMessage("Email không đúng định dạng")
            .MaximumLength(255).WithMessage("Email không được vượt quá 255 ký tự");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Mật khẩu là bắt buộc")
            .MinimumLength(8).WithMessage("Mật khẩu phải có ít nhất 8 ký tự");
    }
}