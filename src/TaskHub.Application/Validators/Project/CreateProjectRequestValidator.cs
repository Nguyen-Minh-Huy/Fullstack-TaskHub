using FluentValidation;
using TaskHub.Application.DTOs.Project;

namespace TaskHub.Application.Validators.Project;

public class CreateProjectRequestValidator : AbstractValidator<CreateProjectRequestDto>
{
    public CreateProjectRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Tên dự án là bắt buộc")
            .MaximumLength(200).WithMessage("Tên dự án không được vượt quá 200 ký tự");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Mô tả không được vượt quá 500 ký tự");
    }
}