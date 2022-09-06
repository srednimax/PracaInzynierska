using LibraryDatabase.Models;

namespace LibraryBackend.Dtos;

public class UserDto
{
    public int Id { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? Birth  { get; set; }
    public Gender Gender { get; set; }
    public Role Role { get; set; }
}