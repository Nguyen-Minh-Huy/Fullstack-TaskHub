using FluentValidation;
using TaskHub.Application.DTOs.Project;

namespace TaskHub.Application.Validators.Project;

public class UpdateProjectRequestValidator : AbstractValidator<UpdateProjectRequestDto>
{
    public UpdateProjectRequestValidator()
    {
        RuleFor(x => x.Name)
            .MaximumLength(200).WithMessage("Tên dự án không được vượt quá 200 ký tự")
            .When(x => !string.IsNullOrEmpty(x.Name));

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Mô tả không được vượt quá 500 ký tự")
            .When(x => !string.IsNullOrEmpty(x.Description));

        RuleFor(x => x.Status)
            .InclusiveBetween(0, 3).WithMessage("Trạng thái phải từ 0 đến 3")
            .When(x => x.Status.HasValue);
    }
}