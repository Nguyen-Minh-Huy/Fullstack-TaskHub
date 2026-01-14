namespace TaskHub.Domain.Enums;


/// Trạng thái của Project và Task

public enum ProjectStatus : byte
{
    /// Cần làm
    Todo = 0,

    /// Đang làm
    InProgress = 1,

    /// Đang xem xét
    Review = 2,

    /// Hoàn thành
    Done = 3
}