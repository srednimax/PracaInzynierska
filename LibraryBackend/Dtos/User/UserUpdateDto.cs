using System.ComponentModel.DataAnnotations;
using LibraryDatabase.Models;

namespace LibraryBackend.Dtos.User;

public class UserUpdateDto
{
    [Required]
    [EmailAddress]
    [MaxLength(200)]
    public string? Email { get; set; }

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