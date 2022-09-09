using System.ComponentModel.DataAnnotations;
using LibraryDatabase.Models;

namespace LibraryBackend.Dtos.User;

public class UserSignUpDto
{
    [Required]
    [EmailAddress]
    [MaxLength(200)]
    public string? Email { get; set; }

    [Required]
    [Compare("Email", ErrorMessage = "E-mails are not the same")]
    public string? ConfirmEmail { get; set; }

    [Required]
    [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,50}$")]
    public string? Password { get; set; }

    [Required]
    [Compare("Password", ErrorMessage = "Passwords are not the same")]
    public string? ConfirmPassword { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    [RegularExpression(@"^[a-zA-Z]+$")]
    public string? FirstName { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    [RegularExpression(@"^[a-zA-Z]+$")]
    public string? LastName { get; set; }

    [Required]
    [Phone]
    [MinLength(9)]
    [MaxLength(9)]
    public string? PhoneNumber { get; set; }

    [Required]
    public DateTime? Birth { get; set; }

    [Required]
    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; }
}