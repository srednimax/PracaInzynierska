namespace LibraryBackend.Services;

public class ServiceResult<T> where T : class
{
    public T? Body { get; set; }
    public int Status { get; set; }
    public string? Message { get; set; }
}