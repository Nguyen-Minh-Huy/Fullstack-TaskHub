namespace TaskHub.Domain.Enums;

/// Độ ưu tiên của Task
public enum TaskPriority : byte
{
    /// Thấp
    Low = 0,

    /// Trung bình
    Medium = 1,

    /// Cao
    High = 2,

    /// Khẩn cấp
    Urgent = 3
}