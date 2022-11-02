using System.ComponentModel.DataAnnotations;

namespace LibraryBackend.Dtos.User;

public class UserUpdatePasswordDto
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string? OldPassword { get; set; }

    [Required]
    public string? NewPassword { get; set; }

    [Required]
    [Compare("NewPassword", ErrorMessage = "Passwords are not the same")]
    public string? ConfirmNewPassword { get; set; }
}