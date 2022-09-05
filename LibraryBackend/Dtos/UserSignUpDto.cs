using Models;

namespace LibraryBackend.Dtos;

public class UserSignUpDto
{
    public string? Email { get; set; }
    public string? ConfirmEmail { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? Birth  { get; set; }
    public Gender Gender { get; set; }
    public Role Role { get; set; }
}