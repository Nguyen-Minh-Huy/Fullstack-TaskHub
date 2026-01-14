using FluentValidation;
using TaskHub.Application.DTOs.Task;

namespace TaskHub.Application.Validators.Task;

public class CreateTaskRequestValidator : AbstractValidator<CreateTaskRequestDto>
{
    public CreateTaskRequestValidator()
    {
        RuleFor(x => x.ProjectId)
            .NotEmpty().WithMessage("Project ID là bắt buộc");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Tiêu đề là bắt buộc")
            .MaximumLength(150).WithMessage("Tiêu đề không được vượt quá 150 ký tự");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Mô tả không được vượt quá 500 ký tự");

        RuleFor(x => x.DueDate)
            .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Ngày hết hạn không được là ngày quá khứ")
            .When(x => x.DueDate.HasValue);

        RuleFor(x => x.TaskPriority)
            .InclusiveBetween(0, 3).WithMessage("Độ ưu tiên phải từ 0 đến 3")
            .When(x => x.TaskPriority.HasValue);
    }
}