using System.ComponentModel.DataAnnotations;

namespace LibraryBackend.Dtos.User;

public class UserSignInDto
{
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
}