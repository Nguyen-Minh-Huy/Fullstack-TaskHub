namespace TaskHub.Application.Common;

public class PaginationResponse
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }
    public int ItemsPerPage { get; set; }
}

public class PaginatedResult<T>
{
    public List<T> Items { get; set; } = new();
    public PaginationResponse Pagination { get; set; } = new();
}