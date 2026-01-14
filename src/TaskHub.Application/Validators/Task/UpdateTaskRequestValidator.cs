using FluentValidation;
using TaskHub.Application.DTOs.Task;

namespace TaskHub.Application.Validators.Task;

public class UpdateTaskRequestValidator : AbstractValidator<UpdateTaskRequestDto>
{
    public UpdateTaskRequestValidator()
    {
        RuleFor(x => x.Title)
            .MaximumLength(150).WithMessage("Tiêu đề không được vượt quá 150 ký tự")
            .When(x => !string.IsNullOrEmpty(x.Title));

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Mô tả không được vượt quá 500 ký tự")
            .When(x => !string.IsNullOrEmpty(x.Description));

        RuleFor(x => x.DueDate)
            .GreaterThanOrEqualTo(DateTime.Today).WithMessage("Ngày hết hạn không được là ngày quá khứ")
            .When(x => x.DueDate.HasValue);

        RuleFor(x => x.TaskPriority)
            .InclusiveBetween(0, 3).WithMessage("Độ ưu tiên phải từ 0 đến 3")
            .When(x => x.TaskPriority.HasValue);

        RuleFor(x => x.Status)
            .InclusiveBetween(0, 3).WithMessage("Trạng thái phải từ 0 đến 3")
            .When(x => x.Status.HasValue);
    }
}